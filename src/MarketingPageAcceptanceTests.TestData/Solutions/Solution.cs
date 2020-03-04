using MarketingPageAcceptanceTests.TestData.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public sealed class Solution
    {
        public string Id { get; set; }
        public string SolutionId => Id;
        public string Name { get; set; }
        public string SolutionName => Name;
        public string Version { get; set; }
        public string SolutionVersion => Version;
        public string SupplierId { get; set; } = "100000";
        public int PublishedStatusId { get; set; } = 1;
        public int AuthorityStatusId { get; set; } = 1;
        public int SupplierStatusId { get; set; } = 1;
        public Guid SolutionDetailId { get; set; }
        public DateTime LastUpdated { get; set; }
        public Guid LastUpdatedBy { get; set; }

        public Solution Retrieve(string connectionString)
        {
            var query = "SELECT * from [dbo].[Solution] WHERE Solution.Id=@solutionId";

            return SqlExecutor.Execute<Solution>(connectionString, query, this).Single();
        }

        public void Create(string connectionString)
        {
            var query = @"INSERT INTO Solution (
                            Id, 
                            SupplierId, 
                            Name, 
                            Version, 
                            PublishedStatusId, 
                            AuthorityStatusId, 
                            SupplierStatusId, 
                            OnCatalogueVersion, 
                            LastUpdatedBy, 
                            LastUpdated) 
                        VALUES (
                            @SolutionId, 
                            @SupplierId, 
                            @SolutionName, 
                            @SolutionVersion, 
                            @PublishedStatusId,
                            @AuthorityStatusId,
                            @SupplierStatusId, 
                            0, 
                            @LastUpdatedBy, 
                            @LastUpdated
                        )";
            SqlExecutor.Execute<Solution>(connectionString, query, this);
        }

        public void Update(string connectionString)
        {
            var query = @"UPDATE Solution 
                        SET 
                            SolutionDetailId=@solutionDetailId, 
                            SupplierId=@supplierId, 
                            Name=@solutionName, 
                            Version=@solutionVersion, 
                            PublishedStatusId=@publishedStatusId,  
                            AuthorityStatusId=@authorityStatusId, 
                            SupplierStatusId=@supplierStatusId 
                        WHERE Id=@solutionId";
            SqlExecutor.Execute<Solution>(connectionString, query, this);
        }

        public void Delete(string connectionString)
        {
            var query = @"DELETE FROM Solution WHERE Id=@solutionId";
            SqlExecutor.Execute<Solution>(connectionString, query, this);
        }

        public IEnumerable<string> RetrieveAll(string connectionString)
        {
            var query = @"SELECT * FROM [dbo].[Solution]";

            return SqlExecutor.Execute<Solution>(connectionString, query, null).Select(s => s.Id);
        }
    }
}
