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
                BrowserBasedSections = new BrowserBasedSections()
                {
                    BrowsersSupported = new Pages.BrowsersSupported(),
                    PluginsOrExtensions = new Pages.PluginsOrExtensions(),                    
                    HardwareRequirements = new Pages.HardwareRequirements(),
                    ConnectivityAndResolution = new Pages.ConnectivityAndResolution(),
                    MobileFirst = new Pages.MobileFirst(),
                },
                NativeMobileSections = new NativeMobileSections()
                {
                    SupportedOperatingSystems = new Pages.SupportedOperatingSystems(),
                    MemoryAndStorage = new Pages.MemoryAndStorage(),
                    ThirdPartyComponentsAndDevices = new Pages.ThirdPartyComponentsAndDevices()
                },
                NativeDesktopSections = new NativeDesktopSections()
                {
                    SupportedOperatingSystems = new Pages.SupportedOperatingSystems()
                },
                ContactDetails = new Pages.ContactDetails()
            };
        }

        public PageCollection Pages { get; set; }
    }
}
