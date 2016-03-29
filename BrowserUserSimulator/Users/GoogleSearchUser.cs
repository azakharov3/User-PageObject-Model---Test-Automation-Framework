using BrowserUserSimulator.Pages.Google;

namespace BrowserUserSimulator.Users
{
    public class GoogleSearchUser : BaseWebUser
    {
        public GoogleSearchUser(string browserName) : base(browserName)
        {
        }

        public GoogleMainPageController GoogleMainPage => new GoogleMainPageController(driver);
        public SearchResultPageController SearchResultPage => new SearchResultPageController(driver);
    }
}
