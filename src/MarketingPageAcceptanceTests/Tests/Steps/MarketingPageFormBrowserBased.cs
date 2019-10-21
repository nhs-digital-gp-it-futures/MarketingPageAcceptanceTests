using MarketingPageAcceptanceTests.Utils;
using System;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile(@".\Tests\Gherkin\MarketingPageFormBrowserBased.txt")]
    public sealed class MarketingPageFormBrowserBased : UITest, IDisposable
    {
        public MarketingPageFormBrowserBased(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that a Supplier has chosen to manage Marketing Page Information")]
        public void SupplierManagesMarketingPageInformation()
        {
            throw new NotImplementedException();
        }

        [And("the User has selected Browser Based as a Client Application Type")]
        public void BrowerBasedSelected()
        {
            throw new NotImplementedException();
        }

        [Then("there is a list of Marketing Page Form Sections")]
        public void MarketingPageFormSectionsDisplayed()
        {
            throw new NotImplementedException();
        }

        [And("the Supplier is able to access the Browser Based Client Type Sub-Dashboard")]
        public void SupplierAccessBrowserBasedDashboard()
        {
            throw new NotImplementedException();
        }

        [Given("the Supplier has selected the Client type")]
        public void ClientTypeSelected()
        {
            throw new NotImplementedException();
        }

        [Given("that a Supplier has not selected a Client Type")]
        public void ClientTypeNotSelected()
        {
            throw new NotImplementedException();
        }

        [And("the Section has a content validation status")]
        public void SectionHasContentValidationStatus()
        {
            throw new NotImplementedException();
        }

        [Then("the Section content validation status is displayed")]
        public void ValidationStatusDisplayed()
        {
            throw new NotImplementedException();
        }

        [Then("the Status will indicate that the User must select a Client Application Type")]
        public void UserMustSelectApplicationType()
        {
            throw new NotImplementedException();
        }
    }
}
