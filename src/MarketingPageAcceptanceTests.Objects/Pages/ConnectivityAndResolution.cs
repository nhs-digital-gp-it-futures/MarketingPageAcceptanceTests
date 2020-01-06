using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class ConnectivityAndResolution
    {
        public By MinimumConnectionSpeed => By.CssSelector("select#minimum-connection-speed");

        public By MinimumDesktopResolution => By.CssSelector("select#minimum-desktop-resolution");
    }
}
