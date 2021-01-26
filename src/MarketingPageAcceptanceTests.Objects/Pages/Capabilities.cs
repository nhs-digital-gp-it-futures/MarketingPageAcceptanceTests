namespace MarketingPageAcceptanceTests.Objects.Pages
{
    using MarketingPageAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public static class Capabilities
    {
        public static By CsvTextArea => By.CssSelector("textarea.nhsuk-textarea");

        public static By CapabilitySection => CustomBy.DataTestId("view-section-table-row-capabilities");

        public static By CapabilityTitle => CustomBy.DataTestId("view-section-table-row-title");

        public static By Description => CustomBy.DataTestId("view-section-table-row-component");
    }
}
