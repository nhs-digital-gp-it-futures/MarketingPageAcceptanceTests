using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void SelectRandomCheckbox()
        {
            Random rand = new Random();
            var checkboxes = driver.FindElements(pages.ClientApplicationTypes.Checkboxes);
            checkboxes[rand.Next(3)].Click();
        }

        public void SelectCheckbox(string checkboxName)
        {
            driver.FindElements(pages.ClientApplicationTypes.CheckboxGroups)
                .Single(s => s.FindElement(By.TagName("label")).Text.Contains(checkboxName))
                .FindElement(pages.ClientApplicationTypes.Checkboxes).Click();
        }

        public void SaveAndReturn()
        {
            // Using Submit() instead of Click() prevents HTTP timeouts to Selenium server errors
            driver.FindElement(pages.Common.SectionSaveAndReturn).Submit();
        }

        public IList<string> GetAppTypes()
        {
            var appTypes = driver.FindElements(pages.ClientApplicationTypes.CheckboxGroups)
                .Select(s => s.FindElement(By.TagName("label")).Text);

            return appTypes.ToList();
        }
    }
}