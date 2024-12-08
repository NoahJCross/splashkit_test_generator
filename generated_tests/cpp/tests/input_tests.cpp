#include "splashkit.h"
#include <catch2/catch.hpp>

TEST_CASE("process_events_integration") {
    simulate_key_press(KeyCode::A);
    process_events();
    REQUIRE(key_typed(KeyCode::A));
    simulate_mouse_click(MouseButton::LEFT);
    process_events();
    REQUIRE(mouse_clicked(MouseButton::LEFT));
}
TEST_CASE("quit_requested_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    process_events();
    REQUIRE_FALSE(quit_requested());
    simulate_key_press(KeyCode::ESCAPE);
    process_events();
    REQUIRE(quit_requested());
    close_window(test_window);
}
TEST_CASE("reset_quit_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    process_events();
    REQUIRE(quit_requested());
    reset_quit();
    process_events();
    REQUIRE_FALSE(quit_requested());
    close_window(test_window);
}
TEST_CASE("any_key_pressed_integration") {
    process_events();
    REQUIRE_FALSE(any_key_pressed());
    simulate_key_press(KeyCode::A);
    process_events();
    REQUIRE(any_key_pressed());
}
TEST_CASE("deregister_callback_on_key_down_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    register_callback_on_key_down(_on_key_down());
    simulate_key_press(KeyCode::A);
    process_events();
    REQUIRE(key_down(KeyCode::A));
    deregister_callback_on_key_down(_on_key_down());
    simulate_key_press(KeyCode::B);
    process_events();
    REQUIRE_FALSE(key_down(KeyCode::B));
    close_window(test_window);
}
TEST_CASE("deregister_callback_on_key_typed_integration") {
    register_callback_on_key_typed(_on_key_typed());
    simulate_key_press(KeyCode::A);
    process_events();
    REQUIRE(key_typed(KeyCode::A));
    deregister_callback_on_key_typed(_on_key_typed());
    simulate_key_press(KeyCode::B);
    process_events();
    REQUIRE_FALSE(key_typed(KeyCode::B));
}
TEST_CASE("deregister_callback_on_key_up_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    register_callback_on_key_up(_on_key_up());
    simulate_key_press(KeyCode::A);
    process_events();
    REQUIRE(key_up(KeyCode::A));
    deregister_callback_on_key_up(_on_key_up());
    simulate_key_press(KeyCode::B);
    process_events();
    REQUIRE_FALSE(key_up(KeyCode::B));
    close_window(test_window);
}
TEST_CASE("key_down_integration") {
    process_events();
    REQUIRE_FALSE(key_down(KeyCode::A));
    simulate_key_press(KeyCode::A);
    process_events();
    REQUIRE(key_down(KeyCode::A));
    simulate_key_release(KeyCode::A);
    process_events();
    REQUIRE_FALSE(key_down(KeyCode::A));
}
TEST_CASE("key_name_integration") {
    auto test_key_name1 = key_name(KeyCode::A);
    REQUIRE("A" == test_key_name1);
    auto test_key_name2 = key_name(KeyCode::ENTER);
    REQUIRE("Enter" == test_key_name2);
}
TEST_CASE("key_released_integration") {
    process_events();
    REQUIRE_FALSE(key_released(KeyCode::A));
    simulate_key_press(KeyCode::A);
    process_events();
    simulate_key_release(KeyCode::A);
    process_events();
    REQUIRE(key_released(KeyCode::A));
}
TEST_CASE("key_typed_integration") {
    process_events();
    REQUIRE_FALSE(key_typed(KeyCode::A));
    simulate_key_press(KeyCode::A);
    process_events();
    REQUIRE(key_typed(KeyCode::A));
}
TEST_CASE("key_up_integration") {
    process_events();
    REQUIRE(key_up(KeyCode::A));
    simulate_key_press(KeyCode::A);
    process_events();
    REQUIRE_FALSE(key_up(KeyCode::A));
    simulate_key_release(KeyCode::A);
    process_events();
    REQUIRE(key_up(KeyCode::A));
}
TEST_CASE("register_callback_on_key_down_integration") {
    register_callback_on_key_down(_on_key_down());
    process_events();
    simulate_key_press(KeyCode::A);
    process_events();
    REQUIRE(key_down(KeyCode::A));
    deregister_callback_on_key_down(_on_key_down());
}
TEST_CASE("register_callback_on_key_typed_integration") {
    register_callback_on_key_typed(_on_key_typed());
    process_events();
    simulate_key_press(KeyCode::A);
    process_events();
    REQUIRE(key_typed(KeyCode::A));
    deregister_callback_on_key_typed(_on_key_typed());
}
TEST_CASE("register_callback_on_key_up_integration") {
    register_callback_on_key_up(_on_key_up());
    process_events();
    simulate_key_press(KeyCode::A);
    simulate_key_release(KeyCode::A);
    process_events();
    REQUIRE("A" == _key_up);
    deregister_callback_on_key_up(_on_key_up());
}
TEST_CASE("hide_mouse_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    process_events();
    REQUIRE(mouse_shown());
    hide_mouse();
    process_events();
    REQUIRE_FALSE(mouse_shown());
    close_window(test_window);
}
TEST_CASE("mouse_clicked_integration") {
    process_events();
    REQUIRE_FALSE(mouse_clicked(MouseButton::LEFT));
    simulate_mouse_click(MouseButton::LEFT);
    process_events();
    REQUIRE(mouse_clicked(MouseButton::LEFT));
}
TEST_CASE("mouse_down_integration") {
    process_events();
    REQUIRE_FALSE(mouse_down(MouseButton::LEFT));
    simulate_mouse_press(MouseButton::LEFT);
    process_events();
    REQUIRE(mouse_down(MouseButton::LEFT));
    simulate_mouse_release(MouseButton::LEFT);
    process_events();
    REQUIRE_FALSE(mouse_down(MouseButton::LEFT));
}
TEST_CASE("mouse_movement_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    move_mouse(100.0, 100.0);
    process_events();
    auto test_movement = mouse_movement();
    REQUIRE(100.0 == test_movement->x);
    REQUIRE(100.0 == test_movement->y);
    close_window(test_window);
}
TEST_CASE("mouse_position_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    move_mouse(400.0, 300.0);
    process_events();
    auto test_position = mouse_position();
    REQUIRE(400.0 == test_position->x);
    REQUIRE(300.0 == test_position->y);
    close_window(test_window);
}
TEST_CASE("mouse_position_vector_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    move_mouse(400.0, 300.0);
    process_events();
    auto test_mouse_position = mouse_position_vector();
    REQUIRE(400.0 == test_mouse_position->x);
    REQUIRE(300.0 == test_mouse_position->y);
    close_window(test_window);
}
TEST_CASE("mouse_shown_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    show_mouse();
    process_events();
    REQUIRE(mouse_shown());
    hide_mouse();
    process_events();
    REQUIRE_FALSE(mouse_shown());
    close_window(test_window);
}
TEST_CASE("mouse_up_integration") {
    process_events();
    REQUIRE(mouse_up(MouseButton::LEFT));
    simulate_mouse_click(MouseButton::LEFT);
    process_events();
    REQUIRE_FALSE(mouse_up(MouseButton::LEFT));
}
TEST_CASE("mouse_wheel_scroll_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    process_events();
    REQUIRE(vector_from_angle(0.0, 0.0) == mouse_wheel_scroll());
    simulate_mouse_wheel_scroll(10.0, 5.0);
    process_events();
    REQUIRE(mouse_wheel_scroll());
    close_window(test_window);
}
TEST_CASE("mouse_x_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    move_mouse(400.0, 300.0);
    process_events();
    REQUIRE(mouse_x() >= 399.0 && mouse_x() <= 401.0);
    close_window(test_window);
}
TEST_CASE("mouse_y_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    move_mouse(400.0, 300.0);
    process_events();
    REQUIRE(300.0 == mouse_y());
    close_window(test_window);
}
TEST_CASE("move_mouse_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    process_events();
    move_mouse(400.0, 300.0);
    process_events();
    REQUIRE(mouse_x() >= 399.0 && mouse_x() <= 401.0);
    REQUIRE(mouse_y() >= 299.0 && mouse_y() <= 301.0);
    close_window(test_window);
}
TEST_CASE("move_mouse_to_point_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    move_mouse(point_at(400.0, 300.0));
    process_events();
    REQUIRE(point_at(400.0, 300.0) == mouse_position());
    close_window(test_window);
}
TEST_CASE("show_mouse_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    hide_mouse();
    process_events();
    REQUIRE_FALSE(mouse_shown());
    show_mouse();
    process_events();
    REQUIRE(mouse_shown());
    close_window(test_window);
}
TEST_CASE("show_mouse_with_boolean_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    show_mouse(true);
    process_events();
    REQUIRE(mouse_shown());
    show_mouse(false);
    process_events();
    REQUIRE_FALSE(mouse_shown());
    close_window(test_window);
}
TEST_CASE("draw_collected_text_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    auto test_font = load_font("test_font", "path/to/font.ttf");
    start_reading_text(rectangle_from(100, 100, 200, 30));
    process_events();
    simulate_key_press(KeyCode::A);
    process_events();
    draw_collected_text(color_black(), test_font, 18, option_defaults());
    refresh_screen();
    REQUIRE(color_black() == get_pixel(test_window, 105, 115));
    end_reading_text();
    free_font(test_font);
    close_window(test_window);
}
TEST_CASE("end_reading_text_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    start_reading_text(rectangle_from(100.0, 100.0, 200.0, 30.0));
    process_events();
    REQUIRE(reading_text());
    end_reading_text();
    process_events();
    REQUIRE_FALSE(reading_text());
    close_window(test_window);
}
TEST_CASE("end_reading_text_in_window_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    auto test_rectangle = rectangle_from(100.0, 100.0, 200.0, 30.0);
    start_reading_text(test_window, test_rectangle);
    process_events();
    REQUIRE(reading_text(test_window));
    end_reading_text(test_window);
    process_events();
    REQUIRE_FALSE(reading_text(test_window));
    close_window(test_window);
}
TEST_CASE("reading_text_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    start_reading_text(rectangle_from(100.0, 100.0, 200.0, 30.0));
    process_events();
    REQUIRE(reading_text());
    end_reading_text();
    process_events();
    REQUIRE_FALSE(reading_text());
    close_window(test_window);
}
TEST_CASE("reading_text_in_window_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    auto test_rectangle = rectangle_from(100.0, 100.0, 200.0, 30.0);
    start_reading_text(test_window, test_rectangle);
    process_events();
    REQUIRE(reading_text(test_window));
    end_reading_text(test_window);
    process_events();
    REQUIRE_FALSE(reading_text(test_window));
    close_window(test_window);
}
TEST_CASE("start_reading_text_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    auto test_rect = rectangle_from(100.0, 100.0, 200.0, 30.0);
    start_reading_text(test_rect);
    process_events();
    REQUIRE(reading_text());
    end_reading_text();
    process_events();
    REQUIRE_FALSE(reading_text());
    close_window(test_window);
}
TEST_CASE("start_reading_text_with_initial_text_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    auto test_rect = rectangle_from(100.0, 100.0, 200.0, 30.0);
    start_reading_text(test_rect, "Initial Text");
    process_events();
    REQUIRE(reading_text());
    end_reading_text();
    close_window(test_window);
}
TEST_CASE("start_reading_text_in_window_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    auto test_rect = rectangle_from(100.0, 100.0, 200.0, 30.0);
    start_reading_text(test_window, test_rect);
    process_events();
    REQUIRE(reading_text(test_window));
    end_reading_text(test_window);
    close_window(test_window);
}
TEST_CASE("start_reading_text_in_window_with_initial_text_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    auto test_rect = rectangle_from(100.0, 100.0, 200.0, 30.0);
    start_reading_text(test_window, test_rect, "Initial Text");
    process_events();
    REQUIRE(reading_text(test_window));
    end_reading_text(test_window);
    close_window(test_window);
}
TEST_CASE("text_entry_cancelled_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    start_reading_text(rectangle_from(100.0, 100.0, 200.0, 30.0));
    process_events();
    REQUIRE_FALSE(text_entry_cancelled());
    simulate_key_press(KeyCode::ESCAPE);
    process_events();
    REQUIRE(text_entry_cancelled());
    end_reading_text();
    close_window(test_window);
}
TEST_CASE("text_entry_cancelled_in_window_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    auto test_rect = rectangle_from(100.0, 100.0, 200.0, 30.0);
    start_reading_text(test_window, test_rect);
    process_events();
    REQUIRE_FALSE(text_entry_cancelled(test_window));
    simulate_key_press(KeyCode::ESCAPE);
    process_events();
    REQUIRE(text_entry_cancelled(test_window));
    close_window(test_window);
}
TEST_CASE("text_input_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    start_reading_text(rectangle_from(100.0, 100.0, 200.0, 30.0));
    process_events();
    simulate_key_press(KeyCode::A);
    process_events();
    REQUIRE("A" == text_input());
    end_reading_text();
    close_window(test_window);
}
TEST_CASE("text_input_in_window_integration") {
    auto test_window = open_window("Test Window", 800, 600);
    auto test_rectangle = rectangle_from(100.0, 100.0, 200.0, 30.0);
    start_reading_text(test_window, test_rectangle);
    process_events();
    simulate_key_press(KeyCode::A);
    process_events();
    REQUIRE("A" == text_input(test_window));
    end_reading_text(test_window);
    close_window(test_window);
}
