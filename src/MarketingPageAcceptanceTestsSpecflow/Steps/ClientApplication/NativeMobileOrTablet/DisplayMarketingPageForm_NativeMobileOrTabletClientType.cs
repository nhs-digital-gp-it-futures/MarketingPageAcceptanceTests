using FluentAssertions;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication.NativeMobileOrTablet
{
    [Binding]
    public class DisplayMarketingPageForm_NativeMobileOrTabletClientType : TestBase
    {
        public DisplayMarketingPageForm_NativeMobileOrTabletClientType(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [When(@"the User has selected Native Mobile or Tablet Client Type as a Client Application Type")]
        public void WhenTheUserHasSelectedNativeMobileOrTabletClientTypeAsAClientApplicationType()
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.SelectCheckbox("Native mobile or tablet");
            _test.pages.ClientApplicationTypes.SaveAndReturn();
        }

        [Then(@"the Authority User is able to access the Native Mobile or Tablet Client Type Type Sub-Dashboard")]
        public void ThenTheAuthorityUserIsAbleToAccessTheNativeMobileOrTabletClientTypeTypeSub_Dashboard()
        {
            _test.pages.Dashboard.NavigateToSection("Native mobile or tablet", true);
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

            _test.pages.BrowserSubDashboard.GetSections().Should().BeEquivalentTo(subSectionsExpected);
        }

    }
}
