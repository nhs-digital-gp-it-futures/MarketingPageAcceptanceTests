using MarketingPageAcceptanceTests.Objects.Collections;

namespace MarketingPageAcceptanceTests.Objects
{
    public sealed class PageObjects
    {
        public PageObjects()
        {
            Pages = new PageCollection();
        }

        public PageCollection Pages { get; set; }
    }
}
