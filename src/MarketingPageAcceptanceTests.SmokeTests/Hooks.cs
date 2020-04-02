using MarketingPageAcceptanceTests.StepSetup.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.SmokeTests
{
    [Binding]
    public sealed class Hooks : TestBase
    {
        public Hooks(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _test.UserType = "supplier";
            _test.SetUrl();
            _test.GoToUrl();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _test.Driver.Quit();
        }
    }
}