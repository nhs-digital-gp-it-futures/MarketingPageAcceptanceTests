using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class ContactDetails
    {
        public By Contact1FirstName => By.Id("contact-1[first-name]");
        public By Contact1LastName => By.Id("contact-1[last-name]");
        public By Contact1PhoneNumber => By.Id("contact-1[phone-number]");
        public By Contact1EmailAddress => By.Id("contact-1[email-address]");
        public By Contact1JobSector => By.Id("contact-1[department-name]");

        public By Contact2FirstName => By.Id("contact-2[first-name]");
        public By Contact2LastName => By.Id("contact-2[last-name]");
        public By Contact2PhoneNumber => By.Id("contact-2[phone-number]");
        public By Contact2EmailAddress => By.Id("contact-2[email-address]");
        public By Contact2JobSector => By.Id("contact-2[department-name]");

    }
}
