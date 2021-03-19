namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MarketingPageAcceptanceTests.TestData.Utils;

    public sealed class CatalogueItem
    {
        public string CatalogueItemId { get; set; }

        public string Name { get; set; }

        public int CatalogueItemTypeId { get; set; } = 1;

        public string SupplierId { get; set; } = "100000";

        public int PublishedStatusId { get; set; } = 1;

        public DateTime Created { get; set; }

        public static async Task<IEnumerable<string>> RetrieveAllAsync(string connectionString)
        {
            var query = "SELECT * FROM [dbo].[CatalogueItem]";
            return (await SqlExecutor.ExecuteAsync<CatalogueItem>(connectionString, query, null)).Select(c => c.CatalogueItemId);
        }

        public async Task<CatalogueItem> RetrieveAsync(string connectionString)
        {
            var query = "SELECT * from [dbo].[CatalogueItem] WHERE CatalogueItemId=@CatalogueItemId";
            return (await SqlExecutor.ExecuteAsync<CatalogueItem>(connectionString, query, this)).Single();
        }

        public async Task CreateAsync(string connectionString)
        {
            var query = "INSERT INTO CatalogueItem (CatalogueItemId, Name, CatalogueItemTypeId, SupplierId, PublishedStatusId, Created) values (@CatalogueItemId, @Name, @CatalogueItemTypeId, @SupplierId, @PublishedStatusId, @Created)";
            await SqlExecutor.ExecuteAsync<CatalogueItem>(connectionString, query, this);
        }

        public async Task UpdateAsync(string connectionString)
        {
            var query = "UPDATE CatalogueItem SET Name=@Name, CatalogueItemTypeId=@CatalogueItemTypeId, SupplierId=@SupplierId, PublishedStatusId=@publishedStatusId, Created=@Created WHERE CatalogueItemId=@CatalogueItemId";
            await SqlExecutor.ExecuteAsync<CatalogueItem>(connectionString, query, this);
        }

        public async Task DeleteAsync(string connectionString)
        {
            var query = "DELETE FROM CatalogueItem WHERE CatalogueItemId=@CatalogueItemId";
            await SqlExecutor.ExecuteAsync<CatalogueItem>(connectionString, query, this);
        }
    }
}
