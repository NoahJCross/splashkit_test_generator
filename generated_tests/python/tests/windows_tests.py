import pytest
from splashkit import *

class TestWindows:

def test_clear_window_integration():
    test_window = open_window("Test Window", 800, 600)
    color = color_black()
    clear_window(test_window, color)
    refresh_window(test_window)
    pixel = get_pixel_at_point(point_at(0.0, 0.0))
    assert color == pixel
    close_window(test_window)


def test_close_all_windows_integration():
    open_window("Test Window 1", 800, 600)
    open_window("Test Window 2", 800, 600)
    close_all_windows()
    assert not has_window("Test Window 1")
    assert not has_window("Test Window 2")


def test_close_current_window_integration():
    test_window = open_window("Test Window", 800, 600)
    set_current_window(test_window)
    close_current_window()
    assert not has_window("Test Window")
    assert current_window() is None


def test_close_window_named_integration():
    open_window("Test Window", 800, 600)
    assert has_window("Test Window")
    close_window_named("Test Window")
    assert not has_window("Test Window")


def test_close_window_integration():
    test_window = open_window("Test Window", 800, 600)
    window_name = window_caption(test_window)
    close_window(test_window)
    assert not has_window(window_name)
    assert not window_has_focus(test_window)


def test_current_window_integration():
    window1 = open_window("Test Window 1", 800, 600)
    window2 = open_window("Test Window 2", 800, 600)
    set_current_window(window2)
    assert window2 == current_window()
    assert is_current_window(window2)
    assert not is_current_window(window1)
    close_all_windows()


def test_current_window_has_border_integration():
    test_window = open_window("Test Window", 800, 600)
    set_current_window(test_window)
    assert current_window_has_border()
    current_window_toggle_border()
    assert not current_window_has_border()
    close_window(test_window)


def test_current_window_height_integration():
    test_window = open_window("Test Window", 800, 600)
    set_current_window(test_window)
    assert 600 == current_window_height()
    resize_current_window(800, 400)
    assert 400 == current_window_height()
    close_window(test_window)


def test_current_window_is_fullscreen_integration():
    test_window = open_window("Test Window", 800, 600)
    set_current_window(test_window)
    assert not current_window_is_fullscreen()
    current_window_toggle_fullscreen()
    assert current_window_is_fullscreen()
    close_window(test_window)


def test_current_window_position_integration():
    test_window = open_window("Test Window", 800, 600)
    set_current_window(test_window)
    move_current_window_to(100, 200)
    position = current_window_position()
    assert 100.0 == position.x
    assert 200.0 == position.y
    close_window(test_window)


def test_current_window_toggle_border_integration():
    test_window = open_window("Test Window", 800, 600)
    set_current_window(test_window)
    initial_border = current_window_has_border()
    current_window_toggle_border()
    assert initial_border != current_window_has_border()
    close_window(test_window)


def test_current_window_toggle_fullscreen_integration():
    test_window = open_window("Test Window", 800, 600)
    set_current_window(test_window)
    initial_fullscreen = current_window_is_fullscreen()
    current_window_toggle_fullscreen()
    assert initial_fullscreen != current_window_is_fullscreen()
    close_window(test_window)


def test_current_window_width_integration():
    test_window = open_window("Test Window", 800, 600)
    set_current_window(test_window)
    assert 800 == current_window_width()
    resize_current_window(400, 600)
    assert 400 == current_window_width()
    close_window(test_window)


def test_current_window_x_integration():
    test_window = open_window("Test Window", 800, 600)
    set_current_window(test_window)
    move_current_window_to(100, 200)
    assert 100 == current_window_x()
    move_current_window_to(300, 200)
    assert 300 == current_window_x()
    close_window(test_window)


def test_current_window_y_integration():
    test_window = open_window("Test Window", 800, 600)
    set_current_window(test_window)
    move_current_window_to(0, 100)
    process_events()
    assert 100 == current_window_y()
    close_window(test_window)


def test_has_window_integration():
    test_window = open_window("Test Window", 800, 600)
    assert has_window("Test Window")
    assert has_window(window_caption(test_window))
    close_window(test_window)
    assert not has_window("Test Window")


def test_is_current_window_integration():
    window1 = open_window("Test Window 1", 800, 600)
    window2 = open_window("Test Window 2", 800, 600)
    set_current_window(window1)
    assert is_current_window(window1)
    assert not is_current_window(window2)
    close_all_windows()


def test_move_current_window_to_integration():
    test_window = open_window("Test Window", 800, 600)
    set_current_window(test_window)
    move_current_window_to(100, 200)
    process_events()
    assert 100 == current_window_x()
    assert 200 == current_window_y()
    close_window(test_window)


