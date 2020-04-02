using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using OpenQA.Selenium;
using System.Linq;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class PluginsOrExtensions : PageAction
    {
        public PluginsOrExtensions(IWebDriver driver) : base(driver)
        {
        }

        public void SelectRadioButton(string choice)
        {
            driver.FindElements(pages.BrowserBasedSections.PluginsOrExtensions.PluginsRequired)
                .Single(s => s.FindElement(By.TagName("label")).Text.Contains(choice))
                .FindElement(By.TagName("input"))
                .Click();
        }

        public void EnterPluginInformation(string information)
        {
            var infoArea = driver.FindElement(pages.BrowserBasedSections.PluginsOrExtensions.PluginDetail);
            infoArea.SendKeys(information);
        }
    }
}