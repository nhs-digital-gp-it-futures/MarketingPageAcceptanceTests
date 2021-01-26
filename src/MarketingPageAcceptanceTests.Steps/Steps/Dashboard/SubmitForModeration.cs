namespace MarketingPageAcceptanceTests.Steps.Steps.Dashboard
{
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
        public void GivenThatASupplierHasProvidedAllMandatoryDataOnTheMarketingPage()
        {
            test.Solution.Delete(test.ConnectionString);
            test.Solution = GenerateSolution.GenerateCompleteSolution(test.CatalogueItem.CatalogueItemId);
            test.Solution.Create(test.ConnectionString);
            test.Driver.Navigate().Refresh();
            test.Pages.Dashboard.NavigateToSection("Solution description");
            test.Pages.SolutionDescription.SummaryAddText(100);
            test.Pages.SolutionDescription.SaveAndReturn();
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
            test.Pages.Dashboard.SubmitForModeration();
        }

        [Then(@"the Marketing Page will be submitted for Moderation")]
        public void ThenTheMarketingPageWillBeSubmittedForModeration()
        {
            test.CatalogueItem.Retrieve(test.ConnectionString).PublishedStatusId.Should().Be(2);
        }

        [Then(@"the Marketing Page will not be submitted for Moderation")]
        public void ThenTheMarketingPageWillNotBeSubmittedForModeration()
        {
            test.Pages.Dashboard.SubmitForModeration();
            test.CatalogueItem.Retrieve(test.ConnectionString).PublishedStatusId.Should().NotBe(2);
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
