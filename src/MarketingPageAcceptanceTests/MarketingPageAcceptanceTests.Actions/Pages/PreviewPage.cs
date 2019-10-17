using FluentAssertions;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class PreviewPage : PageAction
    {
        public Dictionary<string, string> MandatoryFieldsToErrorMessages { get; private set; }

        public PreviewPage(IWebDriver driver, ITestOutputHelper helper) : base(driver, helper)
        {
            ConstructErrorMapping();
        }

        public void PageDisplayed()
        {
            wait.Until(s => s.FindElement(pages.PreviewPage.SolutionDescriptionSummarySection).Displayed);
        }

        public string GetSolutionSummaryText()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionSummarySection)
                .FindElement(pages.PreviewPage.SectionData).Text;
        }

        public string GetSolutionSummaryTitle()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionSummarySection)
                .FindElement(pages.PreviewPage.SectionTitle).Text;
        }

        public string GetSolutionAboutText()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionAboutSection)
                .FindElement(pages.PreviewPage.SectionData).Text;
        }

        public string GetSolutionAboutTitle()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionAboutSection)
                .FindElement(pages.PreviewPage.SectionTitle).Text;
        }
        public string GetSolutionLinkText()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionLinkSection)
                .FindElement(pages.PreviewPage.SectionData).Text;
        }

        public IWebElement GetSolutionLink()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionLinkSection)
                .FindElement(pages.PreviewPage.SectionData);
        }

        public IList<string> GetFeaturesText()
        {
            var features = driver.FindElement(pages.PreviewPage.FeaturesSection).FindElements(By.CssSelector("li label.nhsuk-label")).Select(s => s.Text);
            return features.ToList();
        }

        public string GetSolutionDescriptionContainerTitle()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionContainer)
                .FindElement(By.ClassName("nhsuk_title")).Text;
        }

        public void SubmitForModeration()
        {
            driver.FindElement(pages.PreviewPage.SubmitForModeration).Click();
        }

        private IEnumerable<IWebElement> GetErrorMessages()
        {
            return driver.FindElements(pages.PreviewPage.ErrorMessages);
        }

        public IWebElement GetFirstErrorMessage()
        {
            return GetErrorMessages().First();
        }

        public void AssertSubmitForReviewErrorMessageAppeared()
        {
            GetFirstErrorMessage().Displayed.Should().Be(true);
        }

        public void ClickOnErrorLink()
        {
            GetFirstErrorMessage().Click();
        }
        private void ConstructErrorMapping()
        {
            MandatoryFieldsToErrorMessages = new Dictionary<string, string>
            {
                { "summary", "Solution Summary is a required field error message" }
            };
        }

    }
}
