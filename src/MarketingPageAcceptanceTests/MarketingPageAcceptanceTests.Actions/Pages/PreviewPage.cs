using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    class PreviewPage : PageAction
    {
        public PreviewPage(IWebDriver driver, ITestOutputHelper helper) : base(driver, helper)
        {
        }

        public void PageDisplayed()
        {
            driver.FindElement(pages.PreviewPage.PageTitle).Text.Should().Contain("Preview Page");
        }
    }
}
