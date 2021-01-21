using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public static class BrowsersSupported
    {
        public static By BrowserCheckboxes => By.CssSelector("div.nhsuk-checkboxes__item");

        public static By MobileResponsive => By.CssSelector("div.nhsuk-radios__item");

        public static By SaveAndReturn => CustomBy.DataTestId("section-submit-button", "button");
    }
}
