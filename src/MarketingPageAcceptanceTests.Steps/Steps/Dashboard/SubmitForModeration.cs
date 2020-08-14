using FluentAssertions;
using MarketingPageAcceptanceTests.Steps.Utils;
using MarketingPageAcceptanceTests.TestData.Solutions;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.Dashboard
{
    [Binding]
    public class SubmitForModeration : TestBase
    {
        public SubmitForModeration(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that a Supplier has provided all mandatory data on the Marketing Page")]
        public void GivenThatASupplierHasProvidedAllMandatoryDataOnTheMarketingPage()
        {
            _test.solution.Delete(_test.ConnectionString);
            _test.solution = GenerateSolution.GenerateCompleteSolution(_test.catalogueItem.CatalogueItemId);
            _test.solution.Create(_test.ConnectionString);
            _test.Driver.Navigate().Refresh();
            _test.Pages.Dashboard.NavigateToSection("Solution description");
            _test.Pages.SolutionDescription.SummaryAddText(100);
            _test.Pages.SolutionDescription.SaveAndReturn();
        }

        [Given(@"that a Supplier has not provided all mandatory data on the Marketing Page")]
        public void GivenThatASupplierHasNotProvidedAllMandatoryDataOnTheMarketingPage()
        {
        }

        [Given(@"validation has been triggered")]
        public void GivenValidationHasBeenTriggered()
        {
            ThenTheMarketingPageWillNotBeSubmittedForModeration();
            ThenTheUserWillBeNotifiedThatTheSubmissionWasUnsuccessful();
        }

        [When(@"the User chooses to Submit their Marketing Page for Moderation")]
        public void WhenTheUserChoosesToSubmitTheirMarketingPageForModeration()
        {
            _test.Pages.Dashboard.SubmitForModeration();
        }

        [Then(@"the Marketing Page will be submitted for Moderation")]
        public void ThenTheMarketingPageWillBeSubmittedForModeration()
        {
            _test.catalogueItem.Retrieve(_test.ConnectionString).PublishedStatusId.Should().Be(2);
        }

        [Then(@"the User will be informed that Submission was successful")]
        public void ThenTheUserWillBeInformedThatSubmissionWasSuccessful()
        {
            // Awaiting completion of user info
        }

        [Then(@"the Marketing Page will not be submitted for Moderation")]
        public void ThenTheMarketingPageWillNotBeSubmittedForModeration()
        {
            _test.Pages.Dashboard.SubmitForModeration();
            _test.catalogueItem.Retrieve(_test.ConnectionString).PublishedStatusId.Should().NotBe(2);
        }

        [Then(@"the User remains on the Marketing Page Dashboard")]
        public void ThenTheUserRemainsOnTheMarketingPageDashboard()
        {
            _test.Driver.Url.Should().Contain("/submitForModeration");
        }

        [Then(@"the User will be notified that the submission was unsuccessful")]
        public void ThenTheUserWillBeNotifiedThatTheSubmissionWasUnsuccessful()
        {
            _test.Pages.Common.ErrorSectionDisplayed();
        }

        [Then(@"they will be informed why")]
        public void ThenTheyWillBeInformedWhy()
        {
            _test.Pages.Common.ErrorMessagesDisplayed(2);
        }

        [Then(@"the User will be navigated to the relevant section on the page")]
        public void ThenTheUserWillBeNavigatedToTheRelevantSectionOnThePage()
        {
            _test.Driver.Url.Should().Contain(_test.ExpectedSectionLinkInErrorMessage);
        }
    }
}