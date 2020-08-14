using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.SmokeTests
{
    [Binding]
    public sealed class Hooks
    {
        private readonly UITest _test;

        public Hooks(UITest test)
        {
            _test = test;
        }

        [BeforeScenario("supplier", Order = 1)]
        public void BeforeSupplierScenario()
        {
            BeforeShared("supplier");
        }

        [BeforeScenario("authority", Order = 1)]
        public void BeforeAuthorityScenario()
        {
            BeforeShared("authority");
        }

        private void BeforeShared(string userType)
        {
            _test.CreateSolution = false;
            _test.UserType = userType;
            _test.SetUrl();
            _test.GoToUrl();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _test.Driver.Close();
            _test.Driver.Quit();
        }
    }
}