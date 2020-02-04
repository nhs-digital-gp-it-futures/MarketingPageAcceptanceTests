using MarketingPageAcceptanceTests.Actions;
using MarketingPageAcceptanceTests.Actions.Collections;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Suppliers;
using MarketingPageAcceptanceTests.TestData.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.Utils
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
        public string UserType { get; set; } = "supplier";

        public UITest()
        {
            connectionString = EnvironmentVariables.GetConnectionString();

            solution = CreateSolution.CreateNewSolution(checkForUnique: true, connectionString: connectionString);
            solutionDetail = CreateSolutionDetails.CreateNewSolutionDetail(solution.Id, Guid.NewGuid(), 0, false);

            SqlHelper.CreateBlankSolution(solution, solutionDetail, connectionString);

            driver = new BrowserFactory().Driver;
            pages = new PageActions(driver).PageActionCollection;
        }

        public void SetUrl(string solutionId = null, string userType = null)
        {
            // If param is null, use the solution created at the start of the test run
            if (string.IsNullOrEmpty(solutionId))
            {
                solutionId = solution.Id;
            }

            // If param is not null, set the UserType property to be the provided usertype
            if (userType != null)
            {
                UserType = userType;
            }

            url = $"{EnvironmentVariables.GetUrl()}/{solutionId}".Replace("supplier", UserTypeConvert());
        }

        public void GoToUrl()
        {
            driver.Navigate().GoToUrl(url);
        }

        private string UserTypeConvert()
        {
            string userType;

            switch (UserType)
            {
                case "supplier":
                case "Supplier":
                case "SUPPLIER":
                    userType = "supplier";
                    break;
                case "Authority":
                case "Authority user":
                case "Authority User":
                case "AUTHORITY USER":
                    userType = "authority";
                    break;
                default:
                    userType = "supplier";
                    break;
            }

            return userType;
        }
    }
}
