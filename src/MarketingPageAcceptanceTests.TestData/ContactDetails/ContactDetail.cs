namespace MarketingPageAcceptanceTests.TestData.ContactDetails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MarketingPageAcceptanceTests.TestData.Utils;

    public sealed class ContactDetail : IContactDetail
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }

        public string SolutionId { get; set; }

        public async Task CreateAsync(string connectionString)
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
            await SqlExecutor.ExecuteAsync<ContactDetail>(connectionString, query, this);
        }

        public async Task DeleteAsync(string connectionString)
        {
            var query = "DELETE FROM MarketingContact where SolutionId=@solutionId";
            await SqlExecutor.ExecuteAsync<ContactDetail>(connectionString, query, new { SolutionId });
        }

        public async Task<IContactDetail> RetrieveAsync(string connectionString)
        {
            var query = @"SELECT * FROM MarketingContact WHERE SolutionId=@solutionId";
            return (await SqlExecutor.ExecuteAsync<ContactDetail>(connectionString, query, new { SolutionId })).Single();
        }

        public async Task<IEnumerable<IContactDetail>> RetrieveAllAsync(string connectionString)
        {
            var query = @"SELECT * FROM MarketingContact WHERE SolutionId=@solutionId";
            return await SqlExecutor.ExecuteAsync<ContactDetail>(connectionString, query, new { SolutionId });
        }

        public async Task<int> RetrieveCountAsync(string connectionString)
        {
            var query = @"SELECT COUNT(*) FROM [dbo].[MarketingContact] WHERE SolutionId=@solutionId";
            return await SqlExecutor.ExecuteScalarAsync(connectionString, query, new { SolutionId });
        }
    }
}
