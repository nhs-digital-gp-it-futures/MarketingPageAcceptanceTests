namespace MarketingPageAcceptanceTests.Objects.Pages
{
    using OpenQA.Selenium;

    public static class ConnectivityAndResolution
    {
        public static By MinimumConnectionSpeed => By.CssSelector("select#minimum-connection-speed");

        public static By MinimumDesktopResolution => By.CssSelector("select#minimum-desktop-resolution");
    }
}
