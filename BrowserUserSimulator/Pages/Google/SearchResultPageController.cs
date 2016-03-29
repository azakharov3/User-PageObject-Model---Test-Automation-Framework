using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace BrowserUserSimulator.Pages.Google
{
    public class SearchResultPageController : BasePageController
    {
        [FindsBy(How = How.ClassName, Using = "r")]
        private IList<IWebElement> resultHeadlines;

        [FindsBy(How = How.Id, Using = "resultStats")]
        private IWebElement resultStatsDiv;
        

        public SearchResultPageController(IWebDriver driverToPassToBase) : base (driverToPassToBase)
        { }

        /// <summary>
        /// Gets IEnumerable of result headlines strings
        /// </summary>
        public IEnumerable<string> ResultHealines
        {
            get
            {
                WaitForElementToBeDisplayed(resultStatsDiv);
                return resultHeadlines.Select(healine => healine.Text);
            }
        }
    }
}
