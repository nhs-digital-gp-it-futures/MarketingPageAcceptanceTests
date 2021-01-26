namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using System;
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public sealed class ConnectivityAndResolution : PageAction
    {
        public ConnectivityAndResolution(IWebDriver driver)
            : base(driver)
        {
        }

        public void SelectMinimumConnectionSpeed(string textValue)
        {
            new SelectElement(Driver.FindElement(Objects.Pages.ConnectivityAndResolution
                    .MinimumConnectionSpeed))
                .SelectByText(textValue);
        }

        public void SelectMinimumDesktopResolution(string textValue)
        {
            new SelectElement(Driver.FindElement(Objects.Pages.ConnectivityAndResolution
                    .MinimumDesktopResolution))
                .SelectByText(textValue);
        }

        public void SelectRandomConnectionSpeed()
        {
            var connectionDropdown =
                new SelectElement(Driver.FindElement(Objects.Pages.ConnectivityAndResolution
                    .MinimumConnectionSpeed));
            var index = new Random().Next(connectionDropdown.Options.Count);
            connectionDropdown.SelectByIndex(index);
        }
    }
}
