using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication.ConnectivityAndResolution
{
    [Binding]
    public class ConnectivityAndResolution
    {
        private UITest _test;
        private ScenarioContext _context;

        public ConnectivityAndResolution(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"that a User has provided a value for the Mandatory Information")]
        public void GivenThatAUserHasProvidedAValueForTheMandatoryInformation()
        {
            _context.Pending();
        }

        [Given(@"that an answer has not provided to the mandatory question")]
        public void GivenThatAnAnswerHasNotProvidedToTheMandatoryQuestion()
        {
            _context.Pending();
        }

        [Given(@"that data has been saved in Connectivity and resolution")]
        public void GivenThatDataHasBeenSavedInConnectivityAndResolution()
        {
            _context.Pending();
        }

        [Given(@"that a User has not provided any mandatory data")]
        public void GivenThatAUserHasNotProvidedAnyMandatoryData()
        {
            _context.Pending();
        }

        [Given(@"validation has been triggered for Connectivity and resolution")]
        public void GivenValidationHasBeenTriggeredForConnectivityAndResolution()
        {
            _context.Pending();
        }

        [When(@"the User is managing their Connectivity and Resolution Information")]
        public void WhenTheUserIsManagingTheirConnectivityAndResolutionInformation()
        {
            _context.Pending();
        }

        [When(@"the User exits the page")]
        public void WhenTheUserExitsThePage()
        {
            _test.pages.Common.ClickSectionBackLink();
        }

        [When(@"the User attempts to save")]
        public void WhenTheUserAttemptsToSave()
        {
            _test.pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the Section is marked as '(.*)' on the Browser Based Client Type Sub-Form")]
        public void ThenTheSectionIsMarkedAsOnTheBrowserBasedClientTypeSub_Form(string p0)
        {
            _context.Pending();
        }
    }
}
