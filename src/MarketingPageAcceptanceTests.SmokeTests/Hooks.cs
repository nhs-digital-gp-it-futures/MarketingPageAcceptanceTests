namespace MarketingPageAcceptanceTests.SmokeTests
{
    using System.Threading.Tasks;
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
        public async Task BeforeSupplierScenarioAsync()
        {
            await BeforeSharedAsync("supplier");
        }

        [BeforeScenario("authority", Order = 1)]
        public async Task BeforeAuthorityScenarioAsync()
        {
            await BeforeSharedAsync("authority");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            test.Driver.Close();
            test.Driver.Quit();
        }

        private async Task BeforeSharedAsync(string userType)
        {
            test.CreateSolution = false;
            test.UserType = userType;
            await test.SetUrlAsync();
            test.GoToUrl();
        }
    }
}
