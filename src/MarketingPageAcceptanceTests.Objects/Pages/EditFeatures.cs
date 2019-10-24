using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class EditFeatures
    {
        public By FeatureText => By.ClassName("nhsuk-input");

        public By SaveAndReturn => CustomBy.DataTestId("section-submit-button", "button");

        public By ErrorMessage => By.ClassName("nhsuk-error-message");
    }
}
