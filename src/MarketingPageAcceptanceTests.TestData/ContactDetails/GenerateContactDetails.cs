using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingPageAcceptanceTests.TestData.ContactDetails
{
    public static class GenerateContactDetails
    {
        public static IContactDetail NewContactDetail()
        {
            // en_GB esures UK format Phone Number
            IContactDetail contact = new Faker<ContactDetail>("en_GB")
                .StrictMode(true)
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.EmailAddress, (f, c) => f.Internet.Email(c.FirstName, c.LastName))
                .RuleFor(c => c.JobSector, f => f.Name.JobTitle())
                .Generate();

            return contact;
        }        
    }
}
