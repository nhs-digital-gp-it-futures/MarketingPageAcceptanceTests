using MarketingPageAcceptanceTests.Actions;
using MarketingPageAcceptanceTests.Actions.Collections;
using MarketingPageAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using System;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Utils
{
    public abstract class UITest : Feature, IDisposable
    {
        internal readonly IWebDriver driver;
        internal readonly PageActionCollection pages;
        internal string solutionId;
        internal readonly string connectionString;

        internal ITestOutputHelper helper;

        public UITest(ITestOutputHelper helper)
        {
            this.helper = helper;

            var solution = CreateSolution.CreateNewSolution();

            // Get process only environment variables
            var (url, hubUrl, browser, databaseName, dbPassword) = EnvironmentVariables.Get();
            connectionString = String.Format(ConnectionString.GPitFutures, databaseName, dbPassword);
            solutionId = solution.Id;

            SqlHelper.CreateBlankSolution(solution, connectionString);

            if (!System.Diagnostics.Debugger.IsAttached)
            {
                // Initialize the browser and get the page action collections
                driver = BrowserFactory.GetBrowser(browser, hubUrl);
            }
            else
            {
                // If debugging, run against the local chrome instance
                driver = BrowserFactory.GetBrowser("chrome-local", "");
            }

            pages = new PageActions(driver, helper).PageActionCollection;

            // Navigate to the site url
            driver.Navigate().GoToUrl($"{url}/{solutionId}");

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

            SqlHelper.DeleteSolution(solutionId, connectionString);
        }
    }
}