def test_move_window_to_named_integration():
    test_window = open_window("Test Window", 800, 600)
    move_window_to_named("Test Window", 150, 250)
    process_events()
    assert 150 == window_x_named("Test Window")
    assert 250 == window_y_named("Test Window")
    close_window(test_window)


def test_move_window_to_integration():
    test_window = open_window("Test Window", 800, 600)
    move_window_to(test_window, 200, 300)
    process_events()
    assert 200 == window_x(test_window)
    assert 300 == window_y(test_window)
    close_window(test_window)


def test_open_window_integration():
    test_window = open_window("Test Window", 800, 600)
    assert test_window is not None
    assert "Test Window" == window_caption(test_window)
    assert 800 == window_width(test_window)
    assert 600 == window_height(test_window)
    close_window(test_window)


def test_refresh_window_integration():
    test_window = open_window("Test Window", 800, 600)
    clear_window(test_window, color_white())
    draw_circle(color_black(), 400.0, 300.0, 50.0)
    refresh_window(test_window)
    pixel = get_pixel_at_point(point_at(400.0, 300.0))
    assert color_black() == pixel
    close_window(test_window)


def test_refresh_window_with_target_fps_integration():
    test_window = open_window("Test Window", 800, 600)
    refresh_window_with_target_fps(test_window, 60)
    close_window(test_window)


def test_resize_current_window_integration():
    test_window = open_window("Test Window", 800, 600)
    set_current_window(test_window)
    resize_current_window(1024, 768)
    process_events()
    assert 1024 == window_width(test_window)
    assert 768 == window_height(test_window)
    close_window(test_window)


def test_resize_window_integration():
    test_window = open_window("Test Window", 800, 600)
    resize_window(test_window, 1024, 768)
    process_events()
    assert 1024 == window_width(test_window)
    assert 768 == window_height(test_window)
    close_window(test_window)


def test_set_current_window_named_integration():
    open_window("Test Window 1", 800, 600)
    window2 = open_window("Test Window 2", 800, 600)
    set_current_window_named("Test Window 2")
    assert window2 == current_window()
    close_all_windows()


def test_set_current_window_integration():
    open_window("Test Window 1", 800, 600)
    window2 = open_window("Test Window 2", 800, 600)
    set_current_window(window2)
    assert window2 == current_window()
    close_all_windows()


def test_window_caption_integration():
    test_window = open_window("Test Window", 800, 600)
    assert "Test Window" == window_caption(test_window)
    close_window(test_window)


def test_window_close_requested_named_integration():
    test_window = open_window("Test Window", 800, 600)
    process_events()
    assert not window_close_requested_named("Test Window")
    while window_close_requested_named("Test Window") is False:
        process_events()
    
    assert window_close_requested_named("Test Window")
    close_window(test_window)


def test_window_close_requested_integration():
    test_window = open_window("Test Window", 800, 600)
    process_events()
    assert not window_close_requested(test_window)
    while window_close_requested(test_window) is False:
        process_events()
    
    assert window_close_requested(test_window)
    close_window(test_window)


def test_window_has_border_named_integration():
    test_window = open_window("Test Window", 800, 600)
    assert window_has_border_named("Test Window")
    window_toggle_border_named("Test Window")
    process_events()
    assert not window_has_border_named("Test Window")
    close_window(test_window)


def test_window_has_border_integration():
    test_window = open_window("Test Window", 800, 600)
    assert window_has_border(test_window)
    window_toggle_border(test_window)
    process_events()
    assert not window_has_border(test_window)
    close_window(test_window)


def test_window_has_focus_integration():
    window1 = open_window("Test Window 1", 800, 600)
    window2 = open_window("Test Window 2", 800, 600)
    process_events()
    assert window_has_focus(window2)
    assert not window_has_focus(window1)
    close_all_windows()


def test_window_height_named_integration():
    test_window = open_window("Test Window", 800, 600)
    assert 600 == window_height_named("Test Window")
    resize_window(test_window, 800, 400)
    process_events()
    assert 400 == window_height_named("Test Window")
    close_window(test_window)


def test_window_height_integration():
    test_window = open_window("Test Window", 800, 600)
    assert 600 == window_height(test_window)
    resize_window(test_window, 800, 400)
    process_events()
    assert 400 == window_height(test_window)
    close_window(test_window)


def test_window_is_fullscreen_named_integration():
    test_window = open_window("Test Window", 800, 600)
    assert not window_is_fullscreen_named("Test Window")
    window_toggle_fullscreen_named("Test Window")
    process_events()
    assert window_is_fullscreen_named("Test Window")
    close_window(test_window)


