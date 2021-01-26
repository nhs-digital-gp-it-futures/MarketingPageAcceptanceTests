namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using System.Collections.Generic;
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using MarketingPageAcceptanceTests.TestData.Information;
    using OpenQA.Selenium;

    public class NativeMobileOperatingSystems : PageAction
    {
        public NativeMobileOperatingSystems(IWebDriver driver)
            : base(driver)
        {
        }

        public void SelectCheckboxes(int numberToSelect)
        {
            IList<IWebElement> checkboxes =
                Driver.FindElements(Objects.Pages.SupportedOperatingSystems.OperatingSystems);

            for (var i = 0; i < numberToSelect; i++)
            {
                checkboxes[i].Click();
            }
        }

        public void TextAreaSendText(int characters)
        {
            var text = RandomInformation.RandomString(characters);

            Driver.FindElement(Objects.Pages.SupportedOperatingSystems.OperatingSystemsDescription)
                .SendKeys(text);
        }
    }
}
