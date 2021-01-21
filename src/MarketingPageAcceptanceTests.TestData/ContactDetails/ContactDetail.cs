using System;
using System.Collections.Generic;
using System.Linq;
using MarketingPageAcceptanceTests.TestData.Utils;

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
            var query = @"INSERT INTO [MarketingContact] (
                            SolutionId, 
                            FirstName, 
                            LastName, 
                            Email, 
                            PhoneNumber, 
                            Department, 
                            LastUpdated, 
                            LastUpdatedBy) 
                        VALUES(
                            @solutionId, 
                            @firstName, 
                            @lastName, 
                            @email, 
                            @phoneNumber, 
                            @department, 
                            GETDATE(), 
                            '00000000-0000-0000-0000-000000000000')";
            SqlExecutor.Execute<ContactDetail>(connectionString, query, this);
        }

        public void Delete(string connectionString)
        {
            var query = "DELETE FROM MarketingContact where SolutionId=@solutionId";
            SqlExecutor.Execute<ContactDetail>(connectionString, query, new { SolutionId });
        }

        public IContactDetail Retrieve(string connectionString)
        {
            var query = @"SELECT * FROM MarketingContact WHERE SolutionId=@solutionId";
            return SqlExecutor.Execute<ContactDetail>(connectionString, query, new { SolutionId }).Single();
        }

        public IEnumerable<IContactDetail> RetrieveAll(string connectionString)
        {
            var query = @"SELECT * FROM MarketingContact WHERE SolutionId=@solutionId";
            return SqlExecutor.Execute<ContactDetail>(connectionString, query, new { SolutionId });
        }

        public int RetrieveCount(string connectionString)
        {
            var query = @"SELECT COUNT(*) FROM [dbo].[MarketingContact] WHERE SolutionId=@solutionId";
            return SqlExecutor.ExecuteScalar(connectionString, query, new { SolutionId });
        }

        public void Update(string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
