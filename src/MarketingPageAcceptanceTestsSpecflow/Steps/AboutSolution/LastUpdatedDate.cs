using System;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.AboutSolution
{
    [Binding]
    public class LastUpdatedDate
    {
        private UITest _test;
        private ScenarioContext _context;
        public LastUpdatedDate(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"that the Solution Summary is updated")]
        public void GivenThatTheSolutionSummaryIsUpdated()
        {
            _context.Pending();
        }
        
        [Given(@"that the About Solution URL is updated")]
        public void GivenThatTheAboutSolutionURLIsUpdated()
        {
            _context.Pending();
        }
        
        [Given(@"that the Contact details are updated")]
        public void GivenThatTheContactDetailsAreUpdated()
        {
            _context.Pending();
        }
        
        [When(@"the content has been updated")]
        public void WhenTheContentHasBeenUpdated()
        {
            _context.Pending();
        }
        
        [Then(@"the Last Changed Date is updated")]
        public void ThenTheLastChangedDateIsUpdated()
        {
            _context.Pending();
        }
    }
}
