﻿namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using System;
    using System.Linq;
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using OpenQA.Selenium;

    public class BrowsersSupported : PageAction
    {
        public BrowsersSupported(IWebDriver driver)
            : base(driver)
        {
        }

        public void SelectRandomCheckboxes(int browsersSupported)
        {
            var rand = new Random();

            var checkboxes = Driver.FindElements(Objects.Pages.BrowsersSupported.BrowserCheckboxes);

            // randomise order of list
            var randomised = checkboxes.Select(x => new { value = x, order = rand.Next() })
                .OrderBy(x => x.order).Select(x => x.value).ToList();

            for (var i = 0; i < browsersSupported; i++)
            {
                randomised[i].FindElement(By.TagName("input")).Click();
            }
        }

        public void SelectRandomRadioButton()
        {
            var rand = new Random();

            var radioButtons = Driver.FindElements(Objects.Pages.BrowsersSupported.MobileResponsive);

            radioButtons[rand.Next(radioButtons.Count)].FindElement(By.TagName("input")).Click();
        }

        public void SaveAndReturn()
        {
            Driver.FindElement(Objects.Pages.BrowsersSupported.SaveAndReturn).Click();
        }
    }
}
