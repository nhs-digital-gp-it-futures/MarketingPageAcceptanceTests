using System;
using System.Linq;
using MarketingPageAcceptanceTests.TestData.Utils;

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
            var query = @"INSERT INTO Supplier (
                            Id, 
                            Name, 
                            LegalName, 
                            Summary, 
                            SupplierUrl, 
                            LastUpdated, 
                            LastUpdatedBy) 
                        VALUES (
                            @Id, 
                            @name, 
                            @legalName, 
                            @summary, 
                            @supplierUrl, 
                            @lastUpdated, 
                            @lastUpdatedBy)";
            SqlExecutor.Execute<Supplier>(connectionString, query, this);
        }

        public Supplier Retrieve(string connectionString)
        {
            var query = @"SELECT * FROM [dbo].[Supplier] WHERE [Id]=@Id";
            return SqlExecutor.Execute<Supplier>(connectionString, query, this).Single();
        }

        public static Supplier RetrieveSupplierForSolution(string connectionString, string solutionId)
        {
            var query = @"SELECT 
                            Supplier.[Id],
                            Supplier.[Name],
                            Supplier.[Summary],
                            Supplier.[SupplierUrl],
                            Supplier.[LastUpdated],
                            Supplier.[LastUpdatedBy]
                        FROM [dbo].[Supplier] 
                        LEFT JOIN CatalogueItem on CatalogueItem.SupplierId = Supplier.Id 
                        WHERE CatalogueItem.CatalogueItemId=@solutionId";
            return SqlExecutor.Execute<Supplier>(connectionString, query, new { solutionId }).Single();
        }

        public void Update(string connectionString)
        {
            var query = @"UPDATE Supplier 
                        SET 
                            Name=@name, 
                            LegalName=@legalName, 
                            Summary=@summary, 
                            SupplierUrl=@supplierUrl, 
                            LastUpdated=@lastUpdated, 
                            LastUpdatedBy=@lastUpdatedBy 
                        WHERE Id=@Id";
            SqlExecutor.Execute<Supplier>(connectionString, query, this);
        }

        public void Delete(string connectionString)
        {
            var query = @"DELETE from Supplier where Id=@Id";
            SqlExecutor.Execute<Supplier>(connectionString, query, this);
        }
    }
}
