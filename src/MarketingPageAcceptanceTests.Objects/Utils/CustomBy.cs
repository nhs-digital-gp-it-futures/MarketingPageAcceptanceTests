namespace MarketingPageAcceptanceTests.Objects.Utils
{
    using OpenQA.Selenium;

    internal sealed class CustomBy : By
    {
        public static By DataTestId(string locator, string childTag = null) => CssSelector($"[data-test-id={locator}] {childTag}");

        public static By PartialDataTestId(string partialLocator, string substitution, string childTag = null)
        {
            var replaced = string.Format(partialLocator, substitution);
            return DataTestId(replaced, childTag);
        }
    }
}