def test_window_is_fullscreen_integration():
    test_window = open_window("Test Window", 800, 600)
    assert not window_is_fullscreen(test_window)
    window_toggle_fullscreen(test_window)
    process_events()
    assert window_is_fullscreen(test_window)
    close_window(test_window)


def test_window_named_integration():
    test_window = open_window("Test Window", 800, 600)
    named_window = window_named("Test Window")
    assert test_window == named_window
    assert window_caption(test_window) == window_caption(named_window)
    close_window(test_window)


def test_window_position_named_integration():
    test_window = open_window("Test Window", 800, 600)
    move_window_to_named("Test Window", 100, 200)
    process_events()
    position = window_position_named("Test Window")
    assert 100.0 == position.x
    assert 200.0 == position.y
    close_window(test_window)


def test_window_position_integration():
    test_window = open_window("Test Window", 800, 600)
    move_window_to(test_window, 100, 200)
    process_events()
    position = window_position(test_window)
    assert 100.0 == position.x
    assert 200.0 == position.y
    close_window(test_window)


def test_window_set_icon_integration():
    test_window = open_window("Test Window", 800, 600)
    icon = create_bitmap("test_icon", 32, 32)
    clear_bitmap(icon, color_white())
    window_set_icon(test_window, icon)
    process_events()
    free_bitmap(icon)
    close_window(test_window)


def test_window_toggle_border_named_integration():
    test_window = open_window("Test Window", 800, 600)
    assert window_has_border_named("Test Window")
    window_toggle_border_named("Test Window")
    process_events()
    assert not window_has_border_named("Test Window")
    close_window(test_window)


def test_window_toggle_border_integration():
    test_window = open_window("Test Window", 800, 600)
    assert window_has_border(test_window)
    window_toggle_border(test_window)
    process_events()
    assert not window_has_border(test_window)
    close_window(test_window)


def test_window_toggle_fullscreen_named_integration():
    test_window = open_window("Test Window", 800, 600)
    assert not window_is_fullscreen_named("Test Window")
    window_toggle_fullscreen_named("Test Window")
    process_events()
    assert window_is_fullscreen_named("Test Window")
    close_window(test_window)


def test_window_toggle_fullscreen_integration():
    test_window = open_window("Test Window", 800, 600)
    assert not window_is_fullscreen(test_window)
    window_toggle_fullscreen(test_window)
    process_events()
    assert window_is_fullscreen(test_window)
    close_window(test_window)


def test_window_width_named_integration():
    test_window = open_window("Test Window", 800, 600)
    assert 800 == window_width_named("Test Window")
    resize_window(test_window, 1024, 600)
    process_events()
    assert 1024 == window_width_named("Test Window")
    close_window(test_window)


def test_window_width_integration():
    test_window = open_window("Test Window", 800, 600)
    assert 800 == window_width(test_window)
    resize_window(test_window, 1024, 600)
    process_events()
    assert 1024 == window_width(test_window)
    close_window(test_window)


def test_window_with_focus_integration():
    window1 = open_window("Test Window 1", 800, 600)
    window2 = open_window("Test Window 2", 800, 600)
    process_events()
    assert window2 == window_with_focus()
    set_current_window(window1)
    process_events()
    assert window1 == window_with_focus()
    close_all_windows()


def test_window_x_named_integration():
    test_window = open_window("Test Window", 800, 600)
    move_window_to_named("Test Window", 100, 200)
    process_events()
    assert 100 == window_x_named("Test Window")
    move_window_to_named("Test Window", 300, 200)
    process_events()
    assert 300 == window_x_named("Test Window")
    close_window(test_window)


def test_window_x_integration():
    test_window = open_window("Test Window", 800, 600)
    move_window_to(test_window, 100, 200)
    process_events()
    assert 100 == window_x(test_window)
    move_window_to(test_window, 300, 200)
    process_events()
    assert 300 == window_x(test_window)
    close_window(test_window)


def test_window_y_named_integration():
    test_window = open_window("Test Window", 800, 600)
    move_window_to_named("Test Window", 100, 200)
    process_events()
    assert 200 == window_y_named("Test Window")
    move_window_to_named("Test Window", 100, 400)
    process_events()
    assert 400 == window_y_named("Test Window")
    close_window(test_window)


def test_window_y_integration():
    test_window = open_window("Test Window", 800, 600)
    move_window_to(test_window, 100, 200)
    process_events()
    assert 200 == window_y(test_window)
    move_window_to(test_window, 100, 400)
    process_events()
    assert 400 == window_y(test_window)
    close_window(test_window)

