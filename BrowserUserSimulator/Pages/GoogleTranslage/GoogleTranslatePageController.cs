using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrowserUserSimulator.Pages.GoogleTranslage
{
    public class GoogleTranslatePageController : BasePageController
    {
        [FindsBy(How = How.Id, Using = "source")]
        private IWebElement sourceInput;

        [FindsBy(How = How.CssSelector, Using = "#result_box span")]
        private IWebElement translationResultBox;
        
        public GoogleTranslatePageController(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Opens google translate page
        /// </summary>
        public void Open()
        {
            NavigateToUrl("https://translate.google.com/");
        }

        /// <summary>
        /// Types the specified string in the source field
        /// </summary>
        /// <param name="stringToType">A string to be typed in the source field</param>
        public void TypeInSourceField(string stringToType)
        {
            sourceInput.SendKeys(stringToType);
        }

        /// <summary>
        /// Gets translated text string
        /// </summary>
        public string Translation
        {
            get
            {
                WaitForElementToBeDisplayed(translationResultBox);
                return translationResultBox.Text;
            }
        }
    }
}
