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

            SetUrl(solution.Id);

            driver = new BrowserFactory().Driver;
            pages = new PageActions(driver).PageActionCollection;

            GoToUrl();
        }

        public void SetUrl(string solutionId)
        {
            // Reformatting to remove chance of rogue '/' between site url and solution id
            url = $"{EnvironmentVariables.GetUrl()}/{solutionId}";
        }

        public void GoToUrl()
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
