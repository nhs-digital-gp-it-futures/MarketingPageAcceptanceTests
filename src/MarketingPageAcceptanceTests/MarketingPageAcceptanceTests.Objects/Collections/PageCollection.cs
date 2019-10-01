using MarketingPageAcceptanceTests.Objects.Pages;

namespace MarketingPageAcceptanceTests.Objects.Collections
{
    public sealed class PageCollection
    {
        public Dashboard Dashboard { get; set; }
        public EditFeatures EditFeatures { get; internal set; }
        public Common Common { get; set; }
    }
}
