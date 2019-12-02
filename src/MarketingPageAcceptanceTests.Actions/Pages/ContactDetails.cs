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
            return new Common(driver).PageTitleEquals("Contact Details");
        }
    }
}