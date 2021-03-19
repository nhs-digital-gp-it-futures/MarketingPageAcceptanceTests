namespace MarketingPageAcceptanceTests.SmokeTests
{
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class Hooks
    {
        private readonly UITest test;

        public Hooks(UITest test)
        {
            this.test = test;
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

        [AfterScenario]
        public void AfterScenario()
        {
            test.Driver.Close();
            test.Driver.Quit();
        }

        private void BeforeShared(string userType)
        {
            test.CreateSolution = false;
            test.UserType = userType;
            test.SetUrlAsync();
            test.GoToUrl();
        }
    }
}
