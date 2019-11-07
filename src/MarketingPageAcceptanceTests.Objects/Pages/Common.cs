using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class Common
    {
        public By PageTitle => CustomBy.DataTestId("section-title");

        public By MandatoryFieldSymbol => By.CssSelector("div.nhsuk-form-group > label");

        public By SubDashboardTitle => CustomBy.DataTestId("sub-dashboard-title");

        public By BackLink => CustomBy.DataTestId("sub-dashboard-back-link", "a");

        public By ErrorMessages => By.CssSelector("ul.nhsuk-list.nhsuk-error-summary__list li a");

        public By ErrorSection => By.ClassName("nhsuk-error-summary");
    }
}
