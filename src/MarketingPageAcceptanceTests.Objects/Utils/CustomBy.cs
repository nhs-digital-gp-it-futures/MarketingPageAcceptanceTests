using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Utils
{
    internal sealed class CustomBy : By
    {
        /// <summary>
        /// Custom selector that finds elements using the data-test-id attribute
        /// </summary>
        /// <param name="locator">string that must be contained within the data-test-id attribute</param>
        /// <returns>By clause that can be used to find one or more elements with the data-test-id attribute</returns>
        public static By DataTestId(string locator, string childTag = null)
        {
            return CssSelector($"[data-test-id={locator}] {childTag}");
        }
    }
}
