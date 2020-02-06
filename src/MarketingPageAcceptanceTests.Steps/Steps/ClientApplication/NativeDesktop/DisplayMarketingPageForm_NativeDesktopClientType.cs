using FluentAssertions;
using MarketingPageAcceptanceTests.Steps.Utils;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.NativeDesktop
{
    [Binding]
    public class DisplayMarketingPageForm_NativeDesktopClientType : TestBase
    {
        public DisplayMarketingPageForm_NativeDesktopClientType(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Then(@"there is a list of Native Desktop Client Application Type Sub-Sections")]
        public void ThenThereIsAListOfNativeDesktopClientApplicationTypeSub_Sections()
        {
            IList<string> subSectionsExpected = new List<string>
            {
                "Supported operating systems",
                "Connection details",
                "Memory, storage, processing and aspect ratio",
                "Third party components and device capabilities",
                "Hardware requirements",
                "Additional information"
            };

            _test.pages.BrowserBasedSections.BrowserSubDashboard.GetSections().Should().BeEquivalentTo(subSectionsExpected);
        }
    }
}
