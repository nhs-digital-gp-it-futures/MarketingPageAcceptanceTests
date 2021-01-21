using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public static class PreviewPage
    {
        /// <summary>
        ///     contains Summary, About and Link section
        /// </summary>
        public static By SolutionDescriptionContainer => CustomBy.DataTestId("preview-solution-description");

        public static By SolutionDescriptionSummarySection => CustomBy.DataTestId("preview-section-question-summary");

        public static By SolutionDescriptionAboutSection =>
            CustomBy.DataTestId("preview-section-question-description");

        public static By SolutionDescriptionLinkSection => CustomBy.DataTestId("preview-section-question-link");
        public static By SectionTitle => CustomBy.DataTestId("preview-question-title");
        public static By SectionDataText => CustomBy.DataTestId("preview-question-data-text");
        public static By SectionDataLink => CustomBy.DataTestId("preview-question-data-link");
        public static By FeaturesSection => CustomBy.DataTestId("preview-features");
        public static By BrowserBasedSection => CustomBy.DataTestId("view-section-browser-based", "span");

        public static By PageTitle => CustomBy.DataTestId("view-solution-page-solution-name");
        public static By BrowserBasedSectionTitles => CustomBy.DataTestId("view-section-table-row-title");

        public static By SupportedBrowsers =>
            CustomBy.DataTestId("preview-section-table-row-supported-browsers", "li > label");

        public static By RequiresHscn => CustomBy.DataTestId("view-question-data-text-requires-hscn");

        public static By ContactName => CustomBy.DataTestId("view-question-data-text-contact-name");
        public static By ContactDepartment => CustomBy.DataTestId("view-question-data-text-department-name");
        public static By ContactEmail => CustomBy.DataTestId("view-question-data-text-email-address");
        public static By ContactPhoneNumber => CustomBy.DataTestId("view-question-data-text-phone-number");

        public static By ConnectivityRequirement => CustomBy.DataTestId("view-question-data-text-minimum-connection-speed");

        public static By DesktopResolutionRequirement =>
            CustomBy.DataTestId("view-question-data-text-minimum-desktop-resolution");

        public static By ExpandingSections => By.CssSelector("details.nhsuk-details");
        public static By PreviewHeaders => By.TagName("h3");
        public static By PreviewHeadersSectionContainer => By.CssSelector("div.nhsuk-width-container");
        public static By AboutSupplierDescription => CustomBy.DataTestId("view-question-data-text-description");
        public static By AboutSupplierUrl => CustomBy.DataTestId("view-question-data-link");

        public static By DownloadNHSAssuredIntegrationsDocumentLink =>
            CustomBy.DataTestId("view-question-data-text-link-authority-integrations", "a");

        public static By DownloadRoadmapDocumentLink => CustomBy.DataTestId("view-question-data-link-document-link", "a");

        public static By DownloadAuthorityProvidedDataDocumentLink =>
            CustomBy.DataTestId("view-section-question-document-link", "a");

        public static By CapabilityAccordian => By.ClassName("nhsuk-details__summary-text");
        public static By Capabilities => CustomBy.DataTestId("view-section-capabilities", "summary");

        public static By EpicTitles => By.CssSelector(".bc-c-epic-list li span");

        public static By CapabilityEpicsMaySection => CustomBy.DataTestId("may-tag");
        public static By CapabilityEpicsMustSection => CustomBy.DataTestId("must-tag");
        public static By CapabilityEpicsStatusSymbol => By.CssSelector(".bc-c-epic-list svg");
    }
}
