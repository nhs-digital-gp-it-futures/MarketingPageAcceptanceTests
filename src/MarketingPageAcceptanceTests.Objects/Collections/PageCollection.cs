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
        public BrowserBasedSections BrowserBasedSections { get; set; }
        public NativeMobileSections NativeMobileSections { get; set; }

        public ContactDetails ContactDetails { get; set; }
    }

    public sealed class BrowserBasedSections
    {
        public BrowsersSupported BrowsersSupported { get; set; }
        public PluginsOrExtensions PluginsOrExtensions { get; set; }
        public HardwareRequirements HardwareRequirements { get; set; }
        public ConnectivityAndResolution ConnectivityAndResolution { get; set; }
        public MobileFirst MobileFirst { get; set; }
    }

    public sealed class NativeMobileSections
    {

        public SupportedOperatingSystems SupportedOperatingSystems { get; set; }
    }
}
