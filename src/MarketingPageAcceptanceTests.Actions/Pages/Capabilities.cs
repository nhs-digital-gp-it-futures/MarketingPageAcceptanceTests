using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class Capabilities : PageAction
    {
        public Capabilities(IWebDriver driver) : base(driver)
        {
        }

        public void EnterText(string csv)
        {
            driver.EnterTextViaJS(wait, Objects.Pages.Capabilities.CsvTextArea, csv);
        }

        public IList<IWebElement> GetCapabilityVersions()
        {
            return driver.FindElements(Objects.Pages.Capabilities.CapabilitySection).Select(s => s.FindElement(Objects.Pages.Capabilities.CapabilityTitle)).ToList();
        }

        public IList<IWebElement> GetCapabilityDescriptions()
        {
            return driver.FindElements(Objects.Pages.Capabilities.CapabilitySection).Select(s => s.FindElement(Objects.Pages.Capabilities.Description)).ToList();
        }

        public static IList<IWebElement> GetCapabilityUrls()
        {
            return null;
        }

        public IList<IWebElement> GetCapabilityNames()
        {
            return driver.FindElements(Objects.Pages.Capabilities.CapabilitySection).Select(s => s.FindElement(Objects.Pages.Capabilities.CapabilityTitle)).ToList();
        }
    }
}