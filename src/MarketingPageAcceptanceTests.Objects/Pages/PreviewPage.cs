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
        public By BrowserBasedSection => CustomBy.DataTestId("preview-section-browser-based", "span");

        public By PageTitle => By.CssSelector("div.nhsuk-grid-column-full h1");

        public By SupportedBrowsers => CustomBy.DataTestId("preview-section-table-row-supported-browsers", "li > label");
    }
}
