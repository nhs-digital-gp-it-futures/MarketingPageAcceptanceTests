using MarketingPageAcceptanceTests.Objects.Collections;

namespace MarketingPageAcceptanceTests.Objects
{
    public sealed class PageObjects
    {
        public PageObjects()
        {
            Pages = new PageCollection
            {
                Dashboard = new Pages.Dashboard(),
                EditFeatures = new Pages.EditFeatures(),
                SolutionDescription = new Pages.SolutionDescription(),
                Common = new Pages.Common(),
                PreviewPage = new Pages.PreviewPage()
            };
        }

        public PageCollection Pages { get; set; }
    }
}
