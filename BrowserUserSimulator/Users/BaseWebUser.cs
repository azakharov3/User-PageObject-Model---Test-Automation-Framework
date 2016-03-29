using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace BrowserUserSimulator
{
    public abstract class BaseWebUser : IDisposable
    {
        protected IWebDriver driver;
        private string webDriverServerUrl;
        private string browserName;

        public BaseWebUser(string browserName, string webDriverServerUrl = null)
        {
            this.browserName = browserName;
            this.webDriverServerUrl = webDriverServerUrl;
            OpenBrowserSession(browserName, webDriverServerUrl);
        }

        private void OpenBrowserSession(
            string browserName,
            string webdriverServerUrl = null)
        {
            if (browserName.Equals("Firefox") && webdriverServerUrl == null)
            {
                driver = new FirefoxDriver();
            }
            else
            {
                throw new NotImplementedException("Unknown configuration requested");
            }
        }

        /// <summary>
        /// Closes the browser session
        /// </summary>
        public void CloseBrowser()
        {
            driver.Quit();
        }

        public void Dispose()
        {
            CloseBrowser();
        }
    }
}