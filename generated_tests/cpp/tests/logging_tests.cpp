#include "splashkit.h"
#include <catch2/catch.hpp>
#include "../helpers.hpp"
class TestLogging {
public:
    TEST_CASE("close_log_process_integration") {
        init_custom_logger(string("test_logging"), true, LogMode::LOG_CONSOLE_AND_FILE);
        LoggerCleanup cleanup_logger;
        log(LogLevel::INFO, string("This message should appear in both console and file."));
        close_log_process();
    }
    TEST_CASE("init_custom_logger_integration") {
        init_custom_logger(LogMode::LOG_CONSOLE);
        LoggerCleanup cleanup_logger;
        log(LogLevel::INFO, string("This message should appear in the console."));
        log(LogLevel::INFO, string("This message should appear in the console."));
        init_custom_logger(LogMode::LOG_FILE_ONLY);
        log(LogLevel::INFO, string("This message should only appear in the log file."));
        log(LogLevel::INFO, string("This message should only appear in the log file."));
    }
    TEST_CASE("init_custom_logger__name_override_mode_integration") {
        init_custom_logger(string("test_app"), true, LogMode::LOG_CONSOLE_AND_FILE);
        LoggerCleanup cleanup_logger;
        log(LogLevel::INFO, string("This message should appear in both console and file."));
        init_custom_logger(string("test_app"), false, LogMode::LOG_FILE_ONLY);
        log(LogLevel::INFO, string("This message should only appear in the file."));
    }
    TEST_CASE("log_integration") {
        init_custom_logger(string("test_logging"), true, LogMode::LOG_CONSOLE_AND_FILE);
        LoggerCleanup cleanup_logger;
        log(LogLevel::INFO, string("This message should appear in both console and file."));
    }
};
