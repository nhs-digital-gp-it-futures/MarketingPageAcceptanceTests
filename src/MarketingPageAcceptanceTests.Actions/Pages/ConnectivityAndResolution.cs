using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class ConnectivityAndResolution : PageAction
    {
        public ConnectivityAndResolution(IWebDriver driver) : base(driver)
        {

        }

        public void SelectMinimumConnectionSpeed(string textValue)
        {
            new SelectElement(driver.FindElement(pages.ConnectivityAndResolution.MinimumConnectionSpeed))
                 .SelectByText(textValue);
        }

        public void SelectMinimumDesktopResolution(string textValue)
        {
            new SelectElement(driver.FindElement(pages.ConnectivityAndResolution.MinimumDesktopResolution))
                .SelectByText(textValue);
        }
    }
}
