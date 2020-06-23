using MarketingPageAcceptanceTests.TestData.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public sealed class CatalogueItem
    {

        public string CatalogueItemId { get; set; }
        public string Name { get; set; }
        public int CatalogueItemTypeId { get; set; } = 1;
        public string SupplierId { get; set; } = "100000";
        public int PublishedStatusId { get; set; } = 1;
        public DateTime Created { get; set; }

        public CatalogueItem Retrieve(string connectionString)
        {
            var query = "SELECT * from [dbo].[CatalogueItem] WHERE CatalogueItemId=@CatalogueItemId";
            return SqlExecutor.Execute<CatalogueItem>(connectionString, query, this).Single();
        }

        public void Create(string connectionString)
        {
            var query = "INSERT INTO CatalogueItem (CatalogueItemId, Name, CatalogueItemTypeId, SupplierId, PublishedStatusId, Created) values (@CatalogueItemId, @Name, @CatalogueItemTypeId, @SupplierId, @PublishedStatusId, @Created)";
            SqlExecutor.Execute<CatalogueItem>(connectionString, query, this);
        }

        public void Update(string connectionString)
        {
            var query = "UPDATE CatalogueItem SET Name=@Name, CatalogueItemTypeId=@CatalogueItemTypeId, SupplierId=@SupplierId, PublishedStatusId=@publishedStatusId, Created=@Created WHERE CatalogueItemId=@CatalogueItemId";
            SqlExecutor.Execute<CatalogueItem>(connectionString, query, this);
        }

        public void Delete(string connectionString)
        {
            var query = "DELETE FROM CatalogueItem WHERE CatalogueItemId=@CatalogueItemId";
            SqlExecutor.Execute<CatalogueItem>(connectionString, query, this);
        }

        public IEnumerable<string> RetrieveAll(string connectionString)
        {
            var query = "SELECT * FROM [dbo].[CatalogueItem]";
            return SqlExecutor.Execute<CatalogueItem>(connectionString, query, null).Select(c => c.CatalogueItemId);
        }
    }
