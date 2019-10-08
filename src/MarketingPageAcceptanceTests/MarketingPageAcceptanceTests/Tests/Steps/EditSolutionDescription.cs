﻿using FluentAssertions;
using MarketingPageAcceptanceTests.Utils;
using System;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile(@".\Tests\Gherkin\EditSolutionDescription.txt")]
    public sealed class EditSolutionDescription : UITest, IDisposable
    {
        public EditSolutionDescription(ITestOutputHelper helper) : base(helper)
        {
            pages.Dashboard.NavigateToSection("Solution description");
        }

        [Given("the Supplier has entered data into any field")]
        public void SupplierEnteredDataAnyField()
        {
        }

        [And("it does not exceed the maximum")]
        public void DoesNotExceedMaximum()
        {
            pages.SolutionDescription.SummaryAddText(10);
            pages.SolutionDescription.DescriptionAddText(10);
            pages.SolutionDescription.LinkAddText(10);
        }

        [And("it does exceed the maximum")]
        public void DoesExceedMaximum()
        {
            pages.SolutionDescription.SummaryAddText(11);
            pages.SolutionDescription.DescriptionAddText(11);
            pages.SolutionDescription.LinkAddText(11);
        }

        [When("the Supplier attempts to save")]
        public void SupplierAttemptsSave()
        {
            pages.SolutionDescription.SaveAndReturn();
        }

        [Then("the Section is saved")]
        public void SectionSaved()
        {
            pages.Dashboard.PageDisplayed();
            pages.Dashboard.SectionCompleteStatus("Solution description");
            pages.SolutionDescription.DbContainsSummary(solutionId, connectionString).Should().BeTrue();
            pages.SolutionDescription.DbContainsDescription(solutionId, connectionString).Should().BeTrue();
            pages.SolutionDescription.DbContainsLink(solutionId, connectionString).Should().BeTrue();
        }

        [Then("the Section is not saved")]
        public void SectionNotSaved()
        {
            pages.SolutionDescription.PageDisplayed();
            pages.SolutionDescription.DbContainsSummary(solutionId, connectionString).Should().BeFalse();
            pages.SolutionDescription.DbContainsDescription(solutionId, connectionString).Should().BeFalse();
            pages.SolutionDescription.DbContainsLink(solutionId, connectionString).Should().BeFalse();
        }

        [And("an indication is given to the Supplier as to why")]
        public void IndicationNotSaved()
        {
            pages.SolutionDescription.SummaryErrorDisplayed().Should().BeTrue();
        }

        [Given("the Solution Description Section requires Mandatory Data")]
        public void SolutionDescriptionSectionRequiresMandatoryData()
        {            
        }

        [And("the pre-populated data is not present")]
        public void PrePopulatedDataNotPresent()
        {
            pages.SolutionDescription.ClearAllFields();
            SupplierAttemptsSave();
        }

        [Then("the Solution Description Section is marked as Incomplete")]
        public void SolutionDescriptionMarkedIncomplete()
        {
            pages.Dashboard.SectionIncomplete("Solution description");
        }

        [Given("validation has been triggered")]
        public void ValidationHasBeenTriggered()
        {
            DoesExceedMaximum();
            SupplierAttemptsSave();
        }

        [When("the User selects an error link in the Error Summary")]
        public void UserSelectsErrorLink()
        {
            pages.SolutionDescription.ClickValidationMessage();
        }

        [Then("the User will be navigated to the relevant section on the page")]
        public void UserNavigatedToRelevantSection()
        {
            pages.SolutionDescription.UrlContainsValidationLinkDetails();
        }
    }
}
