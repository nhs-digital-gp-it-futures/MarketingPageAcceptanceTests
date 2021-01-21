using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public static class Common
    {
        public static By PageTitle => CustomBy.DataTestId("section-title");

        public static By MandatoryFieldSymbol => By.CssSelector("div.nhsuk-form-group > label");

        public static By SubDashboardTitle => CustomBy.DataTestId("sub-dashboard-title");

        public static By SubDashboardBackLink => CustomBy.DataTestId("sub-dashboard-back-link", "a");

        public static By ErrorMessages => By.CssSelector("ul.nhsuk-list.nhsuk-error-summary__list li a");

        public static By ErrorSection => By.ClassName("nhsuk-error-summary");

        public static By SectionBackLink => CustomBy.DataTestId("section-back-link", "a");

        public static By SectionSaveAndReturn => CustomBy.DataTestId("section-submit-button", "button");
    }
}
