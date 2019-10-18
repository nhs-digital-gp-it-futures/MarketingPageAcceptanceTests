using MarketingPageAcceptanceTests.Utils;
using System;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile(@".\Tests\Gherkin\DisplaySubFormBrowserBasedClientType.txt")]
    public sealed class DisplaySubFormBrowserBasedClientType : UITest, IDisposable
    {
        public DisplaySubFormBrowserBasedClientType(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that a Supplier has chosen to manage the Browser Based Client Application Type Section")]
        public void SupplierManagesBrowserBasedClientApplicationSection()
        {
            throw new NotImplementedException();
        }

        [When("the the User has selected Browser Based as a Client Application Type")]
        public void SelectedBrowserBasedApplicationType()
        {
            throw new NotImplementedException();
        }

        [And("has navigated to the Browser Based Client Application Sub-Form")]
        public void NavigateToSBrowserBasedSubForm()
        {
            throw new NotImplementedException();
        }

        [Then("there is a list of Browser Based Client Application Type Sub-Sections")]
        public void ListOfSubSectionsDisplayed()
        {
            throw new NotImplementedException();
        }

        [And("the Supplier is able to access the Browser Based Client Type Sub-Sections")]
        public void SupplierAbleToAccessSubSections()
        {
            throw new NotImplementedException();
        }

        [Given("each Section has a content validation status")]
        public void SectionHasContentValidationStatus()
        {
            throw new NotImplementedException();
        }

        [Then("the Section content validation status is displayed")]
        public void ValidationStatusDisplayed()
        {
            throw new NotImplementedException();
        }

        [Given("the Browser Based Client Application Type Section requires Mandatory Data")]
        public void BrowserBasedApplicationTypeMandatoryData()
        {
            throw new NotImplementedException();
        }

        [And("a Supplier has not saved Mandatory data on all the Browser Based Client Application Type Sub-Sections")]
        public void SupplierNotSavedMandatoryData()
        {
            throw new NotImplementedException();
        }

        [Then("the Browser Based Client Application Type Section is marked as Incomplete")]
        public void SectionMarkedIncomplete()
        {
            throw new NotImplementedException();
        }

        [And("a Supplier has saved all mandatory data on the Browser Based Client Application Type Sub-Sections")]
        public void SupplierSavedAllMandatoryData()
        {
            throw new NotImplementedException();
        }

        [Then("the Browser Based Client Application Type Section is marked as Complete")]
        public void SectionMarkedComplete()
        {
            throw new NotImplementedException();
        }
    }
}
