namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using System;
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using MarketingPageAcceptanceTests.Actions.Utils;
    using MarketingPageAcceptanceTests.TestData.Information;
    using OpenQA.Selenium;

    public sealed class EditFeatures : PageAction
    {
        public EditFeatures(IWebDriver driver)
            : base(driver)
        {
        }

        public string AddTextToFeature(int characterCount = 100)
        {
            var randomString = RandomInformation.RandomString(characterCount);
            var randomIndex = new Random().Next(Driver.FindElements(Objects.Pages.EditFeatures.FeatureText).Count);
            Driver.EnterTextViaJS(Wait, Objects.Pages.EditFeatures.FeatureText, randomString, randomIndex);
            return randomString;
        }

        public void ClickSaveAndReturn()
        {
            Driver.FindElement(Objects.Pages.EditFeatures.SaveAndReturn).Click();
        }

        public void PageDisplayed()
        {
            Wait.Until(s => s.FindElements(Objects.Pages.EditFeatures.FeatureText).Count == 10);
        }

        public void ClearAllFields()
        {
            var features = Driver.FindElements(Objects.Pages.EditFeatures.FeatureText);

            foreach (var feature in features)
            {
                feature.Clear();
            }
        }
    }
}
