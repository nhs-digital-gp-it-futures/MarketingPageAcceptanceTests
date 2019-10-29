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
        internal readonly string url;

        internal ITestOutputHelper helper;

        public UITest(ITestOutputHelper helper)
        {
            this.helper = helper;

            var solution = CreateSolution.CreateNewSolution();

            // Get process only environment variables
            var (url, hubUrl, browser, serverUrl, databaseName, dbUser, dbPassword) = EnvironmentVariables.Get();
            connectionString = String.Format(ConnectionString.GPitFutures, serverUrl, databaseName, dbUser, dbPassword);
            solutionId = solution.Id;
            this.url = $"{url}/{solutionId}";

            SqlHelper.CreateBlankSolution(solution, connectionString);

            driver = GetDriver(browser, hubUrl);

            pages = new PageActions(driver, helper).PageActionCollection;

            // Navigate to the site url
            driver.Navigate().GoToUrl(this.url);
            pages.Dashboard.PageDisplayed();
        }

        private IWebDriver GetDriver(string browser, string hubUrl)
        {
            IWebDriver _driver;

            if (!System.Diagnostics.Debugger.IsAttached)
            {
                // Initialize the browser and get the page action collections
                _driver = BrowserFactory.GetBrowser(browser, hubUrl);
            }
            else
            {
                // If debugging, run against the local chrome instance
                _driver = BrowserFactory.GetBrowser("chrome-local", "");
            }
            return _driver;
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
