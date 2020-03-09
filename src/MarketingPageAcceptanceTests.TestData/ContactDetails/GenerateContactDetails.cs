using Bogus;

namespace MarketingPageAcceptanceTests.TestData.ContactDetails
{
    public static class GenerateContactDetails
    {
        public static IContactDetail NewContactDetail(string solutionId)
        {
            // en_GB esures UK format Phone Number
            IContactDetail contact = new Faker<ContactDetail>("en_GB")
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FirstName, c.LastName))
                .RuleFor(c => c.Department, f => f.Name.JobTitle())
                .Generate();

            contact.SolutionId = solutionId;
            return contact;
        }
    }
}