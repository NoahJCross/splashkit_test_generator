# Module for formatting values in test generation
module TestGenerator
  # Formats values for test generation based on their type and language configuration
  module ValueFormatter
    class << self
      # Maps value types to their corresponding formatting methods
      # @return [Hash<String, Symbol>] Map of value types to formatter method names
      def formatter_map
        {
          'function'                  => :format_function_value,
          'variable'                  => :format_variable_value,
          'variable_field'            => :format_variable_field_value,
          'variable_matrix_access'    => :format_variable_matrix_access_value,
          'list'                      => :format_list_value,
          'array_access'              => :format_array_access_value,
          'array_access_field'        => :format_array_access_field_value,
          'primitive'                 => :format_primitive_value,
          'enum'                      => :format_enum_value,
          'inf'                       => :format_infinity_value,
          'neg_inf'                   => :format_neg_infinity_value,
          'char'                      => :format_char_value,
          'max_value'                 => :format_max_value,
          'interpolated_string'       => :format_interpolated_string_value,
          'class_instance'            => :format_class_instance_value
        }
      end

      # Formats the value based on its type
      # @param value [Hash] The value to format
      # @param functions [Array] Available functions
      # @param config [Hash] Language configuration
      # @return [String] The formatted value
      def format_value(value, functions, config)
        formatter = formatter_map[value[:value_type]]
        formatter ? send(formatter, value, functions, config) : value.to_s
      end

      # Formats function values with arguments
      # @param value [Hash] The function value to format
      # @param functions [Array] Available functions
      # @param config [Hash] Language configuration
      # @return [String] The formatted function call
      # @raise [StandardError] If function name is missing
      def format_function_value(value, functions, config)
        args = (value[:args] || []).map { |arg| format_value(arg, functions, config) }.join(', ')
        function_name = FunctionLookup.determine_function_name(value, config, functions)
        raise "Function name is required for function value #{JSON.pretty_generate(value)}" unless function_name

        config.function_handlers[:call].call(function_name, args, false)
      end

      # Formats variable references
      # @param value [Hash] The variable value to format
      # @param _ [Array] Unused functions parameter
      # @param config [Hash] Language configuration
      # @return [String] The formatted variable reference
      def format_variable_value(value, _, config)
        config.variable_handlers[:reference].call(value[:variable_name])
      end

      # Formats field access on variables
      # @param value [Hash] The field access value to format
      # @param functions [Array] Available functions
      # @param config [Hash] Language configuration
      # @return [String] The formatted field access
      def format_variable_field_value(value, functions, config)
        variable_value = format_variable_value(value, functions, config)
        field_name = value[:variable_field]
        config.variable_handlers[:field_access].call(variable_value, field_name)
      end

      # Formats primitive values
      # @param value [Hash] The primitive value to format
      # @return [String] The formatted primitive value
      def format_primitive_value(value, _, _)
        value[:value].inspect
      end

      # Formats enum values
      # @param value [Hash] The enum value to format
      # @param config [Hash] Language configuration
      # @return [String] The formatted enum value
      def format_enum_value(value, _, config)
        config.type_handlers[:enum].call(value[:enum_type], value[:value], false)
      end

      # Formats matrix access on variables
      # @param value [Hash] The matrix access value to format
      # @param functions [Array] Available functions
      # @param config [Hash] Language configuration
      # @return [String] The formatted matrix access
      def format_variable_matrix_access_value(value, functions, config)
        variable_value = format_variable_value(value, functions, config)
        variable_with_field = config.variable_handlers[:field_access].call(variable_value, 'Elements')
        config.variable_handlers[:matrix_access].call(variable_with_field, value[:row], value[:col])
      end

      # Formats array access values
      # @param value [Hash] The array access value to format
      # @param config [Hash] Language configuration
      # @return [String] The formatted array access
      def format_array_access_value(value, _, config)
        array_name = config.variable_handlers[:reference].call(value[:array_name])
        config.variable_handlers[:array_access].call(array_name, value[:index])
      end

      # Formats list values
      # @param value [Hash] The list value to format
      # @param functions [Array] Available functions
      # @param config [Hash] Language configuration
      # @return [String] The formatted list
      def format_list_value(value, functions, config)
        values = value[:value].map { |v| format_value(v, functions, config) }
        config.type_handlers[:list].call(values.join(', '), value[:target_type])
      end

      # Formats field access on array elements
      # @param value [Hash] The array field access value to format
      # @param config [Hash] Language configuration
      # @return [String] The formatted array field access
      def format_array_access_field_value(value, _, config)
        variable = config.variable_handlers[:reference].call(value[:variable_name])
        array_access = config.variable_handlers[:field_access].call(variable, value[:array_name])
        array_with_index = config.variable_handlers[:array_access].call(array_access, value[:index])
        config.variable_handlers[:field_access].call(array_with_index, value[:field])
      end

      # Formats infinity constant
      # @param config [Hash] Language configuration
      # @return [String] The language-specific infinity constant
      def format_infinity_value(_, _, config)
        config.numeric_constants[:infinity]
      end

      # Formats negative infinity constant
      # @param config [Hash] Language configuration
      # @return [String] The language-specific negative infinity constant
      def format_neg_infinity_value(_, _, config)
        config.numeric_constants[:negative_infinity]
      end

      # Formats character values
      # @param value [Hash] The character value to format
      # @param config [Hash] Language configuration
      # @return [String] The formatted character value
      def format_char_value(value, _, config)
        config.string_handlers[:char].call(value[:value])
      end

      # Formats maximum value constant
      # @param config [Hash] Language configuration
      # @return [String] The language-specific maximum value constant
      def format_max_value(_, _, config)
        config.numeric_constants[:max_value]
      end

      # Formats interpolated strings
      # @param value [Hash] The interpolated string value to format
      # @param functions [Array] Available functions
      # @param config [Hash] Language configuration
      # @return [String] The formatted interpolated string
      def format_interpolated_string_value(value, functions, config)
        formatted_parts = value[:parts].map do |part|
          if part[:type] == 'text'
            part[:value]
          else
            expression = format_value(part[:expression], functions, config)
            config.string_handlers[:interpolation].call(expression)
          end
        end
        config.string_handlers[:concatenation].call(formatted_parts)
      end

      # Formats class instance creation
      # @param value [Hash] The class instance value to format
      # @param config [Hash] Language configuration
      # @return [String] The formatted class instance creation
      # @raise [StandardError] If class name is missing
      def format_class_instance_value(value, _, config)
        args = (value[:args] || []).map { |arg| format_value(arg, @functions, @config) }.join(', ')
        raise "Class name is required for class instance value #{JSON.pretty_generate(value)}" unless value[:class_name]

        class_name = config.naming_convention.call(value[:class_name])
        config.type_handlers[:class].call(class_name, args)
      end
    end
  end
end