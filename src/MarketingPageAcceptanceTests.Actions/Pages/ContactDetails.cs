using System;
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

        public void EnterAllData(IContactDetail firstContact, IContactDetail secondContact = null)
        {
            FirstContactComplete(firstContact);

            if(!(secondContact is null))
            {
                SecondContactComplete(secondContact);
            }
        }

        private void FirstContactComplete(IContactDetail contact)
        {
            driver.FindElement(pages.ContactDetails.Contact1FirstName).SendKeys(contact.FirstName);
            driver.FindElement(pages.ContactDetails.Contact1LastName).SendKeys(contact.LastName);
            driver.FindElement(pages.ContactDetails.Contact1EmailAddress).SendKeys(contact.EmailAddress);
            driver.FindElement(pages.ContactDetails.Contact1PhoneNumber).SendKeys(contact.PhoneNumber);
            driver.FindElement(pages.ContactDetails.Contact1JobSector).SendKeys(contact.JobSector);
        }

        private void SecondContactComplete(IContactDetail contact)
        {
            driver.FindElement(pages.ContactDetails.Contact2FirstName).SendKeys(contact.FirstName);
            driver.FindElement(pages.ContactDetails.Contact2LastName).SendKeys(contact.LastName);
            driver.FindElement(pages.ContactDetails.Contact2EmailAddress).SendKeys(contact.EmailAddress);
            driver.FindElement(pages.ContactDetails.Contact2PhoneNumber).SendKeys(contact.PhoneNumber);
            driver.FindElement(pages.ContactDetails.Contact2JobSector).SendKeys(contact.JobSector);
        }
    }
}