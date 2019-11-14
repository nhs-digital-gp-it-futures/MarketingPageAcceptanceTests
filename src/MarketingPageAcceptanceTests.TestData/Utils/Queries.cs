namespace MarketingPageAcceptanceTests.TestData.Utils
{
    internal static class Queries
    {
        internal const string CreateNewSolution = "INSERT INTO Solution (Id, SupplierId, OrganisationId, Name, Version, PublishedStatusId, AuthorityStatusId, SupplierStatusId, OnCatalogueVersion, LastUpdatedBy, LastUpdated) values (@solutionId, 100000, '315F73EC-66C6-42CD-B97A-615CA9586BE8', @solutionName, @solutionVersion, 1,1,1, 0, @lastUpdatedBy, @lastUpdated)";
        internal const string GetSolution = "SELECT SupplierStatusId from [dbo].[Solution] where Id=@solutionId";
        internal const string UpdateSolution = "UPDATE Solution SET (Id=@solutionId, OrganisationId='315F73EC-66C6-42CD-B97A-615CA9586BE8', Name=@solutionName, Version=@solutionVersion, PublishedStatusId=1, AuthorityStatusId=1, SupplierStatusId=1, OnCatalogueVersion=0, SolutionDetailId=@solutionDetailId)";
        internal const string UpdateSolutionSolutionDetailId = "UPDATE Solution SET SolutionDetailId=@solutionDetailId WHERE Id=@solutionId";
        internal const string DeleteSolution = "DELETE from Solution where Id=@solutionId";

        internal const string CreateSolutionDetail = "INSERT INTO SolutionDetail (Id, LastUpdatedBy, LastUpdated, SolutionId) values (@solutionDetailId, @lastUpdatedBy, @lastUpdated, @solutionId)";
        internal const string GetSolutionDetail = "SELECT Features, AboutUrl, Summary, FullDescription from [dbo].[SolutionDetail] where SolutionId=@solutionId";
        internal const string UpdateSolutionDetail = "UPDATE SolutionDetail SET Features=@features, ClientApplication=@clientApplication, AboutUrl=@aboutUrl, Summary=@summary, FullDescription=@fullDescription WHERE SolutionId=@solutionId";        
        internal const string DeleteSolutionDetail = "DELETE from SolutionDetail where SolutionId=@solutionId";
    }
}
