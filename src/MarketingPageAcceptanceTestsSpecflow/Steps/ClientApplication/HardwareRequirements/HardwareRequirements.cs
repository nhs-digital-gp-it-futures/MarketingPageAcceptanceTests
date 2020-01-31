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

        [Given(@"a (Supplier|User) has saved any data in any field within (.*)")]
        public void GivenASupplierHasSavedAnyDataInAnyFieldWithinTheSub_Section(string user, string sectionName)
        {
            _test.pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(sectionName);

            _test.pages.BrowserBasedSections.HardwareRequirements.EnterText(100);
            _test.pages.Common.SectionSaveAndReturn();
        }
    }
}
