namespace MarketingPageAcceptanceTests.Actions.Collections
{
    using MarketingPageAcceptanceTests.Actions.Pages;

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

        public Capabilities Capabilities { get; set; }
    }
}
