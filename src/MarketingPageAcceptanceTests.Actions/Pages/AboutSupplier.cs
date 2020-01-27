using System;
using System.Collections.Generic;
using System.Text;
using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public class AboutSupplier : PageAction
    {
        public AboutSupplier(IWebDriver driver) : base(driver)
        {

        }

        public string GetDescriptionText()
        {
            return driver.FindElement(pages.AboutSupplier.Description).Text;
        }

        public string GetLinkText()
        {
            return driver.FindElement(pages.AboutSupplier.Link).Text;
        }
    }
}
