using FluentAssertions;
using MarketingPageAcceptanceTests.TestData.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class SolutionDescription : PageAction
    {
        string summary = "";
        string href;
        string description = "";
        string link = "";

        public SolutionDescription(IWebDriver driver) : base(driver)
        {
        }

        public string SummaryAddText(int numChars)
        {
            summary = random.GetRandomString(numChars);
            driver.FindElement(pages.SolutionDescription.Summary).SendKeys(summary);
            return summary;
        }

        public string DescriptionAddText(int numChars)
        {
            description = random.GetRandomString(numChars);
            driver.FindElement(pages.SolutionDescription.Description).SendKeys(description);
            return description;
        }

        public string LinkAddText(int numChars, string input = null)
        {

            link = input ?? random.GetRandomString(numChars);
            driver.FindElement(pages.SolutionDescription.Link).SendKeys(link);
            return link;
        }

        public void SaveAndReturn()
        {
            driver.FindElement(pages.SolutionDescription.SaveAndReturn).Click();
        }

        public bool DbContainsSummary(string solutionId, string connectionString)
        {
            var solutionDescription = SqlHelper.GetSolutionSummary(solutionId, connectionString);
            return solutionDescription.Contains(summary.TrimStart());
        }

        public bool DbContainsLink(string solutionId, string connectionString)
        {
            var aboutUrl = SqlHelper.GetSolutionAboutLink(solutionId, connectionString);
            return aboutUrl.Contains(link);
        }

        public bool DbContainsDescription(string solutionId, string connectionString)
        {
            var solutionDescription = SqlHelper.GetSolutionDescription(solutionId, connectionString);
            return solutionDescription.Contains(description);
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

        public void UrlContainsValidationLinkDetails()
        {
            driver.Url.Should().Contain(href);
        }

        public void ClearMandatoryFields()
        {
            driver.FindElement(pages.SolutionDescription.Summary).Clear();
        }
    }
}
