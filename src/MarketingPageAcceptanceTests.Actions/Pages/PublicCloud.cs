using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public class PublicCloud : PageAction
    {
        public PublicCloud(IWebDriver driver) : base(driver)
        {

        }

        public void ClickRequiresHscnN3ConnectivityCheckbox()
        {
            driver.FindElement(pages.HostingTypeSections.PublicCloud.RequiresHscnN3Connectivity).FindElement(By.TagName("input")).Click();
        }
    }
}
