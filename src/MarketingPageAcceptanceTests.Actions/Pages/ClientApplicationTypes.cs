namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using MarketingPageAcceptanceTests.Actions.Utils;
    using OpenQA.Selenium;

    public class ClientApplicationTypes : PageAction
    {
        public ClientApplicationTypes(IWebDriver driver)
            : base(driver)
        {
        }

        public bool PageDisplayed()
        {
            return Driver.FindElement(Objects.Pages.Common.PageTitle).Text == "Client application type";
        }

        public void SelectRandomCheckbox()
        {
            var rand = new Random();
            var checkboxes = Driver.FindElements(Objects.Pages.ClientApplicationTypes.Checkboxes);
            checkboxes[rand.Next(3)].Click();
        }

        public void SelectCheckbox(string checkboxName)
        {
            Driver.FindElements(Objects.Pages.ClientApplicationTypes.CheckboxGroups)
                .Single(s => s.FindElement(By.TagName("label")).Text.Contains(checkboxName))
                .FindElement(Objects.Pages.ClientApplicationTypes.Checkboxes).Click();
        }

        public void SaveAndReturn()
        {
            Policies.GetPolicy().Execute(() =>
            {
                // Using Submit() directly to the form instead of Click() on the button prevents HTTP timeouts to Selenium server errors in 95% of cases
                Driver.FindElement(By.TagName("form")).Submit();
            });
        }

        public IList<string> GetAppTypes()
        {
            var appTypes = Driver.FindElements(Objects.Pages.ClientApplicationTypes.CheckboxGroups)
                .Select(s => s.FindElement(By.TagName("label")).Text);

            return appTypes.ToList();
        }
    }
}
