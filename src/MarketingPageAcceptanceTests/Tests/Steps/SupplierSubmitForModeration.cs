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
            SqlHelper.UpdateMarketingDetails(CreateSolution.CreateCompleteMarketingDetail(solution), connectionString);
            driver.Navigate().Refresh();
            pages.Dashboard.NavigateToSection("Solution description");
            pages.SolutionDescription.SummaryAddText(100);
            pages.SolutionDescription.SaveAndReturn();
        }

        [When("the User chooses to Submit their Marketing Page for Moderation")]
        public void SubmitForModeration()
        {   
            pages.Dashboard.SubmitForModeration();
        }

        [Then("the Marketing Page will be submitted for Moderation")]
        public void SubmittedForModerationSuccess()
        {
            SqlHelper.GetSolutionStatus(solution.Id, connectionString).Should().Be(2);
        }

        [And("the User will be informed that Submission was successful")]
        public void SuccessfulInformation()
        {

        }

        [And("the User remains on the Marketing Page Dashboard")]
        public void RemainOnDashboard()
        {
            driver.Url.Should().Contain("/submitForModeration");
        }

        [Given("that a Supplier has not provided all mandatory data on the Marketing Page")]
        public void SupplierHasNotProvidedAllMandatoryData()
        {
        }

        [Then("the Marketing Page will not be submitted for Moderation")]
        public void MarketingPageNotSubmittedForModeration()
        {   
            pages.Dashboard.SubmitForModeration();            
            SqlHelper.GetSolutionStatus(solution.Id, connectionString).Should().NotBe(2);
        }
        
        [And("the User will be notified that the submission was unsuccessful")]
        public void UnsuccessfulNotificationDisplayed()
        {
            pages.Dashboard.ErrorSectionDisplayed();
        }

        [And("they will be informed why")]
        public void UnsuccessfulNotificationCorrect()
        {
            pages.Dashboard.ErrorMessagesDisplayed(2);
        }

        [Given("validation has been triggered")]
        public void ValidationTriggered()
        {   
            MarketingPageNotSubmittedForModeration();
            UnsuccessfulNotificationDisplayed();
        }

        [When("the User selects an error link in the Error Summary")]
        public void SelectErrorLink()
        {
            ExpectedSectionLinkInErrorMessage = pages.Dashboard.ClickOnErrorLink();
        }

        [Then("the User will be navigated to the relevant section on the page")]
        public void NavigatedToRelevantSection()
        {  
            driver.Url.Should().Contain(ExpectedSectionLinkInErrorMessage);
        }
    }
}
