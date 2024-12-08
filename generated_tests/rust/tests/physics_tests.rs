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
fn test_bitmap_circle_collision_at_point_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_circle = circle_at(150.0, 150.0, 50.0);
    let test_point = point_at(100.0, 100.0);
    assert!(bitmap_circle_collision(test_bitmap, test_point, test_circle));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_circle_collision_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_circle = circle_at(150.0, 150.0, 50.0);
    assert!(bitmap_circle_collision(test_bitmap, 100.0, 100.0, test_circle));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_circle_collision_for_cell_with_translation_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_circle = circle_at(150.0, 150.0, 50.0);
    let test_translation = translation_matrix(100.0, 100.0);
    assert!(bitmap_circle_collision(test_bitmap, 0, test_translation, test_circle));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_circle_collision_for_cell_at_point_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_circle = circle_at(150.0, 150.0, 50.0);
    let test_point = point_at(100.0, 100.0);
    assert!(bitmap_circle_collision(test_bitmap, 0, test_point, test_circle));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_circle_collision_for_cell_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_circle = circle_at(150.0, 150.0, 50.0);
    assert!(bitmap_circle_collision(test_bitmap, 0, 100.0, 100.0, test_circle));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_collision_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap1 = create_bitmap("test_bitmap1", 100, 100);
    let test_bitmap2 = create_bitmap("test_bitmap2", 100, 100);
    clear_bitmap(test_bitmap1, color_black());
    clear_bitmap(test_bitmap2, color_black());
    assert!(bitmap_collision(test_bitmap1, 0, 0.0, 0.0, test_bitmap2, 0, 50.0, 50.0));
    assert!(!bitmap_collision(test_bitmap1, 0, 0.0, 0.0, test_bitmap2, 0, 200.0, 200.0));
    free_all_bitmaps();
    close_window(test_window);
}
#[test]
fn test_bitmap_collision_at_points_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap1 = create_bitmap("test_bitmap1", 100, 100);
    let test_bitmap2 = create_bitmap("test_bitmap2", 100, 100);
    clear_bitmap(test_bitmap1, color_black());
    clear_bitmap(test_bitmap2, color_black());
    let test_point1 = point_at(0.0, 0.0);
    let test_point2 = point_at(50.0, 50.0);
    assert!(bitmap_collision(test_bitmap1, test_point1, test_bitmap2, test_point2));
    free_all_bitmaps();
    close_window(test_window);
}
#[test]
fn test_bitmap_collision_for_cells_with_translations_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap1 = create_bitmap("test_bitmap1", 100, 100);
    let test_bitmap2 = create_bitmap("test_bitmap2", 100, 100);
    clear_bitmap(test_bitmap1, color_black());
    clear_bitmap(test_bitmap2, color_black());
    let matrix1 = translation_matrix(0.0, 0.0);
    let matrix2 = translation_matrix(50.0, 50.0);
    assert!(bitmap_collision(test_bitmap1, 0, matrix1, test_bitmap2, 0, matrix2));
    free_all_bitmaps();
    close_window(test_window);
}
#[test]
fn test_bitmap_collision_for_cells_at_points_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap1 = create_bitmap("test_bitmap1", 50, 50);
    let test_bitmap2 = create_bitmap("test_bitmap2", 50, 50);
    clear_bitmap(test_bitmap1, color_black());
    clear_bitmap(test_bitmap2, color_black());
    let test_point1 = point_at(100.0, 100.0);
    let test_point2 = point_at(125.0, 125.0);
    assert!(bitmap_collision(test_bitmap1, 0, test_point1, test_bitmap2, 0, test_point2));
    free_all_bitmaps();
    close_window(test_window);
}
#[test]
fn test_bitmap_collision_for_cells_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap1 = create_bitmap("test_bitmap1", 100, 100);
    let test_bitmap2 = create_bitmap("test_bitmap2", 100, 100);
    clear_bitmap(test_bitmap1, color_black());
    clear_bitmap(test_bitmap2, color_black());
    assert!(!bitmap_collision(test_bitmap1, 0, 100.0, 100.0, test_bitmap2, 0, 150.0, 100.0));
    assert!(bitmap_collision(test_bitmap1, 0, 100.0, 100.0, test_bitmap2, 0, 100.0, 100.0));
    free_all_bitmaps();
    close_window(test_window);
}
#[test]
fn test_bitmap_point_collision_with_translation_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_translation = translation_matrix(100.0, 100.0);
    let test_point = point_at(150.0, 150.0);
    assert!(bitmap_point_collision(test_bitmap, test_translation, test_point));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_point_collision_at_point_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_bmp_pt = point_at(50.0, 50.0);
    let test_pt = point_at(50.0, 50.0);
    assert!(bitmap_point_collision(test_bitmap, test_bmp_pt, test_pt));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_point_collision_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    assert!(bitmap_point_collision(test_bitmap, 0.0, 0.0, 50.0, 50.0));
    assert!(!bitmap_point_collision(test_bitmap, 0.0, 0.0, 150.0, 150.0));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_point_collision_for_cell_with_translation_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_translation = translation_matrix(100.0, 100.0);
    let test_point = point_at(150.0, 150.0);
    assert!(bitmap_point_collision(test_bitmap, 0, test_translation, test_point));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_point_collision_for_cell_at_point_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_point = point_at(100.0, 100.0);
    assert!(bitmap_point_collision(test_bitmap, 0, test_point, test_point));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_point_collision_for_cell_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    assert!(bitmap_point_collision(test_bitmap, 0, 100.0, 100.0, 100.0, 100.0));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_rectangle_collision_at_point_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_rectangle = rectangle_from(50.0, 50.0, 100.0, 100.0);
    let test_point = point_at(100.0, 100.0);
    assert!(bitmap_rectangle_collision(test_bitmap, test_point, test_rectangle));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_rectangle_collision_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_rectangle = rectangle_from(50.0, 50.0, 100.0, 100.0);
    assert!(bitmap_rectangle_collision(test_bitmap, 0.0, 0.0, test_rectangle));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_rectangle_collision_for_cell_with_translation_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_rectangle = rectangle_from(150.0, 150.0, 50.0, 50.0);
    let test_translation = translation_matrix(100.0, 100.0);
    assert!(bitmap_rectangle_collision(test_bitmap, 0, test_translation, test_rectangle));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_rectangle_collision_for_cell_at_point_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_rectangle = rectangle_from(100.0, 100.0, 50.0, 50.0);
    let test_point = point_at(100.0, 100.0);
    assert!(bitmap_rectangle_collision(test_bitmap, 0, test_point, test_rectangle));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_bitmap_rectangle_collision_for_cell_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_rectangle = rectangle_from(50.0, 50.0, 100.0, 100.0);
    assert!(bitmap_rectangle_collision(test_bitmap, 0, 50.0, 50.0, test_rectangle));
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_sprite_bitmap_collision_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_sprite = create_sprite(test_bitmap);
    sprite_set_collision_kind(test_sprite, pixel_collisions);
    sprite_set_position(test_sprite, point_at(100.0, 100.0));
    assert!(sprite_bitmap_collision(test_sprite, test_bitmap, 100.0, 100.0));
    assert!(!sprite_bitmap_collision(test_sprite, test_bitmap, 200.0, 200.0));
    free_all_sprites();
    free_all_bitmaps();
    close_window(test_window);
}
#[test]
fn test_sprite_bitmap_collision_with_cell_at_point_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_sprite = create_sprite(test_bitmap);
    sprite_set_collision_kind(test_sprite, pixel_collisions);
    sprite_set_position(test_sprite, point_at(50.0, 50.0));
    assert!(sprite_bitmap_collision(test_sprite, test_bitmap, 0, point_at(50.0, 50.0)));
    free_all_sprites();
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_sprite_bitmap_collision_with_cell_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_sprite = create_sprite(test_bitmap);
    sprite_set_collision_kind(test_sprite, pixel_collisions);
    sprite_set_position(test_sprite, point_at(50.0, 50.0));
    assert!(sprite_bitmap_collision(test_sprite, test_bitmap, 0, 50.0, 50.0));
    free_all_sprites();
    free_all_bitmaps();
    close_window(test_window);
}
#[test]
fn test_sprite_collision_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap1 = create_bitmap("test_bitmap_1", 50, 50);
    let test_bitmap2 = create_bitmap("test_bitmap_2", 50, 50);
    clear_bitmap(test_bitmap1, color_black());
    clear_bitmap(test_bitmap2, color_black());
    let test_sprite1 = create_sprite(test_bitmap1);
    let test_sprite2 = create_sprite(test_bitmap2);
    sprite_set_collision_kind(test_sprite1, pixel_collisions);
    sprite_set_collision_kind(test_sprite2, pixel_collisions);
    sprite_set_position(test_sprite1, point_at(100.0, 100.0));
    sprite_set_position(test_sprite2, point_at(100.0, 100.0));
    assert!(sprite_collision(test_sprite1, test_sprite2));
    sprite_set_position(test_sprite2, point_at(200.0, 200.0));
    assert!(!sprite_collision(test_sprite1, test_sprite2));
    free_all_sprites();
    free_all_bitmaps();
    close_window(test_window);
}
#[test]
fn test_sprite_point_collision_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_sprite = create_sprite(test_bitmap);
    sprite_set_collision_kind(test_sprite, pixel_collisions);
    assert!(sprite_point_collision(test_sprite, point_at(50.0, 50.0)));
    assert!(!sprite_point_collision(test_sprite, point_at(200.0, 200.0)));
    free_all_sprites();
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_sprite_rectangle_collision_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_bitmap = create_bitmap("test_bitmap", 100, 100);
    clear_bitmap(test_bitmap, color_black());
    let test_sprite = create_sprite(test_bitmap);
    sprite_set_collision_kind(test_sprite, pixel_collisions);
    let test_rectangle = rectangle_from(0.0, 0.0, 100.0, 100.0);
    assert!(sprite_rectangle_collision(test_sprite, test_rectangle));
    free_all_sprites();
    free_bitmap(test_bitmap);
    close_window(test_window);
}
#[test]
fn test_apply_matrix_to_quad_integration() {
    let test_window = open_window("Test Window", 800, 600);
    let test_matrix = identity_matrix();
    let test_quad = quad_from(point_at(100.0, 100.0), point_at(200.0, 100.0), point_at(200.0, 200.0), point_at(100.0, 200.0));
    apply_matrix_to_quad(test_matrix, test_quad);
    assert_eq!(100.0, {:value_type=>"array_access_field", :variable_name=>"test_quad", :array_name=>"points", :index=>0, :field=>"x"});
    assert_eq!(100.0, {:value_type=>"array_access_field", :variable_name=>"test_quad", :array_name=>"points", :index=>0, :field=>"y"});
    close_window(test_window);
}
#[test]
fn test_apply_matrix_to_triangle_integration() {
    let test_triangle = triangle_from(point_at(0.0, 0.0), point_at(1.0, 0.0), point_at(0.0, 1.0));
    let test_matrix = translation_matrix(1.0, 1.0);
    apply_matrix_to_triangle(test_matrix, test_triangle);
    assert_eq!(1.0, {:value_type=>"array_access_field", :variable_name=>"test_triangle", :array_name=>"points", :index=>0, :field=>"x"});
    assert_eq!(1.0, {:value_type=>"array_access_field", :variable_name=>"test_triangle", :array_name=>"points", :index=>0, :field=>"y"});
}
#[test]
fn test_identity_matrix_integration() {
    let test_matrix = identity_matrix();
    assert_eq!(1.0, {:value_type=>"matrix_access", :variable_name=>"test_matrix", :field=>"elements", :row=>0, :col=>0});
    assert_eq!(1.0, {:value_type=>"matrix_access", :variable_name=>"test_matrix", :field=>"elements", :row=>1, :col=>1});
    assert_eq!(0.0, {:value_type=>"matrix_access", :variable_name=>"test_matrix", :field=>"elements", :row=>0, :col=>1});
    assert_eq!(0.0, {:value_type=>"matrix_access", :variable_name=>"test_matrix", :field=>"elements", :row=>1, :col=>0});
}
#[test]
fn test_matrix_inverse_integration() {
    let test_matrix = scale_rotate_translate_matrix(point_at(2.0, 2.0), 45.0, point_at(10.0, 10.0));
    let inverse_matrix = matrix_inverse(test_matrix);
    let result_matrix = matrix_multiply_matrix(test_matrix, inverse_matrix);
    assert_eq!(1.0, {:value_type=>"matrix_access", :variable_name=>"result_matrix", :field=>"elements", :row=>0, :col=>0});
    assert_eq!(1.0, {:value_type=>"matrix_access", :variable_name=>"result_matrix", :field=>"elements", :row=>1, :col=>1});
}
#[test]
fn test_matrix_multiply_point_integration() {
    let test_matrix = translation_matrix(10.0, 10.0);
    let test_point = point_at(10.0, 20.0);
    let result_point = matrix_multiply_point(test_matrix, test_point);
    assert_eq!(20.0, result_point.x);
    assert_eq!(30.0, result_point.y);
}
#[test]
fn test_matrix_multiply_matrix_integration() {
    let test_matrix1 = scale_matrix(2.0);
    let test_matrix2 = translation_matrix(10.0, 10.0);
    let result_matrix = matrix_multiply_matrix(test_matrix1, test_matrix2);
    assert_eq!(2.0, {:value_type=>"matrix_access", :variable_name=>"result_matrix", :field=>"elements", :row=>0, :col=>0});
    assert_eq!(20.0, {:value_type=>"matrix_access", :variable_name=>"result_matrix", :field=>"elements", :row=>0, :col=>2});
}
#[test]
fn test_matrix_multiply_vector_integration() {
    let test_vector = vector_to(2.0, 2.0);
    let test_matrix = scale_matrix(2.0);
    let result_vector = matrix_multiply_vector(test_matrix, test_vector);
    assert_eq!(4.0, result_vector.x);
    assert_eq!(4.0, result_vector.y);
}
#[test]
fn test_matrix_to_string_integration() {
    let test_matrix = identity_matrix();
    assert_eq!(expected, matrix_to_string(test_matrix));
}
#[test]
fn test_rotation_matrix_integration() {
    let test_matrix = rotation_matrix(90.0);
    let test_point = point_at(1.0, 0.0);
    let result_point = matrix_multiply_point(test_matrix, test_point);
    assert!((-0.1..=).contains(&result_point.x));
    assert!((0.9..=).contains(&result_point.y));
}
#[test]
fn test_scale_matrix_from_point_integration() {
    let test_scale = point_at(2.0, 3.0);
    let test_matrix = scale_matrix(test_scale);
    let test_point = point_at(1.0, 1.0);
    let result_point = matrix_multiply_point(test_matrix, test_point);
    assert_eq!(2.0, result_point.x);
    assert_eq!(3.0, result_point.y);
}
#[test]
fn test_scale_matrix_from_vector_integration() {
    let test_scale = vector_to(2.0, 3.0);
    let test_matrix = scale_matrix(test_scale);
    let test_point = point_at(1.0, 1.0);
    let result_point = matrix_multiply_point(test_matrix, test_point);
    assert_eq!(2.0, result_point.x);
    assert_eq!(3.0, result_point.y);
}
#[test]
fn test_scale_rotate_translate_matrix_integration() {
    let test_scale = point_at(2.0, 2.0);
    let test_translate = point_at(10.0, 10.0);
    let test_matrix = scale_rotate_translate_matrix(test_scale, 90.0, test_translate);
    let test_point = point_at(1.0, 0.0);
    let result_point = matrix_multiply_point(test_matrix, test_point);
    assert!((9.9..=).contains(&result_point.x));
    assert!((11.9..=).contains(&result_point.y));
}
#[test]
fn test_translation_matrix_to_point_integration() {
    let test_point = point_at(10.0, 20.0);
    let test_matrix = translation_matrix(test_point);
    let test_vector = point_at(5.0, 5.0);
    let result_point = matrix_multiply_vector(test_matrix, test_vector);
    assert_eq!(15.0, result_point.x);
    assert_eq!(25.0, result_point.y);
}
#[test]
fn test_translation_matrix_from_vector_integration() {
    let test_vector = vector_to(10.0, 20.0);
    let test_matrix = translation_matrix(test_vector);
    let test_point = point_at(0.0, 0.0);
    let result_point = matrix_multiply_point(test_matrix, test_point);
    assert_eq!(10.0, result_point.x);
    assert_eq!(20.0, result_point.y);
}
#[test]
fn test_translation_matrix_integration() {
    let test_matrix = translation_matrix(10.0, 20.0);
    let test_point = point_at(0.0, 0.0);
    let result_point = matrix_multiply_point(test_matrix, test_point);
    assert_eq!(10.0, result_point.x);
    assert_eq!(20.0, result_point.y);
}
#[test]
fn test_angle_between_integration() {
    let test_vector1 = vector_to(1.0, 0.0);
    let test_vector2 = vector_to(0.0, 1.0);
    assert_eq!(90.0, angle_between(test_vector1, test_vector2));
}
#[test]
fn test_dot_product_integration() {
    let test_vector1 = vector_to(3.0, 4.0);
    let test_vector2 = vector_to(1.0, 2.0);
    assert_eq!(11.0, dot_product(test_vector1, test_vector2));
}
#[test]
fn test_is_zero_vector_integration() {
    let test_zero_vector = vector_to(0.0, 0.0);
    let test_non_zero_vector = vector_to(1.0, 1.0);
    assert!(is_zero_vector(test_zero_vector));
    assert!(!is_zero_vector(test_non_zero_vector));
}
#[test]
fn test_ray_intersection_point_integration() {
    let test_from_pt = point_at(0.0, 0.0);
    let test_heading = vector_to(1.0, 1.0);
    let test_line = line_from(point_at(0.0, 2.0), point_at(2.0, 0.0));
    let intersection_point = point_at(0.0, 0.0);
    assert!(ray_intersection_point(test_from_pt, test_heading, test_line, intersection_point));
    assert_eq!(1.0, intersection_point.x);
    assert_eq!(1.0, intersection_point.y);
}
#[test]
fn test_unit_vector_integration() {
    let test_vector = vector_to(3.0, 4.0);
    let test_unit_vector = unit_vector(test_vector);
    assert_eq!(0.6, test_unit_vector.x);
    assert_eq!(0.8, test_unit_vector.y);
}
#[test]
fn test_vector_add_integration() {
    let test_vector1 = vector_to(1.0, 2.0);
    let test_vector2 = vector_to(3.0, 4.0);
    let result_vector = vector_add(test_vector1, test_vector2);
    assert_eq!(4.0, result_vector.x);
    assert_eq!(6.0, result_vector.y);
}
#[test]
fn test_vector_angle_integration() {
    let test_vector = vector_to(1.0, 1.0);
    assert_eq!(45.0, vector_angle(test_vector));
}
#[test]
fn test_vector_from_angle_integration() {
    let test_vector = vector_from_angle(45.0, 1.0);
    assert_eq!(0.7071, test_vector.x);
    assert_eq!(0.7071, test_vector.y);
}
#[test]
fn test_vector_from_line_integration() {
    let test_line = line_from(point_at(0.0, 0.0), point_at(3.0, 4.0));
    let test_vector = vector_from_line(test_line);
    assert_eq!(3.0, test_vector.x);
    assert_eq!(4.0, test_vector.y);
}
#[test]
fn test_vector_from_point_to_rect_integration() {
    let test_rect = rectangle_from(0.0, 0.0, 100.0, 100.0);
    let test_point = point_at(50.0, 50.0);
    let test_vector = vector_from_point_to_rect(test_point, test_rect);
    assert_eq!(0.0, test_vector.x);
    assert_eq!(0.0, test_vector.y);
}
#[test]
fn test_vector_in_rect_integration() {
    let test_rect = rectangle_from(0.0, 0.0, 100.0, 100.0);
    let test_vector_inside = vector_to(50.0, 50.0);
    let test_vector_outside = vector_to(150.0, 150.0);
    assert!(vector_in_rect(test_vector_inside, test_rect));
    assert!(!vector_in_rect(test_vector_outside, test_rect));
}
#[test]
fn test_vector_invert_integration() {
    let test_vector = vector_to(3.0, 4.0);
    let inverted_vector = vector_invert(test_vector);
    assert_eq!(-3.0, inverted_vector.x);
    assert_eq!(-4.0, inverted_vector.y);
}
#[test]
fn test_vector_limit_integration() {
    let test_vector = vector_to(6.0, 8.0);
    let limited_vector = vector_limit(test_vector, 5.0);
    assert_eq!(3.0, limited_vector.x);
    assert_eq!(4.0, limited_vector.y);
}
#[test]
fn test_vector_magnitude_integration() {
    let test_vector = vector_to(3.0, 4.0);
    assert_eq!(5.0, vector_magnitude(test_vector));
}
#[test]
fn test_vector_magnitude_squared_integration() {
    let test_vector = vector_to(3.0, 4.0);
    assert_eq!(25.0, vector_magnitude_squared(test_vector));
}
#[test]
fn test_vector_multiply_integration() {
    let test_vector = vector_to(3.0, 4.0);
    let result_vector = vector_multiply(test_vector, 2.0);
    assert_eq!(6.0, result_vector.x);
    assert_eq!(8.0, result_vector.y);
}
#[test]
fn test_vector_normal_integration() {
    let test_vector = vector_to(3.0, 4.0);
    let normal_vector = vector_normal(test_vector);
    assert_eq!(-4.0, normal_vector.x);
    assert_eq!(3.0, normal_vector.y);
}
#[test]
fn test_vector_out_of_circle_from_circle_integration() {
    let test_circle_src = circle_at(0.0, 0.0, 10.0);
    let test_circle_bounds = circle_at(15.0, 0.0, 10.0);
    let test_velocity = vector_to(1.0, 0.0);
    let result_vector = vector_out_of_circle_from_circle(test_circle_src, test_circle_bounds, test_velocity);
    assert_eq!(-5.0, result_vector.x);
    assert_eq!(0.0, result_vector.y);
}
#[test]
fn test_vector_out_of_circle_from_point_integration() {
    let test_point = point_at(100.0, 100.0);
    let test_circle = circle_at(150.0, 150.0, 50.0);
    let test_velocity = vector_to(1.0, 1.0);
    let result_vector = vector_out_of_circle_from_point(test_point, test_circle, test_velocity);
    assert_eq!(-50.0, result_vector.x);
    assert_eq!(-50.0, result_vector.y);
}
#[test]
fn test_vector_out_of_rect_from_circle_integration() {
    let test_circle = circle_at(75.0, 75.0, 25.0);
    let test_rect = rectangle_from(0.0, 0.0, 100.0, 100.0);
    let test_velocity = vector_to(1.0, 0.0);
    let result_vector = vector_out_of_rect_from_circle(test_circle, test_rect, test_velocity);
    assert_eq!(-25.0, result_vector.x);
    assert_eq!(0.0, result_vector.y);
}
#[test]
fn test_vector_out_of_rect_from_point_integration() {
    let test_point = point_at(75.0, 75.0);
    let test_rect = rectangle_from(0.0, 0.0, 100.0, 100.0);
    let test_velocity = vector_to(1.0, 0.0);
    let result_vector = vector_out_of_rect_from_point(test_point, test_rect, test_velocity);
    assert_eq!(-25.0, result_vector.x);
    assert_eq!(0.0, result_vector.y);
}
#[test]
fn test_vector_out_of_rect_from_rect_integration() {
    let test_src_rect = rectangle_from(75.0, 75.0, 50.0, 50.0);
    let test_bounds_rect = rectangle_from(0.0, 0.0, 100.0, 100.0);
    let test_velocity = vector_to(1.0, 0.0);
    let result_vector = vector_out_of_rect_from_rect(test_src_rect, test_bounds_rect, test_velocity);
    assert_eq!(-25.0, result_vector.x);
    assert_eq!(0.0, result_vector.y);
}
#[test]
fn test_vector_point_to_point_integration() {
    let test_start_point = point_at(0.0, 0.0);
    let test_end_point = point_at(3.0, 4.0);
    let result_vector = vector_point_to_point(test_start_point, test_end_point);
    assert_eq!(3.0, result_vector.x);
    assert_eq!(4.0, result_vector.y);
}
#[test]
fn test_vector_subtract_integration() {
    let test_vector1 = vector_to(3.0, 4.0);
    let test_vector2 = vector_to(1.0, 1.0);
    let result_vector = vector_subtract(test_vector1, test_vector2);
    assert_eq!(2.0, result_vector.x);
    assert_eq!(3.0, result_vector.y);
}
#[test]
fn test_vector_to_point_integration() {
    let test_point = point_at(3.0, 4.0);
    let result_vector = vector_to(test_point);
    assert_eq!(3.0, result_vector.x);
    assert_eq!(4.0, result_vector.y);
}
#[test]
fn test_vector_to_integration() {
    let test_vector = vector_to(3.0, 4.0);
    assert_eq!(3.0, test_vector.x);
    assert_eq!(4.0, test_vector.y);
}
#[test]
fn test_vector_to_string_integration() {
    let test_vector = vector_to(3.0, 4.0);
    assert_eq!("Vec -> 3:4", vector_to_string(test_vector));
}
#[test]
fn test_vectors_equal_integration() {
    let test_vector1 = vector_to(3.0, 4.0);
    let test_vector2 = vector_to(3.0, 4.0);
    let test_vector3 = vector_to(3.0, 5.0);
    assert!(vectors_equal(test_vector1, test_vector2));
    assert!(!vectors_equal(test_vector1, test_vector3));
}
#[test]
fn test_vectors_not_equal_integration() {
    let test_vector1 = vector_to(3.0, 4.0);
    let test_vector2 = vector_to(3.0, 4.0);
    let test_vector3 = vector_to(3.0, 5.0);
    assert!(!vectors_not_equal(test_vector1, test_vector2));
    assert!(vectors_not_equal(test_vector1, test_vector3));
}
