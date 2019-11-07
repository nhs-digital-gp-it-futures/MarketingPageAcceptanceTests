using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public sealed class Solution
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string OrganisationId { get; set; } = "1000000";
        public int PublishedStatusId { get; set; } = 1;
        public int AuthorityStatusId { get; set; } = 1;
        public int SupplierStatusId { get; set; } = 1;
    }   
}
