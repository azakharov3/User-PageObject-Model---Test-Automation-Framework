using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Drawing.Imaging;

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

        public void Dispose()
        {
            CloseBrowser();
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

        /// <summary>
        /// Saves a screeshot at a specified path
        /// </summary>
        /// <param name="filePath">Screenshot filepath</param>
        public void SaveScreenshot(string filePath)
        {
            driver.TakeScreenshot().SaveAsFile(filePath, ImageFormat.Png);
        }
    }
}