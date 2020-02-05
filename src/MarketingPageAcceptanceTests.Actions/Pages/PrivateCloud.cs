using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.Actions.Utils;
using MarketingPageAcceptanceTests.TestData.Information;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public class PrivateCloud : PageAction
    {
        public PrivateCloud(IWebDriver driver) : base(driver)
        {

        }
        public void EnterText(int characters)
        {
            string randomText = RandomInformation.RandomString(characters);
            driver.EnterTextViaJS(wait, pages.HostingTypeSections.PrivateCloud.HostingModel, randomText);
        }
    }
}
