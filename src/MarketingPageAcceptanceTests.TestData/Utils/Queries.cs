namespace MarketingPageAcceptanceTests.TestData.Utils
{
    internal static class Queries
    {
        internal const string CreateNewSolution = "INSERT INTO Solution (Id, SupplierId, Name, Version, PublishedStatusId, AuthorityStatusId, SupplierStatusId, OnCatalogueVersion, LastUpdatedBy, LastUpdated) values (@solutionId, @supplierId, @solutionName, @solutionVersion, 1,1,1, 0, @lastUpdatedBy, @lastUpdated)";
        internal const string GetSolution = "SELECT Summary, FullDescription, SupplierStatusId from [dbo].[Solution] LEFT JOIN [dbo].[SolutionDetail] ON Solution.Id = SolutionDetail.SolutionId where Solution.Id=@solutionId";
        internal const string UpdateSolutionSolutionDetailId = "UPDATE Solution SET SolutionDetailId=@solutionDetailId WHERE Id=@solutionId";
        internal const string UpdateSolutionSupplierlId = "UPDATE Solution SET SupplierId=@supplierId WHERE Id=@solutionId";
        internal const string DeleteSolution = "DELETE from Solution where Id=@solutionId";

        internal const string CreateSolutionDetail = "INSERT INTO SolutionDetail (Id, LastUpdatedBy, LastUpdated, SolutionId) values (@solutionDetailId, @lastUpdatedBy, @lastUpdated, @solutionId)";
        internal const string GetSolutionDetail = "SELECT Features, AboutUrl, Summary, FullDescription from [dbo].[SolutionDetail] where SolutionId=@solutionId";
        internal const string UpdateSolutionDetail = "UPDATE SolutionDetail SET Features=@features, ClientApplication=@clientApplication, AboutUrl=@aboutUrl, Summary=@summary, FullDescription=@fullDescription, RoadMap=@roadMap, Hosting=@hostingTypes WHERE SolutionId=@solutionId";
        internal const string DeleteSolutionDetail = "DELETE from SolutionDetail where SolutionId=@solutionId";

        internal const string GetMarketingContacts = "SELECT FirstName, LastName, PhoneNumber, Department, Email FROM MarketingContact WHERE SolutionId=@solutionId";
        internal const string GetNumberOfMarketingContactsForSolution = "SELECT COUNT (*) AS Count FROM [dbo].[MarketingContact] WHERE SolutionId=@solutionId";
        internal const string CreateMarketingContact = "INSERT INTO [MarketingContact] (SolutionId, FirstName, LastName, Email, PhoneNumber, Department, LastUpdated, LastUpdatedBy) VALUES(@solutionId, @firstName, @lastName, @email, @phoneNumber, @department, GETDATE(), '00000000-0000-0000-0000-000000000000')";
        internal const string DeleteMarketingContact = "DELETE FROM MarketingContact where SolutionId=@solutionId";

        internal const string UpdateLastUpdated = "UPDATE @table SET LastUpdated=@lastUpdated WHERE @whereKey=@whereValue";
        internal const string GetLastUpdated = "SELECT LastUpdated FROM @table WHERE @whereKey=@whereValue";

        internal const string CreateNewSupplier = "INSERT INTO Supplier (Id, Name, LegalName, Summary, SupplierUrl, LastUpdated, LastUpdatedBy) values (@supplierId, @name, @legalName, @summary, @supplierUrl, @lastUpdated, @lastUpdatedBy)";
        internal const string DeleteSupplier = "DELETE from Supplier where Id=@supplierId";
        internal const string GetSupplier = "SELECT [Id],[Name],[Summary],[SupplierUrl],[LastUpdated],[LastUpdatedBy]FROM [dbo].[Supplier] WHERE [Id]=@supplierId";
        internal const string GetSupplierForSolution = "SELECT Supplier.[Id],Supplier.[Name],Supplier.[Summary],Supplier.[SupplierUrl],Supplier.[LastUpdated],Supplier.[LastUpdatedBy]FROM [dbo].[Supplier] LEFT JOIN Solution on Solution.SupplierId = Supplier.Id WHERE Solution.Id=@solutionId";
        internal const string UpdateSupplier = "UPDATE Supplier SET Name=@name, LegalName=@legalName, Summary=@summary, SupplierUrl=@supplierUrl, LastUpdated=@lastUpdated, LastUpdatedBy=@lastUpdatedBy WHERE Id=@supplierId";
    }
}
