using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public static class BrowserBasedDashboard
    {
        public static By SectionTitle => CustomBy.DataTestId("dashboard-section-title");

        public static By StatusIndicator => CustomBy.DataTestId("dashboard-section-status");
    }
}
