namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using System.Linq;
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using OpenQA.Selenium;

    public sealed class PluginsOrExtensions : PageAction
    {
        public PluginsOrExtensions(IWebDriver driver)
            : base(driver)
        {
        }

        public void SelectRadioButton(string choice)
        {
            Driver.FindElements(Objects.Pages.PluginsOrExtensions.PluginsRequired)
                .Single(s => s.FindElement(By.TagName("label")).Text.Contains(choice))
                .FindElement(By.TagName("input"))
                .Click();
        }

        public void EnterPluginInformation(string information)
        {
            var infoArea = Driver.FindElement(Objects.Pages.PluginsOrExtensions.PluginDetail);
            infoArea.SendKeys(information);
        }
    }
}
