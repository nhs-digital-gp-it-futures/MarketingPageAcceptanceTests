using MarketingPageAcceptanceTests.Utils;
using System;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile(@".\Tests\Gherkin\SuppliersEditClientApplicationType.txt")]
    public sealed class SuppliersEditClientApplicationType : UITest, IDisposable
    {
        public SuppliersEditClientApplicationType(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that a Client Application Type is selected")]
        public void ClientApplicationTypeSelected()
        {
            throw new NotImplementedException();
        }
        [When("the section is saved")]
        public void SectionSaved()
        {
            throw new NotImplementedException();
        }

        [Then("the selected Client Application Type sub-category is available on the Marketing Page Form")]
        public void ClientApplicationTypeAvailable()
        {
            throw new NotImplementedException();
        }

        [Given("that a Client Application Type is not selected")]
        public void ClientApplicationTypeNotSelected()
        {
            throw new NotImplementedException();
        }

        [Then("no Client Application Type sub-category is available on the Marketing Page Form")]
        public void ClientApplicationTypeNotAvailable()
        {
            throw new NotImplementedException();
        }

        [And("there is a guidance message informing the User they need to select a Client Application Type")]
        public void GuidanceMessageForApplicationTypeDisplayed()
        {
            throw new NotImplementedException();
        }

        [Given("the Client Application Type Section requires Mandatory Data")]
        public void ClientApplicationTypeSectionRequiresMandatoryData()
        {
            throw new NotImplementedException();
        }
        [Given("that a User has not provided at least one Client Application Type")]
        [And("a Supplier has not saved any data on the Client Application Type Section")]
        public void SupplierNotSavedDataClientApplicationType()
        {
            throw new NotImplementedException();
        }

        [Then("the Client Application Type Section is marked as Incomplete")]
        public void ClientApplicationTypeSectionIncomplete()
        {
            throw new NotImplementedException();
        }

        [And("a Supplier has saved any data on the Client Application Type Section")]
        public void SupplierHasSavedDataClientApplicationType()
        {
            throw new NotImplementedException();
        }

        [Then("the Client Application Type Section is marked as Complete")]
        public void ClientApplicationTypeSectionComplete()
        {
            throw new NotImplementedException();
        }

        [Given("that data has been saved in this section")]
        public void DataSavedInSection()
        {
            throw new NotImplementedException();
        }

        [When("a User previews the Marketing Page")]
        public void PreviewMarketingPage()
        {
            throw new NotImplementedException();
        }

        [Then("data will be presented on the Preview of the Marketing Page")]
        public void DataPresentedOnPreview()
        {
            throw new NotImplementedException();
        }

        [When("the User submits their Marketing Page")]
        public void UserSubmitsMarketingPage()
        {
            throw new NotImplementedException();
        }

        [Then("the Submission will trigger validation")]
        public void ValidationTriggered()
        {
            throw new NotImplementedException();
        }

        [And("the User will be informed that they need to select a Client Application Type before they can submit")]
        public void ClientApplicationTypeValidationDisplayed()
        {
            throw new NotImplementedException();
        }
    }
}
