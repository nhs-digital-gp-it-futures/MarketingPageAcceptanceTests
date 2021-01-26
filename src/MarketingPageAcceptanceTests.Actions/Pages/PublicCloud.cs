namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using OpenQA.Selenium;

    public class PublicCloud : PageAction
    {
        public PublicCloud(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickRequiresHscnN3ConnectivityCheckbox()
        {
            Driver.FindElement(Objects.Pages.PublicCloud.RequiresHscnN3Connectivity).Click();
        }
    }
}
