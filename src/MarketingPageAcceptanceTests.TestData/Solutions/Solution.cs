﻿namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MarketingPageAcceptanceTests.TestData.Utils;

    public sealed class Solution
    {
        public string Id { get; set; }

        public string SolutionId => Id;

        public string Version { get; set; }

        public string SolutionVersion => Version;

        public string Summary { get; set; }

        public string FullDescription { get; set; }

        public string Features { get; set; }

        public string ClientApplication { get; set; }

        public string Hosting { get; set; }

        public string ImplementationDetail { get; set; }

        public string RoadMap { get; set; }

        public string IntegrationsUrl { get; set; }

        public string AboutUrl { get; set; }

        public string ServiceLevelAgreement { get; set; }

        public DateTime LastUpdated { get; set; }

        public Guid LastUpdatedBy { get; set; }

        public static async Task<IEnumerable<string>> RetrieveAllAsync(string connectionString)
        {
            var query = @"SELECT * FROM [dbo].[Solution]";

            return (await SqlExecutor.ExecuteAsync<Solution>(connectionString, query, null)).Select(s => s.Id);
        }

        public async Task<Solution> RetrieveAsync(string connectionString)
        {
            var query = "SELECT * from [dbo].[Solution] WHERE Solution.Id=@solutionId";

            return (await SqlExecutor.ExecuteAsync<Solution>(connectionString, query, this)).Single();
        }

        public async Task CreateAsync(string connectionString)
        {
            var query = @"INSERT INTO Solution (Id, Version, Summary, FullDescription, Features, ClientApplication, Hosting, ImplementationDetail, RoadMap, IntegrationsUrl, AboutUrl, ServiceLevelAgreement, LastUpdatedBy, LastUpdated) values (@SolutionId, @Version, @Summary, @FullDescription, @Features, @ClientApplication, @Hosting, @ImplementationDetail, @RoadMap, @IntegrationsUrl, @AboutUrl, @ServiceLevelAgreement, @LastUpdatedBy, @LastUpdated)";
            await SqlExecutor.ExecuteAsync<Solution>(connectionString, query, this);
        }

        public async Task UpdateAsync(string connectionString)
        {
            var query = @"UPDATE Solution SET Version=@solutionVersion, Summary=@Summary, FullDescription=@FullDescription, Features=@Features, ClientApplication=@ClientApplication, Hosting=@Hosting, ImplementationDetail=@ImplementationDetail, RoadMap=@RoadMap, IntegrationsUrl=@IntegrationsUrl, AboutUrl=@AboutUrl, ServiceLevelAgreement=@ServiceLevelAgreement, LastUpdatedBy=@LastUpdatedBy, LastUpdated=@LastUpdated WHERE Id=@solutionId";
            await SqlExecutor.ExecuteAsync<Solution>(connectionString, query, this);
        }

        public async Task DeleteAsync(string connectionString)
        {
            var query = @"DELETE FROM Solution WHERE Id=@solutionId";
            await SqlExecutor.ExecuteAsync<Solution>(connectionString, query, this);
        }
    }
}
