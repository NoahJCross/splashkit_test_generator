use splashkit::*;
#[cfg(test)]
mod test_runner {
    pub fn run_tests_sequential(tests: &[&dyn Fn()]) {
        for test in tests {
            test();
        }
    }
}
#![test_runner(test_runner::run_tests_sequential)]
#[test]
fn test_close_log_process_integration() {
    init_custom_logger("test_logging", true, LogMode::LogConsoleAndFile);
    log(LogLevel::Info, "Test message");
    close_log_process();
    assert_eq!(file_exists, "test_logging.log");
    delete_file("test_logging.log");
}
#[test]
fn test_init_custom_logger_integration() {
    init_custom_logger(LogMode::LogConsole);
    log(LogLevel::Info, "This message should appear in the console.");
    assert!(log(LogLevel::Info, "This message should appear in the console."));
    init_custom_logger(LogMode::LogFileOnly);
    log(LogLevel::Info, "This message should only appear in the log file.");
    assert!(!log(LogLevel::Info, "This message should only appear in the log file."));
    close_log_process();
}
#[test]
fn test_init_custom_logger__name_override_mode_integration() {
    init_custom_logger__name_override_mode("test_app", true, LogMode::LogConsoleAndFile);
    log(LogLevel::Info, "This message should appear in both console and file.");
    assert_eq!(file_exists, "test_app.log");
    init_custom_logger__name_override_mode("test_app", false, LogMode::LogFileOnly);
    log(LogLevel::Info, "This message should only appear in the file.");
    assert_eq!(file_exists, "test_app.log");
    close_log_process();
}
#[test]
fn test_log_integration() {
    init_custom_logger("test_logging", true, LogMode::LogConsoleAndFile);
    log(LogLevel::Info, "This is an info message");
    assert!(log(LogLevel::Info, "This is an info message"));
    close_log_process();
}
