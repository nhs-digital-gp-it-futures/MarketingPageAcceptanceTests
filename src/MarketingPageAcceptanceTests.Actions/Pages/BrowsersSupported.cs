using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public class BrowsersSupported : PageAction
    {
        public BrowsersSupported(IWebDriver driver) : base(driver)
        {
        }

        public void SelectRandomCheckboxes(int browsersSupported)
        {
            Random rand = new Random();

            var checkboxes = driver.FindElements(pages.BrowserBasedSections.BrowsersSupported.BrowserCheckboxes);

            // randomise order of list
            var randomised = checkboxes.Select(x => new { value = x, order = rand.Next() })
            .OrderBy(x => x.order).Select(x => x.value).ToList();

            for (int i = 0; i < browsersSupported; i++)
            {
                randomised[i].FindElement(By.TagName("input")).Click();
            }
        }

        public void SelectRandomRadioButton()
        {
            Random rand = new Random();

            var radioButtons = driver.FindElements(pages.BrowserBasedSections.BrowsersSupported.MobileResponsive);

            radioButtons[rand.Next(radioButtons.Count)].FindElement(By.TagName("input")).Click();
        }

        public void SaveAndReturn()
        {
            driver.FindElement(pages.BrowserBasedSections.BrowsersSupported.SaveAndReturn).Click();
        }
    }
}