using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class PreviewPage
    {
        /// <summary>
        /// contains Summary, About and Link section
        /// </summary>
        public By SolutionDescriptionContainer => CustomBy.DataTestId("preview-solution-description");
        public By SolutionDescriptionSummarySection => CustomBy.DataTestId("preview-section-question-summary");
        public By SolutionDescriptionAboutSection =>
            CustomBy.DataTestId("preview-section-question-description");
        public By SolutionDescriptionLinkSection => CustomBy.DataTestId("preview-section-question-link");
        public By SectionTitle => CustomBy.DataTestId("preview-question-title");
        public By SectionDataText => CustomBy.DataTestId("preview-question-data-text");
        public By SectionDataLink => CustomBy.DataTestId("preview-question-data-link");
        public By FeaturesSection => CustomBy.DataTestId("preview-features");
        public By SubmitForModeration => CustomBy.DataTestId("preview-submit-button", "a");
        public By ErrorMessages =>
            By.CssSelector("ul.nhsuk-list.nhsuk-error-summary__list li a");
    }
}
