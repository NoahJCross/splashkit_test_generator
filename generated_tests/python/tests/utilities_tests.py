import pytest
from splashkit import *


def test_Contains_integration():
    test_result = contains("SplashKit is awesome", "awesome")
    assert test_result is True
    test_result = contains("SplashKit is awesome", "unreal")
    assert test_result is False


def test_ConvertToDouble_integration():
    test_result = convert_to_double("123.456")
    assert 123.456 == test_result
    test_result = convert_to_double("-123.456")
    assert -123.456 == test_result
    test_result = convert_to_double("invalid")
    assert test_result is None


def test_ConvertToInteger_integration():
    test_result = convert_to_integer("123")
    assert 123 == test_result
    test_result = convert_to_integer("-456")
    assert -456 == test_result
    test_result = convert_to_integer("123.456")
    assert 123 == test_result
    test_result = convert_to_integer("abc")
    with pytest.raises(Exception):
        convert_to_integer("abc")


def test_IndexOf_integration():
    test_result = index_of("splashkit library", "library")
    assert 10 == test_result
    test_result = index_of("splashkit library", "unreal")
    assert -1 == test_result


def test_IsDouble_integration():
    test_result = is_double("123.456")
    assert test_result is True
    test_result = is_double("123")
    assert test_result is True
    test_result = is_double("-123.456")
    assert test_result is True
    test_result = is_double("SplashKit")
    assert test_result is False
    test_result = is_double("")
    assert test_result is False


def test_IsInteger_integration():
    test_result = is_integer("123")
    assert test_result is True
    test_result = is_integer("123.456")
    assert test_result is False
    test_result = is_integer("-123")
    assert test_result is True
    test_result = is_integer("SplashKit")
    assert test_result is False
    test_result = is_integer("")
    assert test_result is False


def test_IsNumber_integration():
    test_result = is_number("123.456")
    assert test_result is True
    test_result = is_number("abc")
    assert test_result is False


def test_LengthOf_integration():
    test_length = length_of("SplashKit")
    assert 9 == test_length
    test_length_empty = length_of("")
    assert 0 == test_length_empty


def test_ReplaceAll_integration():
    test_result = replace_all("hello world", "world", "SplashKit")
    assert "hello SplashKit" == test_result
    test_result = replace_all("aaaa", "a", "b")
    assert "bbbb" == test_result
    test_result = replace_all("test", "t", "")
    assert "es" == test_result


def test_Split_integration():
    test_result = split("splashkit library", " ")
    assert 2 == length_of(test_result)
    assert 0 == index_of(test_result, "splashkit")
    assert 0 == index_of(test_result, "library")


def test_ToLowercase_integration():
    test_lowercase = to_lowercase("SPLASHKIT")
    assert "splashkit" == test_lowercase
    test_empty = to_lowercase("")
    assert "" == test_empty


def test_ToUppercase_integration():
    test_uppercase = to_uppercase("hello")
    assert "HELLO" == test_uppercase


def test_Trim_integration():
    test_trimmed = trim("  Hello, World!  ")
    assert "Hello, World!" == test_trimmed
    test_empty_trimmed = trim(" \t\n  ")
    assert "" == test_empty_trimmed


def test_RndRange_integration():
    test_result = rnd_range(1, 10)
    assert 1 <= test_result <= 10


def test_Rnd_integration():
    test_random = rnd()
    assert test_random > 0.0
    assert test_random < 1.0


def test_RndInt_integration():
    test_result = rnd_int(10)
    assert 0 <= test_result <= 10


def test_CurrentTicks_integration():
    test_ticks = current_ticks()
    assert test_ticks > 0


def test_Delay_integration():
    test_start_time = current_ticks()
    delay(1000)
    test_end_time = current_ticks()
    assert current_ticks() > test_start_time
    assert test_start_time <= current_ticks() <= 1100


def test_DisplayDialog_integration():
    test_window = open_window("Test Window", 800, 600)
    test_font = load_font("test_font", "path/to/font.ttf")
    display_dialog("Test Title", "This is a test message.", test_font, 12)
    free_font(test_font)
    close_window(test_window)


def test_FileAsString_integration():
    test_file_content = file_as_string("test_file.txt", ResourceKind.BundleResource)
    assert "" != test_file_content

