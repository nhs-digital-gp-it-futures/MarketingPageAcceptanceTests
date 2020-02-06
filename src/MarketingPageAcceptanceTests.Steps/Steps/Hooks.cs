using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Utils;
using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps
{
    [Binding]
    public sealed class Hooks : TestBase
    {
        public Hooks(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _test.driver.Quit();

            _test.solution.Delete(_test.connectionString);

            _test.listOfSolutions.Remove(_test.solution);
            try
            {
                foreach (Solution solution in _test.listOfSolutions)
                {
                    solution.Delete(_test.connectionString);
                }
            }
            finally
            {
                _test.listOfSolutions = null;
            }
            try
            {
                if (_test.supplier != null)
                {
                    _test.supplier.Delete(_test.connectionString);
                }
            }
            finally
            {
                _test.supplier = null;
            }
        }
    }
}
