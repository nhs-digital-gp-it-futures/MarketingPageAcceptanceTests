using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public static class HardwareRequirements
    {
        public static By HardwareRequirementsDescription => By.CssSelector("textarea.govuk-textarea");
    }
}