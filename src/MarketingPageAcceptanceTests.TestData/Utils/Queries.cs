namespace MarketingPageAcceptanceTests.TestData.Utils
{
    internal static class Queries
    {
        internal const string CreateNewSolution = "INSERT INTO Solution (Id, SupplierId, OrganisationId, Name, Version, PublishedStatusId, AuthorityStatusId, SupplierStatusId, OnCatalogueVersion, LastUpdatedBy, LastUpdated) values (@solutionId, (SELECT TOP (1) [Id] FROM [dbo].[Supplier]), (SELECT TOP (1) [Id] FROM [dbo].[Organisation]), @solutionName, @solutionVersion, 1,1,1, 0, @lastUpdatedBy, @lastUpdated)";
        internal const string GetSolution = "SELECT Summary, FullDescription, SupplierStatusId from [dbo].[Solution] LEFT JOIN [dbo].[SolutionDetail] ON Solution.Id = SolutionDetail.SolutionId where Solution.Id=@solutionId";
        internal const string UpdateSolutionSolutionDetailId = "UPDATE Solution SET SolutionDetailId=@solutionDetailId WHERE Id=@solutionId";
        internal const string DeleteSolution = "DELETE from Solution where Id=@solutionId";

        internal const string CreateSolutionDetail = "INSERT INTO SolutionDetail (Id, LastUpdatedBy, LastUpdated, SolutionId) values (@solutionDetailId, @lastUpdatedBy, @lastUpdated, @solutionId)";
        internal const string GetSolutionDetail = "SELECT Features, AboutUrl, Summary, FullDescription from [dbo].[SolutionDetail] where SolutionId=@solutionId";
        internal const string UpdateSolutionDetail = "UPDATE SolutionDetail SET Features=@features, ClientApplication=@clientApplication, AboutUrl=@aboutUrl, Summary=@summary, FullDescription=@fullDescription WHERE SolutionId=@solutionId";
        internal const string DeleteSolutionDetail = "DELETE from SolutionDetail where SolutionId=@solutionId";

        internal const string GetMarketingContactDetails = "";
    }
}
