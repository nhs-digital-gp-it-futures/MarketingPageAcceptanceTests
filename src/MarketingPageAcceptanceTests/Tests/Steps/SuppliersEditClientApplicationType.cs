using FluentAssertions;
using MarketingPageAcceptanceTests.Utils;
using System;
using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile(@".\Tests\Gherkin\SuppliersEditClientApplicationType.txt")]
    public sealed class SuppliersEditClientApplicationType : UITest, IDisposable
    {
        private IList<string> checkboxesSelected;
        private IList<string> allAppTypes;

        public SuppliersEditClientApplicationType(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that a Client Application Type is selected")]
        public void ClientApplicationTypeSelected()
        {
            pages.Dashboard.NavigateToSection("Client application type");
            pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            checkboxesSelected = pages.ClientApplicationTypes.SelectRandomCheckbox();
        }
        [When("the section is saved")]
        public void SectionSaved()
        {
            pages.ClientApplicationTypes.SaveAndReturn();
            pages.Dashboard.PageDisplayed();
        }

        [Then("the selected Client Application Type sub-category is available on the Marketing Page Form")]
        public void ClientApplicationTypeAvailable()
        {
            // Check for link HREF containing the checkbox value from the sub dashboard
            pages.Dashboard.SectionsAvailable(checkboxesSelected).Should().BeTrue();
        }

        [Given("that a Client Application Type is not selected")]
        public void ClientApplicationTypeNotSelected()
        {
            pages.Dashboard.NavigateToSection("Client application type");
            pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            allAppTypes = pages.ClientApplicationTypes.GetAppTypes();
        }

        [Then("no Client Application Type sub-category is available on the Marketing Page Form")]
        public void ClientApplicationTypeNotAvailable()
        {
        }

        [And("there is a guidance message informing the User they need to select a Client Application Type")]
        public void GuidanceMessageForApplicationTypeDisplayed()
        {
            pages.Dashboard.SectionsContainDefaultMessage(allAppTypes, "Select from client application types");
        }

        [Given("the Client Application Type Section requires Mandatory Data")]
        public void ClientApplicationTypeSectionRequiresMandatoryData()
        {
        }

        [Given("that a User has not provided at least one Client Application Type")]
        [And("a Supplier has not saved any data on the Client Application Type Section")]
        public void SupplierNotSavedDataClientApplicationType()
        {
        }

        [Then("the Client Application Type Section is marked as Incomplete")]
        public void ClientApplicationTypeSectionIncomplete()
        {
            pages.Dashboard.SectionIncomplete("Client application type");
        }

        [And("a Supplier has saved any data on the Client Application Type Section")]
        public void SupplierHasSavedDataClientApplicationType()
        {
            pages.Dashboard.NavigateToSection("Client application type");
            pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            pages.ClientApplicationTypes.SelectRandomCheckbox();
            pages.ClientApplicationTypes.SaveAndReturn();
        }

        [Then("the Client Application Type Section is marked as Complete")]
        public void ClientApplicationTypeSectionComplete()
        {
            pages.Dashboard.SectionCompleteStatus("Client application type");
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
