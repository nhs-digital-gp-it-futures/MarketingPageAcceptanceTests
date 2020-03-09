using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.NativeDesktop
{
    [Binding]
    public class MemoryStorageProcessingAndResolution : TestBase
    {
        public MemoryStorageProcessingAndResolution(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(
            @"that Memory, storage, processing and resolution has been completed for Native desktop with (.*) characters")]
        public void GivenThatMemoryStorageProcessingAndAspectRatioHasBeenCompletedForNativeDesktopWithCharacters(
            int chars)
        {
            _test.Pages.Dashboard.NavigateToSection("Native desktop", true);
            _test.Pages.Dashboard.NavigateToSection("Memory, storage, processing and resolution");
            _test.Pages.NativeDesktopSections.MemoryAndStorage.CompleteAllFields(chars);
        }
    }
}