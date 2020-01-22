using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarketingPageAcceptanceTests.Actions.Utils
{
    public static class ElementExtensions
    {
        public static bool ContainsElement(this IWebElement element, By message)
        {
            try
            {
                element.FindElement(message);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Method to set the value of an input field
        /// Useful for entering a large number of characters instead of SendKeys which types each character individually
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="wait"></param>
        /// <param name="elementBy"></param>
        /// <param name="value">default is empty string</param>
        /// <param name="index">default is 0</param>
        public static void EnterTextViaJS(this IWebDriver driver, WebDriverWait wait, By elementBy, string value = "", int index = 0)
        {
            wait.Until(s => s.FindElements(elementBy)[index].Enabled);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value=arguments[1];", driver.FindElements(elementBy)[index], value);
        }
    }
}
