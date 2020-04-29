using MarketingPageAcceptanceTests.StepSetup.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.SupplierTests.Utils
{
    [Binding]
    public sealed class BeforeHook : TestBase
    {
        public BeforeHook(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _test.CreateSolution = true;
            _test.SetUrl(userType: "supplier");
            _test.GoToUrl();
        }
    }
}