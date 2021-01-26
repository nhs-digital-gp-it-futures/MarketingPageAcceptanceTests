namespace MarketingPageAcceptanceTests.Objects.Pages
{
    using MarketingPageAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public static class BrowserBasedDashboard
    {
        public static By SectionTitle => CustomBy.DataTestId("dashboard-section-title");

        public static By StatusIndicator => CustomBy.DataTestId("dashboard-section-status");
    }
}
