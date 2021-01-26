namespace MarketingPageAcceptanceTests.Objects.Pages
{
    using MarketingPageAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public static class EditFeatures
    {
        public static By FeatureText => By.ClassName("nhsuk-input");

        public static By SaveAndReturn => CustomBy.DataTestId("section-submit-button", "button");
    }
}
