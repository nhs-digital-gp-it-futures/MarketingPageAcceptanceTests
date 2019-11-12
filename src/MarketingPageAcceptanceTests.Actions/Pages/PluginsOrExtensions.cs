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
            driver.FindElements(pages.PluginsOrExtensions.PluginsRequired)
                .Single(s => s.FindElement(By.TagName("label")).Text.Contains(choice))
                .FindElement(By.TagName("input"))
                .Click();
        }

        public void EnterPluginInformation(string information)
        {
            var infoArea = driver.FindElement(pages.PluginsOrExtensions.PluginDetail);
            infoArea.SendKeys(information);
        }
    }
}
