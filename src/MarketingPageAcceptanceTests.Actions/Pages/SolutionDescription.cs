﻿using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.Actions.Utils;
using MarketingPageAcceptanceTests.TestData.Information;
using MarketingPageAcceptanceTests.TestData.Solutions;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class SolutionDescription : PageAction
    {
        private string description = "";
        private string link = "";
        private string summary = "";

        public SolutionDescription(IWebDriver driver) : base(driver)
        {
        }

        public string SummaryAddText(int numChars)
        {
            summary = RandomInformation.RandomString(numChars);
            driver.EnterTextViaJS(wait, pages.SolutionDescription.Summary, summary);
            return summary;
        }

        public string DescriptionAddText(int numChars)
        {
            description = RandomInformation.RandomString(numChars);
            driver.EnterTextViaJS(wait, pages.SolutionDescription.Description, description);
            return description;
        }

        public string LinkAddText(int numChars, string input = null)
        {
            link = input ?? RandomInformation.RandomString(numChars);
            driver.EnterTextViaJS(wait, pages.SolutionDescription.Link, link);
            return link;
        }

        public void SaveAndReturn()
        {
            driver.FindElement(pages.SolutionDescription.SaveAndReturn).Click();
        }

        public bool DbContainsLink(Solution solution, string connectionString)
        {
            return solution.Retrieve(connectionString).AboutUrl.Contains(description);
        }

        public bool DbContainsDescription(Solution solution, string connectionString)
        {
            return solution.Retrieve(connectionString).FullDescription.Contains(description);
        }

        public void ClearMandatoryFields()
        {
            driver.FindElement(pages.SolutionDescription.Summary).Clear();
        }
    }
}