﻿namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    using System;
    using System.Collections.Generic;
    using MarketingPageAcceptanceTests.TestData.Utils;

    public sealed class Epic
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Level { get; set; }

        internal static IEnumerable<Epic> GetAllByCapabilityId(string connectionString, Guid capId)
        {
            var query = "SELECT * FROM Epic WHERE CapabilityId=@Id";

            return SqlExecutor.Execute<Epic>(connectionString, query, new { Id = capId });
        }
    }
}
