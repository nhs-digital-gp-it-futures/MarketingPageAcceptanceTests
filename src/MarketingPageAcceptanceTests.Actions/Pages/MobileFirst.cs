using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using OpenQA.Selenium;
using System.Linq;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class MobileFirst : PageAction
    {

        public MobileFirst(IWebDriver driver) : base(driver)
        {

        }

        public void SelectRadioButton(string choice)
        {
            wait.Until(s => s.FindElements(pages.BrowserBasedSections.MobileFirst.DesignedWithMobileFirstApproach).First().Enabled);
            driver.FindElements(pages.BrowserBasedSections.MobileFirst.DesignedWithMobileFirstApproach)
                .Single(s => s.FindElement(By.TagName("label")).Text.Contains(choice))
                .FindElement(By.TagName("input"))
                .Click();
        }
    }
}
