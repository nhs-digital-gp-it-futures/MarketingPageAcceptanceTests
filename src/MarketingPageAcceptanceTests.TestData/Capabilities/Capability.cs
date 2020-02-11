using MarketingPageAcceptanceTests.TestData.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    public class Capability
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CapabilityRef { get; set; }
        public Capability Get(string connectionString, Guid Id)
        {
            var query = Queries.GetCapabilityById;
            return SqlExecutor.Execute<Capability>(connectionString, query, new { Id }).Single();        
        }

        public IEnumerable<Capability> GetAll(string connectionString)
        {
            var query = Queries.GetAllCapabilities;
            return SqlExecutor.Execute<Capability>(connectionString, query, null);
        }
    }
}
