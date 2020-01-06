using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.SolutionDescription
{
    [Binding]
    public class SolutionDescription : TestBase
    {
        public SolutionDescription(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Then(@"the Supplier is able to manage the Solution Description Marketing Page Form Section")]
        public void ThenTheSupplierIsAbleToManageTheSolutionDescriptionMarketingPageFormSection()
        {
            _test.pages.Dashboard.NavigateToSection("Solution description");
        }
    }
}
