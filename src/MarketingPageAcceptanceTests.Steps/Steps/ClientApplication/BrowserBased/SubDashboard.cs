using System.Collections.Generic;
using FluentAssertions;
using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.BrowserBased
{
    [Binding]
    public sealed class SubDashboard : TestBase
    {
        public SubDashboard(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that a (Supplier|Authority User) has chosen to manage the .* Client Application Type Section")]
        public static void GivenThatASupplierHasChosenToManageTheBrowserBasedClientApplicationTypeSection(string userType)
        {
        }

        [Then(@"there is a list of Browser-based Client Application Type Sub-Sections")]
        public void ThenThereIsAListOfBrowserBasedClientApplicationTypeSub_Sections()
        {
            IList<string> subSectionsExpected = new List<string>
            {
                "Supported browsers",
                "Mobile first approach",
                "Plug-ins or extensions required",
                "Connectivity and resolution",
                "Hardware requirements",
                "Additional information"
            };

            _test.Pages.BrowserBasedSections.BrowserSubDashboard.GetSections().Should()
                .BeEquivalentTo(subSectionsExpected);
        }

        [Then(@"the Supplier is able to access the Browser-based Client Type Sub-Sections")]
        public void ThenTheSupplierIsAbleToAccessTheBrowserBasedClientTypeSub_Sections()
        {
            _test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection("Supported browsers");
            _test.Pages.Common.GoBackOnePage();
        }

        [Then(@"the Section content validation status is displayed")]
        public void ThenTheSectionContentValidationStatusIsDisplayed()
        {
            _test.Pages.BrowserBasedSections.BrowserSubDashboard.SectionsHaveStatusIndicators();
        }

        [Given(@"a Supplier has not saved Mandatory data on all the Browser-based Client Application Type Sub-Sections")]
        public static void GivenASupplierHasNotSavedMandatoryDataOnAllTheBrowserBasedClientApplicationTypeSub_Sections()
        {
        }
    }
}