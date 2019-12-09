using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public class ClientApplicationTypes : PageAction
    {
        public ClientApplicationTypes(IWebDriver driver) : base(driver)
        {
        }

        public bool PageDisplayed()
        {
            return driver.FindElement(pages.Common.PageTitle).Text == "Client application type";
        }

        public IList<string> SelectRandomCheckbox()
        {
            Random rand = new Random();
            var checkboxes = driver.FindElements(pages.ClientApplicationTypes.Checkboxes);
            checkboxes[rand.Next(3)].Click();
            return GetSelectedCheckboxNames();
        }

        private IList<string> GetSelectedCheckboxNames()
        {
            var checkboxes = driver.FindElements(pages.ClientApplicationTypes.Checkboxes)
                .Where(s => s.GetProperty("checked") == "true")
                .Select(s => s.GetAttribute("value"));

            return checkboxes.ToList();
        }

        public void SelectCheckbox(string checkboxName)
        {
            driver.FindElements(pages.ClientApplicationTypes.CheckboxGroups)
                .Single(s => s.FindElement(By.TagName("label")).Text.Contains(checkboxName))
                .FindElement(pages.ClientApplicationTypes.Checkboxes).Click();
        }

        public void SaveAndReturn()
        {
            driver.FindElement(pages.Common.SectionSaveAndReturn).Click();
        }

        public IList<string> GetAppTypes()
        {
            var appTypes = driver.FindElements(pages.ClientApplicationTypes.CheckboxGroups)
                .Select(s => s.FindElement(By.TagName("label")).Text);

            return appTypes.ToList();
        }
    }
}