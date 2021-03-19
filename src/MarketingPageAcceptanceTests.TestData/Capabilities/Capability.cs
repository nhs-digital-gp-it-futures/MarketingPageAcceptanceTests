namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MarketingPageAcceptanceTests.TestData.Utils;

    public class Capability
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CapabilityRef { get; set; }

        public static async Task<Capability> GetAsync(string connectionString, Guid id)
        {
            var query = "SELECT * FROM Capability WHERE Id=@Id";
            return (await SqlExecutor.ExecuteAsync<Capability>(connectionString, query, new { id })).Single();
        }

        public static async Task<IEnumerable<Capability>> GetAllAsync(string connectionString)
        {
            var query = "SELECT * FROM Capability";
            return await SqlExecutor.ExecuteAsync<Capability>(connectionString, query, null);
        }
    }
}
