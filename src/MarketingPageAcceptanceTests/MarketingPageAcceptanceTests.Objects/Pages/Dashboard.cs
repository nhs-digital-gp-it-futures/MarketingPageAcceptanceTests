using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class Dashboard
    {
        public By Sections => By.ClassName("app-section-list__item");
        public By Statuses => CustomBy.DataTestId("dashboard-section-status");

        public By SectionTitle => CustomBy.DataTestId("dashboard-section-title");

        public By PreviewPage => CustomBy.DataTestId("dashboard-preview-button");
    }
}
