using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
