using System;
using System.IO;
using Xunit;
using static SplashKitSDK.SplashKit;

namespace SplashKitTests
{
    public class TestAnimations
    {
        [Fact]
        public void TestAnimationCountIntegration()
        {
            var script = LoadAnimationScript("kermit", "kermit.txt");
            var count = AnimationCount(script);
            Assert.True(count > 0);
            FreeAnimationScript(script);
        }
        [Fact]
        public void TestAnimationCurrentCellIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            var currentCell = AnimationCurrentCell(anim);
            Assert.True(currentCell > -1);
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestAnimationCurrentVectorIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            var currentVector = AnimationCurrentVector(anim);
            Assert.Equal(0.0, currentVector.X);
            Assert.Equal(0.0, currentVector.Y);
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestAnimationEndedIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            Assert.False(AnimationEnded(anim));
            for (int i = 0; i < 50; i++) {
                UpdateAnimation(anim, 100.0f);
            }
            Assert.False(AnimationEnded(anim));
            UpdateAnimation(anim);
            Assert.True(AnimationEnded(anim));
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestAnimationEnteredFrameIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "walkfront");
            UpdateAnimation(anim, 20f);
            Assert.True(AnimationEnteredFrame(anim));
            UpdateAnimation(anim);
            Assert.False(AnimationEnteredFrame(anim));
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestAnimationFrameTimeIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "walkfront");
            UpdateAnimation(anim);
            var frameTime = AnimationFrameTime(anim);
            Assert.True(frameTime > 0.0f);
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestAnimationIndexIntegration()
        {
            var script = LoadAnimationScript("kermit", "kermit.txt");
            var index = AnimationIndex(script, "walkfront");
            Assert.True(index > -1);
            var nonExistentIndex = AnimationIndex(script, "NonExistentAnimation");
            Assert.Equal(-1, nonExistentIndex);
            FreeAnimationScript(script);
        }
        [Fact]
        public void TestAnimationNameIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            var animName = AnimationName(anim);
            Assert.Equal("moonwalkback", animName);
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestAnimationScriptNameIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var scriptName = AnimationScriptName(kermitScript);
            Assert.Equal("kermit", scriptName);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestAnimationScriptNamedIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var loadedScript = AnimationScriptNamed("kermit");
            Assert.NotNull(loadedScript);
            Assert.Equal(loadedScript, loadedScript);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestAssignAnimationWithScriptIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            AssignAnimation(anim, kermitScript, "walkfront");
            Assert.Equal("walkfront", AnimationName(anim));
            FreeAnimationScript(kermitScript);
            FreeAnimation(anim);
        }
        [Fact]
        public void TestAssignAnimationWithScriptAndSoundIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "walkfront");
            AssignAnimation(anim, kermitScript, "walkleft", true);
            Assert.Equal("walkleft", AnimationName(anim));
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestAssignAnimationIndexWithScriptIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            AssignAnimation(anim, kermitScript, 0);
            Assert.Equal("walkfront", AnimationName(anim));
            FreeAnimationScript(kermitScript);
            FreeAnimation(anim);
        }
        [Fact]
        public void TestAssignAnimationIndexWithScriptAndSoundIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            AssignAnimation(anim, kermitScript, 0, true);
            Assert.Equal("walkfront", AnimationName(anim));
            FreeAnimationScript(kermitScript);
            FreeAnimation(anim);
        }
        [Fact]
        public void TestAssignAnimationWithScriptNamedIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            AssignAnimation(anim, "kermit", "walkfront");
            Assert.Equal("walkfront", AnimationName(anim));
            FreeAnimationScript(kermitScript);
            FreeAnimation(anim);
        }
        [Fact]
        public void TestAssignAnimationWithScriptNamedAndSoundIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "walkfront");
            AssignAnimation(anim, "kermit", "walkfront", true);
            Assert.Equal("walkfront", AnimationName(anim));
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestAssignAnimationIndexIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            AssignAnimation(anim, 0);
            Assert.Equal(0, AnimationCurrentCell(anim));
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestAssignAnimationIndexWithSoundIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback", false);
            AssignAnimation(anim, 0, true);
            Assert.True(AnimationEnteredFrame(anim));
            FreeAnimationScript(kermitScript);
            FreeAnimation(anim);
        }
        [Fact]
        public void TestAssignAnimationIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            AssignAnimation(anim, "walkfront");
            Assert.Equal("walkfront", AnimationName(anim));
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestAssignAnimationWithSoundIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            AssignAnimation(anim, "walkfront", true);
            Assert.Equal("walkfront", AnimationName(anim));
            FreeAnimationScript(kermitScript);
            FreeAnimation(anim);
        }
        [Fact]
        public void TestCreateAnimationFromIndexWithSoundIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, 0, true);
            Assert.NotNull(anim);
            var animName = AnimationName(anim);
            Assert.Equal("walkfront", animName);
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestCreateAnimationIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            Assert.NotNull(anim);
            var animName = AnimationName(anim);
            Assert.Equal("moonwalkback", animName);
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestCreateAnimationWithSoundIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback", true);
            Assert.NotNull(anim);
            var animName = AnimationName(anim);
            Assert.Equal("moonwalkback", animName);
            FreeAnimationScript(kermitScript);
            FreeAnimation(anim);
        }
        [Fact]
        public void TestCreateAnimationFromScriptNamedIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation("kermit", "moonwalkback");
            Assert.NotNull(anim);
            var animName = AnimationName(anim);
            Assert.Equal("moonwalkback", animName);
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestCreateAnimationFromScriptNamedWithSoundIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation("", "moonwalkback", true);
            Assert.NotNull(anim);
            var animName = AnimationName(anim);
            Assert.Equal("moonwalkback", animName);
            FreeAnimationScript(kermitScript);
            FreeAnimation(anim);
        }
        [Fact]
        public void TestFreeAllAnimationScriptsIntegration()
        {
            LoadAnimationScript("kermitq", "kermit.txt");
            LoadAnimationScript("kermit2", "kermit.txt");
            Assert.True(HasAnimationScript("kermit1"));
            Assert.True(HasAnimationScript("kermit2"));
            FreeAllAnimationScripts();
            Assert.False(HasAnimationScript("kermit1"));
            Assert.False(HasAnimationScript("kermit2"));
        }
        [Fact]
        public void TestFreeAnimationIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            FreeAnimation(anim);
            Assert.Equal("", AnimationName(anim));
            Assert.True(AnimationEnded(anim));
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestFreeAnimationScriptIntegration()
        {
            var script = LoadAnimationScript("kermit", "kermit.txt");
            Assert.NotNull(script);
            FreeAnimationScript(script);
            var scriptExists = HasAnimationScript("kermit");
            Assert.False(scriptExists);
        }
        [Fact]
        public void TestFreeAnimationScriptWithNameIntegration()
        {
            LoadAnimationScript("kermit", "kermit.txt");
            Assert.True(HasAnimationScript("kermit"));
            FreeAnimationScript("kermit");
            Assert.False(HasAnimationScript("kermit"));
        }
        [Fact]
        public void TestHasAnimationNamedIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var hasWalkfront = HasAnimationNamed(kermitScript, "walkfront");
            Assert.True(hasWalkfront);
            var hasNonexistent = HasAnimationNamed(kermitScript, "NonExistentAnimation");
            Assert.False(hasNonexistent);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestHasAnimationScriptIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            Assert.True(HasAnimationScript("kermit"));
            FreeAnimationScript(kermitScript);
            Assert.False(HasAnimationScript("kermit"));
        }
        [Fact]
        public void TestLoadAnimationScriptIntegration()
        {
            var loadedScript = LoadAnimationScript("test_animation", "kermit.txt");
            Assert.NotNull(loadedScript);
            var scriptName = AnimationScriptName(loadedScript);
            Assert.Equal("test_animation", scriptName);
            FreeAnimationScript(loadedScript);
            var scriptExists = HasAnimationScript("test_animation");
            Assert.False(scriptExists);
        }
        [Fact]
        public void TestRestartAnimationIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            for (int i = 0; i < 50; i++) {
                UpdateAnimation(anim, 100.0f);
            }
            var animEnded = AnimationEnded(anim);
            Assert.True(animEnded);
            RestartAnimation(anim);
            var animEndedAfterRestart = AnimationEnded(anim);
            Assert.False(animEndedAfterRestart);
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestRestartAnimationWithSoundIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback", true);
            UpdateAnimation(anim);
            RestartAnimation(anim, true);
            Assert.Equal(3, AnimationCurrentCell(anim));
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestUpdateAnimationPercentWithSoundIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            UpdateAnimation(anim, 0.5f, true);
            Assert.True(AnimationFrameTime(anim) > 0.0f);
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestUpdateAnimationIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "moonwalkback");
            UpdateAnimation(anim);
            Assert.NotEqual(0, AnimationCurrentCell(anim));
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
        [Fact]
        public void TestUpdateAnimationPercentIntegration()
        {
            var kermitScript = LoadAnimationScript("kermit", "kermit.txt");
            var anim = CreateAnimation(kermitScript, "walkfront");
            UpdateAnimation(anim, 0.5f);
            Assert.True(AnimationFrameTime(anim) > 0.0f);
            FreeAnimation(anim);
            FreeAnimationScript(kermitScript);
        }
    }
}
