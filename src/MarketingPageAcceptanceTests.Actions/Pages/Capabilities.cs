namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using MarketingPageAcceptanceTests.Actions.Utils;
    using OpenQA.Selenium;

    public sealed class Capabilities : PageAction
    {
        public Capabilities(IWebDriver driver)
            : base(driver)
        {
        }

        public static IList<IWebElement> GetCapabilityUrls()
        {
            return null;
        }

        public void EnterText(string csv)
        {
            Driver.EnterTextViaJS(Wait, Objects.Pages.Capabilities.CsvTextArea, csv);
        }

        public IList<IWebElement> GetCapabilityVersions()
        {
            return Driver.FindElements(Objects.Pages.Capabilities.CapabilitySection).Select(s => s.FindElement(Objects.Pages.Capabilities.CapabilityTitle)).ToList();
        }

        public IList<IWebElement> GetCapabilityDescriptions()
        {
            return Driver.FindElements(Objects.Pages.Capabilities.CapabilitySection).Select(s => s.FindElement(Objects.Pages.Capabilities.Description)).ToList();
        }

        public IList<IWebElement> GetCapabilityNames()
        {
            return Driver.FindElements(Objects.Pages.Capabilities.CapabilitySection).Select(s => s.FindElement(Objects.Pages.Capabilities.CapabilityTitle)).ToList();
        }
    }
}
