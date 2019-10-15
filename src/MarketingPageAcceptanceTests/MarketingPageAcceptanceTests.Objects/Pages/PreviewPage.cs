using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class PreviewPage
    {
        /// <summary>
        /// contains Summary, About and Link section
        /// </summary>
        public By SolutionDescriptionContainer => CustomBy.DataTestId("preview-section-solution-description");
        public By SolutionDescriptionSummarySection => CustomBy.DataTestId("preview-section-question-summary");

        public By SolutionDescriptionAboutSection =>
            CustomBy.DataTestId("preview-section-question-description");

        public By SolutionDescriptionLinkSection => CustomBy.DataTestId("preview-section-question-link");

        public By SolutionDescriptionFeaturesSection =>
            CustomBy.DataTestId("preview-question-solution-description");

        public By SectionTitle => CustomBy.DataTestId("preview-question-title");

        public By SectionData => CustomBy.DataTestId("preview-question-data");
        public By FeaturesSection => CustomBy.DataTestId("preview-section-features");

        public By SubmitForModeration => By.CssSelector("a[role=button].nhsuk-button");
    }
}
