using Xunit;
using SplashKitSDK;
using static SplashKitSDK.SplashKit;
using HttpMethod = SplashKitSDK.HttpMethod;
namespace SplashKitTests
{
    public class TestGraphics
    {
        public TestGraphics()
        {
            SetResourcesPath("/mnt/c/Users/Noahc/Documents/aYear_2_semester_2/TeamProject/GitHubRepo/splashkit_test_generator/resources");
        }
        [Fact]
        public void TestDrawCircleRecordIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testCircle = CircleAt(400.0, 300.0, 50.0);
            DrawCircle(ColorBlack(), testCircle);
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 460.0, 300.0));
        }
        [Fact]
        public void TestDrawCircleRecordWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testCircle = CircleAt(400.0, 300.0, 50.0);
            DrawCircle(ColorBlack(), testCircle, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 460.0, 300.0));
        }
        [Fact]
        public void TestDrawCircleIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawCircle(ColorBlack(), 400.0, 300.0, 50.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 425.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 460.0, 300.0));
        }
        [Fact]
        public void TestDrawCircleWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawCircle(ColorBlack(), 400.0, 300.0, 50.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 460.0, 300.0));
        }
        [Fact]
        public void TestDrawCircleOnBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawCircleOnBitmap(testBitmap, ColorBlack(), 100.0, 100.0, 50.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 150.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 160.0, 100.0));
        }
        [Fact]
        public void TestDrawCircleOnBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawCircleOnBitmap(testBitmap, ColorBlack(), 100.0, 100.0, 50.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 150.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 160.0, 100.0));
        }
        [Fact]
        public void TestDrawCircleOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawCircleOnWindow(testWindow, ColorBlack(), 400.0, 300.0, 50.0);
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 460.0, 300.0));
        }
        [Fact]
        public void TestDrawCircleOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawCircleOnWindow(testWindow, ColorBlack(), 400.0, 300.0, 50.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 350.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 400.0));
        }
        [Fact]
        public void TestFillCircleRecordIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testCircle = CircleAt(400.0, 300.0, 50.0);
            FillCircle(ColorBlack(), testCircle);
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 425.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 460.0, 300.0));
        }
        [Fact]
        public void TestFillCircleRecordWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testCircle = CircleAt(400.0, 300.0, 50.0);
            FillCircle(ColorBlack(), testCircle, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 425.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 460.0, 300.0));
        }
        [Fact]
        public void TestFillCircleIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillCircle(ColorBlack(), 400.0, 300.0, 50.0);
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 425.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 460.0, 300.0));
        }
        [Fact]
        public void TestFillCircleWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillCircle(ColorBlack(), 400.0, 300.0, 50.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 425.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 460.0, 300.0));
        }
        [Fact]
        public void TestFillCircleOnBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillCircleOnBitmap(testBitmap, ColorRed(), 100.0, 100.0, 50.0);
            Assert.Equal(ColorRed(), GetPixel(testBitmap, 100.0, 100.0));
            Assert.Equal(ColorRed(), GetPixel(testBitmap, 125.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 160.0, 100.0));
        }
        [Fact]
        public void TestFillCircleOnBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillCircleOnBitmap(testBitmap, ColorBlack(), 100.0, 100.0, 50.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 100.0, 100.0));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 125.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 160.0, 100.0));
        }
        [Fact]
        public void TestFillCircleOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillCircleOnWindow(testWindow, ColorBlack(), 400.0, 300.0, 50.0);
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 425.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 460.0, 300.0));
        }
        [Fact]
        public void TestFillCircleOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillCircleOnWindow(testWindow, ColorBlack(), 400.0, 300.0, 50.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 425.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 460.0, 300.0));
        }
        [Fact]
        public void TestCurrentClipIntegration() {
            OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testClip = CurrentClip();
            Assert.Equal(0.0f, RectangleLeft(testClip));
            Assert.Equal(0.0f, RectangleTop(testClip));
            Assert.Equal(800.0, testClip.Width);
            Assert.Equal(600.0, testClip.Height);
        }
        [Fact]
        public void TestCurrentClipForBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            var testRectangle = RectangleFrom(10.0, 10.0, 50.0, 50.0);
            PushClip(testBitmap, testRectangle);
            var testClip = CurrentClip(testBitmap);
            Assert.Equal(10.0f, RectangleLeft(testClip));
            Assert.Equal(10.0f, RectangleTop(testClip));
            Assert.Equal(50.0, testClip.Width);
            Assert.Equal(50.0, testClip.Height);
        }
        [Fact]
        public void TestCurrentClipForWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testClip = CurrentClip(testWindow);
            Assert.Equal(0.0f, RectangleLeft(testClip));
            Assert.Equal(0.0f, RectangleTop(testClip));
            Assert.Equal(800.0, testClip.Width);
            Assert.Equal(600.0, testClip.Height);
        }
        [Fact]
        public void TestPopClipForWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testRectangle = RectangleFrom(0.0, 0.0, 250.0, 250.0);
            PushClip(testWindow, testRectangle);
            var testCurrentClip = CurrentClip(testWindow);
            Assert.Equal(0.0f, RectangleLeft(testCurrentClip));
            Assert.Equal(0.0f, RectangleTop(testCurrentClip));
            Assert.Equal(250.0, testCurrentClip.Width);
            Assert.Equal(250.0, testCurrentClip.Height);
            PopClip(testWindow);
            var testCurrentClipAfterPop = CurrentClip(testWindow);
            Assert.Equal(0.0f, RectangleLeft(testCurrentClipAfterPop));
            Assert.Equal(0.0f, RectangleTop(testCurrentClipAfterPop));
            Assert.Equal(800.0, testCurrentClipAfterPop.Width);
            Assert.Equal(600.0, testCurrentClipAfterPop.Height);
        }
        [Fact]
        public void TestPopClipIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            PushClip(RectangleFrom(0.0, 0.0, 250.0, 250.0));
            FillRectangle(ColorRed(), 0.0, 0.0, 300.0, 300.0);
            RefreshScreen();
            Assert.Equal(ColorRed(), GetPixel(testWindow, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 275.0, 275.0));
            PopClip();
            FillRectangle(ColorGreen(), 300.0, 300.0, 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorRed(), GetPixel(testWindow, 125.0, 125.0));
            var testColor = ColorGreen();
            var testPixel = GetPixel(testWindow, 350.0, 350.0);
            Assert.Equal(RedOf(testColor), RedOf(testPixel));
            Assert.Equal(GreenOf(testColor), GreenOf(testPixel));
            Assert.Equal(BlueOf(testColor), BlueOf(testPixel));
            Assert.Equal(AlphaOf(testColor), AlphaOf(testPixel));
        }
        [Fact]
        public void TestPopClipForBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            PushClip(testBitmap, RectangleFrom(0.0, 0.0, 50.0, 50.0));
            FillCircle(ColorBlack(), 25.0, 25.0, 20.0, OptionDrawTo(testBitmap));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 25.0, 25.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 75.0, 75.0));
            PopClip(testBitmap);
            var testClip = CurrentClip(testBitmap);
            Assert.Equal(0.0f, RectangleLeft(testClip));
            Assert.Equal(0.0f, RectangleTop(testClip));
            Assert.Equal(100.0, testClip.Width);
            Assert.Equal(100.0, testClip.Height);
        }
        [Fact]
        public void TestPushClipForWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testRectangle = RectangleFrom(100.0, 100.0, 200.0, 200.0);
            PushClip(testWindow, testRectangle);
            var testCurrentClip = CurrentClip(testWindow);
            Assert.Equal(100.0f, RectangleLeft(testCurrentClip));
            Assert.Equal(100.0f, RectangleTop(testCurrentClip));
            Assert.Equal(200.0, testCurrentClip.Width);
            Assert.Equal(200.0, testCurrentClip.Height);
            RefreshScreen();
        }
        [Fact]
        public void TestPushClipForBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            var testRectangle = RectangleFrom(50.0, 50.0, 100.0, 100.0);
            PushClip(testBitmap, testRectangle);
            var testCurrentClip = CurrentClip(testBitmap);
            Assert.Equal(50.0f, RectangleLeft(testCurrentClip));
            Assert.Equal(50.0f, RectangleTop(testCurrentClip));
            Assert.Equal(100.0, testCurrentClip.Width);
            Assert.Equal(100.0, testCurrentClip.Height);
        }
        [Fact]
        public void TestPushClipIntegration() {
            OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testRectangle = RectangleFrom(100.0, 100.0, 200.0, 200.0);
            PushClip(testRectangle);
            var testCurrentClip = CurrentClip();
            Assert.Equal(100.0f, RectangleLeft(testCurrentClip));
            Assert.Equal(100.0f, RectangleTop(testCurrentClip));
            Assert.Equal(200.0, testCurrentClip.Width);
            Assert.Equal(200.0, testCurrentClip.Height);
        }
        [Fact]
        public void TestResetClipForBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            PushClip(testBitmap, RectangleFrom(10.0, 10.0, 50.0, 50.0));
            ResetClip(testBitmap);
            var testClip = CurrentClip(testBitmap);
            Assert.Equal(0.0f, RectangleLeft(testClip));
            Assert.Equal(0.0f, RectangleTop(testClip));
            Assert.Equal(100.0, testClip.Width);
            Assert.Equal(100.0, testClip.Height);
        }
        [Fact]
        public void TestResetClipIntegration() {
            OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            PushClip(RectangleFrom(100.0, 100.0, 200.0, 200.0));
            ResetClip();
            var testClip = CurrentClip();
            Assert.Equal(0.0f, RectangleLeft(testClip));
            Assert.Equal(0.0f, RectangleTop(testClip));
            Assert.Equal(800.0, testClip.Width);
            Assert.Equal(600.0, testClip.Height);
        }
        [Fact]
        public void TestResetClipForWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            PushClip(testWindow, RectangleFrom(100.0, 100.0, 200.0, 200.0));
            ResetClip(testWindow);
            var testClip = CurrentClip(testWindow);
            Assert.Equal(0.0f, RectangleLeft(testClip));
            Assert.Equal(0.0f, RectangleTop(testClip));
            Assert.Equal(800.0, testClip.Width);
            Assert.Equal(600.0, testClip.Height);
        }
        [Fact]
        public void TestSetClipIntegration() {
            OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testRectangle = RectangleFrom(100.0, 100.0, 200.0, 200.0);
            SetClip(testRectangle);
            var testCurrentClip = CurrentClip();
            Assert.Equal(100.0f, RectangleLeft(testCurrentClip));
            Assert.Equal(100.0f, RectangleTop(testCurrentClip));
            Assert.Equal(200.0, testCurrentClip.Width);
            Assert.Equal(200.0, testCurrentClip.Height);
        }
        [Fact]
        public void TestSetClipForBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            var testRectangle = RectangleFrom(50.0, 50.0, 100.0, 100.0);
            SetClip(testBitmap, testRectangle);
            var testCurrentClip = CurrentClip(testBitmap);
            Assert.Equal(50.0f, RectangleLeft(testCurrentClip));
            Assert.Equal(50.0f, RectangleTop(testCurrentClip));
            Assert.Equal(100.0, testCurrentClip.Width);
            Assert.Equal(100.0, testCurrentClip.Height);
        }
        [Fact]
        public void TestSetClipForWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testRectangle = RectangleFrom(100.0, 100.0, 200.0, 200.0);
            SetClip(testWindow, testRectangle);
            var testCurrentClip = CurrentClip(testWindow);
            Assert.Equal(100.0f, RectangleLeft(testCurrentClip));
            Assert.Equal(100.0f, RectangleTop(testCurrentClip));
            Assert.Equal(200.0, testCurrentClip.Width);
            Assert.Equal(200.0, testCurrentClip.Height);
        }
        [Fact]
        public void TestOptionDefaultsIntegration() {
            var testOptions = OptionDefaults();
            Assert.NotNull(testOptions);
        }
        [Fact]
        public void TestOptionDrawToBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var testOptions = OptionDrawTo(testBitmap);
            DrawCircle(ColorBlack(), CircleAt(50.0, 50.0, 25.0), testOptions);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 75.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 90.0, 90.0));
        }
        [Fact]
        public void TestOptionDrawToBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var testOptions = OptionDefaults();
            var testDrawingOptions = OptionDrawTo(testBitmap, testOptions);
            DrawCircle(ColorBlack(), CircleAt(50.0, 50.0, 25.0), testDrawingOptions);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 75.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 90.0, 90.0));
        }
        [Fact]
        public void TestOptionDrawToWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawCircle(ColorBlack(), CircleAt(400.0, 300.0, 50.0), OptionDrawTo(testWindow));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 460.0, 300.0));
        }
        [Fact]
        public void TestOptionDrawToWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testOptions = OptionDefaults();
            DrawCircle(ColorBlack(), CircleAt(400.0, 300.0, 50.0), OptionDrawTo(testWindow, testOptions));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 460.0, 300.0));
        }
        [Fact]
        public void TestOptionFlipXIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorBlack(), 0.0, 0.0, 50.0, 100.0);
            DrawBitmap(testBitmap, 100.0, 100.0, OptionFlipX());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 125.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 75.0, 100.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionFlipXWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorBlack(), 0.0, 0.0, 50.0, 100.0);
            DrawBitmap(testBitmap, 400.0, 300.0, OptionFlipX(OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 425.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 375.0, 300.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionFlipXyIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorBlack(), 0.0, 0.0, 50.0, 50.0);
            DrawBitmap(testBitmap, 400.0, 300.0, OptionFlipXy());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 350.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 450.0, 250.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionFlipXyWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorBlack(), 0.0, 0.0, 50.0, 50.0);
            DrawBitmap(testBitmap, 400.0, 300.0, OptionFlipXy(OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 350.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 450.0, 250.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionFlipYIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorBlack(), 0.0, 0.0, 100.0, 50.0);
            DrawBitmap(testBitmap, 400.0, 300.0, OptionFlipY());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 400.0, 325.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 275.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionFlipYWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorBlack(), 0.0, 0.0, 100.0, 50.0);
            DrawBitmap(testBitmap, 400.0, 300.0, OptionFlipY(OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 400.0, 325.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 275.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionLineWidthIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawLine(ColorBlack(), 100.0, 100.0, 200.0, 200.0, OptionLineWidth(5));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 140.0, 150.0));
        }
        [Fact]
        public void TestOptionLineWidthWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawLine(ColorBlack(), 100.0, 100.0, 200.0, 200.0, OptionLineWidth(5, OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 145.0, 150.0));
        }
        [Fact]
        public void TestOptionPartBmpIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorBlack());
            DrawBitmap(testBitmap, 100.0, 100.0, OptionPartBmp(0.0, 0.0, 50.0, 50.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 175.0, 175.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionPartBmpWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorBlack());
            DrawBitmap(testBitmap, 100.0, 100.0, OptionPartBmp(0.0, 0.0, 50.0, 50.0, OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 175.0, 175.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionPartBmpFromRectangleIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorBlack());
            DrawBitmap(testBitmap, 0.0, 0.0, OptionPartBmp(RectangleFrom(0.0, 0.0, 50.0, 50.0)));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 25.0, 25.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 75.0, 75.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionPartBmpFromRectangleWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorBlack());
            DrawBitmap(testBitmap, 0.0, 0.0, OptionPartBmp(RectangleFrom(0.0, 0.0, 50.0, 50.0), OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 25.0, 25.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 75.0, 75.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionRotateBmpIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorBlack(), 0.0, 0.0, 50.0, 100.0);
            DrawBitmap(testBitmap, 400.0, 300.0, OptionRotateBmp(90.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 350.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionRotateBmpWithAnchorIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorBlack(), 0.0, 0.0, 50.0, 100.0);
            DrawBitmap(testBitmap, 400.0, 300.0, OptionRotateBmp(90.0, 50.0, 50.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 500.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 450.0, 300.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionRotateBmpWithAnchorAndOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorBlack(), 0.0, 0.0, 50.0, 100.0);
            DrawBitmap(testBitmap, 400.0, 300.0, OptionRotateBmp(90.0, 50.0, 50.0, OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 500.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 300.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionRotateBmpWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorBlack(), 0.0, 0.0, 50.0, 100.0);
            DrawBitmap(testBitmap, 400.0, 300.0, OptionRotateBmp(90.0, OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 350.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionScaleBmpIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 50, 50);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorBlack());
            DrawBitmap(testBitmap, 400.0, 300.0, OptionScaleBmp(2.0, 2.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 451.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 500.0, 300.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionScaleBmpWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 50, 50);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorBlack());
            DrawBitmap(testBitmap, 400.0, 300.0, OptionScaleBmp(2.0, 2.0, OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 451.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 500.0, 300.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionToScreenIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawCircle(ColorBlack(), CircleAt(400.0, 300.0, 50.0), OptionToScreen());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 451.0, 300.0));
        }
        [Fact]
        public void TestOptionToScreenWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawCircle(ColorBlack(), CircleAt(400.0, 300.0, 50.0), OptionToScreen(OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 400.0, 250.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 300.0));
        }
        [Fact]
        public void TestOptionToWorldIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            MoveCameraTo(100.0, 100.0);
            DrawCircle(ColorBlack(), CircleAt(400.0, 300.0, 50.0), OptionToWorld());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 350.0, 200.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 375.0, 200.0));
        }
        [Fact]
        public void TestOptionToWorldWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            MoveCameraTo(100.0, 100.0);
            DrawCircle(ColorBlack(), CircleAt(400.0, 300.0, 50.0), OptionToWorld(OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 350.0, 200.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 375.0, 200.0));
        }
        [Fact]
        public void TestOptionWithAnimationIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            using var cleanupAnimationScript = new AnimationScriptCleanup();
            var testAnimation = CreateAnimation(kermitScript, "moonwalkback");
            using var cleanupAnimation = new AnimationCleanup(testAnimation);
            var testBitmap = LoadBitmap("frog", "frog.png");
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 73, 105, 4, 4, 16);
            while (!WindowCloseRequested(testWindow)) {
                ClearScreen();
                DrawBitmap(testBitmap, 100.0, 100.0, OptionWithAnimation(testAnimation));
                DrawText("Test: option_with_animation. Should be moving. Close when done.", ColorBlack(), 10.0, 10.0);
                UpdateAnimation(testAnimation);
                Delay(100);
                RefreshScreen();
            }
        }
        [Fact]
        public void TestOptionWithAnimationWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            using var cleanupAnimationScript = new AnimationScriptCleanup();
            var testAnimation = CreateAnimation(kermitScript, "moonwalkback");
            using var cleanupAnimation = new AnimationCleanup(testAnimation);
            var testBitmap = LoadBitmap("frog", "frog.png");
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 73, 105, 4, 4, 16);
            while (!WindowCloseRequested(testWindow)) {
                ClearScreen();
                DrawBitmap(testBitmap, 100.0, 100.0, OptionWithAnimation(testAnimation, OptionDefaults()));
                DrawText("Test: option_with_animation_with_options. Should be moving. Close when done.", ColorBlack(), 10.0, 10.0);
                UpdateAnimation(testAnimation);
                Delay(100);
                RefreshScreen();
            }
        }
        [Fact]
        public void TestOptionWithBitmapCellIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 64, 64);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorBlack());
            BitmapSetCellDetails(testBitmap, 32, 32, 2, 2, 4);
            DrawBitmap(testBitmap, 100.0, 100.0, OptionWithBitmapCell(1));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 116.0, 116.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 84.0, 84.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestOptionWithBitmapCellWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testBitmap = CreateBitmap("test_bitmap", 64, 64);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorBlack());
            BitmapSetCellDetails(testBitmap, 32, 32, 2, 2, 4);
            DrawBitmap(testBitmap, 100.0, 100.0, OptionWithBitmapCell(1, OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 116.0, 116.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 84.0, 84.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestDrawEllipseWithinRectangleIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawEllipse(ColorBlack(), RectangleFrom(100.0, 100.0, 200.0, 150.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 300.0, 175.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 200.0, 175.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 350.0, 175.0));
        }
        [Fact]
        public void TestDrawEllipseWithinRectangleWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawEllipse(ColorBlack(), RectangleFrom(100.0, 100.0, 200.0, 100.0), OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 300.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 200.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 350.0, 150.0));
        }
        [Fact]
        public void TestDrawEllipseIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawEllipse(ColorBlack(), 400.0, 300.0, 100.0, 50.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 500.0, 300.0));
        }
        [Fact]
        public void TestDrawEllipseWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawEllipse(ColorBlack(), 400.0, 300.0, 100.0, 50.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 500.0, 300.0));
        }
        [Fact]
        public void TestDrawEllipseOnBitmapWithinRectangleIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var rect = RectangleFrom(50.0, 50.0, 100.0, 100.0);
            DrawEllipseOnBitmap(testBitmap, ColorBlack(), rect);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 150.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 125.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 175.0, 100.0));
        }
        [Fact]
        public void TestDrawEllipseOnBitmapWithinRectangleWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawEllipseOnBitmap(testBitmap, ColorBlack(), RectangleFrom(50.0, 50.0, 100.0, 100.0), OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 150.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 125.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 175.0, 100.0));
        }
        [Fact]
        public void TestDrawEllipseOnBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawEllipseOnBitmap(testBitmap, ColorBlack(), 100.0, 100.0, 50.0, 30.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 125.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 160.0, 100.0));
        }
        [Fact]
        public void TestDrawEllipseOnBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawEllipseOnBitmap(testBitmap, ColorBlack(), 100.0, 100.0, 50.0, 30.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 125.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 160.0, 100.0));
        }
        [Fact]
        public void TestDrawEllipseOnWindowWithinRectangleIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var rect = RectangleFrom(100.0, 100.0, 200.0, 100.0);
            DrawEllipseOnWindow(testWindow, ColorBlack(), rect);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 300.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 250.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 350.0, 150.0));
        }
        [Fact]
        public void TestDrawEllipseOnWindowWithinRectangleWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var rect = RectangleFrom(100.0, 100.0, 200.0, 100.0);
            DrawEllipseOnWindow(testWindow, ColorBlack(), rect, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 300.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 250.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 350.0, 150.0));
        }
        [Fact]
        public void TestDrawEllipseOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawEllipseOnWindow(testWindow, ColorBlack(), 400.0, 300.0, 100.0, 50.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 500.0, 300.0));
        }
        [Fact]
        public void TestDrawEllipseOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawEllipseOnWindow(testWindow, ColorBlack(), 400.0, 300.0, 100.0, 50.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 450.0, 325.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 500.0, 300.0));
        }
        [Fact]
        public void TestFillEllipseWithinRectangleIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillEllipse(ColorBlack(), RectangleFrom(100.0, 100.0, 200.0, 100.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 200.0, 100.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
        }
        [Fact]
        public void TestFillEllipseWithinRectangleWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillEllipse(ColorBlack(), RectangleFrom(100.0, 100.0, 200.0, 100.0), OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 200.0, 100.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
        }
        [Fact]
        public void TestFillEllipseIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillEllipse(ColorBlack(), 400.0, 300.0, 100.0, 50.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 325.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 500.0, 300.0));
        }
        [Fact]
        public void TestFillEllipseWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillEllipse(ColorBlack(), 400.0, 300.0, 100.0, 50.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 325.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 300.0, 300.0));
        }
        [Fact]
        public void TestFillEllipseOnBitmapWithinRectangleIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillEllipseOnBitmap(testBitmap, ColorBlack(), RectangleFrom(50.0, 50.0, 100.0, 100.0));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 100.0, 100.0));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 75.0, 75.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 175.0, 175.0));
        }
        [Fact]
        public void TestFillEllipseOnBitmapWithinRectangleWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillEllipseOnBitmap(testBitmap, ColorBlack(), RectangleFrom(50.0, 50.0, 100.0, 100.0), OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 100.0, 100.0));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 75.0, 75.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 175.0, 175.0));
        }
        [Fact]
        public void TestFillEllipseOnBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillEllipseOnBitmap(testBitmap, ColorBlack(), 100.0, 100.0, 50.0, 30.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 125.0, 100.0));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 150.0, 100.0));
        }
        [Fact]
        public void TestFillEllipseOnBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillEllipseOnBitmap(testBitmap, ColorBlack(), 50.0, 50.0, 100.0, 50.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 100.0, 50.0));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 100.0, 75.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 150.0, 50.0));
        }
        [Fact]
        public void TestFillEllipseOnWindowWithinRectangleIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillEllipseOnWindow(testWindow, ColorBlack(), RectangleFrom(100.0, 100.0, 200.0, 150.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 200.0, 175.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 175.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 350.0, 175.0));
        }
        [Fact]
        public void TestFillEllipseOnWindowWithinRectangleWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillEllipseOnWindow(testWindow, ColorBlack(), RectangleFrom(100.0, 100.0, 200.0, 150.0), OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 200.0, 175.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 175.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 350.0, 175.0));
        }
        [Fact]
        public void TestFillEllipseOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillEllipseOnWindow(testWindow, ColorBlack(), 400.0, 300.0, 100.0, 50.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 325.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 500.0, 300.0));
        }
        [Fact]
        public void TestFillEllipseOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillEllipseOnWindow(testWindow, ColorBlack(), 400.0, 300.0, 100.0, 50.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 300.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 450.0, 325.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 500.0, 300.0));
        }
        [Fact]
        public void TestClearScreenToWhiteIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            DrawPixel(ColorBlack(), 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            ClearScreen();
            RefreshScreen();
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 100.0, 100.0));
        }
        [Fact]
        public void TestClearScreenIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            DrawPixel(ColorBlack(), 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            ClearScreen(ColorWhite());
            RefreshScreen();
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 100.0, 100.0));
        }
        [Fact]
        public void TestDisplayDetailsIntegration() {
            var displays = NumberOfDisplays();
            Assert.True(displays > 0);
            var display = DisplayDetails(0u);
            Assert.NotNull(display);
            Assert.True(DisplayWidth(display) > 0);
            Assert.True(DisplayHeight(display) > 0);
            Assert.NotEmpty(DisplayName(display));
        }
        [Fact]
        public void TestDisplayHeightIntegration() {
            var display = DisplayDetails(0u);
            Assert.True(DisplayHeight(display) > 0);
        }
        [Fact]
        public void TestDisplayNameIntegration() {
            var display = DisplayDetails(0u);
            Assert.NotEmpty(DisplayName(display));
            Assert.NotEmpty(DisplayName(display));
        }
        [Fact]
        public void TestDisplayWidthIntegration() {
            var display = DisplayDetails(0u);
            Assert.True(DisplayWidth(display) > 0);
        }
        [Fact]
        public void TestDisplayXIntegration() {
            var display = DisplayDetails(0u);
            Assert.Equal(0, DisplayX(display));
        }
        [Fact]
        public void TestDisplayYIntegration() {
            var display = DisplayDetails(0u);
            Assert.Equal(0, DisplayY(display));
        }
        [Fact]
        public void TestNumberOfDisplaysIntegration() {
            Assert.True(NumberOfDisplays() > 0);
        }
        [Fact]
        public void TestRefreshScreenIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawCircle(ColorBlack(), CircleAt(400.0, 300.0, 50.0));
            RefreshScreen();
        }
        [Fact]
        public void TestRefreshScreenWithTargetFpsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawCircle(ColorBlack(), CircleAt(400.0, 300.0, 50.0));
            RefreshScreen(60u);
        }
        [Fact]
        public void TestSaveBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawPixelOnBitmap(testBitmap, ColorBlack(), 50.0, 50.0);
            SaveBitmap(testBitmap, "test_bitmap");
        }
        [Fact]
        public void TestScreenHeightIntegration() {
            OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            Assert.Equal(600, ScreenHeight());
        }
        [Fact]
        public void TestScreenWidthIntegration() {
            OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            Assert.Equal(800, ScreenWidth());
        }
        [Fact]
        public void TestTakeScreenshotIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawCircle(ColorBlack(), CircleAt(400.0, 300.0, 50.0));
            RefreshScreen();
            TakeScreenshot("test_screenshot");
        }
        [Fact]
        public void TestTakeScreenshotOfWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawCircle(ColorBlack(), CircleAt(400.0, 300.0, 50.0));
            RefreshScreen();
            TakeScreenshot(testWindow, "test_screenshot");
        }
        [Fact]
        public void TestBitmapBoundingCircleIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            var testPoint = PointAt(50.0, 50.0);
            var boundingCircle = BitmapBoundingCircle(testBitmap, testPoint);
            Assert.Equal(testPoint, CenterPoint(boundingCircle));
            Assert.Equal(100.0f, CircleRadius(boundingCircle));
        }
        [Fact]
        public void TestBitmapBoundingRectangleIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            var boundingRect = BitmapBoundingRectangle(testBitmap);
            Assert.Equal(0.0, boundingRect.X);
            Assert.Equal(0.0, boundingRect.Y);
            Assert.Equal(100.0, boundingRect.Width);
            Assert.Equal(100.0, boundingRect.Height);
        }
        [Fact]
        public void TestBitmapBoundingRectangleAtLocationIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            var boundingRect = BitmapBoundingRectangle(testBitmap, 50.0, 50.0);
            Assert.Equal(50.0, boundingRect.X);
            Assert.Equal(50.0, boundingRect.Y);
            Assert.Equal(100.0, boundingRect.Width);
            Assert.Equal(100.0, boundingRect.Height);
        }
        [Fact]
        public void TestBitmapCellCenterIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            var center = BitmapCellCenter(testBitmap);
            Assert.Equal(50.0, center.X);
            Assert.Equal(50.0, center.Y);
        }
        [Fact]
        public void TestBitmapCellCircleIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 50, 50, 2, 2, 4);
            var circle = BitmapCellCircle(testBitmap, 50.0, 50.0);
            Assert.Equal(50.0, circle.Center.X);
            Assert.Equal(50.0, circle.Center.X);
            Assert.Equal(25.0, circle.Radius);
        }
        [Fact]
        public void TestBitmapCellCircleAtPointIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 50, 50, 2, 2, 4);
            var circle = BitmapCellCircle(testBitmap, PointAt(100.0, 100.0));
            Assert.Equal(100.0, circle.Center.X);
            Assert.Equal(100.0, circle.Center.X);
            Assert.Equal(25.0, circle.Radius);
        }
        [Fact]
        public void TestBitmapCellCircleAtPointWithScaleIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 50, 50, 2, 2, 4);
            var circle = BitmapCellCircle(testBitmap, PointAt(100.0, 100.0), 2.0);
            Assert.Equal(100.0, circle.Center.X);
            Assert.Equal(100.0, circle.Center.X);
            Assert.Equal(50.0, circle.Radius);
        }
        [Fact]
        public void TestBitmapCellColumnsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 20, 20, 5, 5, 25);
            Assert.Equal(5, BitmapCellColumns(testBitmap));
        }
        [Fact]
        public void TestBitmapCellCountIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 20, 20, 5, 5, 25);
            Assert.Equal(25, BitmapCellCount(testBitmap));
        }
        [Fact]
        public void TestBitmapCellHeightIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 20, 20, 5, 5, 25);
            Assert.Equal(20, BitmapCellHeight(testBitmap));
        }
        [Fact]
        public void TestBitmapCellOffsetIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 25, 25, 4, 4, 16);
            var offset = BitmapCellOffset(testBitmap, 5);
            Assert.Equal(25.0, offset.X);
            Assert.Equal(25.0, offset.Y);
        }
        [Fact]
        public void TestBitmapCellRectangleIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 25, 25, 4, 4, 16);
            var rect = BitmapCellRectangle(testBitmap);
            Assert.Equal(0.0, rect.X);
            Assert.Equal(0.0, rect.Y);
            Assert.Equal(25.0, rect.Width);
            Assert.Equal(25.0, rect.Height);
        }
        [Fact]
        public void TestBitmapCellRectangleAtPointIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 25, 25, 4, 4, 16);
            var rect = BitmapCellRectangle(testBitmap, PointAt(50.0, 50.0));
            Assert.Equal(50.0, rect.X);
            Assert.Equal(50.0, rect.Y);
            Assert.Equal(25.0, rect.Width);
            Assert.Equal(25.0, rect.Height);
        }
        [Fact]
        public void TestBitmapCellRowsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 20, 20, 5, 5, 25);
            Assert.Equal(5, BitmapCellRows(testBitmap));
        }
        [Fact]
        public void TestBitmapCellWidthIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 25, 25, 4, 4, 16);
            Assert.Equal(25, BitmapCellWidth(testBitmap));
        }
        [Fact]
        public void TestBitmapCenterIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            var testCenter = BitmapCenter(testBitmap);
            Assert.Equal(50.0, testCenter.X);
            Assert.Equal(50.0, testCenter.Y);
        }
        [Fact]
        public void TestBitmapFilenameIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            Assert.Equal("", BitmapFilename(testBitmap));
        }
        [Fact]
        public void TestBitmapHeightIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            Assert.Equal(100, BitmapHeight(testBitmap));
        }
        [Fact]
        public void TestBitmapHeightOfBitmapNamedIntegration() {
            CreateBitmap("bitmap_height", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            Assert.Equal(100, BitmapHeight("bitmap_height"));
        }
        [Fact]
        public void TestBitmapNameIntegration() {
            var testBitmap = CreateBitmap("bitmap_name", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            Assert.Equal("bitmap_name", BitmapName(testBitmap));
        }
        [Fact]
        public void TestBitmapNamedIntegration() {
            CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            Assert.NotNull(BitmapNamed("test_bitmap"));
            Assert.Null(BitmapNamed("nonexistent_bitmap"));
        }
        [Fact]
        public void TestBitmapRectangleOfCellIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 25, 25, 4, 4, 16);
            var rect = BitmapRectangleOfCell(testBitmap, 5);
            Assert.Equal(25.0, rect.X);
            Assert.Equal(25.0, rect.Y);
            Assert.Equal(25.0, rect.Width);
            Assert.Equal(25.0, rect.Height);
        }
        [Fact]
        public void TestBitmapSetCellDetailsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            BitmapSetCellDetails(testBitmap, 20, 20, 5, 5, 25);
            Assert.Equal(20, BitmapCellWidth(testBitmap));
            Assert.Equal(20, BitmapCellHeight(testBitmap));
            Assert.Equal(5, BitmapCellColumns(testBitmap));
            Assert.Equal(5, BitmapCellRows(testBitmap));
            Assert.Equal(25, BitmapCellCount(testBitmap));
        }
        [Fact]
        public void TestBitmapValidIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            Assert.True(BitmapValid(testBitmap));
            FreeBitmap(testBitmap);
            Assert.False(BitmapValid(testBitmap));
        }
        [Fact]
        public void TestBitmapWidthIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            Assert.Equal(100, BitmapWidth(testBitmap));
        }
        [Fact]
        public void TestBitmapWidthOfBitmapNamedIntegration() {
            CreateBitmap("bitmap_width", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            Assert.Equal(100, BitmapWidth("bitmap_width"));
        }
        [Fact]
        public void TestClearBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            DrawPixelOnBitmap(testBitmap, ColorBlack(), 50.0, 50.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            ClearBitmap(testBitmap, ColorWhite());
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 50.0, 50.0));
        }
        [Fact]
        public void TestClearBitmapNamedIntegration() {
            var testBitmap = CreateBitmap("bitmap_named", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            FillRectangleOnBitmap(testBitmap, ColorRed(), 0.0, 0.0, 100.0, 100.0);
            Assert.Equal(ColorRed(), GetPixel(testBitmap, 50.0, 50.0));
            ClearBitmap("bitmap_named", ColorWhite());
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 50.0, 50.0));
        }
        [Fact]
        public void TestCreateBitmapIntegration() {
            var testBitmap = CreateBitmap("bitmap_name1", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            Assert.NotNull(testBitmap);
            Assert.Equal(100, BitmapWidth(testBitmap));
            Assert.Equal(100, BitmapHeight(testBitmap));
            Assert.Equal("bitmap_name1", BitmapName(testBitmap));
        }
        [Fact]
        public void TestDrawBitmapIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorRed(), 0.0, 0.0, 50.0, 50.0);
            DrawBitmap(testBitmap, 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorRed(), GetPixel(testWindow, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 175.0, 175.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestDrawBitmapWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorRed(), 0.0, 0.0, 100.0, 100.0);
            DrawBitmap(testBitmap, 100.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorRed(), GetPixel(testWindow, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestDrawBitmapNamedIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorRed(), 0.0, 0.0, 100.0, 100.0);
            DrawBitmap("test_bitmap", 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorRed(), GetPixel(testWindow, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestDrawBitmapNamedWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorRed(), 0.0, 0.0, 100.0, 100.0);
            DrawBitmap("test_bitmap", 100.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorRed(), GetPixel(testWindow, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestDrawBitmapOnBitmapOnBitmapIntegration() {
            var destBitmap = CreateBitmap("test_destination", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            var sourceBitmap = CreateBitmap("test_source", 50, 50);
            ClearBitmap(destBitmap, ColorWhite());
            FillRectangleOnBitmap(sourceBitmap, ColorRed(), 0.0, 0.0, 50.0, 50.0);
            DrawBitmapOnBitmap(destBitmap, sourceBitmap, 25.0, 25.0);
            Assert.Equal(ColorRed(), GetPixel(destBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(destBitmap, 10.0, 10.0));
        }
        [Fact]
        public void TestDrawBitmapOnBitmapOnBitmapWithOptionsIntegration() {
            var destBitmap = CreateBitmap("test_destination", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            var sourceBitmap = CreateBitmap("test_source", 50, 50);
            ClearBitmap(destBitmap, ColorWhite());
            FillRectangleOnBitmap(sourceBitmap, ColorRed(), 0.0, 0.0, 50.0, 50.0);
            DrawBitmapOnBitmap(destBitmap, sourceBitmap, 25.0, 25.0, OptionDefaults());
            Assert.Equal(ColorRed(), GetPixel(destBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(destBitmap, 10.0, 10.0));
        }
        [Fact]
        public void TestDrawBitmapOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorRed(), 0.0, 0.0, 100.0, 100.0);
            DrawBitmapOnWindow(testWindow, testBitmap, 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorRed(), GetPixel(testWindow, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestDrawBitmapOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorRed(), 0.0, 0.0, 100.0, 100.0);
            DrawBitmapOnWindow(testWindow, testBitmap, 100.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorRed(), GetPixel(testWindow, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
            FreeBitmap(testBitmap);
        }
        [Fact]
        public void TestFreeAllBitmapsIntegration() {
            var bitmap1 = CreateBitmap("test_bitmap_1", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            var bitmap2 = CreateBitmap("test_bitmap_2", 100, 100);
            Assert.True(BitmapValid(bitmap1));
            Assert.True(BitmapValid(bitmap2));
            FreeAllBitmaps();
            Assert.False(BitmapValid(bitmap1));
            Assert.False(BitmapValid(bitmap2));
        }
        [Fact]
        public void TestFreeBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            Assert.True(BitmapValid(testBitmap));
            FreeBitmap(testBitmap);
            Assert.False(BitmapValid(testBitmap));
        }
        [Fact]
        public void TestHasBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            Assert.True(HasBitmap("test_bitmap"));
            FreeBitmap(testBitmap);
            Assert.False(HasBitmap("test_bitmap"));
        }
        [Fact]
        public void TestLoadBitmapIntegration() {
            var loadedBitmap = LoadBitmap("loaded_bitmap", "frog.png");
            using var cleanupBitmap = new BitmapCleanup();
            Assert.NotEqual(ColorWhite(), GetPixel(loadedBitmap, 50.0, 50.0));
        }
        [Fact]
        public void TestPixelDrawnAtPointPtIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawPixelOnBitmap(testBitmap, ColorBlack(), PointAt(50.0, 50.0));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 75.0, 75.0));
        }
        [Fact]
        public void TestPixelDrawnAtPointIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawPixelOnBitmap(testBitmap, ColorBlack(), 50.0, 50.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 75.0, 75.0));
        }
        [Fact]
        public void TestPixelDrawnAtPointInCellPtIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawPixelOnBitmap(testBitmap, ColorBlack(), PointAt(50.0, 50.0));
            BitmapSetCellDetails(testBitmap, 100, 100, 1, 1, 1);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 75.0, 50.0));
        }
        [Fact]
        public void TestPixelDrawnAtPointInCellIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawPixelOnBitmap(testBitmap, ColorBlack(), PointAt(50.0, 50.0));
            BitmapSetCellDetails(testBitmap, 100, 100, 1, 1, 1);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 75.0, 75.0));
        }
        [Fact]
        public void TestSetupCollisionMaskIntegration() {
            OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorBlack());
            var testCircle = CircleAt(120.0, 120.0, 30.0);
            var collisionBeforeMask = BitmapCircleCollision(testBitmap, 100.0, 100.0, testCircle);
            SetupCollisionMask(testBitmap);
            var collisionAfterMask = BitmapCircleCollision(testBitmap, 100.0, 100.0, testCircle);
            Assert.False(collisionBeforeMask);
            Assert.True(collisionAfterMask);
        }
        [Fact]
        public void TestDrawLineRecordIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawLine(ColorBlack(), LineFrom(PointAt(100.0, 100.0), PointAt(200.0, 200.0)));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawLineRecordWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawLine(ColorBlack(), LineFrom(PointAt(100.0, 100.0), PointAt(200.0, 200.0)), OptionLineWidth(3, OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawLinePointToPointIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawLine(ColorBlack(), PointAt(100.0, 100.0), PointAt(200.0, 200.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawLinePointToPointWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawLine(ColorBlack(), PointAt(100.0, 100.0), PointAt(200.0, 200.0), OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawLineIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawLine(ColorBlack(), 100.0, 100.0, 200.0, 200.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawLineWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawLine(ColorBlack(), 100.0, 100.0, 200.0, 200.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawLineOnBitmapRecordIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawLineOnBitmap(testBitmap, ColorBlack(), LineFrom(PointAt(10.0, 10.0), PointAt(90.0, 90.0)));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 95.0, 95.0));
        }
        [Fact]
        public void TestDrawLineOnBitmapRecordWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawLineOnBitmap(testBitmap, ColorBlack(), LineFrom(PointAt(10.0, 10.0), PointAt(90.0, 90.0)), OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 95.0, 50.0));
        }
        [Fact]
        public void TestDrawLineOnBitmapPointToPointIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawLineOnBitmap(testBitmap, ColorBlack(), PointAt(10.0, 10.0), PointAt(90.0, 90.0));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 0.0, 0.0));
        }
        [Fact]
        public void TestDrawLineOnBitmapPointToPointWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawLineOnBitmap(testBitmap, ColorBlack(), PointAt(10.0, 10.0), PointAt(90.0, 90.0), OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 10.0, 10.0));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 90.0, 90.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 5.0, 5.0));
        }
        [Fact]
        public void TestDrawLineOnBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawLineOnBitmap(testBitmap, ColorBlack(), 10.0, 10.0, 90.0, 90.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 95.0, 50.0));
        }
        [Fact]
        public void TestDrawLineOnBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawLineOnBitmap(testBitmap, ColorBlack(), 10.0, 10.0, 90.0, 90.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 5.0, 5.0));
        }
        [Fact]
        public void TestDrawLineOnWindowRecordIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testLine = LineFrom(PointAt(100.0, 100.0), PointAt(150.0, 150.0));
            DrawLineOnWindow(testWindow, ColorBlack(), testLine);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawLineOnWindowRecordWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testLine = LineFrom(PointAt(100.0, 100.0), PointAt(150.0, 150.0));
            DrawLineOnWindow(testWindow, ColorBlack(), testLine, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawLineOnWindowPointToPointIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawLineOnWindow(testWindow, ColorBlack(), PointAt(100.0, 100.0), PointAt(200.0, 200.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawLineOnWindowPointToPointWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawLineOnWindow(testWindow, ColorBlack(), PointAt(100.0, 100.0), PointAt(200.0, 200.0), OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawLineOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawLineOnWindow(testWindow, ColorBlack(), 100.0, 100.0, 200.0, 200.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawLineOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawLineOnWindow(testWindow, ColorBlack(), 100.0, 100.0, 200.0, 200.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawPixelAtPointIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixel(ColorBlack(), PointAt(100.0, 100.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawPixelAtPointWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixel(ColorBlack(), PointAt(100.0, 100.0), OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawPixelIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixel(ColorBlack(), 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawPixelWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixel(ColorBlack(), 100.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawPixelOnBitmapAtPointIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawPixelOnBitmap(testBitmap, ColorBlack(), PointAt(50.0, 50.0));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 0.0, 0.0));
        }
        [Fact]
        public void TestDrawPixelOnBitmapAtPointWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawPixelOnBitmap(testBitmap, ColorBlack(), PointAt(50.0, 50.0), OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 0.0, 0.0));
        }
        [Fact]
        public void TestDrawPixelOnBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawPixelOnBitmap(testBitmap, ColorBlack(), 50.0, 50.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 51.0, 50.0));
        }
        [Fact]
        public void TestDrawPixelOnBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawPixelOnBitmap(testBitmap, ColorBlack(), 50.0, 50.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 51.0, 50.0));
        }
        [Fact]
        public void TestDrawPixelOnWindowAtPointIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixelOnWindow(testWindow, ColorBlack(), PointAt(100.0, 100.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawPixelOnWindowAtPointWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixelOnWindow(testWindow, ColorBlack(), PointAt(100.0, 100.0), OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawPixelOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixelOnWindow(testWindow, ColorBlack(), 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawPixelOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixelOnWindow(testWindow, ColorBlack(), 100.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestGetPixelFromBitmapAtPointIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawPixelOnBitmap(testBitmap, ColorBlack(), PointAt(50.0, 50.0));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, PointAt(50.0, 50.0)));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, PointAt(49.0, 49.0)));
        }
        [Fact]
        public void TestGetPixelFromBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawPixelOnBitmap(testBitmap, ColorBlack(), 50.0, 50.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 49.0, 49.0));
        }
        [Fact]
        public void TestGetPixelAtPointIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixel(ColorBlack(), PointAt(100.0, 100.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestGetPixelIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixel(ColorBlack(), 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestGetPixelFromWindowAtPointIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixel(ColorBlack(), PointAt(100.0, 100.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, PointAt(100.0, 100.0)));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, PointAt(99.0, 99.0)));
        }
        [Fact]
        public void TestGetPixelFromWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixel(ColorBlack(), 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestGetPixelFromWindowAtPointFromWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixel(ColorBlack(), PointAt(100.0, 100.0));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixelFromWindow(testWindow, PointAt(100.0, 100.0)));
            Assert.Equal(ColorWhite(), GetPixelFromWindow(testWindow, PointAt(99.0, 99.0)));
        }
        [Fact]
        public void TestGetPixelFromWindowFromWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawPixel(ColorBlack(), 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixelFromWindow(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixelFromWindow(testWindow, 99.0, 99.0));
        }
        [Fact]
        public void TestDrawQuadIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var quad = QuadFrom(PointAt(100.0, 100.0), PointAt(200.0, 100.0), PointAt(100.0, 200.0), PointAt(200.0, 200.0));
            DrawQuad(ColorBlack(), quad);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 150.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 250.0, 250.0));
        }
        [Fact]
        public void TestDrawQuadWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var quad = QuadFrom(PointAt(100.0, 100.0), PointAt(200.0, 100.0), PointAt(100.0, 200.0), PointAt(200.0, 200.0));
            DrawQuad(ColorBlack(), quad, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 150.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 250.0, 250.0));
        }
        [Fact]
        public void TestDrawQuadOnBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var quad = QuadFrom(PointAt(10.0, 10.0), PointAt(90.0, 10.0), PointAt(10.0, 90.0), PointAt(90.0, 90.0));
            DrawQuadOnBitmap(testBitmap, ColorBlack(), quad);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 10.0, 10.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 5.0, 5.0));
        }
        [Fact]
        public void TestDrawQuadOnBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var quad = QuadFrom(PointAt(10.0, 10.0), PointAt(90.0, 10.0), PointAt(90.0, 90.0), PointAt(10.0, 90.0));
            DrawQuadOnBitmap(testBitmap, ColorBlack(), quad, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 10.0, 10.0));
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 5.0, 5.0));
        }
        [Fact]
        public void TestDrawQuadOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var quad = QuadFrom(PointAt(100.0, 100.0), PointAt(200.0, 100.0), PointAt(100.0, 200.0), PointAt(200.0, 200.0));
            DrawQuadOnWindow(testWindow, ColorBlack(), quad);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 150.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 250.0, 250.0));
        }
        [Fact]
        public void TestDrawQuadOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var quad = QuadFrom(PointAt(100.0, 100.0), PointAt(200.0, 100.0), PointAt(100.0, 200.0), PointAt(200.0, 200.0));
            DrawQuadOnWindow(testWindow, ColorBlack(), quad, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 150.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 250.0, 250.0));
        }
        [Fact]
        public void TestDrawRectangleRecordIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var rectangle = RectangleFrom(100.0, 100.0, 200.0, 150.0);
            DrawRectangle(ColorBlack(), rectangle);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 150.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 301.0, 251.0));
        }
        [Fact]
        public void TestDrawRectangleRecordWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var rectangle = RectangleFrom(100.0, 100.0, 200.0, 150.0);
            DrawRectangle(ColorBlack(), rectangle, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 150.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 350.0, 300.0));
        }
        [Fact]
        public void TestDrawRectangleIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawRectangle(ColorBlack(), 100.0, 100.0, 200.0, 150.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 301.0, 251.0));
        }
        [Fact]
        public void TestDrawRectangleWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawRectangle(ColorBlack(), 100.0, 100.0, 200.0, 150.0, OptionLineWidth(3, OptionDefaults()));
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 101.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 150.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 301.0, 251.0));
        }
        [Fact]
        public void TestDrawRectangleOnBitmapRecordIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var rectangle = RectangleFrom(50.0, 50.0, 20.0, 30.0);
            DrawRectangleOnBitmap(testBitmap, ColorBlack(), rectangle);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 80.0, 90.0));
        }
        [Fact]
        public void TestDrawRectangleOnBitmapRecordWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var rectangle = RectangleFrom(50.0, 50.0, 20.0, 20.0);
            DrawRectangleOnBitmap(testBitmap, ColorBlack(), rectangle, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 75.0, 75.0));
        }
        [Fact]
        public void TestDrawRectangleOnBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawRectangleOnBitmap(testBitmap, ColorBlack(), 50.0, 50.0, 20.0, 20.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 75.0, 75.0));
        }
        [Fact]
        public void TestDrawRectangleOnBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawRectangleOnBitmap(testBitmap, ColorBlack(), 50.0, 50.0, 20.0, 20.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 75.0, 75.0));
        }
        [Fact]
        public void TestDrawRectangleOnWindowRecordIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var rectangle = RectangleFrom(100.0, 100.0, 50.0, 50.0);
            DrawRectangleOnWindow(testWindow, ColorBlack(), rectangle);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 200.0, 200.0));
        }
        [Fact]
        public void TestDrawRectangleOnWindowRecordWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var rectangle = RectangleFrom(100.0, 100.0, 50.0, 50.0);
            DrawRectangleOnWindow(testWindow, ColorBlack(), rectangle, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 175.0, 175.0));
        }
        [Fact]
        public void TestDrawRectangleOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawRectangleOnWindow(testWindow, ColorBlack(), 100.0, 100.0, 50.0, 50.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 200.0, 200.0));
        }
        [Fact]
        public void TestDrawRectangleOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawRectangleOnWindow(testWindow, ColorBlack(), 100.0, 100.0, 50.0, 50.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 200.0, 200.0));
        }
        [Fact]
        public void TestFillQuadIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var quad = QuadFrom(PointAt(100.0, 100.0), PointAt(300.0, 100.0), PointAt(100.0, 300.0), PointAt(300.0, 300.0));
            FillQuad(ColorBlack(), quad);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 200.0, 200.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 400.0));
        }
        [Fact]
        public void TestFillQuadWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var quad = QuadFrom(PointAt(100.0, 100.0), PointAt(300.0, 100.0), PointAt(100.0, 300.0), PointAt(300.0, 300.0));
            FillQuad(ColorBlack(), quad, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 200.0, 200.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 400.0, 400.0));
        }
        [Fact]
        public void TestFillQuadOnBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var quad = QuadFrom(PointAt(10.0, 10.0), PointAt(90.0, 10.0), PointAt(10.0, 90.0), PointAt(90.0, 90.0));
            FillQuadOnBitmap(testBitmap, ColorBlack(), quad);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 0.0, 0.0));
        }
        [Fact]
        public void TestFillQuadOnBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var quad = QuadFrom(PointAt(10.0, 10.0), PointAt(90.0, 10.0), PointAt(90.0, 90.0), PointAt(10.0, 90.0));
            FillQuadOnBitmap(testBitmap, ColorBlack(), quad, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 95.0, 50.0));
        }
        [Fact]
        public void TestFillQuadOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var quad = QuadFrom(PointAt(100.0, 100.0), PointAt(200.0, 100.0), PointAt(100.0, 200.0), PointAt(200.0, 200.0));
            FillQuadOnWindow(testWindow, ColorBlack(), quad);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 250.0, 250.0));
        }
        [Fact]
        public void TestFillQuadOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var quad = QuadFrom(PointAt(100.0, 100.0), PointAt(200.0, 100.0), PointAt(200.0, 200.0), PointAt(100.0, 200.0));
            FillQuadOnWindow(testWindow, ColorBlack(), quad, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 250.0, 150.0));
        }
        [Fact]
        public void TestFillRectangleRecordIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var rectangle = RectangleFrom(100.0, 100.0, 200.0, 150.0);
            FillRectangle(ColorBlack(), rectangle);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 350.0, 275.0));
        }
        [Fact]
        public void TestFillRectangleRecordWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var rectangle = RectangleFrom(100.0, 100.0, 200.0, 150.0);
            FillRectangle(ColorBlack(), rectangle, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 350.0, 275.0));
        }
        [Fact]
        public void TestFillRectangleIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillRectangle(ColorBlack(), 100.0, 100.0, 200.0, 150.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 301.0, 251.0));
        }
        [Fact]
        public void TestFillRectangleWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillRectangle(ColorBlack(), 100.0, 100.0, 200.0, 150.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 301.0, 251.0));
        }
        [Fact]
        public void TestFillRectangleOnBitmapRecordIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var rectangle = RectangleFrom(25.0, 25.0, 50.0, 50.0);
            FillRectangleOnBitmap(testBitmap, ColorBlack(), rectangle);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 10.0, 10.0));
        }
        [Fact]
        public void TestFillRectangleOnBitmapRecordWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var rectangle = RectangleFrom(25.0, 25.0, 50.0, 50.0);
            FillRectangleOnBitmap(testBitmap, ColorBlack(), rectangle, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 10.0, 10.0));
        }
        [Fact]
        public void TestFillRectangleOnBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorBlack(), 25.0, 25.0, 50.0, 50.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 75.0, 75.0));
        }
        [Fact]
        public void TestFillRectangleOnBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillRectangleOnBitmap(testBitmap, ColorBlack(), 25.0, 25.0, 50.0, 50.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 10.0, 10.0));
        }
        [Fact]
        public void TestFillRectangleOnWindowRecordIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var rectangle = RectangleFrom(100.0, 100.0, 200.0, 150.0);
            FillRectangleOnWindow(testWindow, ColorBlack(), rectangle);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 350.0, 275.0));
        }
        [Fact]
        public void TestFillRectangleOnWindowRecordWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var rectangle = RectangleFrom(100.0, 100.0, 200.0, 150.0);
            FillRectangleOnWindow(testWindow, ColorBlack(), rectangle, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 350.0, 275.0));
        }
        [Fact]
        public void TestFillRectangleOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillRectangleOnWindow(testWindow, ColorBlack(), 100.0, 100.0, 50.0, 50.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 175.0, 175.0));
        }
        [Fact]
        public void TestFillRectangleOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillRectangleOnWindow(testWindow, ColorBlack(), 100.0, 100.0, 50.0, 50.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 125.0, 125.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 175.0, 175.0));
        }
        [Fact]
        public void TestDrawTextFontAsStringIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            RefreshScreen();
            LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            DrawText("Test Text", ColorBlack(), "hara", 24, 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 120.0, 110.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextWithOptionsFontAsStringIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            DrawText("Test Text", ColorBlack(), "hara", 24, 100.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 120.0, 110.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextNoFontNoSizeIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawText("Test Text", ColorBlack(), 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 105.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextNoFontNoSizeWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawText("Test Text", ColorBlack(), 100.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 105.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            DrawText("Test Text", ColorBlack(), FontNamed("hara"), 24, 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 120.0, 110.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            DrawText("Test Text", ColorBlack(), FontNamed("hara"), 24, 100.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 120.0, 110.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextOnBitmapFontAsStringIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            DrawTextOnBitmap(testBitmap, "Test Text", ColorBlack(), "hara", 24, 100.0, 100.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 120.0, 110.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextOnBitmapWithOptionsFontAsStringIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            DrawTextOnBitmap(testBitmap, "Test Text", ColorBlack(), "hara", 24, 100.0, 100.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 120.0, 110.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextOnBitmapNoFontNoSizeIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawTextOnBitmap(testBitmap, "Test Text", ColorBlack(), 100.0, 100.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 105.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextOnBitmapNoFontNoSizeWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawTextOnBitmap(testBitmap, "Test Text", ColorBlack(), 100.0, 100.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 105.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextOnBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            DrawTextOnBitmap(testBitmap, "Test Text", ColorBlack(), FontNamed("hara"), 24, 100.0, 100.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 120.0, 110.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextOnBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 200, 200);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            DrawTextOnBitmap(testBitmap, "Test Text", ColorBlack(), FontNamed("hara"), 24, 100.0, 100.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 120.0, 110.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextOnWindowFontAsStringIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            DrawTextOnWindow(testWindow, "Test Text", ColorBlack(), "hara", 24, 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 120.0, 110.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextOnWindowWithOptionsFontAsStringIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            DrawTextOnWindow(testWindow, "Test Text", ColorBlack(), "hara", 24, 100.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 120.0, 110.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextOnWindowNoFontNoSizeIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawTextOnWindow(testWindow, "Test Text", ColorBlack(), 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 105.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextOnWindowNoFontNoSizeWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawTextOnWindow(testWindow, "Test Text", ColorBlack(), 100.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 105.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            var testFont = FontNamed("hara");
            FontLoadSize(testFont, 24);
            DrawTextOnWindow(testWindow, "Test Text", ColorBlack(), testFont, 24, 100.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 120.0, 110.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 90.0, 90.0));
        }
        [Fact]
        public void TestDrawTextOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testFont = LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            DrawTextOnWindow(testWindow, "Test Text", ColorBlack(), testFont, 24, 100.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 120.0, 110.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 90.0, 90.0));
        }
        [Fact]
        public void TestFontHasSizeNameAsStringIntegration() {
            LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            FontLoadSize("hara", 12);
            Assert.True(FontHasSize("hara", 12));
            Assert.False(FontHasSize("nonexistent_font", 12));
        }
        [Fact]
        public void TestFontHasSizeIntegration() {
            var testFont = LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            FontLoadSize(testFont, 12);
            Assert.True(FontHasSize(testFont, 12));
            Assert.False(FontHasSize(testFont, 999));
        }
        [Fact]
        public void TestFontLoadSizeNameAsStringIntegration() {
            LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            FontLoadSize("test_font", 12);
            Assert.True(FontHasSize("test_font", 12));
        }
        [Fact]
        public void TestFontLoadSizeIntegration() {
            var testFont = LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            FontLoadSize(testFont, 12);
            Assert.True(FontHasSize(testFont, 12));
        }
        [Fact]
        public void TestFontNamedIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            var testFont = FontNamed("hara");
            DrawText("Test Text", ColorBlack(), testFont, 24, 100.0, 100.0);
            RefreshScreen();
            Assert.NotNull(testFont);
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 120.0, 110.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 90.0, 90.0));
        }
        [Fact]
        public void TestFreeAllFontsIntegration() {
            LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            Assert.True(HasFont("test_font"));
            FreeAllFonts();
            Assert.False(HasFont("test_font"));
        }
        [Fact]
        public void TestFreeFontIntegration() {
            var testFont = LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            Assert.True(HasFont(testFont));
            FreeFont(testFont);
            Assert.False(HasFont(testFont));
        }
        [Fact]
        public void TestGetFontStyleNameAsStringIntegration() {
            LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            var style = GetFontStyle("test_font");
            Assert.Equal(FontStyle.BoldFont, style);
        }
        [Fact]
        public void TestGetFontStyleIntegration() {
            var testFont = LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            var style = GetFontStyle(testFont);
            Assert.Equal(FontStyle.BoldFont, style);
        }
        [Fact]
        public void TestGetSystemFontIntegration() {
            var systemFont = GetSystemFont();
            Assert.NotNull(systemFont);
        }
        [Fact]
        public void TestHasFontIntegration() {
            var testFont = LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            Assert.True(HasFont(testFont));
            FreeFont(testFont);
            Assert.False(HasFont(testFont));
        }
        [Fact]
        public void TestHasFontNameAsStringIntegration() {
            LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            Assert.True(HasFont("test_font"));
            Assert.False(HasFont("nonexistent_font"));
        }
        [Fact]
        public void TestLoadFontIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var testFont = LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            DrawText("Test Text", ColorBlack(), testFont, 24, 100.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.True(HasFont("test_font"));
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 105.0, 105.0));
        }
        [Fact]
        public void TestSetFontStyleNameAsStringIntegration() {
            LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            SetFontStyle("test_font", FontStyle.BoldFont);
            Assert.Equal(FontStyle.BoldFont, GetFontStyle("test_font"));
        }
        [Fact]
        public void TestSetFontStyleIntegration() {
            var testFont = LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            SetFontStyle(testFont, FontStyle.BoldFont);
            Assert.Equal(FontStyle.BoldFont, GetFontStyle(testFont));
        }
        [Fact]
        public void TestTextHeightFontNamedIntegration() {
            LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            FontLoadSize("test_font", 24);
            var height = TextHeight("Test Text", "test_font", 24);
            Assert.True(height > 0);
            Assert.True(height >= 24);
        }
        [Fact]
        public void TestTextHeightIntegration() {
            var testFont = LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            FontLoadSize(testFont, 24);
            var height = TextHeight("Test Text", testFont, 24);
            Assert.True(height > 0);
            Assert.True(height >= 24);
        }
        [Fact]
        public void TestTextWidthFontNamedIntegration() {
            var testFont = LoadFont("hara", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            FontLoadSize(testFont, 12);
            var width = TextWidth("Test Text", "hara", 24);
            Assert.True(width > 0);
            Assert.True(width >= TextHeight("Test Text", "hara", 24));
        }
        [Fact]
        public void TestTextWidthIntegration() {
            var testFont = LoadFont("test_font", "hara.ttf");
            using var cleanupFont = new FontCleanup();
            FontLoadSize(testFont, 12);
            var width = TextWidth("Test Text", testFont, 24);
            Assert.True(width > 0);
            Assert.True(width >= TextHeight("Text Height", testFont, 24));
        }
        [Fact]
        public void TestDrawTriangleRecordIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var triangle = TriangleFrom(PointAt(100.0, 100.0), PointAt(200.0, 200.0), PointAt(150.0, 300.0));
            DrawTriangle(ColorBlack(), triangle);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 150.0, 200.0));
        }
        [Fact]
        public void TestDrawTriangleRecordWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var triangle = TriangleFrom(PointAt(100.0, 100.0), PointAt(200.0, 200.0), PointAt(150.0, 300.0));
            DrawTriangle(ColorBlack(), triangle, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 150.0, 200.0));
        }
        [Fact]
        public void TestDrawTriangleIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawTriangle(ColorBlack(), 100.0, 100.0, 200.0, 300.0, 300.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 200.0, 150.0));
        }
        [Fact]
        public void TestDrawTriangleWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawTriangle(ColorBlack(), 100.0, 100.0, 200.0, 200.0, 150.0, 300.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 150.0, 200.0));
        }
        [Fact]
        public void TestDrawTriangleOnBitmapRecordIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var triangle = TriangleFrom(PointAt(25.0, 25.0), PointAt(75.0, 25.0), PointAt(50.0, 75.0));
            DrawTriangleOnBitmap(testBitmap, ColorBlack(), triangle);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 25.0, 25.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 50.0, 50.0));
        }
        [Fact]
        public void TestDrawTriangleOnBitmapRecordWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var triangle = TriangleFrom(PointAt(25.0, 25.0), PointAt(75.0, 25.0), PointAt(50.0, 75.0));
            DrawTriangleOnBitmap(testBitmap, ColorBlack(), triangle, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 25.0, 25.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 50.0, 50.0));
        }
        [Fact]
        public void TestDrawTriangleOnBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawTriangleOnBitmap(testBitmap, ColorBlack(), 25.0, 25.0, 75.0, 25.0, 50.0, 75.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 25.0, 25.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 50.0, 50.0));
        }
        [Fact]
        public void TestDrawTriangleOnBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            DrawTriangleOnBitmap(testBitmap, ColorBlack(), 25.0, 25.0, 75.0, 25.0, 50.0, 75.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 25.0, 25.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 50.0, 50.0));
        }
        [Fact]
        public void TestDrawTriangleOnWindowRecordIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var triangle = TriangleFrom(PointAt(100.0, 100.0), PointAt(200.0, 200.0), PointAt(150.0, 300.0));
            DrawTriangleOnWindow(testWindow, ColorBlack(), triangle);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
        }
        [Fact]
        public void TestDrawTriangleOnWindowRecordWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var triangle = TriangleFrom(PointAt(100.0, 100.0), PointAt(200.0, 200.0), PointAt(150.0, 250.0));
            DrawTriangleOnWindow(testWindow, ColorBlack(), triangle, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
        }
        [Fact]
        public void TestDrawTriangleOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawTriangleOnWindow(testWindow, ColorBlack(), 100.0, 100.0, 200.0, 300.0, 300.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
        }
        [Fact]
        public void TestDrawTriangleOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            DrawTriangleOnWindow(testWindow, ColorBlack(), 100.0, 100.0, 200.0, 200.0, 150.0, 300.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 100.0, 100.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
        }
        [Fact]
        public void TestFillTriangleRecordIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var triangle = TriangleFrom(PointAt(100.0, 100.0), PointAt(200.0, 300.0), PointAt(300.0, 100.0));
            FillTriangle(ColorBlack(), triangle);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 200.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
        }
        [Fact]
        public void TestFillTriangleRecordWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var triangle = TriangleFrom(PointAt(100.0, 100.0), PointAt(200.0, 300.0), PointAt(300.0, 100.0));
            FillTriangle(ColorBlack(), triangle, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 200.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
        }
        [Fact]
        public void TestFillTriangleIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillTriangle(ColorBlack(), 100.0, 100.0, 200.0, 300.0, 300.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 200.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
        }
        [Fact]
        public void TestFillTriangleWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillTriangle(ColorRed(), 100.0, 100.0, 200.0, 300.0, 300.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorRed(), GetPixel(testWindow, 150.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 350.0, 150.0));
        }
        [Fact]
        public void TestFillTriangleOnBitmapRecordIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var triangle = TriangleFrom(PointAt(25.0, 25.0), PointAt(75.0, 25.0), PointAt(50.0, 75.0));
            FillTriangleOnBitmap(testBitmap, ColorBlack(), triangle);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 0.0, 0.0));
        }
        [Fact]
        public void TestFillTriangleOnBitmapRecordWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            var triangle = TriangleFrom(PointAt(25.0, 25.0), PointAt(75.0, 25.0), PointAt(50.0, 75.0));
            FillTriangleOnBitmap(testBitmap, ColorBlack(), triangle, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 10.0, 10.0));
        }
        [Fact]
        public void TestFillTriangleOnBitmapIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillTriangleOnBitmap(testBitmap, ColorBlack(), 25.0, 25.0, 75.0, 25.0, 50.0, 75.0);
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 0.0, 0.0));
        }
        [Fact]
        public void TestFillTriangleOnBitmapWithOptionsIntegration() {
            var testBitmap = CreateBitmap("test_bitmap", 100, 100);
            using var cleanupBitmap = new BitmapCleanup();
            ClearBitmap(testBitmap, ColorWhite());
            FillTriangleOnBitmap(testBitmap, ColorBlack(), 25.0, 25.0, 75.0, 25.0, 50.0, 75.0, OptionDefaults());
            Assert.Equal(ColorBlack(), GetPixel(testBitmap, 50.0, 50.0));
            Assert.Equal(ColorWhite(), GetPixel(testBitmap, 0.0, 0.0));
        }
        [Fact]
        public void TestFillTriangleOnWindowRecordIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var triangle = TriangleFrom(PointAt(100.0, 100.0), PointAt(200.0, 300.0), PointAt(300.0, 100.0));
            FillTriangleOnWindow(testWindow, ColorBlack(), triangle);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 200.0, 200.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
        }
        [Fact]
        public void TestFillTriangleOnWindowRecordWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            var triangle = TriangleFrom(PointAt(100.0, 100.0), PointAt(200.0, 300.0), PointAt(300.0, 100.0));
            FillTriangleOnWindow(testWindow, ColorBlack(), triangle, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 200.0, 200.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
        }
        [Fact]
        public void TestFillTriangleOnWindowIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillTriangleOnWindow(testWindow, ColorBlack(), 100.0, 100.0, 200.0, 300.0, 300.0, 100.0);
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 200.0, 200.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 50.0, 50.0));
        }
        [Fact]
        public void TestFillTriangleOnWindowWithOptionsIntegration() {
            var testWindow = OpenWindow("Test Window", 800, 600);
            using var cleanupWindow = new WindowCleanup();
            ClearWindow(testWindow, ColorWhite());
            FillTriangleOnWindow(testWindow, ColorBlack(), 100.0, 100.0, 200.0, 300.0, 300.0, 100.0, OptionDefaults());
            RefreshScreen();
            Assert.Equal(ColorBlack(), GetPixel(testWindow, 150.0, 150.0));
            Assert.Equal(ColorWhite(), GetPixel(testWindow, 350.0, 150.0));
        }
    }
}
