using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public static class SolutionDescription
    {
        public static By Summary => By.Id("summary");

        public static By SummaryError => By.Id("summary-error");

        public static By Description => By.Id("description");

        public static By Link => By.Id("link");

        public static By SaveAndReturn => CustomBy.DataTestId("section-submit-button", "button[type=submit]");

        public static By DescriptionError => By.Id("description-error");

        public static By LinkError => By.Id("link-error");
    }
}