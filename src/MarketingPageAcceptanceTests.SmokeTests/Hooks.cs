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
            _test.CreateSolution = false;            
            BeforeShared("supplier");
        }

        [BeforeScenario("authority")]
        public void BeforeAuthorityScenario()
        {
            _test.CreateSolution = false;            
            BeforeShared("authority");
        }

        private void BeforeShared(string userType)
        {
            _test.SetUrl(userType: userType);
            _test.GoToUrl();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _test.Driver.Quit();
        }
    }
}