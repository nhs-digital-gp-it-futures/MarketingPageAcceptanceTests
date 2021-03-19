namespace MarketingPageAcceptanceTests.TestData.Suppliers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MarketingPageAcceptanceTests.TestData.Utils;

    public sealed class Supplier
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string LegalName { get; set; }

        public string Summary { get; set; }

        public string SupplierUrl { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.Now;

        public Guid LastUpdatedBy { get; set; } = Guid.Empty;

        public static async Task<Supplier> RetrieveSupplierForSolutionAsync(string connectionString, string solutionId)
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
            return (await SqlExecutor.ExecuteAsync<Supplier>(connectionString, query, new { solutionId })).Single();
        }

        public async Task CreateAsync(string connectionString)
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
            await SqlExecutor.ExecuteAsync<Supplier>(connectionString, query, this);
        }

        public async Task<Supplier> RetrieveAsync(string connectionString)
        {
            var query = @"SELECT * FROM [dbo].[Supplier] WHERE [Id]=@Id";
            return (await SqlExecutor.ExecuteAsync<Supplier>(connectionString, query, this)).Single();
        }

        public async Task UpdateAsync(string connectionString)
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
            await SqlExecutor.ExecuteAsync<Supplier>(connectionString, query, this);
        }

        public async Task DeleteAsync(string connectionString)
        {
            var query = @"DELETE from Supplier where Id=@Id";
            await SqlExecutor.ExecuteAsync<Supplier>(connectionString, query, this);
        }
    }
}
