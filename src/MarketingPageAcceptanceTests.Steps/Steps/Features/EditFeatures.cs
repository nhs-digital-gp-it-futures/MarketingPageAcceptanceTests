using FluentAssertions;
using MarketingPageAcceptanceTests.StepSetup.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps
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
            _test.Pages.Dashboard.NavigateToSection("Features");
        }

        [Given(@"it does not exceed the maximum character count")]
        public void GivenItDoesNotExceedTheMaximumCharacterCount()
        {
            featureString = _test.Pages.EditFeatures.AddTextToFeature(50);
        }

        [Given(@"it does exceed the maximum character count")]
        public void GivenItDoesExceedTheMaximumCharacterCount()
        {
            featureString = _test.Pages.EditFeatures.AddTextToFeature(101);
        }

        [Given(@"the Features Section has no Mandatory Data")]
        public void GivenTheFeaturesSectionHasNoMandatoryData()
        {
            _test.Pages.Dashboard.NavigateToSection("Features");
            _test.Pages.EditFeatures.PageDisplayed();
        }

        [Given(@"a Supplier has saved any data on the Features Section")]
        public void GivenASupplierHasSavedAnyDataOnTheFeaturesSection()
        {
            GivenItDoesNotExceedTheMaximumCharacterCount();
            WhenTheSupplierAttemptsToSave();
            _test.Pages.Dashboard.PageDisplayed();
        }

        [Given(@"a Supplier has not saved any data on the Features Section")]
        public void GivenASupplierHasNotSavedAnyDataOnTheFeaturesSection()
        {
            _test.Pages.EditFeatures.ClearAllFields();
            _test.Pages.EditFeatures.ClickSaveAndReturn();
        }

        [When(@"the Supplier attempts to save")]
        public void WhenTheSupplierAttemptsToSave()
        {
            _test.Pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the (.*) is saved")]
        public void ThenTheSectionIsSaved(string section)
        {
            _test.Pages.Dashboard.PageDisplayed();
            _test.Pages.Dashboard.ShouldDisplaySections();
        }

        [Then(@"the database contains the Feature Text")]
        public void ThenTheDatabaseContainsTheFeatureText()
        {
            var features = _test.solutionDetail.Retrieve(_test.ConnectionString).Features;
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
            var features = _test.solutionDetail.Retrieve(_test.ConnectionString).Features;
            features.Should().NotContain(featureString);
        }

        [Then(@"the Features Section is marked as (Complete|Incomplete)")]
        public void ThenTheFeaturesSectionIsMarkedAsComplete(string status)
        {
            _test.Pages.Dashboard.AssertSectionStatus("Features", status.ToUpper());
        }
    }
}