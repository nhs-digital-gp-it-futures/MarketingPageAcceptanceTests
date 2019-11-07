using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow
{
    [Binding]
    public class EditSolutionDescription
    {

        private UITest _test;
        private ScenarioContext _context;

        public EditSolutionDescription(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"the Supplier has entered data into any field")]
        public void GivenTheSupplierHasEnteredDataIntoAnyField()
        {
            _test.pages.Dashboard.NavigateToSection("Solution description");
        }

        [Given(@"it does not exceed the maximum")]
        public void GivenItDoesNotExceedTheMaximum()
        {
            _test.pages.SolutionDescription.SummaryAddText(300);
            _test.pages.SolutionDescription.DescriptionAddText(1000);
            _test.pages.SolutionDescription.LinkAddText(1000);
        }

        [Given(@"it does exceed the maximum")]
        public void GivenItDoesExceedTheMaximum()
        {
            _test.pages.SolutionDescription.SummaryAddText(301);
            _test.pages.SolutionDescription.DescriptionAddText(1001);
            _test.pages.SolutionDescription.LinkAddText(1001);
        }

        [Given(@"the Solution Description Section requires Mandatory Data")]
        public void GivenTheSolutionDescriptionSectionRequiresMandatoryData()
        {
        }

        [Given(@"the pre-populated data is not present")]
        public void GivenThePre_PopulatedDataIsNotPresent()
        {
        }

        [Given(@"the Solution Description Section has completed data saved")]
        public void GivenTheSolutionDescriptionSectionHasCompletedDataSaved()
        {
            _test.pages.Dashboard.NavigateToSection("Solution description");
            _test.pages.SolutionDescription.SummaryAddText(10);
            _test.pages.SolutionDescription.DescriptionAddText(10);
            _test.pages.SolutionDescription.LinkAddText(10);
            _test.pages.SolutionDescription.SaveAndReturn();
            _test.pages.Dashboard.PageDisplayed();
            _test.pages.Dashboard.SectionCompleteStatus("Solution description");
        }

        [Given(@"that a Supplier has not provided a Summary Description")]
        public void GivenThatASupplierHasNotProvidedASummaryDescription()
        {
            _test.pages.Dashboard.NavigateToSection("Solution description");
        }

        [Given(@"validation has been triggered on Solution description")]
        public void GivenValidationHasBeenTriggeredOnSolutionDescription()
        {
            _test.pages.Dashboard.NavigateToSection("Solution description");
            _test.pages.SolutionDescription.ClearAllFields();
            _test.pages.SolutionDescription.SaveAndReturn();
            _test.pages.Common.ErrorMessageDisplayed();
        }

        [When(@"the Mandatory fields data is deleted")]
        public void WhenTheMandatoryFieldsDataIsDeleted()
        {
            _test.pages.Dashboard.NavigateToSection("Solution description");
            _test.pages.SolutionDescription.ClearMandatoryFields();
            _test.pages.SolutionDescription.SaveAndReturn();
            _test.pages.Dashboard.PageDisplayed();
        }

        [Then(@"the Solution Description Section is marked as Incomplete")]
        [Then(@"the status is set to INCOMPLETE")]
        public void ThenTheSolutionDescriptionSectionIsMarkedAsIncomplete()
        {
            _test.pages.Dashboard.SectionIncomplete("Solution description");
        }

        [Then(@"the non mandatory data is saved to the database")]
        public void ThenTheNonMandatoryDataIsSavedToTheDatabase()
        {
            _test.pages.SolutionDescription.DbContainsDescription(_test.solution.Id, _test.connectionString);
            _test.pages.SolutionDescription.DbContainsLink(_test.solution.Id, _test.connectionString);
        }

        [Then(@"the Section is not saved because it is mandatory")]
        public void ThenTheSectionIsNotSavedBecauseItIsMandatory()
        {
        }
    }
}
