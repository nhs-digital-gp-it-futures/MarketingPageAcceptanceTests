using System;
using System.Collections.Generic;
using System.IO;
using MarketingPageAcceptanceTests.Actions;
using MarketingPageAcceptanceTests.Actions.Collections;
using MarketingPageAcceptanceTests.TestData.Azure;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Suppliers;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Steps.Utils
{
    public sealed class UITest
    {
        internal AzureBlobStorage azureBlobStorage;
        internal string ConnectionString;
        internal string defaultAzureBlobStorageContainerName;
        internal string downloadPath;
        internal IWebDriver Driver;
        internal string ExpectedSectionLinkInErrorMessage;
        internal List<Solution> listOfSolutions = new List<Solution>();
        internal PageActionCollection Pages;
        internal Solution solution;
        internal SolutionDetail solutionDetail;
        internal Supplier supplier;
        internal string url;

        public UITest()
        {
            ConnectionString = EnvironmentVariables.DbConnectionString();
            azureBlobStorage =
                new AzureBlobStorage(EnvironmentVariables.AzureBlobStorageConnectionString());
            defaultAzureBlobStorageContainerName = EnvironmentVariables.AzureContainerName();
            downloadPath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "downloads");

            solution = GenerateSolution.GenerateNewSolution(checkForUnique: true, connectionString: ConnectionString);
            solution.Create(ConnectionString);
            solutionDetail = GenerateSolutionDetails.GenerateNewSolutionDetail(solution.Id, Guid.NewGuid(), 0, false);
            solutionDetail.Create(ConnectionString);
            solution.SolutionDetailId = solutionDetail.SolutionDetailId;
            solution.Update(ConnectionString);

            Driver = new BrowserFactory().Driver;
            Pages = new PageActions(Driver).PageActionCollection;
        }

        public string UserType { get; set; } = "supplier";

        public void SetUrl(string solutionId = null, string userType = null)
        {
            // If param is null, use the solution created at the start of the test run
            if (string.IsNullOrEmpty(solutionId)) solutionId = solution.Id;

            // If param is not null, set the UserType property to be the provided usertype
            if (userType != null) UserType = userType;

            url = $"{EnvironmentVariables.Url()}/{solutionId}".Replace("supplier", UserTypeConvert());
        }

        public void GoToUrl()
        {
            Driver.Navigate().GoToUrl(url);
        }

        private string UserTypeConvert()
        {
            return UserType.ToLower() switch
            {
                "supplier" => "supplier",
                "authority" => "authority",
                "authority user" => "authority",
                _ => "supplier"
            };
        }
    }
}