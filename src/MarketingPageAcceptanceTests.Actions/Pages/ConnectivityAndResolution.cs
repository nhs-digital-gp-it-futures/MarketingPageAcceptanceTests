using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class ConnectivityAndResolution : PageAction
    {
        public ConnectivityAndResolution(IWebDriver driver) : base(driver)
        {

        }

        public void SelectMinimumConnectionSpeed(string textValue)
        {
            new SelectElement(driver.FindElement(pages.BrowserBasedSections.ConnectivityAndResolution.MinimumConnectionSpeed))
                 .SelectByText(textValue);
        }

        public void SelectMinimumDesktopResolution(string textValue)
        {
            new SelectElement(driver.FindElement(pages.BrowserBasedSections.ConnectivityAndResolution.MinimumDesktopResolution))
                .SelectByText(textValue);
        }

        public void SelectRandomConnectionSpeed()
        {
            var connectionDropdown = new SelectElement(driver.FindElement(pages.BrowserBasedSections.ConnectivityAndResolution.MinimumConnectionSpeed));
            var index = new Random().Next(connectionDropdown.Options.Count);
            connectionDropdown.SelectByIndex(index);
        }
    }
}
