namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.NativeDesktop
{
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class MemoryStorageProcessingAndResolution : TestBase
    {
        public MemoryStorageProcessingAndResolution(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that Memory, storage, processing and resolution has been completed for Native desktop with (.*) characters")]
        public void GivenThatMemoryStorageProcessingAndAspectRatioHasBeenCompletedForNativeDesktopWithCharacters(
            int chars)
        {
            test.Pages.Dashboard.NavigateToSection("Native desktop", true);
            test.Pages.Dashboard.NavigateToSection("Memory, storage, processing and resolution");
            test.Pages.NativeDesktopSections.MemoryAndStorage.CompleteAllFields(chars);
        }
    }
}
