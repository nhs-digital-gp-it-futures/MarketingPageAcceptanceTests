using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.SmokeTests
{
    [Binding]
    public sealed class UniqueSteps : TestBase
    {
        public UniqueSteps(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"a user has chosen to manage (Authority|Supplier) added data")]
        public void GivenAUserHasChosenToManageAuthorityAddedData(string dashboard)
        {
            _test.UserType = dashboard.ToLower();
            _test.SetUrl();
            _test.GoToUrl();
        }

    }
}
