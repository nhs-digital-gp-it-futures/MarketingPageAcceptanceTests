namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.BrowserBased
{
    using System.Collections.Generic;
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SubDashboard : TestBase
    {
        public SubDashboard(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        public static void NoAction(string userType)
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
                "Additional information",
            };

            test.Pages.BrowserBasedSections.BrowserSubDashboard.GetSections().Should()
                .BeEquivalentTo(subSectionsExpected);
        }

        [Then(@"the Supplier is able to access the Browser-based Client Type Sub-Sections")]
        public void ThenTheSupplierIsAbleToAccessTheBrowserBasedClientTypeSub_Sections()
        {
            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection("Supported browsers");
            test.Pages.Common.GoBackOnePage();
        }

        [Then(@"the Section content validation status is displayed")]
        public void ThenTheSectionContentValidationStatusIsDisplayed()
        {
            test.Pages.BrowserBasedSections.BrowserSubDashboard.SectionsHaveStatusIndicators();
        }
    }
}
