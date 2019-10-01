using System;
using System.Linq;
using FluentAssertions;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class EditFeatures : PageAction
    {
        public EditFeatures(IWebDriver driver, ITestOutputHelper helper) : base(driver, helper)
        {
        }

        /// <summary>
        /// Add random characters to a text field
        /// </summary>
        /// <param name="characterCount">The number of characters to add</param>
        public void AddTextToFeature(int characterCount = 100)
        {
            var characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!£$%^&*(){}:@~<>?|\\[];'#,./";
            var randomString = "";

            var random = new Random();
            for(int i = 0; i<= characterCount; i++)
            {
                randomString += characters[random.Next(characters.Length)];
            }

            driver.FindElements(pages.EditFeatures.FeatureText).First().Clear();
            driver.FindElements(pages.EditFeatures.FeatureText).First().SendKeys(randomString);
        }

        /// <summary>
        /// Click the Save and Return button in the features section
        /// </summary>
        public void ClickSaveAndReturn()
        {
            driver.FindElement(pages.EditFeatures.SaveAndReturn).Click();
        }

        /// <summary>
        /// Validate that an error message is displayed (does not validate text within message)
        /// </summary>
        public void ErrorMessageDisplayed()
        {
            driver.FindElement(pages.EditFeatures.ErrorMessage).Text.Should().NotBeNullOrEmpty();
        }

        /// <summary>
        /// Ensure the Edit Features page is displayed by waiting for the inputs to display
        /// </summary>
        public void PageDisplayed()
        {
            wait.Until(s => s.FindElements(pages.EditFeatures.FeatureText).Count > 0);
        }

        /// <summary>
        /// Remove all text from all inputs on the edit features page
        /// </summary>
        public void ClearAllFields()
        {
            var features = driver.FindElements(pages.EditFeatures.FeatureText);

            foreach(var feature in features)
            {
                feature.Clear();
            }
        }
    }
}
