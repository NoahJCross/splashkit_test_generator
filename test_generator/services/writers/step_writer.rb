module TestGenerator
  # Class responsible for writing individual test steps based on their type and configuration
  class StepWriter
    def initialize(step, functions, config, formatter)
      @step = step
      @functions = functions
      @config = config
      @formatter = formatter
    end

    # Writes a test step using a new instance of StepWriter
    # @param step [Hash] The test step to write
    # @param functions [Array<Function>] Available functions
    # @param config [Object] Language configuration
    # @param formatter [CodeFormatter] Code formatting utility
    # @return [String] The formatted test step code
    def self.write_test_step(step, functions, config, formatter)
      new(step, functions, config, formatter).write
    end

    def write
      if respond_to?("write_#{@step[:step_type]}_step", true)
        send("write_#{@step[:step_type]}_step")
      else
        @formatter.indent("# TODO: Implement #{@step[:step_type]} step\n", @config)
      end
    end

    private

    # Writes a variable declaration step
    # @return [String] Formatted variable declaration code
    def write_variable_step
      handlers = @config.variable_handlers
      declaration_op = @step[:is_mutable] ? 
        handlers[:declaration][:mutable] : 
        handlers[:declaration][:regular]
      declaration = declaration_op.call(@step[:variable_name])
      value = if @step[:value_type] == 'reference'
                handlers[:identifier].call(@step[:value])
              else
                ValueFormatter.format_value(@step, @functions, @config)
              end
      @formatter.indent("#{declaration}#{value};", @config)
    end

    # Writes a function call step
    # @return [String] Formatted function call code
    def write_function_step
      call = format_function_call
      if @step[:store_result]
        declaration_op = @step[:is_mutable] ? 
          @config.variable_handlers[:declaration][:mutable] :
          @config.variable_handlers[:declaration][:regular]
        declaration = declaration_op.call(@step[:store_result])
        @formatter.indent("#{declaration}#{call}", @config)
      else
        @formatter.indent(call, @config)
      end
    end

    # Writes an assertion step
    # @return [String] Formatted assertion code
    def write_assertion_step
      comparison = @step[:compare]
      value1 = ValueFormatter.format_value(comparison[:value1], @functions, @config)
      value2 = comparison[:value2] ? ValueFormatter.format_value(comparison[:value2], @functions, @config) : nil
      value3 = comparison[:value3] ? ValueFormatter.format_value(comparison[:value3], @functions, @config) : nil

      @formatter.indent(@config.assert_conditions[comparison[:compare_type]].call(value1, value2, value3), @config)
    end

    # Writes a loop step
    # @return [String] Formatted loop code
    def write_loop_step
      loop_code = @formatter.indent(@config.control_flow[:loop].call(@step[:iterations]), @config)
      @step[:loop_steps].each do |inner_step|
        loop_code << self.class.write_test_step(inner_step, @functions, @config, @formatter)
      end
      loop_code << @formatter.indent(@config.control_flow[:end].call, @config)
      loop_code
    end

    # Writes an if-else step
    # @return [String] Formatted if-else code
    def write_if_step
      condition_code = write_condition(@step[:compare])
      if_code = @formatter.indent(@config.control_flow[:if].call(condition_code), @config)
      @step[:then_steps].each do |then_step|
        if_code << self.class.write_test_step(then_step, @functions, @config, @formatter)
      end
      if_code << @formatter.indent(@config.control_flow[:end].call, @config)
      if_code << write_else_steps
      if_code
    end

    # Writes the else part of an if-else step
    # @return [String] Formatted else code
    def write_else_steps
      return '' unless @step[:else_steps]

      else_code = @formatter.indent(@config.control_flow[:else].call, @config)
      @step[:else_steps].each do |else_step|
        else_code << self.class.write_test_step(else_step, @functions, @config, @formatter)
      end
      else_code << @formatter.indent(@config.control_flow[:end].call, @config)
      else_code
    end

    # Writes a condition for if or while steps
    # @param comparison [Hash] The comparison configuration
    # @return [String] Formatted condition code
    # @raise [StandardError] If comparison type is unsupported
    def write_condition(comparison)
      type = comparison[:compare_type]
      value1 = ValueFormatter.format_value(comparison[:value1], @functions, @config)
      value2 = comparison[:value2] ? ValueFormatter.format_value(comparison[:value2], @functions, @config) : nil
      @config.if_conditions.fetch(type) do
        MessageHandler.log_error("Unsupported comparison type: #{type}", comparison)
        raise "Unsupported comparison type: #{type}"
      end.call(value1, value2)
    end

    # Writes a while loop step
    # @return [String] Formatted while loop code
    def write_while_step
      condition = write_condition(@step[:compare]).strip
      while_code = @formatter.indent(@config.control_flow[:while].call(condition), @config)
      @step[:while_steps].each do |inner_step|
        while_code << self.class.write_test_step(inner_step, @functions, @config, @formatter)
      end
      while_code << @formatter.indent(@config.control_flow[:end].call, @config)
      while_code
    end

    # Writes a break statement
    # @return [String] Formatted break statement
    def write_break_step
      @formatter.indent(@config.control_flow[:break].call, @config)
    end

    # Writes a variable reassignment step
    # @return [String] Formatted reassignment code
    def write_reassignment_step
      value = format_reassignment_value
      variable_identifier = @config.variable_handlers[:identifier].call(@step[:variable_name])
      @formatter.indent("#{variable_identifier} = #{value}", @config)
    end

    # Formats the value for a reassignment step
    # @return [String] Formatted value
    def format_reassignment_value
      if @step[:function_name]
        format_function_call
      else
        ValueFormatter.format_value(@step, @functions, @config) + ';'
      end
    end

    # Formats a function call
    # @return [String] Formatted function call
    def format_function_call
      args = @step[:args].map { |arg| ValueFormatter.format_value(arg, @functions, @config) }.join(', ')
      function_name = FunctionLookup.determine_function_name(@step, @config, @functions)
      @config.function_handlers[:call].call(function_name, args)
    end

    # Writes a prompt step that displays a message to the user
    # @return [String] Formatted prompt code (e.g., cout, print, Console.WriteLine etc.)
    def write_prompt_step
      @formatter.indent(@config.terminal_handlers[:message].call(@step[:message]), @config)
    end

    # Writes a cleanup step
    # @return [String] Formatted cleanup code
    def write_cleanup_step
      args = @step[:args]&.map { |arg| ValueFormatter.format_value(arg, @functions, @config) }&.join(', ')
      setup = @config.cleanup_handlers[:setup].call(@step[:store_result], @step[:cleanup_type], args)
      @formatter.indent(setup, @config)
    end

    # Writes a delegate call step
    # @return [String] Formatted delegate call code
    def write_delegate_call_step
      variable_value = @config.variable_handlers[:identifier].call(@step[:variable_name])
      @formatter.indent(@config.variable_handlers[:delegate_call].call(variable_value, @step[:variable_field]), @config)
    end
  end
end
