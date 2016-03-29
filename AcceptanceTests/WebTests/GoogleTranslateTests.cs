using BrowserUserSimulator.Users;
using NUnit.Framework;

namespace AcceptanceTests.WebTests
{
    class GoogleTranslateTests : BaseWebTest
    {
        [Test]
        public void CanDetectSpanishAutomatically()
        {
            usersInTestSession.Add(new GoogleTranslateUser(ConfigManager.BrowserName));
            var googleTranslateUser = (GoogleTranslateUser)usersInTestSession[0];
            googleTranslateUser.GoogleTranslatePage.Open();
            googleTranslateUser.GoogleTranslatePage.TypeInSourceField(
                "Buenos dias, señor");
            Assert.That(
                googleTranslateUser.GoogleTranslatePage.Translation,
                Is.EqualTo("Good morning sir"));
        }
    }
}
