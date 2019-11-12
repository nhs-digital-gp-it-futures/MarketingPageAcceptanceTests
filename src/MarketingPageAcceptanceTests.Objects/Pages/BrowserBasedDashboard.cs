using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public class BrowserBasedDashboard
    {
        public By Sections => By.ClassName("app-section-list__item");
        public By SectionTitle => CustomBy.DataTestId("dashboard-section-title", "a");

        public By StatusIndicator => CustomBy.DataTestId("dashboard-section-status");
    }
}