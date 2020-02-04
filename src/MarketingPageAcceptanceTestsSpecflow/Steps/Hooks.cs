using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Utils;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps
{
    [Binding]
    public sealed class Hooks : TestBase
    {
        public Hooks(UITest test, ScenarioContext context, FeatureContext feature) : base(test, context)
        {
            context.Set(feature.FeatureInfo.Title, "FeatureTitle");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var user =_test.DetermineUser(_context.Get<string>("FeatureTitle"));
            _test.SetUrl(_test.solution.Id, user);
            _test.GoToUrl();
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
