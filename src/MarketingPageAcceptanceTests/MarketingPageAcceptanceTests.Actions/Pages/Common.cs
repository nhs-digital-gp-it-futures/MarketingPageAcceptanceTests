using System;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class Common : PageAction
    {
        
        public Common(IWebDriver driver, ITestOutputHelper helper) : base (driver, helper)
        {
        }

        /// <summary>
        /// Ensure the page has loaded up correctly
        /// </summary>
        public void WaitForPageLoad()
        {
            throw new NotImplementedException();
        }
    }
}