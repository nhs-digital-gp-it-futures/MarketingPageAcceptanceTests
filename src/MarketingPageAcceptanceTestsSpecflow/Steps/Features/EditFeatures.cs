using FluentAssertions;
using MarketingPageAcceptanceTests.TestData.Utils;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow
{
    [Binding]
    public class EditFeatures : TestBase
    {
        private string featureString;

        public EditFeatures(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"the Supplier has entered a Feature")]
        public void GivenTheSupplierHasEnteredAFeature()
        {
            _test.pages.Dashboard.NavigateToSection("Features");
        }

        [Given(@"it does not exceed the maximum character count")]
        public void GivenItDoesNotExceedTheMaximumCharacterCount()
        {
            featureString = _test.pages.EditFeatures.AddTextToFeature(50);
        }

        [Given(@"it does exceed the maximum character count")]
        public void GivenItDoesExceedTheMaximumCharacterCount()
        {
            featureString = _test.pages.EditFeatures.AddTextToFeature(101);
        }

        [Given(@"the Features Section has no Mandatory Data")]
        public void GivenTheFeaturesSectionHasNoMandatoryData()
        {
            _test.pages.Dashboard.NavigateToSection("Features");
            _test.pages.EditFeatures.PageDisplayed();
        }

        [Given(@"a Supplier has saved any data on the Features Section")]
        public void GivenASupplierHasSavedAnyDataOnTheFeaturesSection()
        {
            GivenItDoesNotExceedTheMaximumCharacterCount();
            WhenTheSupplierAttemptsToSave();
            _test.pages.Dashboard.PageDisplayed();
        }

        [Given(@"a Supplier has not saved any data on the Features Section")]
        public void GivenASupplierHasNotSavedAnyDataOnTheFeaturesSection()
        {
            _test.pages.EditFeatures.ClearAllFields();
            _test.pages.EditFeatures.ClickSaveAndReturn();
        }

        [When(@"the Supplier attempts to save")]
        public void WhenTheSupplierAttemptsToSave()
        {
            _test.pages.EditFeatures.ClickSaveAndReturn();
        }

        [Then(@"the (.*) is saved")]
        public void ThenTheSectionIsSaved(string section)
        {
            _test.pages.Dashboard.PageDisplayed();
            _test.pages.Dashboard.ShouldDisplaySections();
            _test.pages.Dashboard.SectionCompleteStatus(section);
        }

        [Then(@"the database contains the Feature Text")]
        public void ThenTheDatabaseContainsTheFeatureText()
        {
            var features = SqlHelper.GetSolutionFeatures(_test.solution.Id, _test.connectionString);
            features.Should().Contain(featureString);
        }

        [Then(@"the Section is not saved")]
        public void ThenTheSectionIsNotSaved()
        {
        }

        [Then(@"the User is provided with a validation error message")]
        public void ThenTheUserIsProvidedWithAValidationErrorMessage()
        {
            _context.Pending();
        }

        [Then(@"the database does not contain the Feature Text")]
        public void ThenTheDatabaseDoesNotContainTheFeatureText()
        {
            var features = SqlHelper.GetSolutionFeatures(_test.solution.Id, _test.connectionString);
            features.Should().NotContain(featureString);
        }

        [Then(@"the Features Section is marked as (Complete|Incomplete)")]
        public void ThenTheFeaturesSectionIsMarkedAsComplete(string status)
        {
            _test.pages.Dashboard.AssertSectionStatus("Features", status.ToUpper());
        }
    }
}
