using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public class ContactDetails : PageAction
    {
        public ContactDetails(IWebDriver driver) : base(driver)
        {

        }

        public bool PageDisplayed()
        {
            return driver.FindElement(pages.Common.PageTitle).Text == "Contact Details";
        }
    }
}