using FluentAssertions;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Utils;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.Dashboard
{
    [Binding]
    public class SubmitForModeration
    {   
        private UITest _test;

        public SubmitForModeration(UITest test)
        {
            _test = test;
        }

        [Given(@"that a Supplier has provided all mandatory data on the Marketing Page")]
        public void GivenThatASupplierHasProvidedAllMandatoryDataOnTheMarketingPage()
        {
            SqlHelper.UpdateSolutionDetails(CreateSolution.CreateCompleteSolutionDetail(_test.solution, _test.solutionDetail), _test.connectionString);
            _test.driver.Navigate().Refresh();
            _test.pages.Dashboard.NavigateToSection("Solution description");
            _test.pages.SolutionDescription.SummaryAddText(100);
            _test.pages.SolutionDescription.SaveAndReturn();
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
            _test.pages.Dashboard.SubmitForModeration();
        }

        

        [Then(@"the Marketing Page will be submitted for Moderation")]
        public void ThenTheMarketingPageWillBeSubmittedForModeration()
        {
            SqlHelper.GetSolutionStatus(_test.solution.Id, _test.connectionString).Should().Be(2);
        }

        [Then(@"the User will be informed that Submission was successful")]
        public void ThenTheUserWillBeInformedThatSubmissionWasSuccessful()
        {
            // Awaiting completion of user info
        }

        [Then(@"the Marketing Page will not be submitted for Moderation")]
        public void ThenTheMarketingPageWillNotBeSubmittedForModeration()
        {
            _test.pages.Dashboard.SubmitForModeration();
            SqlHelper.GetSolutionStatus(_test.solution.Id, _test.connectionString).Should().NotBe(2);
        }

        [Then(@"the User remains on the Marketing Page Dashboard")]
        public void ThenTheUserRemainsOnTheMarketingPageDashboard()
        {
            _test.driver.Url.Should().Contain("/submitForModeration");
        }

        [Then(@"the User will be notified that the submission was unsuccessful")]
        public void ThenTheUserWillBeNotifiedThatTheSubmissionWasUnsuccessful()
        {
            _test.pages.Common.ErrorSectionDisplayed();
        }

        [Then(@"they will be informed why")]
        public void ThenTheyWillBeInformedWhy()
        {
            _test.pages.Common.ErrorMessagesDisplayed(2);
        }

        [Then(@"the User will be navigated to the relevant section on the page")]
        public void ThenTheUserWillBeNavigatedToTheRelevantSectionOnThePage()
        {
            _test.driver.Url.Should().Contain(_test.ExpectedSectionLinkInErrorMessage);
        }
    }
}
