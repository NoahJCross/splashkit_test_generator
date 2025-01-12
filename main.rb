#!/usr/bin/env ruby
require_relative 'lib'

# Module responsible for generating test cases for SplashKit functions
module TestGenerator
  # Main entry point for test generation
  # @param api_json [String] JSON string containing the API specification
  def self.generate(api_json)
    api = JSON.parse(api_json)
    functions = Parser.parse_functions(api)
    group_tests = TestLoader.new.load_all

    # Generate tests for each supported programming language
    LanguageConfig::SUPPORTED_LANGUAGES.each do |language|
      generate_for_language(functions, language, group_tests)
      MessageHandler.log_success("Completed generating tests for #{language}")
    end
  end

  # Generates test files for a specific programming language
  # @param functions [Array<Function>] List of functions to generate tests for
  # @param language [String] Target programming language
  # @param group_tests [Hash] Pre-loaded test cases grouped by category
  def self.generate_for_language(functions, language, group_tests)
    config = LanguageConfig.for_language(language)
    ConfigValidator.validate!(config)
    base_dir, tests_dir = DirectoryManager.setup(config.language)

    write_test_main_file(base_dir, config)
    write_group_files(functions, tests_dir, config, group_tests)
  rescue StandardError => e
    MessageHandler.log_error('Test generation failed', e.message)
    raise
  end

  # Writes the main test runner file if specified in the language config
  # @param base_dir [String] Base directory for test files
  # @param config [LanguageConfig] Configuration for the target language
  def self.write_test_main_file(base_dir, config)
    return unless config.test_main_file

    main_path = File.join(base_dir, config.test_main_file[:path])
    formatter = CodeFormatter.new(config.indent_size)
    File.open(main_path, 'w') do |file|
      config.test_main_file[:content].each do |line|
        file.write(formatter.format_line(line, config))
      end
    end
  end

  # Writes individual test group files
  # @param functions [Array<Function>] List of all functions
  # @param tests_dir [String] Directory to write test files
  # @param config [LanguageConfig] Language configuration
  # @param group_tests [Hash] Pre-loaded test cases
  def self.write_group_files(functions, tests_dir, config, group_tests)
    functions
      .group_by { |func| func.group || 'ungrouped' } # Group functions by their category
      .each do |group, group_funcs|
        TestWriter.new(group, group_funcs, functions, config, group_tests).write_to(tests_dir)
      end
  end
end

# Script execution starts here
# Validate command line arguments
unless ARGV[0]
  puts MessageHandler.colorize('Usage: ruby main.rb path/to/api.json', '31')
  exit 1
end

# Main execution block
begin
  api_json = File.read(ARGV[0])
  TestGenerator.generate(api_json)
  puts MessageHandler.log_success("Tests generated successfully in 'generated_tests' directory")
rescue Errno::ENOENT
  puts MessageHandler.colorize("WARNING: Could not find file '#{ARGV[0]}'", '31')
  exit 1
rescue JSON::ParserError
  puts MessageHandler.colorize('WARNING: Invalid JSON file', '31')
  exit 1
end
