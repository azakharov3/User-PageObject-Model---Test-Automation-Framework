using BrowserUserSimulator.Users;
using NUnit.Framework;

namespace AcceptanceTests.WebTests
{
    [Parallelizable]
    class GoogleTranslateTests : BaseWebTest
    {
        private GoogleTranslateUser googleTranslateUser;

        [SetUp]
        public void GoogleTranslateTestsSetup()
        {
            usersInCurrentSession.Add(new GoogleTranslateUser(ConfigManager.BrowserName));
            googleTranslateUser = (GoogleTranslateUser)usersInCurrentSession[0];
        }

        [Test]
        public void CanDetectSpanishAutomatically()
        {
            googleTranslateUser.GoogleTranslatePage.Open();
            googleTranslateUser.GoogleTranslatePage.TypeInSourceField(
                "Buenos dias, señor");
            Assert.That(
                googleTranslateUser.GoogleTranslatePage.Translation,
                Is.EqualTo("Good morning sir"));
        }

        [Test]
        public void TestThatFailsIntentionally()
        {
            googleTranslateUser.GoogleTranslatePage.Open();
            googleTranslateUser.GoogleTranslatePage.TypeInSourceField(
                "Buenos dias, señor");
            Assert.That(
                googleTranslateUser.GoogleTranslatePage.Translation,
                Is.EqualTo("Good morning mister"));
        }
    }
}
