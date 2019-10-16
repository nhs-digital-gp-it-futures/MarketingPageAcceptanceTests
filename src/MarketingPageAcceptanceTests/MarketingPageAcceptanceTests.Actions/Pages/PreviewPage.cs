using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class PreviewPage : PageAction
    {
        public PreviewPage(IWebDriver driver, ITestOutputHelper helper) : base(driver, helper)
        {
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
    }
}
