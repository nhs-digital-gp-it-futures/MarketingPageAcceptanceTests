using FluentAssertions;
using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class Common : PageAction
    {

        public Common(IWebDriver driver) : base(driver)
        {
        }

        public bool PageTitleEquals(string expectedTitle)
        {
            return driver.FindElement(pages.Common.PageTitle).Text == expectedTitle;
        }

        public void GoBackOnePage()
        {
            driver.Navigate().Back();
        }

        public bool DidWindowOpenWithCorrectUrl(string url, IEnumerable<string> previousHandles)
        {
            // Get the new window by comparing two lists of window handles and switching to the difference
            var currentHandles = GetWindowHandles();
            var newWindow = currentHandles.Except(previousHandles);
            driver.SwitchTo().Window(newWindow.First());

            return driver.Url.Contains(url);
        }

        public IEnumerable<string> GetWindowHandles()
        {
            return driver.WindowHandles;
        }

        public void ClickSubDashboardBackLink()
        {
            wait.Until(s => s.FindElement(pages.Common.SubDashboardBackLink).Displayed);
            driver.FindElement(pages.Common.SubDashboardBackLink).Click();
        }

        public void ClickSectionBackLink()
        {
            driver.FindElement(pages.Common.SectionBackLink).Click();
            new Dashboard(driver).PageDisplayed();
        }

        /// <summary>
        /// Validate that an error message is displayed (does not validate text within message)
        /// </summary>
        public void ErrorMessageDisplayed()
        {
            ErrorSectionDisplayed();
            driver.FindElement(pages.Common.ErrorMessages).Text.Should().NotBeNullOrEmpty();
        }

        public void ErrorSectionDisplayed()
        {
            wait.Until(s => s.FindElement(pages.Common.ErrorSection).Displayed);
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

        private IEnumerable<IWebElement> GetErrorMessages()
        {
            return driver.FindElements(pages.Common.ErrorMessages);
        }

        public string SubDashboardTitle()
        {
            return driver.FindElement(pages.Common.SubDashboardTitle).Text;
        }

        public string ClickOnErrorLink()
        {
            var errorMessages = GetErrorMessages().ToList();
            var index = new Random().Next(errorMessages.Count());

            var linkHref = errorMessages[index].GetAttribute("href");

            errorMessages[index].Click();

            return linkHref;
        }

        public void SectionSaveAndReturn()
        {
            Policies.GetPolicy().Execute(() =>
            {
                // Using Submit() directly to the form instead of Click() on the button prevents HTTP timeouts to Selenium server errors in 95% of cases
                // wait.Until(ElementExtensions.ElementToBeClickable(pages.Common.SectionSaveAndReturn));
                if (IsDisplayed(By.TagName("form")))
                {
                    driver.FindElement(By.TagName("form")).Submit();
                }
                else
                {
                    driver.FindElement(pages.Common.SectionSaveAndReturn).Click();
                }
            });
        }

        public void WaitUntilSectionPageNotShownAnymore()
        {
            wait.Until(ElementExtensions.InvisibilityOfElement(By.TagName("form")));
        }

        private bool IsDisplayed(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}