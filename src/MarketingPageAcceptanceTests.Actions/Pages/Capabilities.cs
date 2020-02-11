using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class Capabilities : PageAction
    {
        public Capabilities(IWebDriver driver) : base(driver)
        {
        }

        public void EnterText(string csv)
        {
            driver.EnterTextViaJS(wait, pages.Capabilities.CsvTextArea, csv);
        }

        public IList<IWebElement> GetCapabilityVersions()
        {
            return driver.FindElements(pages.Capabilities.CapabilityTitle).ToList();
        }

        public IList<IWebElement> GetCapabilityDescriptions()
        {
            return driver.FindElements(pages.Capabilities.Description).ToList();
        }

        public IList<IWebElement> GetCapabilityUrls()
        {
            return null;
        }

        public IList<IWebElement> GetCapabilityNames()
        {
            return driver.FindElements(pages.Capabilities.CapabilityTitle).ToList();
        }
    }
}
