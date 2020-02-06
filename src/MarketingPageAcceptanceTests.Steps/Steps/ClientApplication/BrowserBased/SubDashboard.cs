using FluentAssertions;
using MarketingPageAcceptanceTests.Steps.Utils;
using System.Collections.Generic;
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
        public void GivenThatASupplierHasChosenToManageTheBrowserBasedClientApplicationTypeSection(string userType)
        {
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

            _test.pages.BrowserBasedSections.BrowserSubDashboard.GetSections().Should().BeEquivalentTo(subSectionsExpected);
        }

        [Then(@"the Supplier is able to access the Browser Based Client Type Sub-Sections")]
        public void ThenTheSupplierIsAbleToAccessTheBrowserBasedClientTypeSub_Sections()
        {
            _test.pages.BrowserBasedSections.BrowserSubDashboard.OpenSection("Browsers supported");
            _test.pages.Common.GoBackOnePage();
        }

        [Then(@"the Section content validation status is displayed")]
        public void ThenTheSectionContentValidationStatusIsDisplayed()
        {
            _test.pages.BrowserBasedSections.BrowserSubDashboard.SectionsHaveStatusIndicators();
        }

        [Given(@"a Supplier has not saved Mandatory data on all the Browser Based Client Application Type Sub-Sections")]
        public void GivenASupplierHasNotSavedMandatoryDataOnAllTheBrowserBasedClientApplicationTypeSub_Sections()
        {
        }
    }
}
