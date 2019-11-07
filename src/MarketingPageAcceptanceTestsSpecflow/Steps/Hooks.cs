using MarketingPageAcceptanceTests.Actions.Utils;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps
{
    [Binding]
    public sealed class Hooks
    {
        private readonly UITest _test;

        public Hooks(UITest test)
        {
            _test = test;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _test.driver.Close();
            _test.driver.Quit();

            SqlHelper.DeleteSolution(_test.solution.Id, _test.connectionString);
        }
    }
}
