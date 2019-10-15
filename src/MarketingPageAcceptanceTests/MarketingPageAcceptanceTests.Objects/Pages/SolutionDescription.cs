using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class SolutionDescription
    {
        public By Summary => By.Id("solution-summary");

        public By SummaryError => By.Id("solution-summary-error");

        public By Description => By.Id("solution-description");

        public By Link => By.Id("solution-link");

        public By SaveAndReturn => By.CssSelector("button[type=submit]");

        public By ErrorSummaryLinks => By.CssSelector("ul.nhsuk-error-summary__list li a");

        public By DescriptionError => By.Id("solution-description-error");

        public By LinkError => By.Id("solution-link-error");
    }
}
