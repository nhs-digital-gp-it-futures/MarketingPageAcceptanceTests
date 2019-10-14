﻿using System;
using System.Collections.Generic;
using System.Text;
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
