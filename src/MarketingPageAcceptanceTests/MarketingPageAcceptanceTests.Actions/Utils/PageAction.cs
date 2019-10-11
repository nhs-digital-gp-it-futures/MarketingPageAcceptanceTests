using MarketingPageAcceptanceTests.Objects;
using MarketingPageAcceptanceTests.Objects.Collections;
using MarketingPageAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public abstract class PageAction
    {
        internal readonly IWebDriver driver;
        internal readonly ITestOutputHelper helper;
        internal RandomGenerator random = new RandomGenerator();
        internal readonly WebDriverWait wait;
        internal PageCollection pages;

        public PageAction(IWebDriver driver, ITestOutputHelper helper)
        {
            this.driver = driver;
            this.helper = helper;

            // Initialize a WebDriverWait that can be reutilized by all that inherit from this class
            // Polls every 0.1 seconds for 10 seconds maximum
            wait = new WebDriverWait(new SystemClock(), this.driver, TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(100));

            // Initialize the page objects
            pages = new PageObjects().Pages;
        }
        
    }
}
