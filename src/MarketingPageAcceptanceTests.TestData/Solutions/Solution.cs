using System;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public sealed class Solution
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string SupplierId { get; set; } = "100000";
        public Guid OrganisationId { get; set; }
        public int PublishedStatusId { get; set; } = 1;
        public int AuthorityStatusId { get; set; } = 1;
        public int SupplierStatusId { get; set; } = 1;
        public Guid SolutionDetailId { get; set; }

        public override string ToString()
        {
            return $"ID: {Id},\nName: {Name},\nVersion: {Version},\nSupplier Id: {SupplierId},\nOrganisation Id: {OrganisationId.ToString()},\nSolutionDetailId: {SolutionDetailId}";
        }
    }
}
