using MarketingPageAcceptanceTests.Objects.Collections;
using MarketingPageAcceptanceTests.Objects.Pages;

namespace MarketingPageAcceptanceTests.Objects
{
    public sealed class PageObjects
    {
        public PageObjects()
        {
            Pages = new PageCollection
            {
                Dashboard = new Dashboard(),
                EditFeatures = new EditFeatures(),
                SolutionDescription = new SolutionDescription(),
                Common = new Common(),
                PreviewPage = new PreviewPage(),
                ClientApplicationTypes = new ClientApplicationTypes(),
                BrowserBasedDashboard = new BrowserBasedDashboard(),
                BrowserBasedSections = new BrowserBasedSections
                {
                    BrowsersSupported = new BrowsersSupported(),
                    PluginsOrExtensions = new PluginsOrExtensions(),
                    HardwareRequirements = new HardwareRequirements(),
                    ConnectivityAndResolution = new ConnectivityAndResolution(),
                    MobileFirst = new MobileFirst()
                },
                NativeMobileSections = new NativeMobileSections
                {
                    SupportedOperatingSystems = new SupportedOperatingSystems(),
                    MemoryAndStorage = new MemoryAndStorage(),
                    ThirdPartyComponentsAndDevices = new ThirdPartyComponentsAndDevices()
                },
                NativeDesktopSections = new NativeDesktopSections
                {
                    SupportedOperatingSystems = new SupportedOperatingSystems(),
                    MemoryAndStorage = new NativeDesktopMemoryStorage()
                },
                HostingTypeSections = new HostingTypeSections
                {
                    PublicCloud = new PublicCloud(),
                    PrivateCloud = new PrivateCloud()
                },
                AboutSupplier = new AboutSupplier(),
                ContactDetails = new ContactDetails(),
                Capabilities = new Capabilities()
            };
        }

        public PageCollection Pages { get; set; }
    }
}