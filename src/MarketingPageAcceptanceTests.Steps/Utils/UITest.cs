using System;
using System.Collections.Generic;
using System.Linq;
using MarketingPageAcceptanceTests.Actions;
using MarketingPageAcceptanceTests.Actions.Collections;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Suppliers;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Steps.Utils
{
    public sealed class UITest
    {
        public string ConnectionString;
        public IWebDriver Driver;
        public string ExpectedSectionLinkInErrorMessage;
        public List<Solution> listOfSolutions = new List<Solution>();
        public PageActionCollection Pages;
        public Solution solution;
        public CatalogueItem catalogueItem;
        public Supplier supplier;
        public string Url;
        public string solutionIdPrefix = "Auto";
        public string CompleteUrl;

        private readonly Settings _settings;

        public UITest(Settings settings, BrowserFactory browserFactory)
        {
            _settings = settings;

            ConnectionString = _settings.DatabaseSettings.ConnectionString;
            Driver = browserFactory.Driver;
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
                    CreateNewSolution(solutionIdPrefix);
                }
                else
                {
                    GetExistingSolution();
                }
            }
            else
            {
                solution = new Solution() { Id = solutionId }.Retrieve(ConnectionString);
            }

            // If param is not null, set the UserType property to be the provided usertype
            if (userType != null) UserType = userType;

            var url = new Uri(GetUrl());

            CompleteUrl = new Uri(url, solution.Id).ToString();
        }

        private void GetExistingSolution()
        {
            var solutionId = Solution.RetrieveAll(ConnectionString).First();

            solution = new Solution() { Id = solutionId }.Retrieve(ConnectionString);
        }

        private void CreateNewSolution(string prefix)
        {
            catalogueItem = GenerateCatalogueItem.GenerateNewCatalogueItem(prefix: prefix, checkForUnique: true, connectionString: ConnectionString);
            catalogueItem.Create(ConnectionString);
            solution = GenerateSolution.GenerateNewSolution(catalogueItem.CatalogueItemId, clientApplication: false);
            solution.Create(ConnectionString);
        }

        public void GoToUrl()
        {
            Driver.Navigate().GoToUrl(CompleteUrl);
        }

        private string GetUrl()
        {
            return UserType.ToLower() switch
            {
                "supplier" => _settings.SupplierMarketingPageUrl,
                "authority" => _settings.AuthorityMarketingPageUrl,
                "authority user" => _settings.AuthorityMarketingPageUrl,
                _ => _settings.SupplierMarketingPageUrl
            };
        }
    }
}
