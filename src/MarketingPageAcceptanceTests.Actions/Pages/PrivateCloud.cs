namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using MarketingPageAcceptanceTests.Actions.Utils;
    using MarketingPageAcceptanceTests.TestData.Information;
    using OpenQA.Selenium;

    public class PrivateCloud : PageAction
    {
        public PrivateCloud(IWebDriver driver)
            : base(driver)
        {
        }

        public void EnterText(int characters)
        {
            var randomText = RandomInformation.RandomString(characters);
            Driver.EnterTextViaJS(Wait, Objects.Pages.PrivateCloud.HostingModel, randomText);
        }
    }
}
