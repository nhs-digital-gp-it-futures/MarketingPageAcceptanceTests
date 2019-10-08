using MarketingPageAcceptanceTests.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile("./Tests/Gherkin/SupplierSubmitForModeration.txt")]
    public sealed class SupplierSubmitForModeration : UITest, IDisposable
    {
        public SupplierSubmitForModeration(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that a Supplier has provided all mandatory data on the Marketing Page")]
        public void SupplierProvidedAllMandatoryData()
        {
            throw new NotImplementedException();
        }

        [When("the User chooses to Submit their Marketing Page for Moderation")]
        public void SubmitForModeration()
        {
            throw new NotImplementedException();
        }

        [Then("the Marketing Page will be submitted for Moderation")]
        public void SubmittedForModerationSuccess()
        {
            throw new NotImplementedException();
        }

        [And("the User remains on the Preview Page")]
        public void RemainOnPreviewPage()
        {
            throw new NotImplementedException();
        }

        [Given("that a Supplier has not provided all mandatory data on the Marketing Page")]
        public void SupplierHasNotProvidedAllMandatoryData()
        {
            throw new NotImplementedException();
        }

        [Then("the Marketing Page will not be submitted for Moderation")]
        public void MarketingPageNotSubmittedForModeration()
        {
            throw new NotImplementedException();
        }
        
        [And("the User will be notified that the submission was unsuccessful")]
        public void UnsuccessfulNotificationDisplayed()
        {
            throw new NotImplementedException();
        }

        [And("they will be informed why")]
        public void UnsuccessfulNotificationCorrect()
        {
            throw new NotImplementedException();
        }

        [Given("validation has been triggered")]
        public void ValidationTriggered()
        {
            throw new NotImplementedException();
        }

        [When("the User selects an error link in the Error Summary")]
        public void SelectErrorLink()
        {
            throw new NotImplementedException();
        }

        [Then("the User will be navigated to the relevant section on the page")]
        public void NavigatedToRelevantSection()
        {
            throw new NotImplementedException();
        }
    }
}
