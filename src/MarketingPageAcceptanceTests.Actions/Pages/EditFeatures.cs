using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.TestData.Information;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class EditFeatures : PageAction
    {

        public EditFeatures(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Add random characters to a random text field
        /// </summary>
        /// <param name="characterCount">The number of characters to add</param>
        public string AddTextToFeature(int characterCount = 100)
        {
            var randomTextField = GetRandomTextField();
            string randomString = RandomInformation.RandomString(characterCount);
            randomTextField.Clear();
            randomTextField.SendKeys(randomString);
            return randomString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a random text field</returns>
        private IWebElement GetRandomTextField()
        {
            IList<IWebElement> textFields = driver.FindElements(pages.EditFeatures.FeatureText);

            return RandomInformation.GetRandomItem(textFields);
        }

        /// <summary>
        /// Click the Save and Return button in the features section
        /// </summary>
        public void ClickSaveAndReturn()
        {
            driver.FindElement(pages.EditFeatures.SaveAndReturn).Click();
        }

        /// <summary>
        /// Ensure the Edit Features page is displayed by waiting for the inputs to display
        /// </summary>
        public void PageDisplayed()
        {
            wait.Until(s => s.FindElements(pages.EditFeatures.FeatureText).Count == 10);
        }

        /// <summary>
        /// Remove all text from all inputs on the edit features page
        /// </summary>
        public void ClearAllFields()
        {
            var features = driver.FindElements(pages.EditFeatures.FeatureText);

            foreach (var feature in features)
            {
                feature.Clear();
            }
        }
    }
}
