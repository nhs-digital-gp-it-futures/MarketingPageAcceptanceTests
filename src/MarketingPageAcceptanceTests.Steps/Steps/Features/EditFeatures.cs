namespace MarketingPageAcceptanceTests.Steps
{
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class EditFeatures : TestBase
    {
        private string featureString;

        public EditFeatures(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"the Supplier has entered a Feature")]
        public void GivenTheSupplierHasEnteredAFeature()
        {
            test.Pages.Dashboard.NavigateToSection("Features");
        }

        [Given(@"it does not exceed the maximum character count")]
        public void GivenItDoesNotExceedTheMaximumCharacterCount()
        {
            featureString = test.Pages.EditFeatures.AddTextToFeature(50);
        }

        [Given(@"it does exceed the maximum character count")]
        public void GivenItDoesExceedTheMaximumCharacterCount()
        {
            featureString = test.Pages.EditFeatures.AddTextToFeature(101);
        }

        [Given(@"the Features Section has no Mandatory Data")]
        public void GivenTheFeaturesSectionHasNoMandatoryData()
        {
            test.Pages.Dashboard.NavigateToSection("Features");
            test.Pages.EditFeatures.PageDisplayed();
        }

        [Given(@"a Supplier has saved any data on the Features Section")]
        public void GivenASupplierHasSavedAnyDataOnTheFeaturesSection()
        {
            GivenItDoesNotExceedTheMaximumCharacterCount();
            WhenTheSupplierAttemptsToSave();
            test.Pages.Dashboard.PageDisplayed();
        }

        [Given(@"a Supplier has not saved any data on the Features Section")]
        public void GivenASupplierHasNotSavedAnyDataOnTheFeaturesSection()
        {
            test.Pages.EditFeatures.ClearAllFields();
            test.Pages.EditFeatures.ClickSaveAndReturn();
        }

        [When(@"the Supplier attempts to save")]
        public void WhenTheSupplierAttemptsToSave()
        {
            test.Pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the (.*) is saved")]
        public void ThenTheSectionIsSaved(string section)
        {
            test.Pages.Dashboard.PageDisplayed();
            test.Pages.Dashboard.ShouldDisplaySections();
        }

        [Then(@"the database contains the Feature Text")]
        public void ThenTheDatabaseContainsTheFeatureText()
        {
            var features = test.Solution.Retrieve(test.ConnectionString).Features;
            features.Should().Contain(featureString);
        }

        [Then(@"the database does not contain the Feature Text")]
        public void ThenTheDatabaseDoesNotContainTheFeatureText()
        {
            var features = test.Solution.Retrieve(test.ConnectionString).Features;
            features.Should().NotContain(featureString);
        }

        [Then(@"the Features Section is marked as (Complete|Incomplete)")]
        public void ThenTheFeaturesSectionIsMarkedAsComplete(string status)
        {
            test.Pages.Dashboard.AssertSectionStatus("Features", status.ToUpper());
        }
    }
}
