using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class Common
    {
        public By PageTitle => CustomBy.DataTestId("section-title");

        public By MandatoryFieldSymbol => By.CssSelector("div.nhsuk-form-group > label");
    }
}
