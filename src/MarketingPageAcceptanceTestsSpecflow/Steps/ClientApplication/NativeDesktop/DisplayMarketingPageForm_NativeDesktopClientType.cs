using System;
using System.Collections.Generic;
using FluentAssertions;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication.NativeDesktop
{
    [Binding]
    public class DisplayMarketingPageForm_NativeDesktopClientType : TestBase
    {
        public DisplayMarketingPageForm_NativeDesktopClientType(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [When(@"the User has selected Native Desktop Client Type as a Client Application Type")]
        public void WhenTheUserHasSelectedNativeDesktopClientTypeAsAClientApplicationType()
        {
            new SharedClientApplicationTypesSteps(_test, _context).SelectClientType("Native desktop");
        }
        
        [Then(@"the Authority User is able to access the Native Desktop Client Type Type Sub-Dashboard")]
        public void ThenTheAuthorityUserIsAbleToAccessTheNativeDesktopClientTypeTypeSub_Dashboard()
        {
            _test.pages.Dashboard.NavigateToSection("Native desktop", true);
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
