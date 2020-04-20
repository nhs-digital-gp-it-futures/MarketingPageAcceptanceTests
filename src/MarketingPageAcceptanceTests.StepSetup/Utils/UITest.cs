using MarketingPageAcceptanceTests.Actions;
using MarketingPageAcceptanceTests.Actions.Collections;
using MarketingPageAcceptanceTests.TestData.Azure;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Suppliers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MarketingPageAcceptanceTests.StepSetup.Utils
{
    public sealed class UITest
    {
        public AzureBlobStorage azureBlobStorage;
        public string ConnectionString;
        public string defaultAzureBlobStorageContainerName;
        public string downloadPath;
        public IWebDriver Driver;
        public string ExpectedSectionLinkInErrorMessage;
        public List<Solution> listOfSolutions = new List<Solution>();
        public PageActionCollection Pages;
        public Solution solution;
        public SolutionDetail solutionDetail;
        public Supplier supplier;
        public string url;

        public UITest()
        {
            ConnectionString = EnvironmentVariables.DbConnectionString();
            azureBlobStorage =
                new AzureBlobStorage(EnvironmentVariables.AzureBlobStorageConnectionString());
            defaultAzureBlobStorageContainerName = EnvironmentVariables.AzureContainerName();
            downloadPath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "downloads");

            Driver = new BrowserFactory().Driver;
            Pages = new PageActions(Driver).PageActionCollection;
        }

        public string UserType { get; set; } = "supplier";
        public bool CreateSolution { get; set; }

        public void SetUrl(string solutionId = null, string userType = null)
        {
            if (solutionId is null)
            {
                if (CreateSolution)
                {
                    CreateNewSolution();
                }
                else
                {
                    GetExistingSolution();
                }
            }

            // If param is not null, set the UserType property to be the provided usertype
            if (userType != null) UserType = userType;

            url = $"{EnvironmentVariables.Url()}/{solution.Id}".Replace("supplier", UserTypeConvert());
        }

        private void GetExistingSolution()
        {
            var solutionId = new Solution().RetrieveAll(ConnectionString).First();

            solution = new Solution() { Id = solutionId }.Retrieve(ConnectionString);
        }

        private void CreateNewSolution()
        {
            solution = GenerateSolution.GenerateNewSolution(checkForUnique: true, connectionString: ConnectionString);
            solution.Create(ConnectionString);
            solutionDetail = GenerateSolutionDetails.GenerateNewSolutionDetail(solution.Id, Guid.NewGuid(), 0, false);
            solutionDetail.Create(ConnectionString);
            solution.SolutionDetailId = solutionDetail.SolutionDetailId;
            solution.Update(ConnectionString);
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