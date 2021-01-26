namespace MarketingPageAcceptanceTests.Actions.Utils
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

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

        public static void EnterTextViaJS(
            this IWebDriver driver,
            WebDriverWait wait,
            By elementBy,
            string value = "",
            int index = 0)
        {
            wait.Until(s => s.FindElements(elementBy)[index].Enabled);
            ((IJavaScriptExecutor)driver).ExecuteScript(
                "arguments[0].value=arguments[1];",
                driver.FindElements(elementBy)[index],
                value);
        }

        internal static Func<IWebDriver, bool> InvisibilityOfElement(By locator)
        {
            return driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    // Returns true because the element is not present in DOM.
                    // The try block checks if the element is present but is invisible.
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    // Returns true because stale element reference implies that element is no longer visible.
                    return true;
                }
            };
        }

        internal static Func<IWebDriver, IWebElement> ElementToBeClickable(By locator)
        {
            return driver =>
            {
                var element = driver.FindElement(locator).Displayed ? driver.FindElement(locator) : null;
                try
                {
                    if (element != null && element.Enabled)
                    {
                        return element;
                    }

                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }
    }
}
