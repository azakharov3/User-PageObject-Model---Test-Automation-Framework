using BrowserUserSimulator.Pages;
using BrowserUserSimulator.Pages.GoogleTranslage;

namespace BrowserUserSimulator.Users
{
    public class GoogleTranslateUser : BaseWebUser
    {
        public GoogleTranslateUser(string browserName) : base(browserName)
        { }

        public GoogleTranslatePageController GoogleTranslatePage => new GoogleTranslatePageController(driver);
    }
}
