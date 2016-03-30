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
        private bool disposing = false;
        private bool disposed = false;

        public BaseWebUser(string browserName, string webDriverServerUrl = null)
        {
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
            disposed = true;
            disposing = false;
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