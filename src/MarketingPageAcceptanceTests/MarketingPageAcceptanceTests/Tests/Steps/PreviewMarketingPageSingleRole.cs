using MarketingPageAcceptanceTests.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile("./Tests/Gherkin/PreviewMarketingPageSingleRole.txt")]
    public sealed class PreviewMarketingPageSingleRole : UITest, IDisposable
    {
        public PreviewMarketingPageSingleRole(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that Marketing Page data has been saved")]
        public void MarketingPageDataSaved()
        {
            pages.SolutionDescription.SummaryAddText(300);
            pages.SolutionDescription.DescriptionAddText(1000);
            pages.SolutionDescription.LinkAddText(1000);
        }

        [When("the Catalogue User chooses to preview the Marketing Page")]
        public void MarketingPageVisited()
        {
           pages.Dashboard.NavigateToPreviewPage();
        }
        [When("a User previews the Marketing Page")]
        [When("the User previews the Marketing Page")]
        public void CatalogueUserPreviewsMarketingPage()
        {
            throw new NotImplementedException();
        }

        [Then("the Marketing Page Preview is displayed")]
        public void MarketingPagePreviewDisplayed() 
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
