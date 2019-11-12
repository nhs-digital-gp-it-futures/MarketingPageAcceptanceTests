using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class SolutionDescription
    {
        public By Summary => By.Id("summary");

        public By SummaryError => By.Id("summary-error");

        public By Description => By.Id("description");

        public By Link => By.Id("link");

        public By SaveAndReturn => CustomBy.DataTestId("section-submit-button", "button[type=submit]");

        public By DescriptionError => By.Id("description-error");

        public By LinkError => By.Id("link-error");
    }
}
