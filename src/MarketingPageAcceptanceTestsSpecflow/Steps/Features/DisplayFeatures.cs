using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.Features
{
    [Binding]
    public class DisplayFeatures
    {
        private UITest _test;
        private ScenarioContext _context;

        public DisplayFeatures(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"that a Supplier has chosen to manage Marketing Page Information")]
        public void GivenThatASupplierHasChosenToManageMarketingPageInformation()
        {
        }

        [Then(@"the Supplier is able to manage the Features Marketing Page Form Section")]
        public void ThenTheSupplierIsAbleToManageTheFeaturesMarketingPageFormSection()
        {
            _test.pages.Dashboard.NavigateToSection("Features");
        }

        [Then(@"the Features section content validation status is displayed")]
        public void ThenTheFeaturesSectionContentValidationStatusIsDisplayed()
        {
            _test.pages.Dashboard.SectionHasStatus("Features");
        }
    }
}
