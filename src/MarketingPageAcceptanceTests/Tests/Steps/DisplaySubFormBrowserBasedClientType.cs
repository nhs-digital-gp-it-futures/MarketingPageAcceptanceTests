using FluentAssertions;
using MarketingPageAcceptanceTests.Utils;
using System;
using System.Collections.Generic;
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
        }

        [When("the User has selected Browser Based as a Client Application Type")]
        [And("the User has selected Browser Based as a Client Application Type")]
        public void SelectedBrowserBasedApplicationType()
        {
            pages.Dashboard.NavigateToSection("Client application type");
            pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            pages.ClientApplicationTypes.SelectCheckbox("Browser based");
            pages.ClientApplicationTypes.SaveAndReturn();
        }

        [And("has navigated to the Browser Based Client Application Sub-Form")]
        public void NavigateToBrowserBasedSubForm()
        {
            pages.Dashboard.NavigateToSection("Browser based", true);
        }

        [Then("there is a list of Browser Based Client Application Type Sub-Sections")]
        public void ListOfSubSectionsDisplayed()
        {
            IList<string> subSectionsExpected = new List<string>
            {
                "Browsers supported",
                "Plug-ins or extensions",
                "Connectivity and resolution",
                "Hardware requirements",
                "Additional information"
            };

            pages.BrowserSubDashboard.GetSections().Should().BeEquivalentTo(subSectionsExpected);
        }

        [And("the Supplier is able to access the Browser Based Client Type Sub-Sections")]
        public void SupplierAbleToAccessSubSections()
        {
            pages.BrowserSubDashboard.OpenSection("Browsers supported");
            pages.Common.GoBackOnePage();
        }

        [Given("each Section has a content validation status")]
        public void SectionHasContentValidationStatus()
        {
            pages.Dashboard.NavigateToSection("Client application type");
            pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
            pages.ClientApplicationTypes.SelectCheckbox("Browser based");
            pages.ClientApplicationTypes.SaveAndReturn();
            pages.Dashboard.NavigateToSection("Browser based", true);
        }

        [Then("the Section content validation status is displayed")]
        public void ValidationStatusDisplayed()
        {
            pages.BrowserSubDashboard.SectionsHaveStatusIndicators();
        }

        [Given("the Browser Based Client Application Type Section requires Mandatory Data")]
        public void BrowserBasedApplicationTypeMandatoryData()
        {
        }

        [And("a Supplier has not saved Mandatory data on all the Browser Based Client Application Type Sub-Sections")]
        public void SupplierNotSavedMandatoryData()
        {
        }

        [Then("the Browser Based Client Application Type Section is marked as Incomplete")]
        public void SectionMarkedIncomplete()
        {
            pages.Dashboard.SectionIncomplete("Browser based");
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
