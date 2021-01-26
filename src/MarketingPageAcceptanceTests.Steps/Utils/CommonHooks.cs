namespace MarketingPageAcceptanceTests.Steps.Utils
{
    using BoDi;
    using Microsoft.Extensions.Configuration;
    using TechTalk.SpecFlow;

    [Binding]
    public class CommonHooks
    {
        private readonly IObjectContainer objectContainer;

        public CommonHooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario(Order = 0)]
        public void SetupAppSettings()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            objectContainer.RegisterInstanceAs<IConfiguration>(configurationBuilder);
        }
    }
}
