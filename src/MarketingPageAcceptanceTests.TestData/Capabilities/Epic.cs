namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MarketingPageAcceptanceTests.TestData.Utils;

    public sealed class Epic
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Level { get; set; }

        internal static async Task<IEnumerable<Epic>> GetAllByCapabilityIdAsync(string connectionString, Guid capId)
        {
            var query = "SELECT * FROM Epic WHERE CapabilityId=@Id";

            return await SqlExecutor.ExecuteAsync<Epic>(connectionString, query, new { Id = capId });
        }
    }
}
