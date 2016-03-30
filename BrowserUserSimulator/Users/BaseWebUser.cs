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
        private bool disposing;
        private bool disposed;

        public BaseWebUser(string browserName, string webDriverServerUrl = null)
        {
            this.browserName = browserName;
            this.webDriverServerUrl = webDriverServerUrl;
            OpenBrowserSession(browserName, webDriverServerUrl);
        }

        ~BaseWebUser()
        {
            if (!disposed && !disposing)
                Dispose();
        }

        public void Dispose()
        {
            disposing = true;
            CloseBrowser();
            disposing = false;
            disposed = true;
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
                throw new InvalidOperationException("Unknown configuration requested");
            }
        }

        /// <summary>
        /// Closes the browser session
        /// </summary>
        public void CloseBrowser()
        {
            Console.WriteLine("Closing browser");
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