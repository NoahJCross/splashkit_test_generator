#include "splashkit.h"
#include <catch2/catch.hpp>
#include "../helpers.hpp"
class TestGeometry {
public:
    TEST_CASE("center_point_of_circle_integration") {
        auto test_circle = circle_at(100.0, 100.0, 50.0);
        auto test_center_point = center_point(test_circle);
        REQUIRE(test_center_point == point_at(100.0, 100.0));
    }
    TEST_CASE("circle_at_integration") {
        open_window(string("Test Window"), 800, 600);
        WindowCleanup cleanup_window;
        auto test_circle = circle_at(point_at(400.0, 300.0), 50.0);
        draw_circle(color_black(), test_circle);
        refresh_screen();
        REQUIRE(point_in_circle(point_at(400.0, 300.0), test_circle));
    }
    TEST_CASE("circle_at_from_points_integration") {
        open_window(string("Circle Test"), 800, 600);
        WindowCleanup cleanup_window;
        auto test_circle = circle_at(400.0, 300.0, 50.0);
        draw_circle(color_black(), test_circle, option_defaults());
        refresh_screen();
        REQUIRE(point_in_circle(point_at(400.0, 300.0), test_circle));
    }
    TEST_CASE("circle_radius_integration") {
        auto test_circle = circle_at(100.0, 100.0, 50.0);
        auto test_radius = circle_radius(test_circle);
        REQUIRE(50.0 == test_radius);
    }
    TEST_CASE("circle_triangle_intersect_integration") {
        auto test_circle = circle_at(100.0, 100.0, 50.0);
        auto test_triangle = triangle_from(point_at(50.0, 50.0), point_at(150.0, 50.0), point_at(100.0, 150.0));
        auto test_result = circle_triangle_intersect(test_circle, test_triangle);
        REQUIRE(test_result);
    }
    TEST_CASE("circle_triangle_intersect_get_closest_point_integration") {
        auto test_circle = circle_at(100.0, 100.0, 50.0);
        auto test_triangle = triangle_from(point_at(50.0, 50.0), point_at(150.0, 50.0), point_at(100.0, 150.0));
        auto test_point = point_at(0.0, 0.0);
        auto test_result = circle_triangle_intersect(test_circle, test_triangle, &test_point);
        REQUIRE(test_result);
    }
    TEST_CASE("circle_x_integration") {
        auto test_circle = circle_at(100.0, 100.0, 50.0);
        REQUIRE(100.0 == circle_x(test_circle));
    }
    TEST_CASE("circle_y_integration") {
        auto test_circle = circle_at(100.0, 150.0, 50.0);
        REQUIRE(150.0 == circle_y(test_circle));
    }
    TEST_CASE("circles_intersect_integration") {
        auto test_circle1 = circle_at(0.0, 0.0, 50.0);
        auto test_circle2 = circle_at(100.0, 0.0, 50.0);
        auto test_result1 = circles_intersect(test_circle1, test_circle2);
        REQUIRE_FALSE(test_result1);
        auto test_circle3 = circle_at(50.0, 0.0, 50.0);
        auto test_result2 = circles_intersect(test_circle1, test_circle3);
        REQUIRE(test_result2);
    }
    TEST_CASE("circles_intersect_using_values_integration") {
        auto test_intersect_result = circles_intersect(0.0, 0.0, 5.0, 5.0, 0.0, 5.0);
        REQUIRE(test_intersect_result);
        auto test_not_intersect_result = circles_intersect(0.0, 0.0, 5.0, 11.0, 0.0, 5.0);
        REQUIRE_FALSE(test_not_intersect_result);
    }
    TEST_CASE("closest_point_on_circle_integration") {
        auto test_circle = circle_at(100.0, 100.0, 50.0);
        auto test_point = point_at(200.0, 100.0);
        auto test_closest_point = closest_point_on_circle(test_point, test_circle);
        REQUIRE(circle_radius(test_circle) == point_point_distance(test_closest_point, test_point));
    }
    TEST_CASE("closest_point_on_line_from_circle_integration") {
        auto test_circle = circle_at(100.0, 100.0, 50.0);
        auto test_line = line_from(50.0, 50.0, 150.0, 150.0);
        auto test_closest_point = closest_point_on_line_from_circle(test_circle, test_line);
        REQUIRE(point_on_line(test_closest_point, test_line));
    }
    TEST_CASE("closest_point_on_rect_from_circle_integration") {
        auto test_circle = circle_at(100.0, 100.0, 50.0);
        auto test_rectangle = rectangle_from(100.0, 50.0, 100.0, 100.0);
        auto test_closest_point = closest_point_on_rect_from_circle(test_circle, test_rectangle);
        REQUIRE(point_in_rectangle(test_closest_point, test_rectangle));
        REQUIRE(circle_radius(test_circle) == point_point_distance(center_point(test_circle), test_closest_point));
    }
    TEST_CASE("closest_point_on_triangle_from_circle_integration") {
        auto test_circle = circle_at(100.0, 100.0, 50.0);
        auto test_triangle = triangle_from(point_at(50.0, 50.0), point_at(150.0, 50.0), point_at(100.0, 150.0));
        auto test_closest_point = closest_point_on_triangle_from_circle(test_circle, test_triangle);
        REQUIRE(point_in_triangle(test_closest_point, test_triangle));
    }
    TEST_CASE("distant_point_on_circle_integration") {
        auto test_circle = circle_at(100.0, 100.0, 50.0);
        auto test_point = point_at(100.0, 150.0);
        auto test_distant_point = distant_point_on_circle(test_point, test_circle);
        REQUIRE(100.0f == point_point_distance(test_point, test_distant_point));
    }
    TEST_CASE("distant_point_on_circle_heading_integration") {
        auto test_circle = circle_at(100.0, 100.0, 50.0);
        auto test_point1 = point_at(150.0, 100.0);
        auto test_heading = vector_from_angle(180.0, 1.0);
        auto test_point2 = point_at(0.0, 0.0);
        auto test_result = distant_point_on_circle_heading(test_point1, test_circle, test_heading, &test_point2);
        REQUIRE(test_result);
        REQUIRE(abs(50.0 - test_point2.x) <= 2.0);
        REQUIRE(abs(100.0 - test_point2.y) <= 2.0);
    }
    TEST_CASE("ray_circle_intersect_distance_integration") {
        auto test_circle = circle_at(100.0, 100.0, 50.0);
        auto test_ray_origin = point_at(0.0, 0.0);
        auto test_ray_heading = vector_from_angle(45.0, 1.0);
        auto test_distance = ray_circle_intersect_distance(test_ray_origin, test_ray_heading, test_circle);
        REQUIRE(91.4213562f == test_distance);
    }
    TEST_CASE("tangent_points_integration") {
        auto test_from_pt = point_at(100.0, 100.0);
        auto test_circle = circle_at(150.0, 150.0, 50.0);
        auto test_point1 = point_at(0.0, 0.0);
        auto test_point2 = point_at(0.0, 0.0);
        auto test_result = tangent_points(test_from_pt, test_circle, &test_point1, &test_point2);
        REQUIRE(test_result);
        REQUIRE(point_at(0.0, 0.0) != test_point1);
        REQUIRE(point_at(0.0, 0.0) != test_point2);
    }
    TEST_CASE("widest_points_integration") {
        auto test_circle = circle_at(100.0, 100.0, 50.0);
        auto test_vector = vector_from_angle(45.0, 45.0);
        auto test_point1 = point_at(0.0, 0.0);
        auto test_point2 = point_at(0.0, 0.0);
        widest_points(test_circle, test_vector, &test_point1, &test_point2);
        REQUIRE(point_in_circle(point_at(circle_x(test_circle), circle_y(test_circle)), test_circle));
        REQUIRE(point_in_circle(point_at(circle_x(test_circle), circle_y(test_circle)), test_circle));
    }
    TEST_CASE("cosine_integration") {
        auto test_cosine_0 = cosine(0.0f);
        REQUIRE(abs(1.0 - test_cosine_0) <= 2.0);
        auto test_cosine_90 = cosine(90.0f);
        REQUIRE(abs(0.0 - test_cosine_90) <= 2.0);
        auto test_cosine_180 = cosine(180.0f);
        REQUIRE(abs(-1.0 - test_cosine_180) <= 2.0);
    }
    TEST_CASE("sine_integration") {
        auto test_sine_0 = sine(0.0f);
        REQUIRE(abs(0.0 - test_sine_0) <= 2.0);
        auto test_sine_90 = sine(90.0f);
        REQUIRE(abs(1.0 - test_sine_90) <= 2.0);
        auto test_sine_180 = sine(180.0f);
        REQUIRE(abs(0.0 - test_sine_180) <= 2.0);
        auto test_sine_270 = sine(270.0f);
        REQUIRE(-1.0 == test_sine_270);
    }
    TEST_CASE("tangent_integration") {
        auto test_tangent_result = tangent(45.0f);
        REQUIRE(test_tangent_result >= 1.0 && test_tangent_result <= 2.0);
    }
    TEST_CASE("closest_point_on_line_integration") {
        auto test_line = line_from(point_at(0.0, 0.0), point_at(10.0, 10.0));
        auto test_closest_point = closest_point_on_line(point_at(5.0, 5.0), test_line);
        REQUIRE(0.0 == point_point_distance(point_at(5.0, 5.0), test_closest_point));
    }
    TEST_CASE("closest_point_on_lines_integration") {
        auto test_from_pt = point_at(0.0, 0.0);
        auto test_line1 = line_from(point_at(-10.0, 0.0), point_at(10.0, 0.0));
        auto test_line2 = line_from(point_at(0.0, -10.0), point_at(0.0, 10.0));
        auto test_index = 0;
    auto test_lines = vector<Line> { test_line1, test_line2 };
    auto test_closest_point = closest_point_on_lines(test_from_pt, test_lines, &test_index);
    REQUIRE(0.0 == point_point_distance(test_from_pt, test_closest_point));
}
TEST_CASE("line_from_point_to_point_integration") {
    auto test_start_point = point_at(0.0, 0.0);
    auto test_end_point = point_at(100.0, 100.0);
    auto test_line = line_from(test_start_point, test_end_point);
    REQUIRE(abs(141.421356 - line_length(test_line)) <= 2.0);
}
TEST_CASE("line_from_start_with_offset_integration") {
    auto test_start_point = point_at(0.0, 0.0);
    auto test_offset_vector = vector_from_angle(45.0, 10.0);
    auto test_line = line_from(test_start_point, test_offset_vector);
    REQUIRE(point_on_line(point_at(0.0, 0.0), test_line));
    REQUIRE(point_on_line(point_offset_by(test_start_point, test_offset_vector), test_line));
}
TEST_CASE("line_from_vector_integration") {
    auto test_vector = vector_from_angle(100.0, 50.0);
    auto test_line = line_from(test_vector);
    REQUIRE(point_at_origin() == test_line.start_point);
    REQUIRE(-8.682409286499023 == test_line.end_point.x);
    REQUIRE(49.240386962890625 == test_line.end_point.y);
}
TEST_CASE("line_from_integration") {
    auto test_line = line_from(0.0, 0.0, 10.0, 10.0);
    REQUIRE(abs(14.1421356 - line_length(test_line)) <= 2.0);
}
TEST_CASE("line_intersection_point_integration") {
    auto test_line1 = line_from(0.0, 0.0, 10.0, 10.0);
    auto test_line2 = line_from(10.0, 0.0, 0.0, 10.0);
    auto test_point = point_at(0.0, 0.0);
    auto test_intersection_result = line_intersection_point(test_line1, test_line2, &test_point);
    REQUIRE(test_intersection_result);
}
TEST_CASE("line_intersects_circle_integration") {
    auto test_line = line_from(0.0, 0.0, 10.0, 10.0);
    auto test_circle = circle_at(5.0, 5.0, 3.0);
    auto test_result = line_intersects_circle(test_line, test_circle);
    REQUIRE(test_result);
}
TEST_CASE("line_intersects_lines_integration") {
    auto test_line = line_from(0.0, 0.0, 10.0, 10.0);
    auto test_line1 = line_from(0.0, 10.0, 10.0, 0.0);
    auto test_line2 = line_from(20.0, 20.0, 30.0, 30.0);
auto test_lines = vector<Line> { test_line1, test_line2 };
auto test_result = line_intersects_lines(test_line, test_lines);
REQUIRE(test_result);
}
TEST_CASE("line_intersects_rect_integration") {
    auto test_rect = rectangle_from(0.0, 0.0, 100.0, 100.0);
    auto test_line = line_from(point_at(-50.0, 50.0), point_at(150.0, 50.0));
    REQUIRE(line_intersects_rect(test_line, test_rect));
    auto test_line_outside = line_from(point_at(-50.0, 150.0), point_at(150.0, 150.0));
    REQUIRE_FALSE(line_intersects_rect(test_line_outside, test_rect));
}
TEST_CASE("line_length_integration") {
    auto test_line = line_from(point_at(0.0, 0.0), point_at(3.0, 4.0));
    auto test_length = line_length(test_line);
    REQUIRE(5.0 == test_length);
}
TEST_CASE("line_length_squared_integration") {
    auto test_line = line_from(point_at(0.0, 0.0), point_at(3.0, 4.0));
    auto test_result = line_length_squared(test_line);
    REQUIRE(25.0 == test_result);
}
TEST_CASE("line_mid_point_integration") {
    auto test_line = line_from(point_at(0.0, 0.0), point_at(100.0, 100.0));
    auto test_mid_point = line_mid_point(test_line);
    REQUIRE(0.0 == point_point_distance(test_mid_point, point_at(50.0, 50.0)));
}
TEST_CASE("line_normal_integration") {
    auto test_line = line_from(0.0, 0.0, 1.0, 1.0);
    auto test_normal = line_normal(test_line);
    REQUIRE(-0.7071067811865475 == test_normal.x);
    REQUIRE(0.7071067811865475 == test_normal.y);
}
TEST_CASE("line_to_string_integration") {
    auto test_line = line_from(point_at(0.0, 0.0), point_at(100.0, 100.0));
    auto test_line_string = line_to_string(test_line);
    REQUIRE(string("Line from Pt @0:0 to Pt @100:100") != test_line_string);
}
TEST_CASE("lines_from_rectangle_integration") {
    auto test_rectangle = rectangle_from(0.0, 0.0, 100.0, 100.0);
    auto test_lines = lines_from(test_rectangle);
    REQUIRE(4 == test_lines.size());
}
TEST_CASE("lines_from_triangle_integration") {
    auto test_triangle = triangle_from(point_at(0.0, 0.0), point_at(100.0, 0.0), point_at(50.0, 86.6));
    auto test_lines = lines_from(test_triangle);
    REQUIRE(3 == test_lines.size());
}
TEST_CASE("lines_intersect_integration") {
    auto test_line1 = line_from(point_at(0.0, 0.0), point_at(10.0, 10.0));
    auto test_line2 = line_from(point_at(5.0, 0.0), point_at(5.0, 10.0));
    auto test_result = lines_intersect(test_line1, test_line2);
    REQUIRE(test_result);
}
TEST_CASE("point_at_integration") {
    auto test_point = point_at(10.0, 20.0);
    REQUIRE(10.0 == test_point.x);
    REQUIRE(20.0 == test_point.y);
}
TEST_CASE("point_at_origin_integration") {
    auto test_point = point_at_origin();
    REQUIRE(0.0 == test_point.x);
    REQUIRE(0.0 == test_point.y);
}
TEST_CASE("point_in_circle_integration") {
    auto test_circle = circle_at(100.0, 100.0, 50.0);
    REQUIRE(point_in_circle(point_at(100.0, 100.0), test_circle));
    REQUIRE(point_in_circle(point_at(150.0, 100.0), test_circle));
    REQUIRE_FALSE(point_in_circle(point_at(200.0, 100.0), test_circle));
}
TEST_CASE("point_in_circle_with_values_integration") {
    auto test_result1 = point_in_circle(100.0, 100.0, 100.0, 100.0, 50.0);
    REQUIRE(test_result1);
    auto test_result2 = point_in_circle(200.0, 100.0, 100.0, 100.0, 50.0);
    REQUIRE_FALSE(test_result2);
}
TEST_CASE("point_in_quad_integration") {
    auto test_quad = quad_from(point_at(0.0, 0.0), point_at(100.0, 0.0), point_at(100.0, 100.0), point_at(0.0, 100.0));
    REQUIRE(point_in_quad(point_at(50.0, 51.0), test_quad));
    REQUIRE_FALSE(point_in_quad(point_at(150.0, 50.0), test_quad));
}
TEST_CASE("point_in_rectangle_integration") {
    auto test_rectangle = rectangle_from(0.0, 0.0, 100.0, 100.0);
    auto test_point_inside = point_at(50.0, 50.0);
    auto test_point_outside = point_at(150.0, 150.0);
    REQUIRE(point_in_rectangle(test_point_inside, test_rectangle));
    REQUIRE_FALSE(point_in_rectangle(test_point_outside, test_rectangle));
}
TEST_CASE("point_in_rectangle_with_values_integration") {
    auto test_result_inside = point_in_rectangle(10.0, 10.0, 0.0, 0.0, 20.0, 20.0);
    REQUIRE(test_result_inside);
    auto test_result_outside = point_in_rectangle(25.0, 25.0, 0.0, 0.0, 20.0, 20.0);
    REQUIRE_FALSE(test_result_outside);
}
TEST_CASE("point_in_triangle_integration") {
    auto test_triangle = triangle_from(point_at(0.0, 0.0), point_at(100.0, 0.0), point_at(50.0, 100.0));
    REQUIRE(point_in_triangle(point_at(50.0, 50.0), test_triangle));
    REQUIRE_FALSE(point_in_triangle(point_at(150.0, 50.0), test_triangle));
}
TEST_CASE("point_line_distance_integration") {
    auto test_point = point_at(0.0, 0.0);
    auto test_line = line_from(0.0, 0.0, 10.0, 10.0);
    auto test_distance = point_line_distance(test_point, test_line);
    REQUIRE(0.0 == test_distance);
}
TEST_CASE("point_offset_by_integration") {
    auto test_start_point = point_at(10.0, 20.0);
    auto test_offset = vector_from_angle(5.0, 10.0);
    auto test_result_point = point_offset_by(test_start_point, test_offset);
    REQUIRE(19.961947202682495 == test_result_point.x);
    REQUIRE(20.87155744433403 == test_result_point.y);
}
TEST_CASE("point_offset_from_origin_integration") {
    auto test_vector = vector_from_angle(10.0, 20.0);
    auto test_point = point_offset_from_origin(test_vector);
    REQUIRE(19.696154594421387 == test_point.x);
    REQUIRE(3.472963571548462 == test_point.y);
}
TEST_CASE("point_on_line_integration") {
    auto test_line = line_from(0.0, 0.0, 10.0, 10.0);
    auto test_point_on_line = point_at(5.0, 5.0);
    auto test_point_off_line = point_at(15.0, 15.0);
    REQUIRE(point_on_line(test_point_on_line, test_line));
    REQUIRE_FALSE(point_on_line(test_point_off_line, test_line));
}
TEST_CASE("point_on_line_with_proximity_integration") {
    auto test_line = line_from(point_at(0.0, 0.0), point_at(10.0, 10.0));
    auto test_point_on_line = point_at(5.0, 5.0);
    auto test_point_near_line = point_at(5.1, 5.1);
    auto test_point_far_from_line = point_at(15.0, 15.0);
    REQUIRE(point_on_line(test_point_on_line, test_line, 0.1f));
    REQUIRE(point_on_line(test_point_near_line, test_line, 0.2f));
    REQUIRE_FALSE(point_on_line(test_point_far_from_line, test_line, 0.1f));
}
TEST_CASE("point_point_angle_integration") {
    auto test_point1 = point_at(0.0, 0.0);
    auto test_point2 = point_at(1.0, 0.0);
    auto test_angle = point_point_angle(test_point1, test_point2);
    REQUIRE(0.0 == test_angle);
}
TEST_CASE("point_point_distance_integration") {
    auto test_point1 = point_at(0.0, 0.0);
    auto test_point2 = point_at(3.0, 4.0);
    auto test_distance = point_point_distance(test_point1, test_point2);
    REQUIRE(5.0 == test_distance);
}
TEST_CASE("point_to_string_integration") {
    auto test_point = point_at(10.0, 20.0);
    auto test_string = point_to_string(test_point);
    REQUIRE(string("Pt @10.000000:20.000000") == test_string);
}
TEST_CASE("random_bitmap_point_integration") {
    auto test_bitmap = create_bitmap(string("test_bitmap"), 100, 100);
    BitmapCleanup cleanup_bitmap;
    auto test_point = random_bitmap_point(test_bitmap);
    REQUIRE(test_point.x >= 0.0 && test_point.x <= bitmap_width(test_bitmap));
    REQUIRE(test_point.y >= 0.0 && test_point.y <= bitmap_height(test_bitmap));
}
TEST_CASE("random_screen_point_integration") {
    auto test_window = open_window(string("Test Window"), 800, 600);
    WindowCleanup cleanup_window;
    auto test_point = random_screen_point();
    refresh_screen();
    REQUIRE(test_point.x >= 0.0 && test_point.x <= window_width(test_window));
    REQUIRE(test_point.y >= 0.0 && test_point.y <= window_height(test_window));
}
TEST_CASE("random_window_point_integration") {
    auto test_window = open_window(string("Test Window"), 800, 600);
    WindowCleanup cleanup_window;
    auto test_point = random_window_point(test_window);
    REQUIRE(test_point.x >= 0.0 && test_point.x <= window_width(test_window));
    REQUIRE(test_point.y >= 0.0 && test_point.y <= window_height(test_window));
}
TEST_CASE("same_point_integration") {
    auto test_point1 = point_at(10.0, 20.0);
    auto test_point2 = point_at(10.0, 20.0);
    auto test_point3 = point_at(10.0, 21.0);
    REQUIRE(same_point(test_point1, test_point2));
    REQUIRE_FALSE(same_point(test_point1, test_point3));
}
TEST_CASE("quad_from_points_integration") {
    auto test_p1 = point_at(0.0, 0.0);
    auto test_p2 = point_at(100.0, 0.0);
    auto test_p3 = point_at(0.0, 100.0);
    auto test_p4 = point_at(100.0, 100.0);
    auto test_quad = quad_from(test_p1, test_p2, test_p3, test_p4);
    REQUIRE(point_in_quad(point_at(50.0, 51.0), test_quad));
}
TEST_CASE("quad_from_rectangle_integration") {
    auto test_rectangle = rectangle_from(0.0, 0.0, 100.0, 100.0);
    auto test_quad = quad_from(test_rectangle);
    REQUIRE(point_in_quad(point_at(50.0, 51.0), test_quad));
    REQUIRE_FALSE(point_in_quad(point_at(150.0, 150.0), test_quad));
}
TEST_CASE("quad_from_rectangle_with_transformation_integration") {
    auto test_rectangle = rectangle_from(0.0, 0.0, 100.0, 100.0);
    auto test_transform = rotation_matrix(45.0);
    auto test_quad = quad_from(test_rectangle, test_transform);
    REQUIRE(point_in_quad(point_at(50.0, 51.0), test_quad));
    REQUIRE_FALSE(point_in_quad(point_at(150.0, 150.0), test_quad));
}
TEST_CASE("quad_from_integration") {
    auto test_quad = quad_from(0.0, 0.0, 100.0, 0.0, 0.0, 100.0, 100.0, 100.0);
    REQUIRE(point_in_quad(point_at(50.0, 51.0), test_quad));
    REQUIRE_FALSE(point_in_quad(point_at(150.0, 150.0), test_quad));
}
TEST_CASE("quads_intersect_integration") {
    auto test_quad1 = quad_from(point_at(0.0, 0.0), point_at(100.0, 0.0), point_at(0.0, 100.0), point_at(100.0, 100.0));
    auto test_quad2 = quad_from(point_at(50.0, 50.0), point_at(150.0, 50.0), point_at(50.0, 150.0), point_at(150.0, 150.0));
    auto test_result = quads_intersect(test_quad1, test_quad2);
    REQUIRE(test_result);
}
TEST_CASE("set_quad_point_integration") {
    auto test_quad = quad_from(point_at(0.0, 0.0), point_at(100.0, 0.0), point_at(0.0, 100.0), point_at(100.0, 100.0));
    REQUIRE_FALSE(point_in_quad(point_at(50.0, 150.0), test_quad));
    set_quad_point(&test_quad, 2, point_at(50.0, 150.0));
    REQUIRE(point_in_quad(point_at(50.0, 150.0), test_quad));
}
TEST_CASE("triangles_from_integration") {
    auto test_quad = quad_from(point_at(0.0, 0.0), point_at(100.0, 0.0), point_at(0.0, 100.0), point_at(100.0, 100.0));
    auto test_triangles = triangles_from(test_quad);
    REQUIRE(2 == test_triangles.size());
}
TEST_CASE("inset_rectangle_integration") {
    auto test_rectangle = rectangle_from(0.0, 0.0, 100.0, 100.0);
    auto test_inset_rectangle = inset_rectangle(test_rectangle, 10.0f);
    REQUIRE(10.0 == rectangle_left(test_inset_rectangle));
    REQUIRE(10.0 == rectangle_top(test_inset_rectangle));
    REQUIRE(90.0 == rectangle_right(test_inset_rectangle));
    REQUIRE(90.0 == rectangle_bottom(test_inset_rectangle));
}
TEST_CASE("intersection_integration") {
    auto test_rect1 = rectangle_from(0.0, 0.0, 10.0, 10.0);
    auto test_rect2 = rectangle_from(5.0, 5.0, 10.0, 10.0);
    auto test_intersection = intersection(test_rect1, test_rect2);
    REQUIRE(5.0 == rectangle_left(test_intersection));
    REQUIRE(5.0 == rectangle_top(test_intersection));
    REQUIRE(10.0 == rectangle_right(test_intersection));
    REQUIRE(10.0 == rectangle_bottom(test_intersection));
}
TEST_CASE("rectangle_around_circle_integration") {
    auto test_circle = circle_at(100.0, 100.0, 50.0);
    auto test_rectangle = rectangle_around(test_circle);
    REQUIRE(50.0 == rectangle_left(test_rectangle));
    REQUIRE(50.0 == rectangle_top(test_rectangle));
    REQUIRE(150.0 == rectangle_right(test_rectangle));
    REQUIRE(150.0 == rectangle_bottom(test_rectangle));
}
TEST_CASE("rectangle_around_line_integration") {
    auto test_line = line_from(point_at(10.0, 10.0), point_at(50.0, 50.0));
    auto test_rectangle = rectangle_around(test_line);
    REQUIRE(point_in_rectangle(point_at(10.0, 10.0), test_rectangle));
    REQUIRE(point_in_rectangle(point_at(50.0, 50.0), test_rectangle));
}
TEST_CASE("rectangle_around_quad_integration") {
    auto test_quad = quad_from(point_at(0.0, 0.0), point_at(100.0, 0.0), point_at(0.0, 100.0), point_at(100.0, 100.0));
    auto test_rectangle = rectangle_around(test_quad);
    REQUIRE(0.0 == rectangle_left(test_rectangle));
    REQUIRE(0.0 == rectangle_top(test_rectangle));
    REQUIRE(100.0 == rectangle_right(test_rectangle));
    REQUIRE(100.0 == rectangle_bottom(test_rectangle));
}
TEST_CASE("rectangle_around_triangle_integration") {
    auto test_triangle = triangle_from(point_at(0.0, 0.0), point_at(100.0, 0.0), point_at(50.0, 100.0));
    auto test_rectangle = rectangle_around(test_triangle);
    REQUIRE(0.0 == rectangle_left(test_rectangle));
    REQUIRE(0.0 == rectangle_top(test_rectangle));
    REQUIRE(100.0 == rectangle_right(test_rectangle));
    REQUIRE(100.0 == rectangle_bottom(test_rectangle));
}
TEST_CASE("rectangle_bottom_integration") {
    auto test_rectangle = rectangle_from(10.0, 20.0, 50.0, 60.0);
    REQUIRE(80.0 == rectangle_bottom(test_rectangle));
}
TEST_CASE("rectangle_center_integration") {
    auto test_rectangle = rectangle_from(point_at(0.0, 0.0), 100.0, 100.0);
    auto test_center_point = rectangle_center(test_rectangle);
    REQUIRE(0.0 == point_point_distance(point_at(50.0, 50.0), test_center_point));
}
TEST_CASE("rectangle_from_point_and_size_integration") {
    auto test_point = point_at(10.0, 20.0);
    auto test_rectangle = rectangle_from(test_point, 50.0, 30.0);
    REQUIRE(10.0 == rectangle_left(test_rectangle));
    REQUIRE(20.0 == rectangle_top(test_rectangle));
    REQUIRE(60.0 == rectangle_right(test_rectangle));
    REQUIRE(50.0 == rectangle_bottom(test_rectangle));
}
TEST_CASE("rectangle_from_points_integration") {
    auto test_point1 = point_at(0.0, 0.0);
    auto test_point2 = point_at(100.0, 100.0);
    auto test_rectangle = rectangle_from(test_point1, test_point2);
    REQUIRE(0.0 == rectangle_left(test_rectangle));
    REQUIRE(0.0 == rectangle_top(test_rectangle));
    REQUIRE(100.0 == rectangle_right(test_rectangle));
    REQUIRE(100.0 == rectangle_bottom(test_rectangle));
}
TEST_CASE("rectangle_from_integration") {
    auto test_rectangle = rectangle_from(10.0, 20.0, 50.0, 30.0);
    REQUIRE(10.0 == rectangle_left(test_rectangle));
    REQUIRE(20.0 == rectangle_top(test_rectangle));
    REQUIRE(60.0 == rectangle_right(test_rectangle));
    REQUIRE(50.0 == rectangle_bottom(test_rectangle));
}
TEST_CASE("rectangle_left_integration") {
    auto test_rectangle = rectangle_from(10.0, 20.0, 50.0, 60.0);
    auto test_left = rectangle_left(test_rectangle);
    REQUIRE(10.0 == test_left);
}
TEST_CASE("rectangle_offset_by_integration") {
    auto test_rectangle = rectangle_from(10.0, 10.0, 50.0, 50.0);
    auto test_offset_rectangle = rectangle_offset_by(test_rectangle, vector_to(20.0, 30.0));
    REQUIRE(30.0 == rectangle_left(test_offset_rectangle));
    REQUIRE(40.0 == rectangle_top(test_offset_rectangle));
}
TEST_CASE("rectangle_right_integration") {
    auto test_rectangle = rectangle_from(10.0, 20.0, 50.0, 60.0);
    REQUIRE(60.0 == rectangle_right(test_rectangle));
}
TEST_CASE("rectangle_to_string_integration") {
    auto test_rectangle = rectangle_from(10.0, 20.0, 30.0, 40.0);
    auto test_string = rectangle_to_string(test_rectangle);
    REQUIRE(string("Rect @10,20 30x40") == test_string);
}
TEST_CASE("rectangle_top_integration") {
    auto test_rectangle = rectangle_from(10.0, 20.0, 50.0, 60.0);
    auto test_top = rectangle_top(test_rectangle);
    REQUIRE(20.0 == test_top);
}
TEST_CASE("rectangles_intersect_integration") {
    auto test_rect1 = rectangle_from(0.0, 0.0, 10.0, 10.0);
    auto test_rect2 = rectangle_from(5.0, 5.0, 10.0, 10.0);
    auto test_result = rectangles_intersect(test_rect1, test_rect2);
    REQUIRE(test_result);
}
TEST_CASE("triangle_barycenter_integration") {
    auto test_triangle = triangle_from(point_at(0.0, 0.0), point_at(100.0, 0.0), point_at(50.0, 50.0));
    auto test_barycenter = triangle_barycenter(test_triangle);
    REQUIRE(50.0 == test_barycenter.x);
    REQUIRE(abs(16.67 - test_barycenter.y) <= 2.0);
}
TEST_CASE("triangle_from_integration") {
    auto test_point1 = point_at(0.0, 0.0);
    auto test_point2 = point_at(100.0, 0.0);
    auto test_point3 = point_at(50.0, 100.0);
    auto test_triangle = triangle_from(test_point1, test_point2, test_point3);
    REQUIRE(point_in_triangle(point_at(50.0, 50.0), test_triangle));
}
TEST_CASE("triangle_from__from_coordinates_integration") {
    auto test_triangle = triangle_from(0.0, 0.0, 100.0, 0.0, 50.0, 100.0);
    REQUIRE(point_in_triangle(point_at(50.0, 50.0), test_triangle));
    REQUIRE_FALSE(point_in_triangle(point_at(150.0, 150.0), test_triangle));
}
TEST_CASE("triangle_rectangle_intersect_integration") {
    auto test_triangle = triangle_from(point_at(0.0, 0.0), point_at(100.0, 0.0), point_at(50.0, 100.0));
    auto test_rectangle = rectangle_from(point_at(40.0, 40.0), 60.0, 60.0);
    auto test_result = triangle_rectangle_intersect(test_triangle, test_rectangle);
    REQUIRE(test_result);
}
TEST_CASE("triangle_to_string_integration") {
    auto test_triangle = triangle_from(point_at(0.0, 0.0), point_at(100.0, 0.0), point_at(50.0, 100.0));
    auto test_triangle_string = triangle_to_string(test_triangle);
    REQUIRE(string("Triangle @Pt @0:0 - Pt @100:0 - Pt @50:100") != test_triangle_string);
}
TEST_CASE("triangles_intersect_integration") {
    auto test_triangle1 = triangle_from(point_at(0.0, 0.0), point_at(2.0, 0.0), point_at(1.0, 2.0));
    auto test_triangle2 = triangle_from(point_at(1.0, 0.0), point_at(3.0, 0.0), point_at(2.0, 2.0));
    auto test_result = triangles_intersect(test_triangle1, test_triangle2);
    REQUIRE(test_result);
}
};
