using FluentAssertions;
using MarketingPageAcceptanceTests.StepSetup.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps
{
    [Binding]
    public class EditSolutionDescription : TestBase
    {
        public EditSolutionDescription(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"the Supplier has entered data into any field")]
        public void GivenTheSupplierHasEnteredDataIntoAnyField()
        {
            _test.Pages.Dashboard.NavigateToSection("Solution description");
        }

        [Given(@"it does not exceed the maximum")]
        public void GivenItDoesNotExceedTheMaximum()
        {
            _test.Pages.SolutionDescription.SummaryAddText(300);
            _test.Pages.SolutionDescription.DescriptionAddText(1000);
            _test.Pages.SolutionDescription.LinkAddText(1000);
        }

        [Given(@"it does exceed the maximum")]
        public void GivenItDoesExceedTheMaximum()
        {
            _test.Pages.SolutionDescription.SummaryAddText(301);
            _test.Pages.SolutionDescription.DescriptionAddText(1001);
            _test.Pages.SolutionDescription.LinkAddText(1001);
        }

        [Given(@"the Solution Description Section requires Mandatory Data")]
        public void GivenTheSolutionDescriptionSectionRequiresMandatoryData()
        {
        }

        [Given(@"the pre-populated data is not present")]
        public void GivenThePre_PopulatedDataIsNotPresent()
        {
            _test.solution.Summary = null;
            _test.solution.FullDescription = null;
            _test.solution.AboutUrl = null;
            _test.solution.Update(_test.ConnectionString);
            _test.Driver.Navigate().Refresh();
        }

        [Given(@"the Solution Description Section has completed data saved")]
        public void GivenTheSolutionDescriptionSectionHasCompletedDataSaved()
        {
            _test.Pages.Dashboard.NavigateToSection("Solution description");
            _test.Pages.SolutionDescription.SummaryAddText(10);
            _test.Pages.SolutionDescription.DescriptionAddText(10);
            _test.Pages.SolutionDescription.LinkAddText(10);
            _test.Pages.SolutionDescription.SaveAndReturn();
            _test.Pages.Dashboard.PageDisplayed();
            _test.Pages.Dashboard.SectionCompleteStatus("Solution description");
        }

        [Given(@"that a Supplier has not provided a Summary Description")]
        public void GivenThatASupplierHasNotProvidedASummaryDescription()
        {
            _test.Pages.Dashboard.NavigateToSection("Solution description");
        }

        [When(@"the Mandatory fields data is deleted")]
        public void WhenTheMandatoryFieldsDataIsDeleted()
        {
            _test.Pages.Dashboard.NavigateToSection("Solution description");
            _test.Pages.SolutionDescription.ClearMandatoryFields();
            _test.Pages.SolutionDescription.SaveAndReturn();
            _test.Pages.Dashboard.PageDisplayed();
        }

        [Then(@"the Solution Description Section is marked as Incomplete")]
        [Then(@"the status is set to INCOMPLETE")]
        public void ThenTheSolutionDescriptionSectionIsMarkedAsIncomplete()
        {
            _test.Pages.Dashboard.SectionIncompleteStatus("Solution description");
        }

        [Then(@"the non mandatory data is saved to the database")]
        public void ThenTheNonMandatoryDataIsSavedToTheDatabase()
        {
            _test.Pages.SolutionDescription.DbContainsDescription(_test.solution, _test.ConnectionString).Should()
                .BeTrue();
            _test.Pages.SolutionDescription.DbContainsLink(_test.solution, _test.ConnectionString).Should()
                .BeTrue();
        }

        [Then(@"the Section is not saved because it is mandatory")]
        public void ThenTheSectionIsNotSavedBecauseItIsMandatory()
        {
        }
    }
}