# frozen_string_literal: true
# rubocop:disable Layout/HashAlignment

module LanguageConfig
  # Configuration class for generating Rust test files
  class RustConfig < BaseConfig
    def initialize
      super()
      self.config = DEFAULT_CONFIG.merge
    end
    DEFAULT_CONFIG = {
      supports_overloading: false,
      imports: [
        "use splashkit::*;\n",
        "#[cfg(test)]\n",
        "mod test_runner {\n",
        "    pub fn run_tests_sequential(tests: &[&dyn Fn()]) {\n",
        "        for test in tests {\n",
        "            test();\n",
        "        }\n",
        "    }\n",
        "}\n",
        "#![test_runner(test_runner::run_tests_sequential)]\n"
      ],

      naming_convention: ->(name) { name.to_snake_case },

      assert_conditions: {
        'equal'                   => ->(v1, v2, _)    { "assert_eq!(#{v1}, #{v2});\n" },
        'not_equal'               => ->(v1, v2, _)    { "assert_ne!(#{v1}, #{v2});\n" },
        'greater_than'            => ->(v1, v2, _)    { "assert!(#{v1} > #{v2});\n" },
        'less_than'               => ->(v1, v2, _)    { "assert!(#{v1} < #{v2});\n" },
        'null'                    => ->(v1, _, _)     { "assert!(#{v1}.is_none());\n" },
        'not_null'                => ->(v1, _, _)     { "assert!(#{v1}.is_some());\n" },
        'range'                   => ->(v1, v2, v3)   { "assert!((#{v2}..=#{v3}).contains(&#{v1}));\n" },
        'true'                    => ->(v1, _, _)     { "assert!(#{v1});\n" },
        'false'                   => ->(v1, _, _)     { "assert!(!#{v1});\n" },
        'greater_than_or_equal'   => ->(v1, v2, _)    { "assert!(#{v1} >= #{v2});\n" },
        'less_than_or_equal'      => ->(v1, v2, _)    { "assert!(#{v1} <= #{v2});\n" },
        'throws'                  => ->(v1, _, _)     { "assert!(std::panic::catch_unwind(|| { #{v1} }).is_err());\n" },
        'not_empty'               => ->(v1, _, _)     { "assert!(!#{v1}.is_empty());\n" },
        'contains'                => ->(v1, v2, _)    { "assert!(#{v2}.contains(#{v1}));\n" },
        'empty'                   => ->(v1, _, _)     { "assert!(#{v1}.is_empty());\n" }
      }.freeze,

      if_conditions: {
        'greater_than' => ->(v1, v2) { "#{v1} > #{v2}" },
        'true'         => ->(v1, _)  { "#{v1} == true" },
        'false'        => ->(v1, _)  { "#{v1} == false" },
        'equal'        => ->(v1, v2) { "#{v1} == #{v2}" },
        'not_equal'    => ->(v1, v2) { "#{v1} != #{v2}" }
      }.freeze,

      control_flow: {
        loop:      ->(iterations) { "for _ in 0..#{iterations} {\n" },
        while:     ->(condition) { "while #{condition} {\n" },
        if:        ->(condition) { "if #{condition} {\n" },
        else:      -> { "else {\n" },
        break:     -> { "break;\n" },
        end:       -> { "}\n" }
      }.freeze,

      string_handlers: {
        interpolation: ->(expr) { "{#{expr}}" },
        concatenation: ->(parts) { "format!(\"#{parts.join}\")" },
        char:          ->(value) { "'#{value}'" }
      }.freeze,

      numeric_constants: {
        'inf'          => 'f64::INFINITY',
        'neg_inf'      => 'f64::NEG_INFINITY',
        'max_value'    => 'f32::MAX'
      }.freeze,

      type_handlers: {
        list:      ->(values, _) { "vec![#{values}]" },
        class:     ->(name, args) { "#{name}::new(#{args})" },
        mapping:   {
          'double' => 'f64',
          'json'   => 'Json',
          'line'   => 'Line'
        }.freeze,
        enum:      ->(type, value, semicolon = true) { 
          "#{type.to_pascal_case}::#{value.to_pascal_case}#{semicolon ? ";\n" : ''}" 
        }
      }.freeze,

      variable_handlers: {
        declaration:  ->(name) { "let #{name.to_snake_case} = " },
        reference:    ->(name) { name.to_snake_case.to_s },
        field_access: ->(var, field) { "#{var}.#{field}" },
        array_access: ->(arr, idx) { "#{arr}[#{idx}]" },
        matrix_access: ->(var, row, col) { "#{var}[#{row}, #{col}]" }
      }.freeze,

      function_handlers: {
        call:      ->(name, params, semicolon = true) { "#{name.to_snake_case}(#{params})#{semicolon ? ';' : ''}" },
        pointer:   ->(name) { "let callback = |_| (); #{name}Wrapper::new(callback);\n" },
        test:      ->(name) { "#[test]\nfn test_#{name.to_snake_case}_integration() {\n" }
      }.freeze,

      class_wrapper: {
        header: [
          ->(group) { "mod test_#{group.to_snake_case} {\n" },
          "use super::*;\n"
        ],
        constructor_wrapper: {
          header: "fn setup() {\n",
          footer: "}\n\n"
        },
        footer: ["}\n"],
        indent_after: [->(group) { "mod test_#{group.to_snake_case} {\n" }, "fn setup() {\n"],
        unindent_before: ["}\n"]
      }.freeze,

      file_extension: 'rs',
      runtime_requirement: 'Rust',
      installation_steps: [
        '1. Install SplashKit SDK following instructions at https://splashkit.io/installation/',
        '2. Create new Cargo project: cargo new splashkit_tests',
        '3. Add to Cargo.toml:',
        '   [dependencies]',
        '   splashkit = "*"',
        '4. Move integration_tests.rs to splashkit_tests/src/lib.rs'
      ].join("\n"),
      run_command: 'cd splashkit_tests && cargo test'
    }.freeze
  end
end