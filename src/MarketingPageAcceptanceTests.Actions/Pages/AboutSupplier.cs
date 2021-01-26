namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using OpenQA.Selenium;

    public class AboutSupplier : PageAction
    {
        public AboutSupplier(IWebDriver driver)
            : base(driver)
        {
        }

        public string GetDescriptionText()
        {
            return Driver.FindElement(Objects.Pages.AboutSupplier.Description).Text;
        }

        public string GetLinkText()
        {
            return Driver.FindElement(Objects.Pages.AboutSupplier.Link).GetAttribute("value");
        }
    }
}
