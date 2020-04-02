using MarketingPageAcceptanceTests.Actions;
using MarketingPageAcceptanceTests.Actions.Collections;
using MarketingPageAcceptanceTests.TestData.Solutions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketingPageAcceptanceTests.SmokeTests.Utils
{
    public sealed class UITest
    {
        public string ConnectionString;
        public IWebDriver Driver;
        public List<Solution> listOfSolutions = new List<Solution>();
        public PageActionCollection Pages;
        public Solution solution;
        public SolutionDetail solutionDetail;
        public string url;
        public WebDriverWait Wait;

        public UITest()
        {
            ConnectionString = EnvironmentVariables.DbConnectionString();

            GetSolution();

            Driver = new BrowserFactory().Driver;
            Pages = new PageActions(Driver).PageActionCollection;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
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

        private void GetSolution()
        {
            var solutionId = new Solution().RetrieveAll(ConnectionString).First();

            solution = new Solution() { Id = solutionId }.Retrieve(ConnectionString);
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