using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Utils;
using MarketingPageAcceptanceTestsSpecflow.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.Steps
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

            SqlHelper.DeleteSolution(_test.solution.Id, _test.connectionString);
            _test.listOfSolutions.Remove(_test.solution);
            try
            {
                foreach (Solution solution in _test.listOfSolutions)
                {
                    SqlHelper.DeleteSolution(solution.Id, _test.connectionString);
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
                    SqlHelper.DeleteSupplier(_test.supplier.Id, _test.connectionString);
                }
            }
            finally
            {
                _test.supplier = null;
            }
        }
    }
}
