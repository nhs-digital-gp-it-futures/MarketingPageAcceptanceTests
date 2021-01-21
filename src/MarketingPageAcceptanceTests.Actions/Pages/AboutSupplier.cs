using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public class AboutSupplier : PageAction
    {
        public AboutSupplier(IWebDriver driver) : base(driver)
        {
        }

        public string GetDescriptionText()
        {
            return driver.FindElement(Objects.Pages.AboutSupplier.Description).Text;
        }

        public string GetLinkText()
        {
            return driver.FindElement(Objects.Pages.AboutSupplier.Link).GetAttribute("value");
        }
    }
}