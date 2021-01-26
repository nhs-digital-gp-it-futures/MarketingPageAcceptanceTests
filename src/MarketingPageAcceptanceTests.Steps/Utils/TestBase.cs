namespace MarketingPageAcceptanceTests.Steps.Utils
{
    using TechTalk.SpecFlow;

    public abstract class TestBase
    {
        protected readonly ScenarioContext context;
        protected readonly UITest test;

        public TestBase(UITest test, ScenarioContext context)
        {
            this.test = test;
            this.context = context;
        }
    }
}
