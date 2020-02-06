using MarketingPageAcceptanceTests.TestData.Utils;
using System.Collections.Generic;
using System.Linq;

namespace MarketingPageAcceptanceTests.TestData.ContactDetails
{
    public sealed class ContactDetail : IContactDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string SolutionId { get; set; }

        public void Create(string connectionString)
        {
            var query = Queries.CreateMarketingContact;
            SqlReader.Read<ContactDetail>(connectionString, query, this);
        }

        public void Delete(string connectionString)
        {
            var query = Queries.DeleteMarketingContact;
            SqlReader.Read<ContactDetail>(connectionString, query, new { SolutionId });
        }

        public IContactDetail Retrieve(string connectionString)
        {
            var query = Queries.GetMarketingContacts;
            return SqlReader.Read<ContactDetail>(connectionString, query, new { SolutionId }).Single();
        }

        public IEnumerable<IContactDetail> RetrieveAll(string connectionString)
        {
            var query = Queries.GetMarketingContacts;
            return SqlReader.Read<ContactDetail>(connectionString, query, new { SolutionId });
        }

        public int RetrieveCount(string connectionString)
        {
            var query = Queries.GetNumberOfMarketingContactsForSolution;
            return SqlReader.ReadCount(connectionString, query, new { SolutionId });
        }

        public void Update(string connectionString)
        {
            throw new System.NotImplementedException();
        }
    }
}
