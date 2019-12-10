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
                PreviewPage = new Pages.PreviewPage(),
                ClientApplicationTypes = new Pages.ClientApplicationTypes(),
                BrowserBasedDashboard = new Pages.BrowserBasedDashboard(),
                BrowsersSupported = new Pages.BrowsersSupported(),
                PluginsOrExtensions = new Pages.PluginsOrExtensions(),
                ContactDetails = new Pages.ContactDetails(),
                ConnectivityAndResolution = new Pages.ConnectivityAndResolution()
            };
        }

        public PageCollection Pages { get; set; }
    }
}
