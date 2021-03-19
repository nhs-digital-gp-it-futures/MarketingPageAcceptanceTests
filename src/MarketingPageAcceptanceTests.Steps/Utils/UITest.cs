namespace MarketingPageAcceptanceTests.Steps.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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

        public FrameworkSolution FrameworkSolution { get; set; }

        public bool DeleteSolution { get; private set; }

        public async Task SetUrlAsync(string solutionId = null, string userType = null)
        {
            if (solutionId is null)
            {
                if (CreateSolution)
                {
                    await CreateNewSolutionAsync();
                    DeleteSolution = true;
                }
                else
                {
                    await GetExistingSolutionAsync();
                    DeleteSolution = false;
                }
            }
            else
            {
                Solution = await new Solution() { Id = solutionId }.RetrieveAsync(ConnectionString);
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

        private async Task GetExistingSolutionAsync()
        {
            var solutionId = (await Solution.RetrieveAllAsync(ConnectionString)).First();

            Solution = await new Solution() { Id = solutionId }.RetrieveAsync(ConnectionString);
        }

        private async Task CreateNewSolutionAsync()
        {
            CatalogueItem = GenerateCatalogueItem.GenerateNewCatalogueItem();
            await CatalogueItem.CreateAsync(ConnectionString);
            Solution = GenerateSolution.GenerateNewSolution(CatalogueItem.CatalogueItemId, clientApplication: false);
            await Solution.CreateAsync(ConnectionString);
            FrameworkSolution = new FrameworkSolution { SolutionId = Solution.Id, FrameworkId = "NHSDGP001", IsFoundation = false };
            await FrameworkSolution.Create(ConnectionString);
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
