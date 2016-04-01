using BrowserUserSimulator.Users;
using NUnit.Framework;
using System.Linq;

namespace AcceptanceTests.WebTests
{
    [Parallelizable]
    public class GoogleSearchTests : BaseWebTest
    {
        [Test]
        public void CanSearchForCatVideos()
        {
            usersInCurrentSession.Add(new GoogleSearchUser(ConfigManager.BrowserName));
            var catLover = (GoogleSearchUser)usersInCurrentSession[0];
            catLover.GoogleMainPage.Open();
            catLover.GoogleMainPage.SearchFor("cute cats");
            var searchResults = catLover.SearchResultPage.ResultHealines;
            Assert.That(searchResults.Count, Is.GreaterThan(5), "the results count is low");
            CollectionAssert.AllItemsAreNotNull(
                searchResults);
            CollectionAssert.AllItemsAreUnique(
                searchResults,
                "There are some duplicates");
            Assert.That(
                searchResults.FirstOrDefault(result => result.ToLower().Contains("cat")),
                Is.Not.Null);
        }
    }
}
