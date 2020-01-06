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
        /// Enter text into a text field on the page
        /// </summary>
        /// <param name="characters">String value to enter</param>
        /// <param name="fieldIndex">optional, by default it will go for the first one unless other is specified</param>
        public void EnterText(int characters, int fieldIndex = 0)
        {
            string randomText = RandomInformation.RandomString(characters);

            driver.FindElements(pages.BrowserBasedSections.HardwareRequirements.HardwareRequirementsDescription)[fieldIndex].SendKeys(randomText);
        }
    }
}
