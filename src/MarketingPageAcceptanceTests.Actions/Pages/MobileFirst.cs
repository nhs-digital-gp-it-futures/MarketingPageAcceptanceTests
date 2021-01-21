﻿using System.Linq;
using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class MobileFirst : PageAction
    {
        public MobileFirst(IWebDriver driver) : base(driver)
        {
        }

        public void SelectRadioButton(string choice)
        {
            wait.Until(s =>
                s.FindElements(Objects.Pages.MobileFirst.DesignedWithMobileFirstApproach).First().Enabled);
            driver.FindElements(Objects.Pages.MobileFirst.DesignedWithMobileFirstApproach)
                .Single(s => s.FindElement(By.TagName("label")).Text.Contains(choice))
                .FindElement(By.TagName("input"))
                .Click();
        }
    }
}