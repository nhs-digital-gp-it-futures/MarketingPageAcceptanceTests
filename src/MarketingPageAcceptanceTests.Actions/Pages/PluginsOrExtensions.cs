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

        public void EnterPluginInformation(string information, bool clear = false)
        {
            var infoTextArea = driver.FindElement(pages.PluginsOrExtensions.PluginInformation);

            if (clear)
            {
                infoTextArea.Clear();
            }

            infoTextArea.SendKeys(information);
        }
    }
}
