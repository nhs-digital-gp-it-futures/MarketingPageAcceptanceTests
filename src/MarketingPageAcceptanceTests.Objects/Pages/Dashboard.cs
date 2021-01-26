namespace MarketingPageAcceptanceTests.Objects.Pages
{
    using MarketingPageAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public static class Dashboard
    {
        public static By Sections => By.CssSelector("li.bc-c-section-list__item");

        public static By Statuses => CustomBy.DataTestId("dashboard-section-status");

        public static By SectionTitle => CustomBy.DataTestId("dashboard-section-title");

        public static By PreviewPage => CustomBy.DataTestId("dashboard-preview-button", "a.nhsuk-button--secondary");

        public static By Requirement => CustomBy.DataTestId("dashboard-section-requirement");

        public static By DefaultMessage => CustomBy.DataTestId("dashboard-section-default-message");

        public static By SubmitForModerationButton =>
            CustomBy.DataTestId("dashboard-submit-for-moderation-button", "a.nhsuk-button");
    }
}
