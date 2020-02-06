using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Utils
{
    public abstract class TestBase
    {
        public readonly UITest _test;
        public readonly ScenarioContext _context;

        public TestBase(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }
    }
}
