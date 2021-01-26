namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using MarketingPageAcceptanceTests.Actions.Utils;
    using OpenQA.Selenium;

    public sealed class Common : PageAction
    {
        public Common(IWebDriver driver)
            : base(driver)
        {
        }

        public bool PageTitleEquals(string expectedTitle)
        {
            return Driver.FindElement(Objects.Pages.Common.PageTitle).Text == expectedTitle;
        }

        public void GoBackOnePage()
        {
            Driver.Navigate().Back();
        }

        public bool DidWindowOpenWithCorrectUrl(string url, IEnumerable<string> previousHandles)
        {
            // Get the new window by comparing two lists of window handles and switching to the difference
            var currentHandles = GetWindowHandles();
            var newWindow = currentHandles.Except(previousHandles);
            Driver.SwitchTo().Window(newWindow.First());

            return Driver.Url.Contains(url);
        }

        public IEnumerable<string> GetWindowHandles()
        {
            return Driver.WindowHandles;
        }

        public void ClickSubDashboardBackLink()
        {
            Wait.Until(s => s.FindElement(Objects.Pages.Common.SubDashboardBackLink).Displayed);
            Driver.FindElement(Objects.Pages.Common.SubDashboardBackLink).Click();
        }

        public void ClickSectionBackLink()
        {
            Driver.FindElement(Objects.Pages.Common.SectionBackLink).Click();
            new Dashboard(Driver).PageDisplayed();
        }

        public void ErrorMessageDisplayed()
        {
            ErrorSectionDisplayed();
            Driver.FindElement(Objects.Pages.Common.ErrorMessages).Text.Should().NotBeNullOrEmpty();
        }

        public void ErrorSectionDisplayed()
        {
            Wait.Until(s => s.FindElements(Objects.Pages.Common.ErrorSection).Count == 1);
        }

        public void ErrorMessagesDisplayed(int numSections)
        {
            var errorMessages = GetErrorMessages();
            errorMessages.Should().HaveCount(numSections);
        }

        public void ErrorMessageTextDisplayed(string text)
        {
            var errorMessages = GetErrorMessages();
            errorMessages.Select(s => s.Text).Should().Contain(text);
        }

        public string SubDashboardTitle()
        {
            return Driver.FindElement(Objects.Pages.Common.SubDashboardTitle).Text;
        }

        public string ClickOnErrorLink()
        {
            var errorMessages = GetErrorMessages().ToList();
            var index = new Random().Next(errorMessages.Count);

            var linkHref = errorMessages[index].GetAttribute("href");

            errorMessages[index].Click();

            return linkHref;
        }

        public void SectionSaveAndReturn()
        {
            Policies.GetPolicy().Execute(() =>
            {
                // Using Submit() directly to the form instead of Click() on the button prevents HTTP timeouts to Selenium server errors in 95% of cases
                if (IsDisplayed(By.TagName("form")))
                {
                    Driver.FindElement(By.TagName("form")).Submit();
                }
                else
                {
                    Driver.FindElement(Objects.Pages.Common.SectionSaveAndReturn).Click();
                }
            });
        }

        public void WaitUntilSectionPageNotShownAnymore()
        {
            Wait.Until(ElementExtensions.InvisibilityOfElement(By.TagName("form")));
        }

        private bool IsDisplayed(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private IEnumerable<IWebElement> GetErrorMessages()
        {
            return Driver.FindElements(Objects.Pages.Common.ErrorMessages);
        }
    }
}
