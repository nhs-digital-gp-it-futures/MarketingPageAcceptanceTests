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
            SqlExecutor.Execute<Supplier>(connectionString, query, this);
        }

        public Supplier Retrieve(string connectionString)
        {
            var query = Queries.GetSupplier;
            return SqlExecutor.Execute<Supplier>(connectionString, query, this).Single();
        }

        public Supplier RetrieveSupplierForSolution(string connectionString, string solutionId)
        {
            var query = Queries.GetSupplierForSolution;
            return SqlExecutor.Execute<Supplier>(connectionString, query, new { solutionId }).Single();
        }

        public void Update(string connectionString)
        {
            var query = Queries.UpdateSupplier;
            SqlExecutor.Execute<Supplier>(connectionString, query, this);
        }

        public void Delete(string connectionString)
        {
            var query = Queries.DeleteSupplier;
            SqlExecutor.Execute<Supplier>(connectionString, query, this);
        }
    }
}
