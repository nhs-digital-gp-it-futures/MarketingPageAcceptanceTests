using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.Actions.Utils;
using MarketingPageAcceptanceTests.TestData.Information;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class HardwareRequirements : PageAction
    {
        public HardwareRequirements(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        ///     Enter text into a text field on the page
        /// </summary>
        /// <param name="characters">String value to enter</param>
        /// <param name="fieldIndex">optional, by default it will go for the first one unless other is specified</param>
        /// <returns>the value entered into the field</returns>
        public string EnterText(int characters, int fieldIndex = 0)
        {
            var randomText = RandomInformation.RandomString(characters);
            driver.EnterTextViaJS(wait, pages.BrowserBasedSections.HardwareRequirements.HardwareRequirementsDescription,
                randomText, fieldIndex);
            return randomText;
        }
    }
}