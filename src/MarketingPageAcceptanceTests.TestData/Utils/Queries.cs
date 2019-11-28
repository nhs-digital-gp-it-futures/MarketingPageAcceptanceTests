namespace MarketingPageAcceptanceTests.TestData.Utils
{
    internal static class Queries
    {
        internal const string CreateNewSolution = @"INSERT INTO Solution 
            (
                Id, 
                SupplierId, 
                OrganisationId, 
                Name, 
                Version, 
                PublishedStatusId, 
                AuthorityStatusId, 
                SupplierStatusId, 
                OnCatalogueVersion, 
                LastUpdated, 
                LastUpdatedBy
            ) 
            VALUES 
            (
                @solutionId, 
                (SELECT TOP (1) [Id] FROM [dbo].[Supplier]), 
                (SELECT TOP (1) [Id] FROM [dbo].[Organisation]), 
                @solutionName, 
                @solutionVersion, 
                4,
                1,
                1, 
                0, 
                CURRENT_TIMESTAMP, 
                NewID()
            )";
        internal const string GetSolution = "SELECT Summary, FullDescription, SupplierStatusId from [dbo].[Solution] LEFT JOIN [dbo].[SolutionDetail] ON Solution.Id = SolutionDetail.SolutionId where Solution.Id=@solutionId";
        internal const string DeleteSolution = "DELETE from Solution where Id=@solutionId";
        internal const string UpdateSolutionWithSolutionDetailId = "UPDATE [Solution] SET [Solution].SolutionDetailId=[SolutionDetail].Id FROM [dbo].[Solution] INNER JOIN  [dbo].[SolutionDetail] ON [Solution].Id=[SolutionDetail].SolutionId WHERE [Solution].Id=@solutionId";

        internal const string CreateSolutionDetail = @"INSERT INTO SolutionDetail 
            (
                Id, 
                SolutionId, 
                PublishedStatusId,
                Features,
                ClientApplication,
                Hosting,
                AboutUrl, 
                Summary, 
                FullDescription,
                LastUpdated, 
                LastUpdatedBy
            ) 
            VALUES 
            (
                NewID(), 
                @solutionId, 
                4,
                NULL,
                NULL,
                NULL,
                NULL,
			    NULL,
			    NULL,
                CURRENT_TIMESTAMP, 
                NewID()
            )";
        internal const string GetSolutionDetail = "SELECT Features, AboutUrl from [dbo].[SolutionDetail] where SolutionId=@solutionId";
        internal const string UpdateSolutionDetail = "UPDATE SolutionDetail SET Features=@features, ClientApplication=@clientApplication, AboutUrl=@aboutUrl WHERE SolutionId=@solutionId";
        internal const string DeleteSolutionDetail = "DELETE from SolutionDetail where SolutionId=@solutionId";
    }
}
