using BrowserUserSimulator;
using NUnit.Framework;
using System.Collections.Generic;

namespace AcceptanceTests.WebTests
{
    [TestFixture]
    public abstract class BaseWebTest
    {
        protected List<BaseWebUser> usersInCurrentSession = new List<BaseWebUser>();

        [TearDown]
        public void TestTearDown()
        {
            bool testPassed =
                TestContext.CurrentContext.Result.Outcome == NUnit.Framework.Interfaces.ResultState.Success;
            string screeshotPaths = string.Empty;
            foreach (var user in usersInCurrentSession)
            {
                if (!testPassed)
                {
                    string testName = TestContext.CurrentContext.Test.Name;
                    string fullDate = System.DateTime.Now.ToString("yyyyMMdd-HHmmssfff");
                    string fullScreenshotPath = $"{ConfigManager.ScreenshotsDirectory}{testName}{fullDate}.png";
                    user.SaveScreenshot(fullScreenshotPath);
                    screeshotPaths += $"\n{fullScreenshotPath}";
                }
                user.Dispose();
            }
            if (!testPassed)
            {
                Assert.Fail($"Test failed. See screenshots at: {screeshotPaths}");
            }
        }
    }
}
