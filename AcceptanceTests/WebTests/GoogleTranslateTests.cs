using BrowserUserSimulator.Users;
using NUnit.Framework;

namespace AcceptanceTests.WebTests
{
    [Parallelizable]
    class GoogleTranslateTests : BaseWebTest
    {
        [Test]
        public void CanDetectSpanishAutomatically()
        {
            usersInCurrentSession.Add(new GoogleTranslateUser(ConfigManager.BrowserName));
            var googleTranslateUser = (GoogleTranslateUser) usersInCurrentSession[0];
            googleTranslateUser.GoogleTranslatePage.Open();
            googleTranslateUser.GoogleTranslatePage.TypeInSourceField(
                "Buenos dias, señor");
            Assert.That(
                googleTranslateUser.GoogleTranslatePage.Translation,
                Is.EqualTo("Good morning sir"));
        }

        [Test]
        public void GetPath()
        {
            string date = System.DateTime.Now.ToString("yyyyMMdd-HHmmssfff");
            string testName = NUnit.Framework.TestContext.CurrentContext.Test.Name;
        }
    }
}
