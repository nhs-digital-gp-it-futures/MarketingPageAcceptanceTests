using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps
{
    [Binding]
    public sealed class CommonSteps
    {
        private UITest _test;

        public CommonSteps(UITest test)
        {
            _test = test;
        }

        [When("the Marketing Page Form is presented")]
        public void MarketingPageFormPresented()
        {
            _test.pages.Dashboard.PageDisplayed();
        }
    }
}
