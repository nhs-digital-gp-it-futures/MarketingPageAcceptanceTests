using System;
using System.Collections.Generic;
using System.Text;
using MarketingPageAcceptanceTests.TestData.Information;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public class NativeDesktopOperatingSystems : PageAction
    {
        public NativeDesktopOperatingSystems(IWebDriver driver) : base(driver)
        {

        }

        public void TextAreaSendText(int characters)
        {
            var text = RandomInformation.RandomString(characters);

            driver.FindElement(pages.NativeDesktopSections.SupportedOperatingSystems.OperatingSystemsDescription).SendKeys(text);
        }
    }
}
