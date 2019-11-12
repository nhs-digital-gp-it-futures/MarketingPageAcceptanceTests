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
        internal string ExpectedSectionLinkInErrorMessage;

        public UITest()
        {
            solution = CreateSolution.CreateNewSolution();

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine(solution.Id);
                Console.WriteLine(solution.Name);
                Console.WriteLine(solution.Version);
            }

            connectionString = EnvironmentVariables.GetConnectionString();
            SqlHelper.CreateBlankSolution(solution, connectionString);

            url = $"{EnvironmentVariables.GetUrl()}/{solution.Id}";                   

            driver = new BrowserFactory().Driver;
            pages = new PageActions(driver).PageActionCollection;

            driver.Navigate().GoToUrl(url);
        }
    }
}
