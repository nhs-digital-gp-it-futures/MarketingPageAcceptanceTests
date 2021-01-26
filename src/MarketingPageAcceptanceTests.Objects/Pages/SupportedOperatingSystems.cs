namespace MarketingPageAcceptanceTests.Objects.Pages
{
    using OpenQA.Selenium;

    public static class SupportedOperatingSystems
    {
        public static By OperatingSystems => By.ClassName("nhsuk-checkboxes__item");

        public static By OperatingSystemsDescription => By.CssSelector("textarea.govuk-textarea");
    }
}
