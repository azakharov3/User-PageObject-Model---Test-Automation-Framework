using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace BrowserUserSimulator.Pages
{
    public abstract class BasePageController
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private TimeSpan defaultTimeOut;

        public BasePageController(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            defaultTimeOut = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, defaultTimeOut);
        }

        /// <summary>
        /// Navigates browser to specified URL
        /// </summary>
        /// <param name="urlToNavigate">URL to navigate</param>
        protected void NavigateToUrl(string urlToNavigate)
        {
            driver.Navigate().GoToUrl(urlToNavigate);
        }

        /// <summary>
        /// Waits for webelement to be displayed on the page
        /// </summary>
        /// <param name="element">Web element</param>
        /// <param name="timeout">Timeout value</param>
        protected void WaitForElementToBeDisplayed(IWebElement element, TimeSpan? timeout = null)
        {
            if (timeout == null)
                timeout = defaultTimeOut;
            wait.Timeout = timeout.Value;
            wait.Until(elementVisibility => element.Displayed);
        }
    }
}
