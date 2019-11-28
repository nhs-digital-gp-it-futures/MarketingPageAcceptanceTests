using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public class BrowserBasedDashboard : Dashboard
    {
        //public By Sections => By.ClassName("bc-c-section-list__item");
        public new By SectionTitle => CustomBy.DataTestId("dashboard-section-title", "a");

        public By StatusIndicator => CustomBy.DataTestId("dashboard-section-status");
    }
}