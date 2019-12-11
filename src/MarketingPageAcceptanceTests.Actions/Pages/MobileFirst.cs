﻿using System.Linq;
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
            driver.FindElements(pages.MobileFirst.DesignedWithMobileFirstApproach)
                .Single(s => s.FindElement(By.TagName("label")).Text.Contains(choice))
                .FindElement(By.TagName("input"))
                .Click();
        }
    }
}
