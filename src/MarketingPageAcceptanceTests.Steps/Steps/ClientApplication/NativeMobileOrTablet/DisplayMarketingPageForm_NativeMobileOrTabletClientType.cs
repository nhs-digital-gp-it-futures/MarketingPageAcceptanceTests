using System.Collections.Generic;
using FluentAssertions;
using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.NativeMobileOrTablet
{
    [Binding]
    public class DisplayMarketingPageForm_NativeMobileOrTabletClientType : TestBase
    {
        public DisplayMarketingPageForm_NativeMobileOrTabletClientType(UITest test, ScenarioContext context) : base(
            test, context)
        {
        }

        [Then(@"there is a list of Native Mobile or Tablet Client Application Type Sub-Sections")]
        public void ThenThereIsAListOfNativeMobileOrTabletClientApplicationTypeSub_Sections()
        {
            List<string> subSectionsExpected = new()
            {
                "Supported operating systems",
                "Mobile first approach",
                "Memory and storage",
                "Connectivity",
                "Third-party components and device capabilities",
                "Hardware requirements",
                "Additional information"
            };

            _test.Pages.BrowserBasedSections.BrowserSubDashboard.GetSections().Should()
                .BeEquivalentTo(subSectionsExpected);
        }
    }
}
