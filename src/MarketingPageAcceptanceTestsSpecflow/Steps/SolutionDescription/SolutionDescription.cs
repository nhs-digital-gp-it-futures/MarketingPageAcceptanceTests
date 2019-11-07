using MarketingPageAcceptanceTestsSpecflow.Utils;
using System;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.SolutionDescription
{
    [Binding]
    public class SolutionDescription
    {
        private UITest _test;
        private ScenarioContext _context;

        public SolutionDescription(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Then(@"the Supplier is able to manage the Solution Description Marketing Page Form Section")]
        public void ThenTheSupplierIsAbleToManageTheSolutionDescriptionMarketingPageFormSection()
        {
            _test.pages.Dashboard.NavigateToSection("Solution description");
        }
    }
}
