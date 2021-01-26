namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using MarketingPageAcceptanceTests.TestData.ContactDetails;
    using OpenQA.Selenium;

    public class ContactDetails : PageAction
    {
        public ContactDetails(IWebDriver driver)
            : base(driver)
        {
        }

        public bool PageDisplayed()
        {
            return new Common(Driver).PageTitleEquals("Contact details");
        }

        public void EnterAllData(
            IContactDetail firstContact,
            IContactDetail secondContact = null,
            bool clearFirst = false)
        {
            FirstContactComplete(firstContact, clearFirst);

            if (!(secondContact is null))
            {
                SecondContactComplete(secondContact, clearFirst);
            }
        }

        private void FirstContactComplete(IContactDetail contact, bool clearFirst)
        {
            if (clearFirst)
            {
                Driver.FindElement(Objects.Pages.ContactDetails.Contact1FirstName).Clear();
                Driver.FindElement(Objects.Pages.ContactDetails.Contact1LastName).Clear();
                Driver.FindElement(Objects.Pages.ContactDetails.Contact1EmailAddress).Clear();
                Driver.FindElement(Objects.Pages.ContactDetails.Contact1PhoneNumber).Clear();
                Driver.FindElement(Objects.Pages.ContactDetails.Contact1JobSector).Clear();
            }

            Driver.FindElement(Objects.Pages.ContactDetails.Contact1FirstName).SendKeys(contact.FirstName);
            Driver.FindElement(Objects.Pages.ContactDetails.Contact1LastName).SendKeys(contact.LastName);
            Driver.FindElement(Objects.Pages.ContactDetails.Contact1EmailAddress).SendKeys(contact.Email);
            Driver.FindElement(Objects.Pages.ContactDetails.Contact1PhoneNumber).SendKeys(contact.PhoneNumber);
            Driver.FindElement(Objects.Pages.ContactDetails.Contact1JobSector).SendKeys(contact.Department);
        }

        private void SecondContactComplete(IContactDetail contact, bool clearFirst)
        {
            if (clearFirst)
            {
                Driver.FindElement(Objects.Pages.ContactDetails.Contact2FirstName).Clear();
                Driver.FindElement(Objects.Pages.ContactDetails.Contact2LastName).Clear();
                Driver.FindElement(Objects.Pages.ContactDetails.Contact2EmailAddress).Clear();
                Driver.FindElement(Objects.Pages.ContactDetails.Contact2PhoneNumber).Clear();
                Driver.FindElement(Objects.Pages.ContactDetails.Contact2JobSector).Clear();
            }

            Driver.FindElement(Objects.Pages.ContactDetails.Contact2FirstName).SendKeys(contact.FirstName);
            Driver.FindElement(Objects.Pages.ContactDetails.Contact2LastName).SendKeys(contact.LastName);
            Driver.FindElement(Objects.Pages.ContactDetails.Contact2EmailAddress).SendKeys(contact.Email);
            Driver.FindElement(Objects.Pages.ContactDetails.Contact2PhoneNumber).SendKeys(contact.PhoneNumber);
            Driver.FindElement(Objects.Pages.ContactDetails.Contact2JobSector).SendKeys(contact.Department);
        }
    }
}
