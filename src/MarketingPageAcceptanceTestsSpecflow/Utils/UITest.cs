using MarketingPageAcceptanceTests.Actions;
using MarketingPageAcceptanceTests.Actions.Collections;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Suppliers;
using MarketingPageAcceptanceTests.TestData.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace MarketingPageAcceptanceTestsSpecflow.Utils
{
    public sealed class UITest
    {
        internal IWebDriver driver;
        internal PageActionCollection pages;
        internal string connectionString;
        internal string url;
        internal Solution solution;
        internal SolutionDetail solutionDetail;
        internal string ExpectedSectionLinkInErrorMessage;
        internal Supplier supplier;
        internal List<Solution> listOfSolutions = new List<Solution>();

        public UITest()
        {
            connectionString = EnvironmentVariables.GetConnectionString();

            solution = CreateSolution.CreateNewSolution(checkForUnique: true, connectionString: connectionString);
            solutionDetail = CreateSolutionDetails.CreateNewSolutionDetail(solution.Id, Guid.NewGuid(), 0, false);

            SqlHelper.CreateBlankSolution(solution, solutionDetail, connectionString);

            driver = new BrowserFactory().Driver;
            pages = new PageActions(driver).PageActionCollection;
        }

        public string DetermineUser(string scenarioTitle)
        {
            return scenarioTitle.Contains("authority", System.StringComparison.OrdinalIgnoreCase) ? "authoriy" : "supplier";
        }

        public void SetUrl(string solutionId, string userType = "supplier")
        {
            url = $"{EnvironmentVariables.GetUrl()}/{solutionId}".Replace("supplier", userType);
        }

        public void GoToUrl()
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
