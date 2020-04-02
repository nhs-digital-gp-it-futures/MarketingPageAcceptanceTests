using MarketingPageAcceptanceTests.TestData.Utils;
using System;
using System.Linq;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public sealed class SolutionDetail
    {
        public Guid SolutionDetailId { get; set; }
        public string SolutionId { get; set; }
        public string AboutUrl { get; set; }
        public string Features { get; set; }
        public string ClientApplication { get; set; }
        public string Summary { get; set; }
        public string FullDescription { get; set; }
        public string RoadMap { get; set; }
        public string HostingTypes { get; set; }
        public string IntegrationsUrl { get; set; }
        public string ImplementationTimescales { get; set; }
        public Guid LastUpdatedBy { get; set; } = Guid.Empty;
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        public SolutionDetail Retrieve(string connectionString)
        {
            var query = @"SELECT * from [dbo].[SolutionDetail] where SolutionId=@solutionId";

            return SqlExecutor.Execute<SolutionDetail>(connectionString, query, this).Single();
        }

        public void Create(string connectionString)
        {
            var query = @"INSERT INTO SolutionDetail (
                            Id, 
                            LastUpdatedBy, 
                            LastUpdated, 
                            SolutionId) 
                        VALUES (
                            @solutionDetailId, 
                            @lastUpdatedBy, 
                            @lastUpdated, 
                            @solutionId)";

            SqlExecutor.Execute<SolutionDetail>(connectionString, query, this);
        }

        public void Update(string connectionString)
        {
            var query = @"UPDATE SolutionDetail 
                        SET 
                            Features=@features, 
                            ClientApplication=@clientApplication, 
                            AboutUrl=@aboutUrl, 
                            Summary=@summary, 
                            FullDescription=@fullDescription, 
                            RoadMap=@roadMap, 
                            Hosting=@hostingTypes, 
                            IntegrationsUrl=@integrationsUrl, 
                            ImplementationDetail=@implementationTimescales 
                        WHERE SolutionId=@solutionId";

            SqlExecutor.Execute<SolutionDetail>(connectionString, query, this);
        }

        public void Delete(string connectionString)
        {
            var query = @"DELETE from SolutionDetail where SolutionId=@solutionId";

            SqlExecutor.Execute<SolutionDetail>(connectionString, query, this);
        }
    }
}