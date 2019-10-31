using FluentAssertions;
using MarketingPageAcceptanceTests.Actions.Utils;
using MarketingPageAcceptanceTests.Utils;
using System;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile("./Tests/Gherkin/SupplierSubmitForModeration.txt")]
    public sealed class SupplierSubmitForModeration : UITest, IDisposable
    {
        private string ExpectedSectionLinkInErrorMessage = string.Empty;

        public SupplierSubmitForModeration(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that a Supplier has provided all mandatory data on the Marketing Page")]
        public void SupplierProvidedAllMandatoryData()
        {
            pages.Dashboard.NavigateToSection("Solution description");
            pages.SolutionDescription.SummaryAddText(100);
            pages.SolutionDescription.SaveAndReturn();

        }

        [When("the User chooses to Submit their Marketing Page for Moderation")]
        public void SubmitForModeration()
        {
            pages.Dashboard.NavigateToPreviewPage();
            pages.PreviewPage.PageDisplayed();
            pages.PreviewPage.SubmitForModeration();
        }

        [Then("the Marketing Page will be submitted for Moderation")]
        public void SubmittedForModerationSuccess()
        {

            SqlHelper.GetSolutionStatus(solution.Id, connectionString).Should().Be(2);
        }

        [And("the User remains on the Preview Page")]
        public void RemainOnPreviewPage()
        {
            driver.Url.ToLower().Should().Contain("preview");
        }

        [Given("that a Supplier has not provided all mandatory data on the Marketing Page")]
        public void SupplierHasNotProvidedAllMandatoryData()
        {
        }

        [Then("the Marketing Page will not be submitted for Moderation")]
        public void MarketingPageNotSubmittedForModeration()
        {
            pages.PreviewPage.PageDisplayed();
            pages.PreviewPage.SubmitForModeration();
            pages.PreviewPage.PageDisplayed();
            SqlHelper.GetSolutionStatus(solution.Id, connectionString).Should().NotBe(2);
        }

        [And("the User will be notified that the submission was unsuccessful")]
        public void UnsuccessfulNotificationDisplayed()
        {
            pages.PreviewPage.AssertSubmitForReviewErrorMessageAppeared();
            ExpectedSectionLinkInErrorMessage = pages.PreviewPage.GetFirstErrorMessage().GetAttribute("href");
        }

        [And("they will be informed why")]
        public void UnsuccessfulNotificationCorrect()
        {
            pages.PreviewPage.GetFirstErrorMessage().Text.Should()
                .BeEquivalentTo(pages.PreviewPage.MandatoryFieldsToErrorMessages["summary"]);
        }

        [Given("validation has been triggered")]
        public void ValidationTriggered()
        {
            pages.Dashboard.NavigateToPreviewPage();
            MarketingPageNotSubmittedForModeration();
            UnsuccessfulNotificationDisplayed();
        }

        [When("the User selects an error link in the Error Summary")]
        public void SelectErrorLink()
        {
            pages.PreviewPage.ClickOnErrorLink();
        }

        [Then("the User will be navigated to the relevant section on the page")]
        public void NavigatedToRelevantSection()
        {
            driver.Url.Should().Contain(ExpectedSectionLinkInErrorMessage);
        }
    }
}
