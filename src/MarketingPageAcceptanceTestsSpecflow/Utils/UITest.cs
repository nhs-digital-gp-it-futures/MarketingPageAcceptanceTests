using MarketingPageAcceptanceTests.Actions;
using MarketingPageAcceptanceTests.Actions.Collections;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Utils;
using OpenQA.Selenium;
using System;

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

        public UITest()
        {
            solution = CreateSolution.CreateNewSolution();
            solutionDetail = CreateSolutionDetails.CreateNewSolutionDetail(solution.Id, Guid.NewGuid(), 0, false);

            connectionString = EnvironmentVariables.GetConnectionString();
            SqlHelper.CreateBlankSolution(solution, solutionDetail, connectionString);

            // Reformatting to remove chance of rogue '/' between site url and solution id
            url = $"{EnvironmentVariables.GetUrl()}/{solution.Id}";

            driver = new BrowserFactory().Driver;
            pages = new PageActions(driver).PageActionCollection;

            driver.Navigate().GoToUrl(url);
        }
    }
}
