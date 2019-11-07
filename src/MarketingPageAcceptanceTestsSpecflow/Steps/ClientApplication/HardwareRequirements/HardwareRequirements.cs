using MarketingPageAcceptanceTestsSpecflow.Utils;
using System;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication.HardwareRequirements
{
    [Binding]
    public class HardwareRequirements
    {
        private UITest _test;
        private ScenarioContext _context;

        public HardwareRequirements(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"the Supplier has entered text on the (.*) page")]
        public void GivenTheSupplierHasEnteredText(string page)
        {
            _context.Pending();
        }
        
        [Given(@"the Browser Based Client Application Type Sub-Section does not require Mandatory Data")]
        public void GivenTheBrowserBasedClientApplicationTypeSub_SectionDoesNotRequireMandatoryData()
        {
            _context.Pending();
        }
        
        [Given(@"a Supplier has not saved any data in any field within the Sub-Section")]
        public void GivenASupplierHasNotSavedAnyDataInAnyFieldWithinTheSub_Section()
        {
            _context.Pending();
        }
        
        [Given(@"a Supplier has saved any data in any field within the Sub-Section")]
        public void GivenASupplierHasSavedAnyDataInAnyFieldWithinTheSub_Section()
        {
            _context.Pending();
        }
        
        [When(@"the Browser Based Client Application Sub-Form is presented")]
        public void WhenTheBrowserBasedClientApplicationSub_FormIsPresented()
        {
            _context.Pending();
        }
        
        [Then(@"the Browser Based Client Application Type Sub-Section is marked as Incomplete")]
        public void ThenTheBrowserBasedClientApplicationTypeSub_SectionIsMarkedAsIncomplete()
        {
            _context.Pending();
        }
        
        [Then(@"the Browser Based Client Application Type Sub-Section is marked as Complete")]
        public void ThenTheBrowserBasedClientApplicationTypeSub_SectionIsMarkedAsComplete()
        {
            _context.Pending();
        }
    }
}
