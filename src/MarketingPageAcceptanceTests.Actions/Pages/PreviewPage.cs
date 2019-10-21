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

        /// <summary>
        /// Assures the page is displayed
        /// </summary>
        public void PageDisplayed()
        {
            wait.Until(s => s.FindElement(pages.PreviewPage.SolutionDescriptionSummarySection).Displayed);
        }

        /// <returns>value of mandatory field - summary of a solution</returns>
        public string GetSolutionSummaryText()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionSummarySection)
                .FindElement(pages.PreviewPage.SectionData).Text;
        }

        /// <returns>the title of the mandatory field</returns>
        public string GetSolutionSummaryTitle()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionSummarySection)
                .FindElement(pages.PreviewPage.SectionTitle).Text;
        }

        /// <returns>value of non-mandatory field - About the solution</returns>
        public string GetSolutionAboutText()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionAboutSection)
                .FindElement(pages.PreviewPage.SectionData).Text;
        }

        /// <returns>the title of a non-mandatory field - About the solution</returns>
        public string GetSolutionAboutTitle()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionAboutSection)
                .FindElement(pages.PreviewPage.SectionTitle).Text;
        }

        /// <returns>value of non-mandatory field - link</returns>
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
        
        /// <returns>list of features</returns>
        public IList<string> GetFeaturesText()
        {
            var features = driver.FindElement(pages.PreviewPage.FeaturesSection).FindElements(By.CssSelector("li label.nhsuk-label")).Select(s => s.Text);
            return features.ToList();
        }

        /// <returns>title of the 'Solution description' section</returns>
        public string GetSolutionDescriptionContainerTitle()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionContainer)
                .FindElement(By.ClassName("nhsuk_title")).Text;
        }

        /// <summary>
        /// Clicks the 'SubmitForModeration' button
        /// </summary>
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
        private int GetSectionFieldsCount(string sectionName)
        {
            return driver.FindElement(
                    By.CssSelector(ConvertToSectionCssSelector(sectionName)))
                .FindElements(pages.PreviewPage.SectionTitle)
                .Count;

        }

        private string ConvertToSectionCssSelector(string sectionName)
        {
            return $"[data-test-id=preview-section-{sectionName.ToLower().Replace(" ", "-")}";
        }

        public void AssertSectionHasMandatoryFields(string sectionName, int numFields)
        {
            GetSectionFieldsCount(sectionName).Should().Be(numFields);
        }

    }
}
