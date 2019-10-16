using MarketingPageAcceptanceTests.Utils;
using System;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile("./Tests/Gherkin/FeaturesSection.txt")]
    public sealed class FeaturesSection : UITest, IDisposable
    {
        public FeaturesSection(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that a Supplier has chosen to manage Marketing Page Information")]
        public void SupplierManageMarketingPageInfo()
        {

        }

        [Given("the Section has a content validation status")]
        public void SectionContentValidationStatus()
        {
            pages.Dashboard.AllSectionsContainStatus();
        }

        [Then("there is a list of Marketing Page Form Sections")]
        public void ListMarketingPageFormSections()
        {
            pages.Dashboard.ShouldDisplaySections();
        }

        [Then("the Section content validation status is displayed")]
        public void SectionContentValidationStatusDisplayed()
        {
            pages.Dashboard.AllSectionsContainStatus();
        }

        [And("the Supplier is able to manage the Features Marketing Page Form Section")]
        public void SupplierManageFeaturesSection()
        {
            pages.Dashboard.NavigateToSection("Features");
        }
    }
}
