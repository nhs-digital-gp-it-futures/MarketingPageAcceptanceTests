using OpenQA.Selenium;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class Common : PageAction
    {

        public Common(IWebDriver driver, ITestOutputHelper helper) : base(driver, helper)
        {
        }
        public void GoBackOnePage()
        {
            driver.Navigate().Back();
        }

        public bool didWindowOpenWithCorrectUrl(string url)
        {
            foreach (var winHandle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(winHandle);

                return driver.Url.ToLower().Equals(url.ToLower());
            }

            return false;
        }
    }
}