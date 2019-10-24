using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
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

        public bool DidWindowOpenWithCorrectUrl(string url, IEnumerable<string> previousHandles)
        {
            // Get the new window by comparing two lists of window handles and switching to the difference
            var currentHandles = GetWindowHandles();
            var newWindow = currentHandles.Except(previousHandles);
            driver.SwitchTo().Window(newWindow.First());

            return driver.Url.Contains(url);
        }

        public IEnumerable<string> GetWindowHandles()
        {
            return driver.WindowHandles;
        }
    }
}