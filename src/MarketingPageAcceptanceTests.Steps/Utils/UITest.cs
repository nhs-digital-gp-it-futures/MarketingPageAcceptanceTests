namespace MarketingPageAcceptanceTests.Steps.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MarketingPageAcceptanceTests.Actions;
    using MarketingPageAcceptanceTests.Actions.Collections;
    using MarketingPageAcceptanceTests.TestData.Solutions;
    using MarketingPageAcceptanceTests.TestData.Suppliers;
    using OpenQA.Selenium;

    public sealed class UITest
    {
        private readonly Settings settings;

        public UITest(Settings settings, BrowserFactory browserFactory)
        {
            this.settings = settings;

            ConnectionString = this.settings.DatabaseSettings.ConnectionString;
            Driver = browserFactory.Driver;
            Pages = new PageActions(Driver).PageActionCollection;
        }

        public string UserType { get; set; } = "supplier";

        public bool CreateSolution { get; set; }

        public IWebDriver Driver { get; }

        public string ConnectionString { get; }

        public string ExpectedSectionLinkInErrorMessage { get; set; }

        public List<Solution> ListOfSolutions { get; init; } = new();

        public PageActionCollection Pages { get; }

        public Solution Solution { get; set; }

        public CatalogueItem CatalogueItem { get; set; }

        public Supplier Supplier { get; set; }

        public string Url { get; set; }

        public string SolutionIdPrefix { get; set; } = "Auto";

        public string CompleteUrl { get; set; }

        public void SetUrl(string solutionId = null, string userType = null)
        {
            if (solutionId is null)
            {
                if (CreateSolution)
                {
                    CreateNewSolution(SolutionIdPrefix);
                }
                else
                {
                    GetExistingSolution();
                }
            }
            else
            {
                Solution = new Solution() { Id = solutionId }.Retrieve(ConnectionString);
            }

            // If param is not null, set the UserType property to be the provided usertype
            if (userType != null)
            {
                UserType = userType;
            }

            var url = new Uri(GetUrl());

            CompleteUrl = new Uri(url, Solution.Id).ToString();
        }

        public void GoToUrl()
        {
            Driver.Navigate().GoToUrl(CompleteUrl);
        }

        private void GetExistingSolution()
        {
            var solutionId = Solution.RetrieveAll(ConnectionString).First();

            Solution = new Solution() { Id = solutionId }.Retrieve(ConnectionString);
        }

        private void CreateNewSolution(string prefix)
        {
            CatalogueItem = GenerateCatalogueItem.GenerateNewCatalogueItem(prefix: prefix, checkForUnique: true, connectionString: ConnectionString);
            CatalogueItem.Create(ConnectionString);
            Solution = GenerateSolution.GenerateNewSolution(CatalogueItem.CatalogueItemId, clientApplication: false);
            Solution.Create(ConnectionString);
        }

        private string GetUrl()
        {
            return UserType.ToLower() switch
            {
                "supplier" => settings.SupplierMarketingPageUrl,
                "authority" => settings.AuthorityMarketingPageUrl,
                "authority user" => settings.AuthorityMarketingPageUrl,
                _ => settings.SupplierMarketingPageUrl,
            };
        }
    }
}
