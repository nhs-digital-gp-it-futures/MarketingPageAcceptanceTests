using MarketingPageAcceptanceTests.Actions.Pages;

namespace MarketingPageAcceptanceTests.Actions.Collections
{
    public sealed class PageActionCollection
    {
        public Common Common { get; set; }
        public Dashboard Dashboard { get; set; }
        public EditFeatures EditFeatures { get; set; }
        public SolutionDescription SolutionDescription { get; set; }
        public PreviewPage PreviewPage { get; set; }
        public ClientApplicationTypes ClientApplicationTypes { get; set; }
        public BrowserBasedSections BrowserBasedSections { get; set; }
        public NativeMobileSections NativeMobileSections { get; set; }
        public NativeDesktopSections NativeDesktopSections { get; set; }
        public HostingTypeSections HostingTypeSections { get; set; }
        public AboutSupplier AboutSupplier { get; set; }
        public ContactDetails ContactDetails { get; set; }
    }

    public sealed class BrowserBasedSections
    {
        public BrowserSubDashboard BrowserSubDashboard { get; set; }
        public BrowsersSupported BrowsersSupported { get; set; }
        public PluginsOrExtensions PluginsOrExtensions { get; set; }
        public HardwareRequirements HardwareRequirements { get; set; }
        public ConnectivityAndResolution ConnectivityAndResolution { get; set; }
        public MobileFirst MobileFirst { get; set; }
    }

    public sealed class NativeMobileSections
    {   
        public NativeMobileOperatingSystems OperatingSystems { get; set; }
        public MemoryAndStorage MemoryAndStorage { get; set; }
    }

    public sealed class NativeDesktopSections
    {
        public NativeDesktopOperatingSystems OperatingSystems { get; set; }
        public NativeDesktopMemoryAndStorage MemoryAndStorage { get; set; }
    }

    public sealed class HostingTypeSections
    {
        public PublicCloud PublicCloud { get; set; }
        public PrivateCloud PrivateCloud { get; set; }
    }
}
