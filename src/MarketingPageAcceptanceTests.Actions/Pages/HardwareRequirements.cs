using MarketingPageAcceptanceTests.TestData.Information;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class HardwareRequirements : PageAction
    {
        public HardwareRequirements(IWebDriver driver) : base(driver)
        {
        }

        public void EnterText(int characters)
        {
            string randomText = RandomInformation.RandomString(characters);

            driver.FindElement(pages.BrowserBasedSections.HardwareRequirements.HardwareRequirementsDescription).SendKeys(randomText);
        }
    }
}
