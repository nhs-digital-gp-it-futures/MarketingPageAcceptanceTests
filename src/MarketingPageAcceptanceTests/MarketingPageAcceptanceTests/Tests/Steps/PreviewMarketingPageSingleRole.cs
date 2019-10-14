using MarketingPageAcceptanceTests.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using FluentAssertions;
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

        public PreviewMarketingPageSingleRole(ITestOutputHelper helper) : base(helper)
        {
            pages.Dashboard.NavigateToSection("Solution description");
        }

        [Given("that Marketing Page data has been saved")]
        public void MarketingPageDataSaved()
        {
            summary = pages.SolutionDescription.SummaryAddText(300).TrimStart();
            description = pages.SolutionDescription.DescriptionAddText(1000).TrimStart(); 
            link = pages.SolutionDescription.LinkAddText(1000).TrimStart();
            pages.SolutionDescription.SaveAndReturn();
        }

        [When("the Catalogue User chooses to preview the Marketing Page")]
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
 
        [When("the User previews the Marketing Page")]
        public void CatalogueUserPreviewsMarketingPage()
        {
            throw new NotImplementedException();
        }
        
        [And("any saved data will be visible on the Marketing Page Preview")]
        public void SavedDataVisibleOnMarketingPagePreview()
        {
            throw new NotImplementedException();
        }

        [Given("that the Marketing Page has Mandatory Data")]
        public void MarketingPageMandatoryData()
        {
            throw new NotImplementedException();
        }        
        
        [Then("the Sections and the Mandatory Question are displayed on the preview regardless of whether any data has been added to the section")]
        public void SectionsAndMandatoryQuestionDisplayed()
        {
            throw new NotImplementedException();
        }

        [And("the Section and the Question for non-Mandatory data are displayed only if the User has saved data to the section")]
        public void SectionAndQuestionDisplayedOnlyIfUserSavedToSection()
        {
            throw new NotImplementedException();
        }

        [Given("that the Solution Description and Features section are the only sections completed")]
        public void SolutionDescriptionAndFeaturesCompleted()
        {
            throw new NotImplementedException();
        }

        [Then("the Solution Description and Features section are displayed on the preview")]
        public void SolutionDescriptionAndFeaturesDisplayedPreview()
        {
            throw new NotImplementedException();
        }
    }
}
