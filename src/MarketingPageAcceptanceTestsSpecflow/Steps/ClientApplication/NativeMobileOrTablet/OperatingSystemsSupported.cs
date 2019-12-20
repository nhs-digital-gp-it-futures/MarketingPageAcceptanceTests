using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication.NativeMobileOrTablet
{
    [Binding]
    public class OperatingSystemsSupported : TestBase
    {
        public OperatingSystemsSupported(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that a User has provided a value for the Mandatory Information")]
        public void GivenThatAUserHasProvidedAValueForTheMandatoryInformation()
        {
            _context.Pending();
        }

        [Given(@"that an answer has not been provided to the mandatory question")]
        public void GivenThatAnAnswerHasNotBeenProvidedToTheMandatoryQuestion()
        {
            _context.Pending();
        }

        [Given(@"the User has entered text")]
        public void GivenTheUserHasEnteredText()
        {
            _context.Pending();
        }

        [Given(@"that a User has not provided any mandatory data")]
        public void GivenThatAUserHasNotProvidedAnyMandatoryData()
        {
            _context.Pending();
        }

        [When(@"the User is managing their Operating System Information")]
        public void WhenTheUserIsManagingTheirOperatingSystemInformation()
        {
            _context.Pending();
        }

        [Then(@"the Section is marked as '(.*)' on the Native Desktop Client Type Sub-Form")]
        public void ThenTheSectionIsMarkedAsOnTheNativeDesktopClientTypeSub_Form(string status)
        {
            _context.Pending();
        }

        [Then(@"the Section is marked as '(.*)' on the Browser Based Client Type Sub-Form")]
        public void ThenTheSectionIsMarkedAsOnTheBrowserBasedClientTypeSub_Form(string status)
        {
            _context.Pending();
        }
    }
}
