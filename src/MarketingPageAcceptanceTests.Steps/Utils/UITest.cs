using MarketingPageAcceptanceTests.Actions;
using MarketingPageAcceptanceTests.Actions.Collections;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Suppliers;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

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

        public UITest(Settings settings, BrowserFactory browserFactory)
        {
            ConnectionString = settings.DatabaseSettings.ConnectionString;
            Url = settings.MarketingPageUrl;
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

            CompleteUrl = $"{Url}/{solution.Id}".Replace("supplier", UserTypeConvert());
        }

        private void GetExistingSolution()
        {
            var solutionId = new Solution().RetrieveAll(ConnectionString).First();

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