using MarketingPageAcceptanceTests.StepSetup.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.HardwareRequirements
{
    [Binding]
    public class HardwareRequirements : TestBase
    {
        public HardwareRequirements(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"a .* has saved any data in any field within (.*)")]
        public void GivenASupplierHasSavedAnyDataInAnyFieldWithinTheSub_Section(string sectionName)
        {
            _test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(sectionName);

            _test.Pages.BrowserBasedSections.HardwareRequirements.EnterText(100);
            _test.Pages.Common.SectionSaveAndReturn();
        }
    }
}