using MarketingPageAcceptanceTests.Steps.Utils;
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
            _test.UserType = "authority";
            _test.SetUrl();
            _test.GoToUrl();
        }
    }
}
