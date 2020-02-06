using System.Collections.Generic;

namespace MarketingPageAcceptanceTests.TestData.ContactDetails
{
    public interface IContactDetail
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        string Department { get; set; }
        string SolutionId { get; set; }

        IContactDetail Get(string connectionString);
        IEnumerable<IContactDetail> GetAll(string connectionString);
        void Create(string connectionString);
        void Update(string connectionString);
        void Delete(string connectionString);
        int GetCount(string connectionString);
    }
}
