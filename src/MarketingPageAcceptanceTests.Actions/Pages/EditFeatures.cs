using System;
using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.Actions.Utils;
using MarketingPageAcceptanceTests.TestData.Information;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class EditFeatures : PageAction
    {
        public EditFeatures(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        ///     Add random characters to a random text field
        /// </summary>
        /// <param name="characterCount">The number of characters to add</param>
        public string AddTextToFeature(int characterCount = 100)
        {
            var randomString = RandomInformation.RandomString(characterCount);
            var randomIndex = new Random().Next(driver.FindElements(Objects.Pages.EditFeatures.FeatureText).Count);
            driver.EnterTextViaJS(wait, Objects.Pages.EditFeatures.FeatureText, randomString, randomIndex);
            return randomString;
        }

        /// <summary>
        ///     Click the Save and Return button in the features section
        /// </summary>
        public void ClickSaveAndReturn()
        {
            driver.FindElement(Objects.Pages.EditFeatures.SaveAndReturn).Click();
        }

        /// <summary>
        ///     Ensure the Edit Features page is displayed by waiting for the inputs to display
        /// </summary>
        public void PageDisplayed()
        {
            wait.Until(s => s.FindElements(Objects.Pages.EditFeatures.FeatureText).Count == 10);
        }

        /// <summary>
        ///     Remove all text from all inputs on the edit features page
        /// </summary>
        public void ClearAllFields()
        {
            var features = driver.FindElements(Objects.Pages.EditFeatures.FeatureText);

            foreach (var feature in features) feature.Clear();
        }
    }
}
