using MarketingPageAcceptanceTests.Actions.Pages;

namespace MarketingPageAcceptanceTests.Actions.Collections
{
    public sealed class PageActionCollection
    {
        public Common Common { get; set; }
        public Dashboard Dashboard { get; set; }
        public EditFeatures EditFeatures { get; set; }
        public SolutionDescription SolutionDescription { get; internal set; }
        public PreviewPage PreviewPage { get; internal set; }
        public ClientApplicationTypes ClientApplicationTypes { get; set; }
        public BrowserSubDashboard BrowserSubDashboard { get; set; }
        public BrowsersSupported BrowsersSupported { get; set; }
        public PluginsOrExtensions PluginsOrExtensions { get; set; }
    }
}
