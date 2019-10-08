using FluentAssertions;
using MarketingPageAcceptanceTests.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile("./Tests/Gherkin/SolutionDescriptionSection.txt")]
    public sealed class SolutionDescriptionSection : UITest, IDisposable
    {
        public SolutionDescriptionSection(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that a Supplier has chosen to manage Marketing Page Information")]
        public void SupplierManagesMarketingPageInformation()
        {
            pages.Dashboard.PageDisplayed();
        }

        [Then("there is a list of Marketing Page Form Sections")]
        public void ListOfMarketingPageFormSections()
        {
            pages.Dashboard.ShouldDisplaySections();
        }

        [And("the Supplier is able to manage the Solution Description Marketing Page Form Section")]
        public void SupplierAbleToManageSolutionDescriptionMarketingPageFormSection()
        {
            pages.Dashboard.NavigateToSection("Solution description");
        }

        [Given("the Section has a content validation status")]
        public void SectionHasContentValidationStatus()
        {
            pages.Dashboard.AllSectionsContainStatus();
        }
    
        [Then("the Section content validation status is displayed")]
        public void SectionContentValidationStatusDisplayed()
        {
            pages.Dashboard.SectionHasStatus("Solution description").Should().BeTrue();
        }
    }
}
