using MarketingPageAcceptanceTests.TestData.Information;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public class NativeMobileOperatingSystems : PageAction
    {
        public NativeMobileOperatingSystems(IWebDriver driver) : base(driver)
        {
        }

        public void SelectCheckboxes(int numberToSelect)
        {
            IList<IWebElement> checkboxes = driver.FindElements(pages.NativeMobileSections.SupportedOperatingSystems.OperatingSystems);

            for (int i = 0; i < numberToSelect; i++)
            {
                checkboxes[i].Click();
            }
        }

        public void TextAreaSendText(int characters)
        {
            var text = RandomInformation.RandomString(characters);

            driver.FindElement(pages.NativeMobileSections.SupportedOperatingSystems.OperatingSystemsDescription).SendKeys(text);
        }
    }
}