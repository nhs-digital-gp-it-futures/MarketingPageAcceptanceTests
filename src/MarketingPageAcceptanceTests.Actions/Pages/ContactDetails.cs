using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.TestData.ContactDetails;
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
            return new Common(driver).PageTitleEquals("Contact details");
        }

        public void EnterAllData(IContactDetail firstContact, IContactDetail secondContact = null,
            bool clearFirst = false)
        {
            FirstContactComplete(firstContact, clearFirst);

            if (!(secondContact is null)) SecondContactComplete(secondContact, clearFirst);
        }

        private void FirstContactComplete(IContactDetail contact, bool clearFirst)
        {
            if (clearFirst)
            {
                driver.FindElement(Objects.Pages.ContactDetails.Contact1FirstName).Clear();
                driver.FindElement(Objects.Pages.ContactDetails.Contact1LastName).Clear();
                driver.FindElement(Objects.Pages.ContactDetails.Contact1EmailAddress).Clear();
                driver.FindElement(Objects.Pages.ContactDetails.Contact1PhoneNumber).Clear();
                driver.FindElement(Objects.Pages.ContactDetails.Contact1JobSector).Clear();
            }

            driver.FindElement(Objects.Pages.ContactDetails.Contact1FirstName).SendKeys(contact.FirstName);
            driver.FindElement(Objects.Pages.ContactDetails.Contact1LastName).SendKeys(contact.LastName);
            driver.FindElement(Objects.Pages.ContactDetails.Contact1EmailAddress).SendKeys(contact.Email);
            driver.FindElement(Objects.Pages.ContactDetails.Contact1PhoneNumber).SendKeys(contact.PhoneNumber);
            driver.FindElement(Objects.Pages.ContactDetails.Contact1JobSector).SendKeys(contact.Department);
        }

        private void SecondContactComplete(IContactDetail contact, bool clearFirst)
        {
            if (clearFirst)
            {
                driver.FindElement(Objects.Pages.ContactDetails.Contact2FirstName).Clear();
                driver.FindElement(Objects.Pages.ContactDetails.Contact2LastName).Clear();
                driver.FindElement(Objects.Pages.ContactDetails.Contact2EmailAddress).Clear();
                driver.FindElement(Objects.Pages.ContactDetails.Contact2PhoneNumber).Clear();
                driver.FindElement(Objects.Pages.ContactDetails.Contact2JobSector).Clear();
            }

            driver.FindElement(Objects.Pages.ContactDetails.Contact2FirstName).SendKeys(contact.FirstName);
            driver.FindElement(Objects.Pages.ContactDetails.Contact2LastName).SendKeys(contact.LastName);
            driver.FindElement(Objects.Pages.ContactDetails.Contact2EmailAddress).SendKeys(contact.Email);
            driver.FindElement(Objects.Pages.ContactDetails.Contact2PhoneNumber).SendKeys(contact.PhoneNumber);
            driver.FindElement(Objects.Pages.ContactDetails.Contact2JobSector).SendKeys(contact.Department);
        }
    }
}
