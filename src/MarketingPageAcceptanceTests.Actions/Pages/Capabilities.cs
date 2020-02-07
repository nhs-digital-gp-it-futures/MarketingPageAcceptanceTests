using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class Capabilities : PageAction
    {
        public Capabilities(IWebDriver driver) : base(driver)
        {
        }

        public void EnterText(string csv)
        {
            driver.EnterTextViaJS(wait, pages.Capabilities.CsvTextArea, csv);
        }
    }
}
