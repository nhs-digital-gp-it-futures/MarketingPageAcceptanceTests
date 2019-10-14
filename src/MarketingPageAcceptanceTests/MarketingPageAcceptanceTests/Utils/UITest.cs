using MarketingPageAcceptanceTests.Actions;
using MarketingPageAcceptanceTests.Actions.Collections;
using MarketingPageAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using System;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Utils
{
    public abstract class UITest : Feature, IDisposable
    {
        internal readonly IWebDriver driver;
        internal readonly PageActionCollection pages;
        internal readonly ResetDbEntry resetDb;
        internal string solutionId;
        internal readonly string connectionString;

        internal readonly int initialSupplierStatus;

        internal ITestOutputHelper helper;

        public UITest(ITestOutputHelper helper)
        {
            this.helper = helper;

            // Get process only environment variables
            var (url, hubUrl, browser, apiUrl, databaseName, dbPassword) = EnvironmentVariables.Get();
            connectionString = String.Format(ConnectionString.GPitFutures, databaseName, dbPassword);
            solutionId = url.Split('/').Last();

            initialSupplierStatus = SqlHelper.GetSolutionStatus(solutionId, connectionString);

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

            // Setup a HttpClient and get the details of the solution used for this test
            resetDb = new ResetDbEntry(url, apiUrl);
            resetDb.GetSolutionDetails().Wait();

            pages = new PageActions(driver, helper).PageActionCollection;

            // Navigate to the site url
            driver.Navigate().GoToUrl(url);

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

            resetDb.PutSolutionDetails().Wait();
            resetDb.Dispose();

            // Reset the solution status
            SqlHelper.ResetSolutionStatus(solutionId, connectionString);
        }
    }
}
