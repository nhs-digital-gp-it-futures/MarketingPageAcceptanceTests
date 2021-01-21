using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public static class SupportedOperatingSystems
    {
        public static By OperatingSystems => By.ClassName("nhsuk-checkboxes__item");
        public static By OperatingSystemsDescription => By.CssSelector("textarea.govuk-textarea");
    }
}