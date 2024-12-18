require_relative 'base_config'
Dir[File.join(__dir__, 'languages', '*_config.rb')].sort.each { |file| require file }

module TestGenerator
  # Manages configuration for different programming language test generators
  class LanguageConfig
    # List of supported languages
    SUPPORTED_LANGUAGES = %i[python cpp rust csharp pascal].freeze

    attr_reader :language,
                :indent_size,
                :file_extension,
                :imports,
                :function_handlers,
                :variable_handlers,
                :assert_conditions,
                :if_conditions,
                :control_flow,
                :string_handlers,
                :type_handlers,
                :runtime_requirement,
                :installation_steps,
                :run_command,
                :supports_overloading,
                :naming_convention,
                :class_wrapper,
                :class_wrapper_handler,
                :numeric_constants,
                :prompt_handlers

    def initialize(config)
      validate_config(config)
      @language = config[:language]
      @indent_size = config[:indent_size]
      @file_extension = config[:file_extension]
      @imports = config[:imports]
      @class_wrapper = config[:class_wrapper]
      @function_handlers = config[:function_handlers]
      @variable_handlers = config[:variable_handlers]
      @assert_conditions = config[:assert_conditions]
      @if_conditions = config[:if_conditions]
      @control_flow = config[:control_flow]
      @string_handlers = config[:string_handlers]
      @type_handlers = config[:type_handlers]
      @runtime_requirement = config[:runtime_requirement]
      @installation_steps = config[:installation_steps]
      @run_command = config[:run_command]
      @supports_overloading = config[:supports_overloading]
      @naming_convention = config[:naming_convention]
      @numeric_constants = config[:numeric_constants]
      @prompt_handlers = config[:prompt_handlers]
      @class_wrapper_handler = ClassWrapperHandler.new(config[:class_wrapper])
    end

    # Creates a configuration instance for a specific language
    # @param language [Symbol] The programming language to configure
    # @return [LanguageConfig] The configuration instance
    # @raise [StandardError] If language is unsupported or configuration is missing
    def self.for_language(language)
      raise LanguageError, "Unsupported language: #{language}" unless SUPPORTED_LANGUAGES.include?(language)

      begin
        config_class = Object.const_get("LanguageConfig::#{language.to_s.capitalize}Config")
        config = config_class.new.get
        config[:language] = language
        new(config)
      rescue NameError
        raise ConfigurationError, "Configuration not found for language: #{language}"
      rescue StandardError => e
        raise TestGeneratorError, "Error loading configuration: #{e.message}"
      end
    end

    # Gets the class wrapper handler instance
    # @return [ClassWrapperHandler] The class wrapper handler
    def class_wrapper
      @class_wrapper_handler ||= ClassWrapperHandler.new(@class_wrapper)
    end

    private

    # Validates that all required configuration keys are present
    # @param config [Hash] The configuration to validate
    # @raise [StandardError] If any required keys are missing
    def validate_config(config)
      required_keys = %i[
        language indent_size file_extension imports function_handlers
        variable_handlers assert_conditions if_conditions control_flow
        string_handlers type_handlers runtime_requirement installation_steps
        run_command supports_overloading naming_convention class_wrapper
        numeric_constants prompt_handlers
      ]
      missing_keys = required_keys - config.keys
      raise ConfigurationError, "Missing required configuration keys: #{missing_keys.join(', ')}" if missing_keys.any?
    end
  end
end