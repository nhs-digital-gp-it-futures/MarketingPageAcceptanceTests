using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class ConnectivityAndResolution
    {
        public By MinimumConnectionSpeed => CustomBy.DataTestId("combobox-options-minimum-connection-speed");

        public By MinimumDesktopResolution => CustomBy.DataTestId("combobox-options-minimum-desktop-resolution");
    }
}
