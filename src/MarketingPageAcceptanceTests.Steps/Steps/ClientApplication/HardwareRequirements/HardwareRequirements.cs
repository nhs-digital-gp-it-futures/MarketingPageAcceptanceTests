namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.HardwareRequirements
{
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class HardwareRequirements : TestBase
    {
        public HardwareRequirements(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"a .* has saved any data in any field within (.*)")]
        public void GivenASupplierHasSavedAnyDataInAnyFieldWithinTheSub_Section(string sectionName)
        {
            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(sectionName);

            test.Pages.BrowserBasedSections.HardwareRequirements.EnterText(100);
            test.Pages.Common.SectionSaveAndReturn();
        }
    }
}
