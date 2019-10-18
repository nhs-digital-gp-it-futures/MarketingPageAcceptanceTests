using MarketingPageAcceptanceTests.Utils;
using System;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile(@".\Tests\Gherkin\DisplayMarketingPageFormClientApplicationType.txt")]
    public sealed class DisplayMarketingPageFormClientApplicationType : UITest, IDisposable
    {
        public DisplayMarketingPageFormClientApplicationType(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that a Supplier has chosen to manage Marketing Page Information")]
        public void SupplierManageInformation()
        {
            throw new NotImplementedException();
        }

        [Then("there is a list of Marketing Page Form Sections")]
        public void MarketingPageSectionsDisplayed()
        {
            throw new NotImplementedException();
        }

        [And("the Supplier is able to manage the Client Application Type Marketing Page Form Section")]
        public void SupplierManageSection()
        {
            throw new NotImplementedException();
        }

        [Given("the Section has a content validation status")]
        public void SectionHasValidationStatus()
        {
            throw new NotImplementedException();
        }

        [Then("the Section content validation status is displayed")]
        public void ValidationStatusDisplayed()
        {
            throw new NotImplementedException();
        }
    }
}
