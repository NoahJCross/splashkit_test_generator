#include <catch2/catch_all.hpp>
#include <limits>
#include "splashkit.h"
#include "../helpers.hpp"
struct TestCameraFixture
{
};
TEST_CASE_METHOD(TestCameraFixture, "camera_position_integration") {
    open_window("Test Window 1", 800, 600);
    window_cleanup cleanup_window;
    auto test_camera_position = camera_position();
    REQUIRE(0.0 == test_camera_position.x);
    REQUIRE(0.0 == test_camera_position.y);
}
TEST_CASE_METHOD(TestCameraFixture, "camera_x_integration") {
    open_window("Test Window 2", 800, 600);
    window_cleanup cleanup_window;
    set_camera_position(point_at(100.0, 100.0));
    REQUIRE(100.0 == camera_x());
}
TEST_CASE_METHOD(TestCameraFixture, "camera_y_integration") {
    open_window("Test Window 3", 800, 600);
    window_cleanup cleanup_window;
    set_camera_position(point_at(100.0, 200.0));
    REQUIRE(200.0 == camera_y());
}
TEST_CASE_METHOD(TestCameraFixture, "center_camera_on_vector_integration") {
    open_window("Test Window 4", 800, 600);
    window_cleanup cleanup_window;
    auto test_bitmap = create_bitmap("Test Bitmap 1", 100, 100);
    bitmap_cleanup cleanup_bitmap;
    auto test_sprite = create_sprite(test_bitmap);
    sprite_cleanup cleanup_sprite;
    sprite_set_position(test_sprite, point_at(100.0, 100.0));
    center_camera_on(test_sprite, vector_from_angle(50.0, 50.0));
    REQUIRE(point_at(-267.8606182336807, -161.69777810573578) == camera_position());
}
TEST_CASE_METHOD(TestCameraFixture, "center_camera_on_integration") {
    open_window("Test Window 5", 800, 600);
    window_cleanup cleanup_window;
    auto test_bitmap = create_bitmap("Test Bitmap 2", 100, 100);
    bitmap_cleanup cleanup_bitmap;
    auto test_sprite = create_sprite(test_bitmap);
    sprite_cleanup cleanup_sprite;
    sprite_set_position(test_sprite, point_at(100.0, 100.0));
    center_camera_on(test_sprite, 0.0, 0.0);
    REQUIRE(point_at(-300.0, -200.0) == camera_position());
}
TEST_CASE_METHOD(TestCameraFixture, "move_camera_by_vector_integration") {
    open_window("Test Window 6", 800, 600);
    window_cleanup cleanup_window;
    auto test_vector = vector_from_angle(0.0, 100.0);
    move_camera_to(0.0, 0.0);
    move_camera_by(test_vector);
    REQUIRE(100.0 == camera_x());
    REQUIRE(0.0 == camera_y());
}
TEST_CASE_METHOD(TestCameraFixture, "move_camera_by_integration") {
    open_window("Test Window 7", 800, 600);
    window_cleanup cleanup_window;
    move_camera_to(0.0, 0.0);
    move_camera_by(100.0, 100.0);
    REQUIRE(100.0 == camera_x());
    REQUIRE(100.0 == camera_y());
}
TEST_CASE_METHOD(TestCameraFixture, "move_camera_to_point_integration") {
    open_window("Test Window 8", 800, 600);
    window_cleanup cleanup_window;
    move_camera_to(point_at(100.0, 100.0));
    REQUIRE(point_at(100.0, 100.0) == camera_position());
}
TEST_CASE_METHOD(TestCameraFixture, "move_camera_to_integration") {
    open_window("Test Window 9", 800, 600);
    window_cleanup cleanup_window;
    move_camera_to(100.0, 100.0);
    REQUIRE(100.0 == camera_x());
    REQUIRE(100.0 == camera_y());
}
TEST_CASE_METHOD(TestCameraFixture, "point_in_window_integration") {
    auto test_window = open_window("Test Window 10", 800, 600);
    window_cleanup cleanup_window;
    auto test_point = point_at(400.0, 300.0);
    REQUIRE(point_in_window(test_window, test_point));
    auto test_point_outside = point_at(1000.0, 1000.0);
    REQUIRE_FALSE(point_in_window(test_window, test_point_outside));
}
TEST_CASE_METHOD(TestCameraFixture, "point_on_screen_integration") {
    open_window("Test Window 11", 800, 600);
    window_cleanup cleanup_window;
    auto test_point = point_at(400.0, 300.0);
    REQUIRE(point_on_screen(test_point));
    auto test_point_outside = point_at(1000.0, 1000.0);
    REQUIRE_FALSE(point_on_screen(test_point_outside));
}
TEST_CASE_METHOD(TestCameraFixture, "rect_in_window_integration") {
    auto test_window = open_window("Test Window 12", 800, 600);
    window_cleanup cleanup_window;
    set_camera_x(0.0);
    set_camera_y(0.0);
    auto test_rectangle = rectangle_from(0.0, 0.0, 100.0, 100.0);
    REQUIRE(rect_in_window(test_window, test_rectangle));
    auto test_rectangle_outside = rectangle_from(1000.0, 1000.0, 100.0, 100.0);
    REQUIRE_FALSE(rect_in_window(test_window, test_rectangle_outside));
}
TEST_CASE_METHOD(TestCameraFixture, "rect_on_screen_integration") {
    open_window("Test Window 13", 800, 600);
    window_cleanup cleanup_window;
    auto test_rectangle = rectangle_from(0.0, 0.0, 100.0, 100.0);
    REQUIRE(rect_on_screen(test_rectangle));
    move_camera_to(1000.0, 1000.0);
    REQUIRE_FALSE(rect_on_screen(test_rectangle));
}
TEST_CASE_METHOD(TestCameraFixture, "screen_center_integration") {
    open_window("Test Window 14", 800, 600);
    window_cleanup cleanup_window;
    set_camera_x(0.0);
    set_camera_y(0.0);
    auto test_center = screen_center();
    REQUIRE(400.0 == test_center.x);
    REQUIRE(300.0 == test_center.y);
}
TEST_CASE_METHOD(TestCameraFixture, "screen_rectangle_integration") {
    open_window("Test Window 15", 800, 600);
    window_cleanup cleanup_window;
    auto test_rectangle = screen_rectangle();
    REQUIRE(800.0 == test_rectangle.width);
    REQUIRE(600.0 == test_rectangle.height);
}
TEST_CASE_METHOD(TestCameraFixture, "set_camera_position_integration") {
    open_window("Test Window 16", 800, 600);
    window_cleanup cleanup_window;
    set_camera_position(point_at(100.0, 100.0));
    REQUIRE(point_at(100.0, 100.0) == camera_position());
}
TEST_CASE_METHOD(TestCameraFixture, "set_camera_x_integration") {
    open_window("Test Window 17", 800, 600);
    window_cleanup cleanup_window;
    set_camera_x(100.0);
    REQUIRE(100.0 == camera_x());
}
TEST_CASE_METHOD(TestCameraFixture, "set_camera_y_integration") {
    open_window("Test Window 18", 800, 600);
    window_cleanup cleanup_window;
    set_camera_y(100.0);
    REQUIRE(100.0 == camera_y());
}
TEST_CASE_METHOD(TestCameraFixture, "to_screen_point_integration") {
    open_window("Test Window 19", 800, 600);
    window_cleanup cleanup_window;
    set_camera_position(point_at(100.0, 100.0));
    auto test_screen_point = to_screen(point_at(150.0, 150.0));
    REQUIRE(50.0 == test_screen_point.x);
    REQUIRE(50.0 == test_screen_point.y);
}
TEST_CASE_METHOD(TestCameraFixture, "to_screen_rectangle_integration") {
    open_window("Test Window 20", 800, 600);
    window_cleanup cleanup_window;
    auto test_rectangle = rectangle_from(100.0, 100.0, 200.0, 200.0);
    auto screen_rectangle = to_screen(test_rectangle);
    REQUIRE(to_screen_x(100.0) == rectangle_left(screen_rectangle));
    REQUIRE(to_screen_y(100.0) == rectangle_top(screen_rectangle));
}
TEST_CASE_METHOD(TestCameraFixture, "to_screen_x_integration") {
    open_window("Test Window 21", 800, 600);
    window_cleanup cleanup_window;
    set_camera_x(100.0);
    auto test_screen_x = to_screen_x(150.0);
    REQUIRE(50.0 == test_screen_x);
}
TEST_CASE_METHOD(TestCameraFixture, "to_screen_y_integration") {
    open_window("Test Window 22", 800, 600);
    window_cleanup cleanup_window;
    set_camera_y(100.0);
    auto test_screen_y = to_screen_y(150.0);
    REQUIRE(50.0 == test_screen_y);
}
TEST_CASE_METHOD(TestCameraFixture, "to_world_integration") {
    open_window("Test Window 23", 800, 600);
    window_cleanup cleanup_window;
    set_camera_position(point_at(100.0, 100.0));
    auto test_world_point = to_world(point_at(400.0, 300.0));
    REQUIRE(500.0 == test_world_point.x);
    REQUIRE(400.0 == test_world_point.y);
}
TEST_CASE_METHOD(TestCameraFixture, "to_world_x_integration") {
    open_window("Test Window 24", 800, 600);
    window_cleanup cleanup_window;
    set_camera_position(point_at(100.0, 100.0));
    auto test_world_x = to_world_x(400.0);
    REQUIRE(500.0 == test_world_x);
}
TEST_CASE_METHOD(TestCameraFixture, "to_world_y_integration") {
    open_window("Test Window 25", 800, 600);
    window_cleanup cleanup_window;
    set_camera_position(point_at(100.0, 100.0));
    auto test_world_y = to_world_y(300.0);
    REQUIRE(400.0 == test_world_y);
}
TEST_CASE_METHOD(TestCameraFixture, "vector_world_to_screen_integration") {
    auto test_vector1 = vector_world_to_screen();
    REQUIRE(vector_from_angle(0.0, 0.0) == test_vector1);
    move_camera_to(100.0, 100.0);
    auto test_vector2 = vector_world_to_screen();
    auto test_vector_to = vector_to(-100.0, -100.0);
    REQUIRE(test_vector_to.x == test_vector2.x);
    REQUIRE(test_vector_to.y == test_vector2.y);
}
TEST_CASE_METHOD(TestCameraFixture, "window_area_integration") {
    auto test_window = open_window("Test Window 26", 800, 600);
    window_cleanup cleanup_window;
    auto test_area = window_area(test_window);
    REQUIRE(800.0 == test_area.width);
    REQUIRE(600.0 == test_area.height);
}
