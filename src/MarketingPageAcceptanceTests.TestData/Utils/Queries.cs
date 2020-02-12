namespace MarketingPageAcceptanceTests.TestData.Utils
{
    internal static class Queries
    {
        internal const string CreateNewSolution = "INSERT INTO Solution (Id, SupplierId, Name, Version, PublishedStatusId, AuthorityStatusId, SupplierStatusId, OnCatalogueVersion, LastUpdatedBy, LastUpdated) values (@SolutionId, @SupplierId, @SolutionName, @SolutionVersion, @PublishedStatusId,@AuthorityStatusId,@SupplierStatusId, 0, @LastUpdatedBy, @LastUpdated)";
        internal const string GetSolution = "SELECT * from [dbo].[Solution] WHERE Solution.Id=@solutionId";
        internal const string UpdateSolution = "UPDATE Solution SET SolutionDetailId=@solutionDetailId, SupplierId=@supplierId, Name=@solutionName, Version=@solutionVersion, PublishedStatusId=@publishedStatusId, AuthorityStatusId=@authorityStatusId, SupplierStatusId=@supplierStatusId WHERE Id=@solutionId";
        internal const string UpdateSolutionSupplierlId = "UPDATE Solution SET SupplierId=@supplierId WHERE Id=@solutionId";
        internal const string DeleteSolution = "DELETE FROM Solution WHERE Id=@solutionId";
        internal const string GetAllSolutions = "SELECT * FROM [dbo].[Solution]";

        internal const string CreateSolutionDetail = "INSERT INTO SolutionDetail (Id, LastUpdatedBy, LastUpdated, SolutionId) values (@solutionDetailId, @lastUpdatedBy, @lastUpdated, @solutionId)";
        internal const string GetSolutionDetail = "SELECT * from [dbo].[SolutionDetail] where SolutionId=@solutionId";
        internal const string UpdateSolutionDetail = "UPDATE SolutionDetail SET Features=@features, ClientApplication=@clientApplication, AboutUrl=@aboutUrl, Summary=@summary, FullDescription=@fullDescription, RoadMap=@roadMap, Hosting=@hostingTypes, IntegrationsUrl=@integrationsUrl, ImplementationDetail=@implementationTimescales WHERE SolutionId=@solutionId";
        internal const string DeleteSolutionDetail = "DELETE from SolutionDetail where SolutionId=@solutionId";

        internal const string GetMarketingContacts = "SELECT * FROM MarketingContact WHERE SolutionId=@solutionId";
        internal const string GetNumberOfMarketingContactsForSolution = "SELECT COUNT(*) FROM [dbo].[MarketingContact] WHERE SolutionId=@solutionId";
        internal const string CreateMarketingContact = "INSERT INTO [MarketingContact] (SolutionId, FirstName, LastName, Email, PhoneNumber, Department, LastUpdated, LastUpdatedBy) VALUES(@solutionId, @firstName, @lastName, @email, @phoneNumber, @department, GETDATE(), '00000000-0000-0000-0000-000000000000')";
        internal const string DeleteMarketingContact = "DELETE FROM MarketingContact where SolutionId=@solutionId";

        internal const string UpdateLastUpdated = "UPDATE @table SET LastUpdated=@lastUpdated WHERE @whereKey=@whereValue";
        internal const string GetLastUpdated = "SELECT LastUpdated FROM @table WHERE @whereKey=@whereValue";

        internal const string CreateNewSupplier = "INSERT INTO Supplier (Id, Name, LegalName, Summary, SupplierUrl, LastUpdated, LastUpdatedBy) values (@Id, @name, @legalName, @summary, @supplierUrl, @lastUpdated, @lastUpdatedBy)";
        internal const string DeleteSupplier = "DELETE from Supplier where Id=@Id";
        internal const string GetSupplier = "SELECT * FROM [dbo].[Supplier] WHERE [Id]=@Id";
        internal const string GetSupplierForSolution = "SELECT Supplier.[Id],Supplier.[Name],Supplier.[Summary],Supplier.[SupplierUrl],Supplier.[LastUpdated],Supplier.[LastUpdatedBy]FROM [dbo].[Supplier] LEFT JOIN Solution on Solution.SupplierId = Supplier.Id WHERE Solution.Id=@solutionId";
        internal const string UpdateSupplier = "UPDATE Supplier SET Name=@name, LegalName=@legalName, Summary=@summary, SupplierUrl=@supplierUrl, LastUpdated=@lastUpdated, LastUpdatedBy=@lastUpdatedBy WHERE Id=@Id";
        
        internal const string GetCapabilityById = "SELECT * FROM Capability WHERE Id=@Id";
        internal const string GetAllCapabilities = "SELECT * FROM Capability";

        internal const string GetAllEpicsByCapabilityId = "SELECT TOP (1000) e.Id,e.Name,e.CapabilityId,c.Name AS Level FROM[buyingcatalogue].[dbo].[Epic] AS e INNER JOIN CompliancyLevel AS c ON e.CompliancyLevelId = c.Id WHERE e.CapabilityId=@Id";
    }
}
