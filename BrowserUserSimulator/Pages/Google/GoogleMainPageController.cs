using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace BrowserUserSimulator.Pages.Google
{
    public class GoogleMainPageController : BasePageController
    {
        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement googleSearchField;

        [FindsBy(How = How.Name, Using = "btnG")]
        private IWebElement googleSearchBtn;
        

        public GoogleMainPageController(IWebDriver driverToPassToBase) : base (driverToPassToBase)
        { }

        /// <summary>
        /// Opens main google page
        /// </summary>
        public void Open()
        {
            NavigateToUrl("https://www.google.com/");
        }

        /// <summary>
        /// Types search query and clicks on search button
        /// </summary>
        /// <param name="testToSearch"></param>
        public void SearchFor(string testToSearch)
        {
            googleSearchField.SendKeys(testToSearch);
            googleSearchBtn.Click();
        }
    }
}
