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

        [BeforeScenario("supplier")]
        public void BeforeSupplierScenario()
        {
            _test.UserType = "supplier";
            BeforeShared();
        }

        [BeforeScenario("authority")]
        public void BeforeAuthorityScenario()
        {
            _test.UserType = "authority";
            BeforeShared();
        }

        private void BeforeShared()
        {
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