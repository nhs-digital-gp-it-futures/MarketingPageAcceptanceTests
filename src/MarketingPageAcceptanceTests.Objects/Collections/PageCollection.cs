using MarketingPageAcceptanceTests.Objects.Pages;

namespace MarketingPageAcceptanceTests.Objects.Collections
{
    public sealed class PageCollection
    {
        public Dashboard Dashboard { get; set; }
        public EditFeatures EditFeatures { get; set; }
        public Common Common { get; set; }
        public SolutionDescription SolutionDescription { get; set; }
        public PreviewPage PreviewPage { get; set; }
        public ClientApplicationTypes ClientApplicationTypes { get; set; }
        public BrowserBasedDashboard BrowserBasedDashboard { get; set; }
        public BrowsersSupported BrowsersSupported { get; set; }
        public PluginsOrExtensions PluginsOrExtensions { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public HardwareRequirements HardwareRequirements { get; set; }
        public ConnectivityAndResolution ConnectivityAndResolution { get; set; }
    }
}
