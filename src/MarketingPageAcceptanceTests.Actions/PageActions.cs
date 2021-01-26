namespace MarketingPageAcceptanceTests.Actions
{
    using MarketingPageAcceptanceTests.Actions.Collections;
    using MarketingPageAcceptanceTests.Actions.Pages;
    using OpenQA.Selenium;

    public sealed class PageActions
    {
        public PageActions(IWebDriver driver)
        {
            PageActionCollection = new PageActionCollection
            {
                Common = new Common(driver),
                Dashboard = new Dashboard(driver),
                EditFeatures = new EditFeatures(driver),
                SolutionDescription = new SolutionDescription(driver),
                PreviewPage = new PreviewPage(driver),
                ClientApplicationTypes = new ClientApplicationTypes(driver),
                BrowserBasedSections = new BrowserBasedSections
                {
                    BrowserSubDashboard = new BrowserSubDashboard(driver),
                    BrowsersSupported = new BrowsersSupported(driver),
                    PluginsOrExtensions = new PluginsOrExtensions(driver),
                    HardwareRequirements = new HardwareRequirements(driver),
                    ConnectivityAndResolution = new ConnectivityAndResolution(driver),
                    MobileFirst = new MobileFirst(driver),
                },
                NativeMobileSections = new NativeMobileSections
                {
                    OperatingSystems = new NativeMobileOperatingSystems(driver),
                    MemoryAndStorage = new MemoryAndStorage(driver),
                },
                NativeDesktopSections = new NativeDesktopSections
                {
                    OperatingSystems = new NativeDesktopOperatingSystems(driver),
                    MemoryAndStorage = new NativeDesktopMemoryAndStorage(driver),
                },
                HostingTypeSections = new HostingTypeSections
                {
                    PublicCloud = new PublicCloud(driver),
                    PrivateCloud = new PrivateCloud(driver),
                },
                AboutSupplier = new AboutSupplier(driver),
                ContactDetails = new ContactDetails(driver),
                Capabilities = new Capabilities(driver),
            };
        }

        public PageActionCollection PageActionCollection { get; set; }
    }
}
