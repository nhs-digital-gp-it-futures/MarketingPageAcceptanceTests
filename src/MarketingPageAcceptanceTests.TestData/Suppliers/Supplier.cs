using MarketingPageAcceptanceTests.TestData.Utils;
using System;
using System.Linq;

namespace MarketingPageAcceptanceTests.TestData.Suppliers
{
    public sealed class Supplier
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LegalName { get; set; }
        public string Summary { get; set; }
        public string SupplierUrl { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public Guid LastUpdatedBy { get; set; } = Guid.Empty;

        public void Create(string connectionString)
        {
            var query = Queries.CreateNewSupplier;
            SqlReader.Read<Supplier>(connectionString, query, this);
        }

        public Supplier Get(string connectionString)
        {
            var query = Queries.GetSupplier;
            return SqlReader.Read<Supplier>(connectionString, query, this).Single();
        }

        public Supplier GetSupplierForSolution(string connectionString, string solutionId)
        {
            var query = Queries.GetSupplierForSolution;
            return SqlReader.Read<Supplier>(connectionString, query, new { solutionId }).Single();
        }

        public void Update(string connectionString)
        {
            var query = Queries.UpdateSupplier;
            SqlReader.Read<Supplier>(connectionString, query, this);
        }

        public void Delete(string connectionString)
        {
            var query = Queries.DeleteSupplier;
            SqlReader.Read<Supplier>(connectionString, query, this);
        }
    }
}
