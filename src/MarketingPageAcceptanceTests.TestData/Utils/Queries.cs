namespace MarketingPageAcceptanceTests.TestData.Utils
{
    internal static class Queries
    {
        internal const string CreateNewSolution = "INSERT INTO Solution (Id, SupplierId, OrganisationId, Name, Version, PublishedStatusId, AuthorityStatusId, SupplierStatusId, OnCatalogueVersion, LastUpdated, LastUpdatedBy) values (@solutionId, (SELECT TOP (1) [Id] FROM [dbo].[Supplier]), (SELECT TOP (1) [Id] FROM [dbo].[Organisation]), @solutionName, @solutionVersion, 1,1,1, 0, CURRENT_TIMESTAMP, NewID())";
        internal const string GetSolution = "SELECT Summary, FullDescription, SupplierStatusId from [dbo].[Solution] where Id=@solutionId";
        internal const string DeleteSolution = "DELETE from Solution where Id=@solutionId";

        internal const string CreateMarketingDetail = "INSERT INTO SolutionDetail (Id, SolutionId, LastUpdated, LastUpdatedBy) values (NewID(), @solutionId, CURRENT_TIMESTAMP, NewID())";
        internal const string GetMarketingDetail = "SELECT Features, AboutUrl from [dbo].[SolutionDetail] where SolutionId=@solutionId";
        internal const string UpdateMarketingDetail = "UPDATE SolutionDetail SET Features=@features, ClientApplication=@clientApplication, AboutUrl=@aboutUrl WHERE SolutionId=@solutionId";
        internal const string DeleteMarketingDetail = "DELETE from SolutionDetail where SolutionId=@solutionId";
    }
}
