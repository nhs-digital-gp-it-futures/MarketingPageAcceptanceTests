using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public class Dashboard
    {
        public By Sections => By.CssSelector("li.bc-c-section-list__item");

        public By Statuses => CustomBy.DataTestId("dashboard-section-status");

        public By SectionTitle => CustomBy.DataTestId("dashboard-section-title");

        public By PreviewPage => CustomBy.DataTestId("dashboard-preview-button", "a.nhsuk-button--secondary");

        public By Requirement => CustomBy.DataTestId("dashboard-section-requirement");

        public By DefaultMessage => CustomBy.DataTestId("dashboard-section-default-message");

        public By SubmitForModerationButton => CustomBy.DataTestId("dashboard-submit-for-moderation-button", "a.nhsuk-button");


    }
}
