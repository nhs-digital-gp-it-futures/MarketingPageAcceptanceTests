using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication
{
    [Binding]
    public sealed class SharedBrowserBasedSteps : TestBase
    {
        public SharedBrowserBasedSteps(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that an answer has not been provided to the (.*) mandatory question")]
        public void GivenThatAnAnswerHasNotBeenProvidedToThePlug_InsOrExtensionsMandatoryQuestion(string section)
        {
            _test.pages.Dashboard.NavigateToSection("Browser based", true);
            _test.pages.BrowserSubDashboard.OpenSection(section);
        }

        [Given(@"validation has been triggered on Browser based section (.*)")]
        public void GivenValidationHasBeenTriggeredOnSection(string section)
        {
            _test.pages.Dashboard.NavigateToSection("Browser based", true);
            _test.pages.BrowserSubDashboard.OpenSection(section);
            _test.pages.Common.SectionSaveAndReturn();
        }

        [Given(@"that a User has not provided any mandatory data for (.*)")]
        public void GivenThatAUserHasNotProvidedAnyMandatoryDataForSection(string section)
        {
            _test.pages.Dashboard.NavigateToSection("Browser based", true);
            _test.pages.BrowserSubDashboard.OpenSection(section);
        }

        [Given(@"the user has saved the data")]
        public void GivenTheUserHasSavedTheData()
        {
            _test.pages.Common.SectionSaveAndReturn();
            _test.pages.Common.ClickSubDashboardBackLink();
        }


        [Then(@"the (.*) section is marked as (COMPLETE|INCOMPLETE) on the Browser Based Client Type Sub-Form")]
        public void ThenTheSectionIsMarkedAsOnTheBrowserBasedClientTypeSub_Form(string section, string status)
        {
            _test.pages.Dashboard.AssertSectionStatus(section, status);
        }

        [Then(@"the Submission will trigger validation")]
        public void ThenTheSubmissionWillTriggerValidation()
        {
            _test.pages.Common.ErrorMessageDisplayed();
        }

        [Then(@"an indication is given to the Supplier as to why")]
        public void ThenAnIndicationIsGivenToTheSupplierAsToWhy()
        {
            _test.pages.Common.ErrorMessageDisplayed();
        }


    }
}
