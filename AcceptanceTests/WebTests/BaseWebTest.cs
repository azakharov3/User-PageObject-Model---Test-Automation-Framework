using BrowserUserSimulator;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AcceptanceTests.WebTests
{
    [TestFixture]
    public abstract class BaseWebTest
    {
        protected List<BaseWebUser> usersInTestSession = new List<BaseWebUser>();

        [TearDown]
        public void TestTeardown()
        {
            Console.WriteLine("Closing {0} browser session(s)", usersInTestSession.Count);
            usersInTestSession.ForEach(user => user.CloseBrowser());
        }
    }
}
