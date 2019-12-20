using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class HardwareRequirements
    {
        public By HardwareRequirementsDescription => By.CssSelector("textarea.nhsuk-textarea");
    }
}
