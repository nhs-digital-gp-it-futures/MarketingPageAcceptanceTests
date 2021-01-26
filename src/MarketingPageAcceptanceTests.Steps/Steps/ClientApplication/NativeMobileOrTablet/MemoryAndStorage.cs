namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.NativeMobileOrTablet
{
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class MemoryAndStorage : TestBase
    {
        public MemoryAndStorage(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"the User selects a memory requirement")]
        public void GivenTheUserSelectsAMemoryRequirement()
        {
            test.Pages.NativeMobileSections.MemoryAndStorage.SelectRequirementFromList();
        }
    }
}
