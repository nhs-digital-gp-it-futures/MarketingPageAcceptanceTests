using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class EditFeatures
    {
        public By FeatureText => By.ClassName("nhsuk-input");

        public By SaveAndReturn => By.CssSelector("button[type=submit]");

        public By ErrorMessage => By.ClassName("nhsuk-error-message");
    }
}
