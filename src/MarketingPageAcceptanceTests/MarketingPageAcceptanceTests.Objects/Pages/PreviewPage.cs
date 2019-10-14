using System;
using System.Collections.Generic;
using System.Text;
using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class PreviewPage
    {
        public By PageTitle => By.TagName("h1");

        public By PreviewSection => CustomBy.DataTestId("preview-section");

        public By SolutionDescriptionSummarySection => CustomBy.DataTestId("preview-section-question-solution-summary");

        public By SolutionDescriptionAboutSection =>
            CustomBy.DataTestId("preview-section-question-solution-description");

        public By SolutionDescriptionLinkSection => CustomBy.DataTestId("preview-section-question-solution-link");

        public By SolutionDescriptionFeaturesSection =>
            CustomBy.DataTestId("preview-section-question-solution-description");

        public By SectionTitle => CustomBy.DataTestId("preview-question-title");

        public By SectionData => CustomBy.DataTestId("preview-question-data");
        public By FeaturesSection => CustomBy.DataTestId("preview-section-features");
    }
}
