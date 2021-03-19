namespace MarketingPageAcceptanceTests.SmokeTests
{
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class UniqueSteps : TestBase
    {
        public UniqueSteps(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"a user has chosen to manage (Authority|Supplier) added data")]
        public void GivenAUserHasChosenToManageAuthorityAddedData(string dashboard)
        {
            test.UserType = dashboard.ToLower();
            test.SetUrlAsync();
            test.GoToUrl();
        }
    }
}
