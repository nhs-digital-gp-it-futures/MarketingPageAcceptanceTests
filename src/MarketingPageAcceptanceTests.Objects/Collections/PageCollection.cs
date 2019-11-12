using MarketingPageAcceptanceTests.Objects.Pages;

namespace MarketingPageAcceptanceTests.Objects.Collections
{
    public sealed class PageCollection
    {
        public Dashboard Dashboard { get; internal set; }
        public EditFeatures EditFeatures { get; internal set; }
        public Common Common { get; internal set; }
        public SolutionDescription SolutionDescription { get; internal set; }
        public PreviewPage PreviewPage { get; internal set; }
        public ClientApplicationTypes ClientApplicationTypes { get; internal set; }
        public BrowserBasedDashboard BrowserBasedDashboard { get; set; }
        public BrowsersSupported BrowsersSupported { get; set; }
        public PluginsOrExtensions PluginsOrExtensions { get; set; }
    }
}
