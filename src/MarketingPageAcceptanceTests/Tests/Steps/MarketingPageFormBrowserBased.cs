using FluentAssertions;
using MarketingPageAcceptanceTests.Utils;
using System;
using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile(@".\Tests\Gherkin\MarketingPageFormBrowserBased.txt")]
    public sealed class MarketingPageFormBrowserBased : UITest, IDisposable
    {
        private IList<string> checkboxesSelected;

        public MarketingPageFormBrowserBased(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that a Supplier has chosen to manage Marketing Page Information")]
        public void SupplierManagesMarketingPageInformation()
        {
        }

        [And("the User has selected Browser Based as a Client Application Type")]
        public void BrowerBasedSelected()
        {
            pages.Dashboard.NavigateToSection("Client application type");
            pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            pages.ClientApplicationTypes.SelectCheckbox("Browser based");
            pages.ClientApplicationTypes.SaveAndReturn();
        }

        [Then("there is a list of Marketing Page Form Sections")]
        public void MarketingPageFormSectionsDisplayed()
        {
            pages.Dashboard.PageDisplayed();
        }

        [And("the Supplier is able to access the Browser Based Client Type Sub-Dashboard")]
        public void SupplierAccessBrowserBasedDashboard()
        {
            pages.Dashboard.NavigateToSection("Browser based", true);
        }

        [Given("the Supplier has selected the Client type")]
        public void ClientTypeSelected()
        {
            pages.Dashboard.NavigateToSection("Client application type");
            pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            checkboxesSelected = pages.ClientApplicationTypes.SelectRandomCheckbox();
            pages.ClientApplicationTypes.SaveAndReturn();
        }

        [Given("that a Supplier has not selected a Client Type")]
        public void ClientTypeNotSelected()
        {
        }

        [And("the Section has a content validation status")]
        public void SectionHasContentValidationStatus()
        {
            pages.Dashboard.SectionsAvailable(checkboxesSelected).Should().BeTrue();
        }

        [Then("the Section content validation status is displayed")]
        public void ValidationStatusDisplayed()
        {
            pages.Dashboard.SectionsHaveStatusIndicator(checkboxesSelected).Should().BeTrue();
        }

        [Then("the Status will indicate that the User must select a Client Application Type")]
        public void UserMustSelectApplicationType()
        {
            pages.Dashboard.GetSectionDefaultMessage("Browser based").Should().Be("Select from client application types");
        }
    }
}
