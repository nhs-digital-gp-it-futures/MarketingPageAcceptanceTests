using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.TestData.Information;
using MarketingPageAcceptanceTests.TestData.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class SolutionDescription : PageAction
    {
        string summary = "";
        string description = "";
        string link = "";

        public SolutionDescription(IWebDriver driver) : base(driver)
        {
        }

        public string SummaryAddText(int numChars)
        {
            summary = RandomInformation.RandomString(numChars);
            TextCopy.Clipboard.SetText(summary);
            driver.FindElement(pages.SolutionDescription.Summary).SendKeys(Keys.LeftControl + "v");
            return summary;
        }

        public string DescriptionAddText(int numChars)
        {
            description = RandomInformation.RandomString(numChars);
            TextCopy.Clipboard.SetText(description);
            driver.FindElement(pages.SolutionDescription.Description).SendKeys(Keys.LeftControl + "v");
            return description;
        }

        public string LinkAddText(int numChars, string input = null)
        {
            link = input ?? RandomInformation.RandomString(numChars);
            TextCopy.Clipboard.SetText(link);
            driver.FindElement(pages.SolutionDescription.Link).SendKeys(Keys.LeftControl + "v");
            return link;
        }

        public void SaveAndReturn()
        {
            driver.FindElement(pages.SolutionDescription.SaveAndReturn).Click();
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

        public void ClearMandatoryFields()
        {
            driver.FindElement(pages.SolutionDescription.Summary).Clear();
        }
    }
}
