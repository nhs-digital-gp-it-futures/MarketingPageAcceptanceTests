using BoDi;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Utils
{
    [Binding]
    public class CommonHooks
    {
        private readonly IObjectContainer _objectContainer;

        public CommonHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario(Order = 0)]
        public void SetupAppSettings()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            _objectContainer.RegisterInstanceAs<IConfiguration>(configurationBuilder);
        }
    }
}
