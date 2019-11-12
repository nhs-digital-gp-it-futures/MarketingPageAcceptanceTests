using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Objects.Pages
{
    public sealed class PluginsOrExtensions
    {
        public By PluginsRequired => By.CssSelector("div.nhsuk-radios__item");
        public By PluginDetail => By.Id("plugins-detail");
    }
}
