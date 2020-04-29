﻿using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class Capabilities
    {
        public By CsvTextArea => By.CssSelector("textarea.nhsuk-textarea");

        public By CapabilitySection => CustomBy.DataTestId("view-section-table-row-capabilities");
        public By CapabilityTitle => CustomBy.DataTestId("view-section-table-row-title");
        public By Description => CustomBy.DataTestId("view-section-table-row-component");
    }
}