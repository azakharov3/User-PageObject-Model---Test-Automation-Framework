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
            usersInCurrentSession.ForEach(user => user.Dispose());
        }
    }
}
