using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public class SupportedOperatingSystems
    {
        public By OperatingSystems => By.ClassName("nhsuk-checkboxes__item");
        public By OperatingSystemsDescription => By.CssSelector("textarea.nhsuk-textarea");
    }
}