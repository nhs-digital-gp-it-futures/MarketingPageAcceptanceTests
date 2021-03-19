namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using System.Threading.Tasks;
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using MarketingPageAcceptanceTests.Actions.Utils;
    using MarketingPageAcceptanceTests.TestData.Information;
    using MarketingPageAcceptanceTests.TestData.Solutions;
    using OpenQA.Selenium;

    public sealed class SolutionDescription : PageAction
    {
        private string description = string.Empty;
        private string link = string.Empty;
        private string summary = string.Empty;

        public SolutionDescription(IWebDriver driver)
            : base(driver)
        {
        }

        public string SummaryAddText(int numChars)
        {
            summary = RandomInformation.RandomString(numChars);
            Driver.EnterTextViaJS(Wait, Objects.Pages.SolutionDescription.Summary, summary);
            return summary;
        }

        public string DescriptionAddText(int numChars)
        {
            description = RandomInformation.RandomString(numChars);
            Driver.EnterTextViaJS(Wait, Objects.Pages.SolutionDescription.Description, description);
            return description;
        }

        public string LinkAddText(int numChars, string input = null)
        {
            link = input ?? RandomInformation.RandomString(numChars);
            Driver.EnterTextViaJS(Wait, Objects.Pages.SolutionDescription.Link, link);
            return link;
        }

        public void SaveAndReturn()
        {
            Driver.FindElement(Objects.Pages.SolutionDescription.SaveAndReturn).Click();
        }

        public async Task<bool> DbContainsLinkAsync(Solution solution, string connectionString)
        {
            return (await solution.RetrieveAsync(connectionString)).AboutUrl.Contains(description);
        }

        public async Task<bool> DbContainsDescriptionAsync(Solution solution, string connectionString)
        {
            return (await solution.RetrieveAsync(connectionString)).FullDescription.Contains(description);
        }

        public void ClearMandatoryFields()
        {
            Driver.FindElement(Objects.Pages.SolutionDescription.Summary).Clear();
        }
    }
}
