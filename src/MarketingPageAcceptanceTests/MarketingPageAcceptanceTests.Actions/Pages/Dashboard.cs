using System;
using System.Linq;
using FluentAssertions;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class Dashboard : PageAction
    {
        public Dashboard(IWebDriver driver, ITestOutputHelper helper) : base(driver, helper)
        {
        }

        /// <summary>
        /// Ensure the Marketing Page Dashboard is displayed by checking that some Dashboard Sections are displayed
        /// </summary>
        public void PageDisplayed()
        {
            wait.Until(s => s.FindElements(pages.Dashboard.Sections).Count > 0);
        }

        /// <summary>
        /// Ensure that each dashboard section contains a status block
        /// </summary>
        public void AllSectionsContainStatus()
        {
            var sections = driver.FindElements(pages.Dashboard.Sections);

            // Assert that each section has a status displayed (does not consider the content of the status)
            foreach(var section in sections)
            {
                section.FindElement(pages.Dashboard.Statuses).Displayed.Should().BeTrue();
            }
        }

        /// <summary>
        /// Navigate to a section
        /// </summary>
        /// <param name="sectionTitle">Case sensitive name of a section</param>
        public void NavigateToSection(string sectionTitle)
        {
            driver.FindElements(pages.Dashboard.Sections)
                .Single(s => s.FindElement(pages.Dashboard.SectionTitle).Text.Contains(sectionTitle))
                .FindElement(pages.Dashboard.SectionTitle)
                .Click();

            wait.Until(s => s.FindElement(pages.Common.PageTitle).Text.Contains(sectionTitle));
        }

        /// <summary>
        /// Navigate to the PreviewPage
        /// </summary>
        public void NavigateToPreviewPage()
        {
            driver.FindElement(pages.Dashboard.PreviewPage).Click();
        }

        public bool SectionHasStatus(string section)
        {
            try
            {
                driver.FindElements(pages.Dashboard.Sections)
                    .Single(s => s.FindElement(pages.Dashboard.SectionTitle).Text.Contains(section))
                    .FindElement(pages.Dashboard.Statuses);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Ensure a section has a status of COMPLETE
        /// </summary>
        /// <param name="sectionName">Case sensitive name of a section</param>
        public void SectionCompleteStatus(string sectionName)
        {
            SectionStatus(sectionName, "COMPLETE");
        }

        public void ShouldDisplaySections()
        {
            var sections = driver.FindElements(pages.Dashboard.Sections);

            sections.Should().HaveCountGreaterThan(0);
        }

        /// <summary>
        /// Ensure a section has a status of INCOMPLETE
        /// </summary>
        /// <param name="sectionName">Case sensitive name of a section</param>
        public void SectionIncomplete(string sectionName)
        {
            SectionStatus(sectionName, "INCOMPLETE");
        }

        /// <summary>
        /// Helper function that checks for a given status on a named section
        /// </summary>
        /// <param name="sectionName">Case sensitive name of a section</param>
        /// <param name="status">Case sensitive expected status</param>
        private void SectionStatus(string sectionName, string status)
        {
            var section = driver.FindElements(pages.Dashboard.Sections)
                .Single(s => s.FindElement(pages.Dashboard.SectionTitle).Text == sectionName);
            section.FindElement(pages.Dashboard.Statuses).Text.Should().Be(status);
        }
    }
}