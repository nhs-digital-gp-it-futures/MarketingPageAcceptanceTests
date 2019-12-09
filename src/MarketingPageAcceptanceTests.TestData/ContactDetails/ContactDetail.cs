namespace MarketingPageAcceptanceTests.TestData.ContactDetails
{
    public sealed class ContactDetail : IContactDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string JobSector { get; set; }
    }
}
