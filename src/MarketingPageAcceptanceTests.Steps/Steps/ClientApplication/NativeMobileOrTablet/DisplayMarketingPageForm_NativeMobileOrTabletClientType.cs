using FluentAssertions;
using MarketingPageAcceptanceTests.Steps.Utils;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.NativeMobileOrTablet
{
    [Binding]
    public class DisplayMarketingPageForm_NativeMobileOrTabletClientType : TestBase
    {
        public DisplayMarketingPageForm_NativeMobileOrTabletClientType(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Then(@"there is a list of Native Mobile or Tablet Client Application Type Sub-Sections")]
        public void ThenThereIsAListOfNativeMobileOrTabletClientApplicationTypeSub_Sections()
        {
            IList<string> subSectionsExpected = new List<string>
            {
                "Supported operating systems",
                "Mobile first",
                "Memory and storage",
                "Connection details",
                "Third party components and device capabilities",
                "Hardware requirements",
                "Additional information"
            };

            _test.pages.BrowserBasedSections.BrowserSubDashboard.GetSections().Should().BeEquivalentTo(subSectionsExpected);
        }

    }
}
