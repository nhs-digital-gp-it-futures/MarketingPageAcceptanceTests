using MarketingPageAcceptanceTests.Actions;
using MarketingPageAcceptanceTests.Actions.Collections;
using MarketingPageAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using System;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;
using Microsoft.Extensions.DependencyInjection;

namespace MarketingPageAcceptanceTests.Utils
{
    public abstract class UITest : Feature, IDisposable
    {
        internal readonly IWebDriver driver;
        internal readonly PageActionCollection pages;
        internal readonly string connectionString;
        internal readonly string url;
        internal Solution solution;

        internal ITestOutputHelper helper;

        public UITest(ITestOutputHelper helper)
        {   
            this.helper = helper;

            solution = CreateSolution.CreateNewSolution();

            // Get process only environment variables
            var (serverUrl, databaseName, dbUser, dbPassword) = EnvironmentVariables.GetDbConnectionDetails();
            connectionString = String.Format(ConnectionString.GPitFutures, serverUrl, databaseName, dbUser, dbPassword);
            SqlHelper.CreateBlankSolution(solution, connectionString);

            driver = new BrowserFactory().Driver;

            pages = new PageActions(driver, helper).PageActionCollection;

            var url = EnvironmentVariables.GetUrl();
            this.url = $"{url}/{solution.Id}";
            // Navigate to the site url
            driver.Navigate().GoToUrl(this.url);
            pages.Dashboard.PageDisplayed();
        }

        #region common steps        
        [When("the Marketing Page Form is presented")]
        public void MarketingPageFormPresented()
        {
            pages.Dashboard.PageDisplayed();
        }

        #endregion

        public void Dispose()
        {
            // Exits all browser windows and disposes of the driver instance
            driver.Close();
            driver.Quit();

            SqlHelper.DeleteSolution(solution.Id, connectionString);
        }
    }
}
