using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public class BrowserBasedDashboard : Dashboard
    {
        public new By SectionTitle => CustomBy.DataTestId("dashboard-section-title", "a");

        public By StatusIndicator => CustomBy.DataTestId("dashboard-section-status");
    }
}