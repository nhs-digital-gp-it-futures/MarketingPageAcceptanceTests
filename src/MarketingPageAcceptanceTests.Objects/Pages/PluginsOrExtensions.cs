namespace MarketingPageAcceptanceTests.Objects.Pages
{
    using OpenQA.Selenium;

    public static class PluginsOrExtensions
    {
        public static By PluginsRequired => By.CssSelector("div.nhsuk-radios__item");

        public static By PluginDetail => By.Id("plugins-detail");
    }
}
