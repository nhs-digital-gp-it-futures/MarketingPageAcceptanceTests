using MarketingPageAcceptanceTests.Actions;
using MarketingPageAcceptanceTests.Actions.Collections;
using OpenQA.Selenium;
using System;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Utils
{
    public abstract class UITest : IDisposable
    {
        internal readonly IWebDriver driver;
        internal readonly PageActionCollection pages;

        internal ITestOutputHelper helper;

        public UITest(ITestOutputHelper helper)
        {
            this.helper = helper;

            // Get process only environment variables
            var (url, hubUrl, browser) = EnvironmentVariables.Get();

            // Initialize the browser and get the page action collections
            driver = BrowserFactory.GetBrowser(browser, hubUrl);
            pages = new PageActions(driver, helper).PageActionCollection;

            // Navigate to the site url
            driver.Navigate().GoToUrl(url);

            pages.Common.WaitForPageLoad();
        }

        public void Dispose()
        {
            // Exits all browser windows and disposes of the driver instance
            driver.Close();
            driver.Quit();
        }
    }
}
