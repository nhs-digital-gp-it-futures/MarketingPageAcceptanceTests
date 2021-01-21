using MarketingPageAcceptanceTests.Actions.Pages.Utils;
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

            driver.FindElement(Objects.Pages.SupportedOperatingSystems.OperatingSystemsDescription)
                .SendKeys(text);
        }
    }
}
