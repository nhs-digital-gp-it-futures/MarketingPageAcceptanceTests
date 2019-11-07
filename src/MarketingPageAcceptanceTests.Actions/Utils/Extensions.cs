using OpenQA.Selenium;

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
    }
}
