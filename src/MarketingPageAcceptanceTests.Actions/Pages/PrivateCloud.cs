using System;
using System.Collections.Generic;
using System.Text;
using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.TestData.Information;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public class PrivateCloud : PageAction
    {
        public PrivateCloud(IWebDriver driver) : base(driver)
        {

        }
        public void EnterText(int characters)
        {
            string randomText = RandomInformation.RandomString(characters);

            driver.FindElement(pages.HostingTypeSections.PrivateCloud.HostingModel).SendKeys(randomText);
        }
    }
}
