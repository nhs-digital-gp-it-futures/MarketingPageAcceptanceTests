using MarketingPageAcceptanceTests.StepSetup.Utils;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.StepSetup
{
    [Binding]
    public sealed class Hooks : TestBase
    {
        public Hooks(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            _test.Driver.Quit();

            _test.solution.Delete(_test.ConnectionString);

            _test.listOfSolutions.Remove(_test.solution);
            try
            {
                foreach (var solution in _test.listOfSolutions) solution.Delete(_test.ConnectionString);
            }
            finally
            {
                _test.listOfSolutions = null;
            }

            try
            {
                if (_test.supplier != null) _test.supplier.Delete(_test.ConnectionString);
            }
            finally
            {
                _test.supplier = null;
            }

            await _test.azureBlobStorage.ClearStorage();
        }
    }
}