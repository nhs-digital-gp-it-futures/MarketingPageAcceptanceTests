using FluentAssertions;
using MarketingPageAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using System;
using System.Linq;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class SolutionDescription : PageAction
    {
        string summary = "";
        string href;
        string description = "";
        string link = "";

        public SolutionDescription(IWebDriver driver, ITestOutputHelper helper) : base(driver, helper)
        {
        }

        public void SummaryAddText(int numChars)
        {
            summary = RandomString(numChars);
            driver.FindElement(pages.SolutionDescription.Summary).SendKeys(summary);
        }

        public void DescriptionAddText(int numChars)
        {
            description = RandomString(numChars);
            driver.FindElement(pages.SolutionDescription.Description).SendKeys(description);
        }

        public void LinkAddText(int numChars)
        {
            link = RandomString(numChars);
            driver.FindElement(pages.SolutionDescription.Link).SendKeys(link);
        }

        private string RandomString(int characters)
        {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!£$%^&*()_-+=";

            string randomString = "";

            Random rand = new Random();

            for (int i = 0; i < characters; i++)
            {
                randomString += chars[rand.Next(chars.Length)];
            }

            return randomString;
        }

        public void SaveAndReturn()
        {
            driver.FindElement(pages.SolutionDescription.SaveAndReturn).Click();
        }

        public bool DbContainsSummary(string solutionId, string connectionString)
        {
            var solutionDescription = SqlHelper.GetSolutionFeatures(solutionId, connectionString);
            return solutionDescription.Contains(summary);
        }

        public bool DbContainsLink(string solutionId, string connectionString)
        {
            var solutionDescription = SqlHelper.GetSolutionFeatures(solutionId, connectionString);
            return solutionDescription.Contains(description);
        }

        public bool DbContainsDescription(string solutionId, string connectionString)
        {
            var solutionDescription = SqlHelper.GetSolutionFeatures(solutionId, connectionString);
            return solutionDescription.Contains(link);
        }

        public void PageDisplayed()
        {
            wait.Until(s => s.FindElement(pages.SolutionDescription.Summary).Displayed && s.FindElement(pages.SolutionDescription.Description).Displayed);
        }

        public bool SummaryErrorDisplayed()
        {
            try
            {
                driver.FindElement(pages.SolutionDescription.SummaryError);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DescriptionErrorDisplayed()
        {
            try
            {
                driver.FindElement(pages.SolutionDescription.DescriptionError);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LinkErrorDisplayed()
        {
            try
            {
                driver.FindElement(pages.SolutionDescription.LinkError);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ClearAllFields()
        {
            driver.FindElement(pages.SolutionDescription.Summary).Clear();
            driver.FindElement(pages.SolutionDescription.Description).Clear();
            driver.FindElement(pages.SolutionDescription.Link).Clear();
        }

        public void ClickValidationMessage()
        {
            var errorLink = driver.FindElements(pages.SolutionDescription.ErrorSummaryLinks).First();
            
            href = errorLink.GetAttribute("href");

            errorLink.Click();
        }

        public void UrlContainsValidationLinkDetails()
        {
            driver.Url.Should().Contain(href);
        }
    }
}
