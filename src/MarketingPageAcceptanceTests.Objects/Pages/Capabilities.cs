using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public static class Capabilities
    {
        public static By CsvTextArea => By.CssSelector("textarea.nhsuk-textarea");

        public static By CapabilitySection => CustomBy.DataTestId("view-section-table-row-capabilities");
        public static By CapabilityTitle => CustomBy.DataTestId("view-section-table-row-title");
        public static By Description => CustomBy.DataTestId("view-section-table-row-component");
    }
}