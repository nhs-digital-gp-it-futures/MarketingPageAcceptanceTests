namespace MarketingPageAcceptanceTests.TestData.ContactDetails
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IContactDetail
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        string PhoneNumber { get; set; }

        string Email { get; set; }

        string Department { get; set; }

        string SolutionId { get; set; }

        Task<IContactDetail> RetrieveAsync(string connectionString);

        Task<IEnumerable<IContactDetail>> RetrieveAllAsync(string connectionString);

        Task CreateAsync(string connectionString);

        Task DeleteAsync(string connectionString);

        Task<int> RetrieveCountAsync(string connectionString);
    }
}
