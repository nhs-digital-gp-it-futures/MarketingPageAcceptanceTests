using System;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.HostingType
{
    [Binding]
    public class Suppliers_EditPublicCloudHostingType : TestBase
    {
        public Suppliers_EditPublicCloudHostingType(UITest test, ScenarioContext context) : base(test, context)
        {
                
        }

        [Given(@"that Public cloud has been completed in the Hosting type section")]
        public void GivenThatPublicCloudHasBeenCompletedInTheHostingTypeSection()
        {
            _test.pages.Dashboard.NavigateToSection("Public cloud");
            _test.pages.BrowserBasedSections.HardwareRequirements.EnterText(500, 0);
            _test.pages.BrowserBasedSections.HardwareRequirements.EnterText(1000, 1);
            _test.pages.HostingTypeSections.PublicCloud.ClickRequiresHscnN3ConnectivityCheckbox();
            _test.pages.Common.SectionSaveAndReturn();
            _context.Pending();
        }

        [Given(@"the user unchecks the HSCN/N3 connection checkbox on the Public cloud section")]
        public void GivenTheUserUnchecksTheHSCNNConnectionCheckboxOnThePublicCloudSection()
        {
            _test.pages.Dashboard.NavigateToSection("Public cloud");
            _test.pages.HostingTypeSections.PublicCloud.ClickRequiresHscnN3ConnectivityCheckbox();
            _test.pages.Common.SectionSaveAndReturn();
        }

    }
}
