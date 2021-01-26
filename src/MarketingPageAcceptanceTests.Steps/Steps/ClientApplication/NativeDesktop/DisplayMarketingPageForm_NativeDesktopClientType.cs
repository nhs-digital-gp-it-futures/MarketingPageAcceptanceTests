namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.NativeDesktop
{
    using System.Collections.Generic;
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class DisplayMarketingPageForm_NativeDesktopClientType : TestBase
    {
        public DisplayMarketingPageForm_NativeDesktopClientType(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Then(@"there is a list of Native Desktop Client Application Type Sub-Sections")]
        public void ThenThereIsAListOfNativeDesktopClientApplicationTypeSub_Sections()
        {
            List<string> subSectionsExpected = new()
            {
                "Supported operating systems",
                "Connectivity",
                "Memory, storage, processing and resolution",
                "Third-party components and device capabilities",
                "Hardware requirements",
                "Additional information",
            };

            test.Pages.BrowserBasedSections.BrowserSubDashboard.GetSections().Should()
                .BeEquivalentTo(subSectionsExpected);
        }
    }
}
