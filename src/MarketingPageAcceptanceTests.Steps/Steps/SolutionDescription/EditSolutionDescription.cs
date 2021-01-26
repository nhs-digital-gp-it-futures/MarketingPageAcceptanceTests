namespace MarketingPageAcceptanceTests.Steps
{
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class EditSolutionDescription : TestBase
    {
        public EditSolutionDescription(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"the Solution Description Section requires Mandatory Data")]
        public static void GivenTheSolutionDescriptionSectionRequiresMandatoryData()
        {
        }

        [Given(@"the Supplier has entered data into any field")]
        public void GivenTheSupplierHasEnteredDataIntoAnyField()
        {
            test.Pages.Dashboard.NavigateToSection("Solution description");
        }

        [Given(@"it does not exceed the maximum")]
        public void GivenItDoesNotExceedTheMaximum()
        {
            test.Pages.SolutionDescription.SummaryAddText(300);
            test.Pages.SolutionDescription.DescriptionAddText(1000);
            test.Pages.SolutionDescription.LinkAddText(1000);
        }

        [Given(@"it does exceed the maximum")]
        public void GivenItDoesExceedTheMaximum()
        {
            test.Pages.SolutionDescription.SummaryAddText(301);
            test.Pages.SolutionDescription.DescriptionAddText(1001);
            test.Pages.SolutionDescription.LinkAddText(1001);
        }

        [Given(@"the pre-populated data is not present")]
        public void GivenThePre_PopulatedDataIsNotPresent()
        {
            test.Solution.Summary = null;
            test.Solution.FullDescription = null;
            test.Solution.AboutUrl = null;
            test.Solution.Update(test.ConnectionString);
            test.Driver.Navigate().Refresh();
        }

        [Given(@"the Solution Description Section has completed data saved")]
        public void GivenTheSolutionDescriptionSectionHasCompletedDataSaved()
        {
            test.Pages.Dashboard.NavigateToSection("Solution description");
            test.Pages.SolutionDescription.SummaryAddText(10);
            test.Pages.SolutionDescription.DescriptionAddText(10);
            test.Pages.SolutionDescription.LinkAddText(10);
            test.Pages.SolutionDescription.SaveAndReturn();
            test.Pages.Dashboard.PageDisplayed();
            test.Pages.Dashboard.SectionCompleteStatus("Solution description");
        }

        [Given(@"that a Supplier has not provided a Summary Description")]
        public void GivenThatASupplierHasNotProvidedASummaryDescription()
        {
            GivenThePre_PopulatedDataIsNotPresent();
            test.Pages.Dashboard.NavigateToSection("Solution description");
        }

        [When(@"the Mandatory fields data is deleted")]
        public void WhenTheMandatoryFieldsDataIsDeleted()
        {
            test.Pages.Dashboard.NavigateToSection("Solution description");
            test.Pages.SolutionDescription.ClearMandatoryFields();
            test.Pages.SolutionDescription.SaveAndReturn();
            test.Pages.Dashboard.PageDisplayed();
        }

        [Then(@"the Solution Description Section is marked as Incomplete")]
        [Then(@"the status is set to INCOMPLETE")]
        public void ThenTheSolutionDescriptionSectionIsMarkedAsIncomplete()
        {
            test.Pages.Dashboard.SectionIncompleteStatus("Solution description");
        }

        [Then(@"the non mandatory data is saved to the database")]
        public void ThenTheNonMandatoryDataIsSavedToTheDatabase()
        {
            test.Pages.SolutionDescription.DbContainsDescription(test.Solution, test.ConnectionString).Should()
                .BeTrue();
            test.Pages.SolutionDescription.DbContainsLink(test.Solution, test.ConnectionString).Should()
                .BeTrue();
        }
    }
}
