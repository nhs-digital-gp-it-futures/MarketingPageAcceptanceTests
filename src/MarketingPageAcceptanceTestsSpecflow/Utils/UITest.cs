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

        public UITest()
        {
            solution = CreateSolution.CreateNewSolution();
            Console.WriteLine(solution.Id);
            Console.WriteLine(solution.Name);
            Console.WriteLine(solution.Version);
            var (serverUrl, databaseName, dbUser, dbPassword) = EnvironmentVariables.GetDbConnectionDetails();
            connectionString = string.Format(ConnectionString.GPitFutures, serverUrl, databaseName, dbUser, dbPassword);
            SqlHelper.CreateBlankSolution(solution, connectionString);

            var url = EnvironmentVariables.GetUrl();
            this.url = $"{url}/{solution.Id}";
            // Navigate to the site url            

            driver = new BrowserFactory().Driver;

            pages = new PageActions(driver).PageActionCollection;

            driver.Navigate().GoToUrl(this.url);
        }
    }
}
