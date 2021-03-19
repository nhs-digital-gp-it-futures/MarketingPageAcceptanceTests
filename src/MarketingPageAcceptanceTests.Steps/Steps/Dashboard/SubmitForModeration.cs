namespace MarketingPageAcceptanceTests.Steps.Steps.Dashboard
{
    using System.Threading.Tasks;
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using MarketingPageAcceptanceTests.TestData.Solutions;
    using TechTalk.SpecFlow;

    [Binding]
    public class SubmitForModeration : TestBase
    {
        public SubmitForModeration(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that a Supplier has provided all mandatory data on the Marketing Page")]
        public async Task GivenThatASupplierHasProvidedAllMandatoryDataOnTheMarketingPageAsync()
        {
            await test.Solution.DeleteAsync(test.ConnectionString);
            test.Solution = GenerateSolution.GenerateCompleteSolution(test.CatalogueItem.CatalogueItemId);
            await test.Solution.CreateAsync(test.ConnectionString);
            test.Driver.Navigate().Refresh();
            test.Pages.Dashboard.NavigateToSection("Solution description");
            test.Pages.SolutionDescription.SummaryAddText(100);
            test.Pages.SolutionDescription.SaveAndReturn();
        }

        [Given(@"validation has been triggered")]
        public async Task GivenValidationHasBeenTriggeredAsync()
        {
            await ThenTheMarketingPageWillNotBeSubmittedForModerationAsync();
            ThenTheUserWillBeNotifiedThatTheSubmissionWasUnsuccessful();
        }

        [When(@"the User chooses to Submit their Marketing Page for Moderation")]
        public void WhenTheUserChoosesToSubmitTheirMarketingPageForModeration()
        {
            test.Pages.Dashboard.SubmitForModeration();
        }

        [Then(@"the Marketing Page will be submitted for Moderation")]
        public async Task ThenTheMarketingPageWillBeSubmittedForModerationAsync()
        {
            (await test.CatalogueItem.RetrieveAsync(test.ConnectionString)).PublishedStatusId.Should().Be(2);
        }

        [Then(@"the Marketing Page will not be submitted for Moderation")]
        public async Task ThenTheMarketingPageWillNotBeSubmittedForModerationAsync()
        {
            test.Pages.Dashboard.SubmitForModeration();
            (await test.CatalogueItem.RetrieveAsync(test.ConnectionString)).PublishedStatusId.Should().NotBe(2);
        }

        [Then(@"the User remains on the Marketing Page Dashboard")]
        public void ThenTheUserRemainsOnTheMarketingPageDashboard()
        {
            test.Driver.Url.Should().Contain("/submitForModeration");
        }

        [Then(@"the User will be notified that the submission was unsuccessful")]
        public void ThenTheUserWillBeNotifiedThatTheSubmissionWasUnsuccessful()
        {
            test.Pages.Common.ErrorSectionDisplayed();
        }

        [Then(@"they will be informed why")]
        public void ThenTheyWillBeInformedWhy()
        {
            test.Pages.Common.ErrorMessagesDisplayed(2);
        }

        [Then(@"the User will be navigated to the relevant section on the page")]
        public void ThenTheUserWillBeNavigatedToTheRelevantSectionOnThePage()
        {
            test.Driver.Url.Should().Contain(test.ExpectedSectionLinkInErrorMessage);
        }
    }
}
