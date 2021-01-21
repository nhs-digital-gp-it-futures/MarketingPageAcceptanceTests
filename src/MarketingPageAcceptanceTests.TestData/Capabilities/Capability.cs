using System;
using System.Collections.Generic;
using System.Linq;
using MarketingPageAcceptanceTests.TestData.Utils;

namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    public class Capability
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CapabilityRef { get; set; }

        public static Capability Get(string connectionString, Guid Id)
        {
            var query = "SELECT * FROM Capability WHERE Id=@Id";
            return SqlExecutor.Execute<Capability>(connectionString, query, new { Id }).Single();
        }

        public static IEnumerable<Capability> GetAll(string connectionString)
        {
            var query = "SELECT * FROM Capability";
            return SqlExecutor.Execute<Capability>(connectionString, query, null);
        }
    }
}