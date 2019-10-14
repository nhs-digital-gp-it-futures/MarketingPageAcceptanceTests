using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class Common : PageAction
    {
        
        public Common(IWebDriver driver, ITestOutputHelper helper) : base (driver, helper)
        {
        }
        public void GoBackOnePage()
        {
            driver.Navigate().Back();
        }
    }
}