using System;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class Common
    {
        private readonly IWebDriver driver;
        private readonly ITestOutputHelper helper;

        public Common(IWebDriver driver, ITestOutputHelper helper)
        {
            this.driver = driver;
            this.helper = helper;
        }

        public void WaitForPageLoad()
        {
            throw new NotImplementedException();
        }
    }
}