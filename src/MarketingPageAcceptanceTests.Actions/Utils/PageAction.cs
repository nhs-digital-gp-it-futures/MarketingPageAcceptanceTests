namespace MarketingPageAcceptanceTests.Actions.Pages.Utils
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public abstract class PageAction
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        protected PageAction(IWebDriver driver)
        {
            Driver = driver;

            // Initialize a WebDriverWait that can be reutilized by all that inherit from this class
            // Polls every 0.1 seconds for 10 seconds maximum
            Wait = new WebDriverWait(
                new SystemClock(),
                Driver,
                TimeSpan.FromSeconds(10),
                TimeSpan.FromMilliseconds(100));
        }
    }
}
