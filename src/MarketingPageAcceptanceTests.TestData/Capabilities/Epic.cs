using MarketingPageAcceptanceTests.TestData.Utils;
using System;
using System.Collections.Generic;

namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    public sealed class Epic
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        internal IEnumerable<Epic> GetAllByCapabilityId(string connectionString, Guid capId)
        {
            var query = "SELECT * FROM Epic WHERE CapabilityId=@Id";

            return SqlExecutor.Execute<Epic>(connectionString, query, new { Id = capId });
        }
    }
}