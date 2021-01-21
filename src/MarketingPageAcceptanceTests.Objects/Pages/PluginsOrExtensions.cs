using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public static class PluginsOrExtensions
    {
        public static By PluginsRequired => By.CssSelector("div.nhsuk-radios__item");
        public static By PluginDetail => By.Id("plugins-detail");
    }
}
