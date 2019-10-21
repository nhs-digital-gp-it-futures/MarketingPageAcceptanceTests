﻿using FluentAssertions;
using MarketingPageAcceptanceTests.Utils;
using System;
using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile("./Tests/Gherkin/PreviewMarketingPageSingleRole.txt")]
    public sealed class PreviewMarketingPageSingleRole : UITest, IDisposable
    {
        private string summary = String.Empty;
        private string description = String.Empty;
        private string link = String.Empty;
        private string featureString = String.Empty;
        private readonly string absoluteURLLink = "https://www.google.com";

        private IEnumerable<string> windowHandles;

        public PreviewMarketingPageSingleRole(ITestOutputHelper helper) : base(helper)
        {
            pages.Dashboard.ConstructSectionToNumFieldsMapping();
        }

        [Given("that Marketing Page data has been saved")]
        public void MarketingPageDataSaved()
        {
            pages.Dashboard.NavigateToSection("Solution description");
            summary = pages.SolutionDescription.SummaryAddText(300).TrimStart();
            description = pages.SolutionDescription.DescriptionAddText(1000).TrimStart();
            link = pages.SolutionDescription.LinkAddText(1000).TrimStart();
            pages.SolutionDescription.SaveAndReturn();
        }

        [When("the Catalogue User chooses to preview the Marketing Page")]
        [When("the User previews the Marketing Page")]
        [When("a User previews the Marketing Page")]
        public void MarketingPageVisited()
        {
            pages.Dashboard.NavigateToPreviewPage();
        }

        [Then("the Marketing Page Preview is displayed")]
        public void MarketingPageDisplayed()
        {
            pages.PreviewPage.PageDisplayed();
        }

        [And("any saved data will be visible on the Marketing Page Preview")]
        public void SavedDataVisible()
        {
            this.summary.Should().BeEquivalentTo(pages.PreviewPage.GetSolutionSummaryText());
            this.description.Should().BeEquivalentTo(pages.PreviewPage.GetSolutionAboutText());
            this.link.Should().BeEquivalentTo(pages.PreviewPage.GetSolutionLinkText());
        }

        [Given("that the Marketing Page has Mandatory Data")]
        public void MarketingPageMandatoryData()
        {
            pages.Dashboard.SectionNameToNumOfMandatoryFields.Count.Should().BeGreaterThan(0);
        }
        /// <summary>
        /// Will pass if "Solution description" and "Summary" is present atm,
        /// hopefully this will be replaced with something more dynamic in the future.
        /// </summary>
        [Then("the Sections and the Mandatory Question are displayed on the preview regardless of whether any data has been added to the section")]
        public void SectionsAndMandatoryQuestionDisplayed()
        {
            var items = pages.Dashboard.SectionNameToNumOfMandatoryFields;
            foreach (var item in items)
            {
                pages.PreviewPage.AssertSectionHasMandatoryFields(item.Key, item.Value);
            }
        }

        [And("the Section and the Question for non-Mandatory data are displayed only if the User has saved data to the section")]
        public void SectionAndQuestionDisplayedOnlyIfUserSavedToSection()
        {
            // go back to dashboard and make sure the page loaded.
            pages.Common.GoBackOnePage();
            pages.Dashboard.PageDisplayed();
            pages.Dashboard.NavigateToSection("Solution description");
            var linkText = pages.SolutionDescription.LinkAddText(50).TrimStart();
            pages.SolutionDescription.SaveAndReturn();
            pages.Dashboard.NavigateToPreviewPage();
            pages.PreviewPage.GetSolutionLinkText().Should().BeEquivalentTo(linkText);
        }

        [Given("that the Solution Description and Features section are the only sections completed")]
        public void SolutionDescriptionAndFeaturesCompleted()
        {
            // Solution Description section
            MarketingPageDataSaved();

            // Features Section
            pages.Dashboard.NavigateToSection("Features");
            pages.EditFeatures.PageDisplayed();
            featureString = pages.EditFeatures.AddTextToFeature(50);
            pages.EditFeatures.ClickSaveAndReturn();
            pages.Dashboard.PageDisplayed();
        }

        [Then("the Solution Description and Features section are displayed on the preview")]
        public void SolutionDescriptionAndFeaturesDisplayedPreview()
        {
            // Solution description sections
            SavedDataVisible();

            // Features Section
            pages.PreviewPage.GetFeaturesText().Should().Contain(featureString);
        }

        [Given("that the user enters an absolute path URL in the link field on the solution description page")]
        public void UserEntersAbsolutePathURL()
        {
            pages.Dashboard.NavigateToSection("Solution description");
            pages.SolutionDescription.LinkAddText(0, absoluteURLLink);
            pages.SolutionDescription.SaveAndReturn();
        }

        [And("clicks the About URL on the Preview Page")]
        public void UserClicksAboutUrlInPreview()
        {
            windowHandles = pages.Common.GetWindowHandles();

            pages.PreviewPage.GetSolutionLink().Click();            
        }

        [Then("a new browser window is opened with the correct URL")]
        public void NewBrowserWindowIsOpenedWithCorrectURL()
        {
            pages.Common.DidWindowOpenWithCorrectUrl(absoluteURLLink, windowHandles).Should().BeTrue();
        }
    }
}