using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public class BrowsersSupported
    {
        public By BrowserCheckboxes => By.CssSelector("div.nhsuk-checkboxes__item");

        public By MobileResponsive => By.CssSelector("div.nhsuk-radios__item");

        public By SaveAndReturn => CustomBy.DataTestId("section-submit-button", "button");
    }
}