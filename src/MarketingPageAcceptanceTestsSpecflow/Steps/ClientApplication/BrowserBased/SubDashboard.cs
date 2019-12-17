using System.Collections.Generic;
using FluentAssertions;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication.BrowserBased
{
    [Binding]
    public sealed class SubDashboard : TestBase
    {
        public SubDashboard(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that a Supplier has chosen to manage the Browser Based Client Application Type Section")]
        public void GivenThatASupplierHasChosenToManageTheBrowserBasedClientApplicationTypeSection()
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.PageDisplayed().Should().BeTrue();
        }

        [Given(@"that a Supplier has chosen the Browser based Client Application Type")]
        public void GivenThatASupplierHasChosenTheBrowserBasedClientApplicationType()
        {
            GivenThatASupplierHasChosenToManageTheBrowserBasedClientApplicationTypeSection();
            WhenTheUserHasSelectedBrowserBasedAsAClientApplicationType();
        }


        [When(@"the User has selected Browser Based as a Client Application Type")]
        public void WhenTheUserHasSelectedBrowserBasedAsAClientApplicationType()
        {
            _test.pages.ClientApplicationTypes.SelectCheckbox("Browser based");
            _test.pages.ClientApplicationTypes.SaveAndReturn();
        }

        [Then(@"there is a list of Browser Based Client Application Type Sub-Sections")]
        public void ThenThereIsAListOfBrowserBasedClientApplicationTypeSub_Sections()
        {
            IList<string> subSectionsExpected = new List<string>
            {
                "Browsers supported",
                "Plug-ins or extensions",
                "Connectivity and resolution",
                "Hardware requirements",
                "Additional information",
                "Mobile first"
            };

            _test.pages.BrowserSubDashboard.GetSections().Should().BeEquivalentTo(subSectionsExpected);
        }

        [Then(@"the Supplier is able to access the Browser Based Client Type Sub-Sections")]
        public void ThenTheSupplierIsAbleToAccessTheBrowserBasedClientTypeSub_Sections()
        {
            _test.pages.BrowserSubDashboard.OpenSection("Browsers supported");
            _test.pages.Common.GoBackOnePage();
        }

        [Then(@"the Section content validation status is displayed")]
        public void ThenTheSectionContentValidationStatusIsDisplayed()
        {
            _test.pages.BrowserSubDashboard.SectionsHaveStatusIndicators();
        }

        [Given(@"the Browser Based Client Application Type Section requires Mandatory Data")]
        public void GivenTheBrowserBasedClientApplicationTypeSectionRequiresMandatoryData()
        {

        }

        [Given(@"the User has selected Browser Based as a Client Application Type")]
        public void GivenTheUserHasSelectedBrowserBasedAsAClientApplicationType()
        {
            GivenThatASupplierHasChosenToManageTheBrowserBasedClientApplicationTypeSection();
            WhenTheUserHasSelectedBrowserBasedAsAClientApplicationType();
        }

        [Given(@"a Supplier has not saved Mandatory data on all the Browser Based Client Application Type Sub-Sections")]
        public void GivenASupplierHasNotSavedMandatoryDataOnAllTheBrowserBasedClientApplicationTypeSub_Sections()
        {
        }

        [Then(@"the Browser Based Client Application Type Section is marked as Incomplete")]
        public void ThenTheBrowserBasedClientApplicationTypeSectionIsMarkedAsIncomplete()
        {
            _test.pages.Dashboard.AssertSectionStatus("Browser based", "INCOMPLETE");
        }

        [Given(@"a Supplier has saved all mandatory data on the Browser Based Client Application Type Sub-Sections")]
        public void GivenASupplierHasSavedAllMandatoryDataOnTheBrowserBasedClientApplicationTypeSub_Sections()
        {
        }

        [Then(@"the Browser Based Client Application Type Section is marked as Complete")]
        public void ThenTheBrowserBasedClientApplicationTypeSectionIsMarkedAsComplete()
        {

        }

    }
}
