using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication.HardwareRequirements
{
    [Binding]
    public class HardwareRequirements : TestBase
    {
        public HardwareRequirements(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"the Supplier has entered (\d{3,4}) characters on the (.*) page")]
        public void GivenTheSupplierHasEnteredText(int characters, string page)
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.SelectCheckbox("Browser based");
            _test.pages.ClientApplicationTypes.SaveAndReturn();
            _test.pages.Dashboard.NavigateToSection("Browser based", true);

            _test.pages.BrowserSubDashboard.OpenSection(page);

            _test.pages.HardwareRequirements.EnterText(characters);
        }

        [Given(@"the (.*) Sub-Section does not require Mandatory Data")]
        public void GivenTheSub_SectionDoesNotRequireMandatoryData(string sectionName)
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.SelectCheckbox("Browser based");
            _test.pages.ClientApplicationTypes.SaveAndReturn();
            _test.pages.Dashboard.NavigateToSection("Browser based", true);
        }


        [Given(@"a Supplier has not saved any data in any field within the Sub-Section")]
        public void GivenASupplierHasNotSavedAnyDataInAnyFieldWithinTheSub_Section()
        {
            
        }

        [Given(@"a Supplier has saved any data in any field within (.*)")]
        public void GivenASupplierHasSavedAnyDataInAnyFieldWithinTheSub_Section(string sectionName)
        {
            _test.pages.BrowserSubDashboard.OpenSection(sectionName);

            _test.pages.HardwareRequirements.EnterText(100);
            _test.pages.Common.SectionSaveAndReturn();
        }

        [When(@"the Browser Based Client Application Sub-Form is presented")]
        public void WhenTheBrowserBasedClientApplicationSub_FormIsPresented()
        {   
        }

        [Then(@"the (.*) Sub-Section is marked as (Incomplete|Complete)")]
        public void ThenTheBrowserBasedClientApplicationTypeSub_SectionIsMarkedAsIncomplete(string sectionName, string status)
        {
            _test.pages.Dashboard.AssertSectionStatus(sectionName, status.ToUpper());
        }

        [Then(@"the Browser Based Client Application Type Sub-Section is marked as Complete")]
        public void ThenTheBrowserBasedClientApplicationTypeSub_SectionIsMarkedAsComplete()
        {
            _context.Pending();
        }
    }
}
