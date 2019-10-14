using FluentAssertions;
using MarketingPageAcceptanceTests.Actions.Utils;
using MarketingPageAcceptanceTests.Utils;
using System;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile("./Tests/Gherkin/EditFeatures.txt")]
    public sealed class EditFeatures : UITest, IDisposable
    {
        string featureString = "";

        public EditFeatures(ITestOutputHelper helper) : base(helper)
        {

        }

        [Given("the Supplier has entered a Feature")]
        public void SupplierEnteredFeature()
        {
            pages.Dashboard.NavigateToSection("Features");
        }

        [And("it does not exceed the maximum character count")]
        public void DoesNotExceedCharacterCount()
        {
            featureString = pages.EditFeatures.AddTextToFeature(50);
        }

        [And("it does exceed the maximum character count")]
        public void DoesExceedCharacterCount()
        {
            featureString = pages.EditFeatures.AddTextToFeature(101);
        }

        [When("the Supplier attempts to save")]
        public void SupplierSaves()
        {
            pages.EditFeatures.ClickSaveAndReturn();
        }

        [Then("the Section is saved")]
        public void SectionSaved()
        {
            pages.Dashboard.ShouldDisplaySections();
            pages.Dashboard.SectionCompleteStatus("Features");
        }

        [Then("the Section is not saved")]
        public void SectionNotSaved()
        {
        }

        [And("an indication is given to the Supplier as to why")]
        public void NotSavedNotification()
        {
            pages.EditFeatures.ErrorMessageDisplayed();
        }

        [Given("the Features Section has no Mandatory Data")]
        public void FeaturesSectionNoMandatoryData()
        {
            pages.Dashboard.NavigateToSection("Features");
            pages.EditFeatures.PageDisplayed();
        }

        [And("a Supplier has saved any data on the Features Section")]
        public void ExistingDataSaved()
        {
            DoesNotExceedCharacterCount();
            SupplierSaves();
            pages.Dashboard.PageDisplayed();
        }

        [Then("the Features Section is marked as Complete")]
        public void FeaturesSectionMarkedComplete()
        {
            pages.Dashboard.SectionCompleteStatus("Features");
        }

        [And("a Supplier has not saved any data on the Features Section")]
        public void NoExistingDataSaved()
        {
            pages.EditFeatures.ClearAllFields();
            pages.EditFeatures.ClickSaveAndReturn();
        }

        [Then("the Features Section is marked as Incomplete")]
        public void FeaturesSectionMarkedIncomplete()
        {
            pages.Dashboard.SectionIncomplete("Features");
        }

        [And("the database contains the Feature Text")]
        public void AssertFeatureInDb()
        {
            var features = SqlHelper.GetSolutionFeatures(solutionId, connectionString);
            features.Should().Contain(featureString);
        }

        [And("the database does not contain the Feature Text")]
        public void AssertFeatureNotInDb()
        {
            var features = SqlHelper.GetSolutionFeatures(solutionId, connectionString);
            features.Should().NotContain(featureString);
        }
    }
}
