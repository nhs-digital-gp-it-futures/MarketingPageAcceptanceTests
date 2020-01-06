namespace MarketingPageAcceptanceTests.TestData.ContactDetails
{
    public interface IContactDetail
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string EmailAddress { get; set; }
        string JobSector { get; set; }
    }
}
