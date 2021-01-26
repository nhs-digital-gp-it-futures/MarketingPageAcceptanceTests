namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication
{
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SharedBrowserBasedSteps : TestBase
    {
        public SharedBrowserBasedSteps(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that an answer has not been provided to the (.*) mandatory question on the (.*) section")]
        public void GivenThatAnAnswerHasNotBeenProvidedToThePlug_InsOrExtensionsMandatoryQuestion(
            string section,
            string subDashboard)
        {
            test.Pages.Dashboard.NavigateToSection(subDashboard, true);
            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(section);
        }

        [Given(@"that a User has not provided any mandatory data for (.*)")]
        public void GivenThatAUserHasNotProvidedAnyMandatoryDataForSection(string section)
        {
            NavigateToBrowserBasedSubDashboard();
            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection(section);
        }

        [Given(@"the user has saved the data")]
        public void GivenTheUserHasSavedTheData()
        {
            test.Pages.Common.SectionSaveAndReturn();
            test.Pages.Common.ClickSubDashboardBackLink();
        }

        [Then(@"the (.*) section is marked as (COMPLETE|INCOMPLETE) on the Browser-based Client Type Sub-Form")]
        public void ThenTheSectionIsMarkedAsOnTheBrowserBasedClientTypeSub_Form(string section, string status)
        {
            test.Pages.Dashboard.AssertSectionStatus(section, status);
        }

        [Then(@"the Submission will trigger validation")]
        public void ThenTheSubmissionWillTriggerValidation()
        {
            test.Pages.Common.ErrorMessageDisplayed();
        }

        [Then(@"an indication is given to the (Supplier|User) as to why")]
        public void ThenAnIndicationIsGivenToTheSupplierAsToWhy(string user)
        {
            test.Pages.Common.ErrorMessageDisplayed();
        }

        [Then(@"the Supplier is shown (.*) error messages")]
        public void NumberOfErrorMessagesDisplayed(int numberOfExpectedErrorMessages)
        {
            test.Pages.Common.ErrorMessagesDisplayed(numberOfExpectedErrorMessages);
        }

        private void NavigateToBrowserBasedSubDashboard()
        {
            new SharedClientApplicationTypesSteps(test, context)
                .WhenHasNavigatedToTheSpecifiedClientApplicationSub_Form("Browser-based");
        }
    }
}
