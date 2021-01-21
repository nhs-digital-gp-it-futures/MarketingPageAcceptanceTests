using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using OpenQA.Selenium;
using static MarketingPageAcceptanceTests.Actions.Utils.ElementExtensions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class Dashboard : PageAction
    {
        public Dashboard(IWebDriver driver) : base(driver)
        {
            SectionNameToNumOfMandatoryFields = new Dictionary<string, int>();
        }

        public IDictionary<string, int> SectionNameToNumOfMandatoryFields { get; internal set; }

        /// <summary>
        ///     Ensure the Marketing Page Dashboard is displayed by checking that some Dashboard Sections are displayed
        /// </summary>
        public void PageDisplayed()
        {
            wait.Until(s => s.FindElements(Objects.Pages.Dashboard.Sections).Count > 0);
        }

        /// <summary>
        ///     Ensure that each dashboard section contains a status block
        /// </summary>
        public void AllSectionsContainStatus()
        {
            var sections = driver.FindElements(Objects.Pages.Dashboard.Sections);

            // Assert that each section has a status displayed (does not consider the content of the status)
            foreach (var section in sections)
                if (!section.ContainsElement(Objects.Pages.Dashboard.DefaultMessage))
                    section.FindElement(Objects.Pages.Dashboard.Statuses).Displayed.Should().BeTrue();
        }

        public void SubmitForModeration()
        {
            driver.FindElement(Objects.Pages.Dashboard.SubmitForModerationButton).Click();
        }

        public bool SectionsAvailable(IList<string> checkboxesSelected)
        {
            var resultCount = 0;
            foreach (var cb in checkboxesSelected)
            {
                // Find link that has the saved checkbox value in the href attribute. Return false if any are not found
                var sectionTitle = driver.FindElements(Objects.Pages.Dashboard.SectionTitle)
                    .Single(s => s.Text.Contains(cb));
                var child = sectionTitle.FindElements(By.CssSelector("a"));
                if (child.Count > 0) resultCount++;
            }

            return resultCount == checkboxesSelected.Count;
        }

        public bool SectionsHaveStatusIndicator(IList<string> checkboxesSelected)
        {
            foreach (var cb in checkboxesSelected)
                try
                {
                    // Find Status indicator on chosen section
                    driver.FindElements(Objects.Pages.Dashboard.Sections)
                        .Single(s => s.FindElement(Objects.Pages.Dashboard.SectionTitle).Text.ToLower().Contains(cb.ToLower()))
                        .FindElement(Objects.Pages.Dashboard.Statuses);
                }
                catch
                {
                    return false;
                }

            return true;
        }

        public void SectionsContainDefaultMessage(IList<string> allAppTypes, string message)
        {
            foreach (var section in allAppTypes) GetSectionDefaultMessage(section).Should().Be(message);
        }

        public string GetSectionDefaultMessage(string sectionTitle)
        {
            return driver.FindElements(Objects.Pages.Dashboard.Sections)
                .Where(s => s.ContainsElement(Objects.Pages.Dashboard.SectionTitle))
                .Single(s =>
                    s.FindElement(Objects.Pages.Dashboard.SectionTitle).Text.ToLower().Contains(sectionTitle.ToLower()))
                .FindElement(Objects.Pages.Dashboard.DefaultMessage).Text;
        }

        /// <summary>
        ///     Navigate to a section
        /// </summary>
        /// <param name="sectionTitle">Case sensitive name of a section</param>
        public void NavigateToSection(string sectionTitle, bool subDashboard = false)
        {
            PageDisplayed();
            driver.FindElements(Objects.Pages.Dashboard.SectionTitle)
                .Single(s => s.Text.Contains(sectionTitle))
                .FindElement(By.TagName("a"))
                .Click();
            if (subDashboard)
                wait.Until(s => s.FindElement(Objects.Pages.Common.SubDashboardTitle).Text.Contains(sectionTitle));
            else
                wait.Until(s =>
                    s.FindElement(Objects.Pages.Common.PageTitle).Text
                        .Contains(sectionTitle, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///     Navigate to the PreviewPage
        /// </summary>
        public void NavigateToPreviewPage()
        {
            wait.Until(s =>
                s.FindElement(Objects.Pages.Dashboard.PreviewPage).Displayed &&
                s.FindElement(Objects.Pages.Dashboard.PreviewPage).Enabled);
            driver.FindElement(Objects.Pages.Dashboard.PreviewPage).Click();
            new PreviewPage(driver).PageDisplayed();
        }

        public bool SectionHasStatus(string section)
        {
            try
            {
                driver.FindElements(Objects.Pages.Dashboard.Sections)
                    .Where(s => s.ContainsElement(Objects.Pages.Dashboard.SectionTitle))
                    .Single(s => s.FindElement(Objects.Pages.Dashboard.SectionTitle).Text.Contains(section))
                    .FindElement(Objects.Pages.Dashboard.Statuses);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Ensure a section has a status of COMPLETE
        /// </summary>
        /// <param name="sectionName">Case sensitive name of a section</param>
        public void SectionCompleteStatus(string sectionName)
        {
            AssertSectionStatus(sectionName, "COMPLETE");
        }

        public void ShouldDisplaySections()
        {
            var sections = driver.FindElements(Objects.Pages.Dashboard.Sections);

            sections.Should().HaveCountGreaterThan(0);
        }

        /// <summary>
        ///     Ensure a section has a status of INCOMPLETE
        /// </summary>
        /// <param name="sectionName">Case sensitive name of a section</param>
        public void SectionIncompleteStatus(string sectionName)
        {
            AssertSectionStatus(sectionName, "INCOMPLETE");
        }

        /// <summary>
        ///     Helper function that checks for a given status on a named section
        /// </summary>
        /// <param name="sectionName">Case sensitive name of a section</param>
        /// <param name="status">Case sensitive expected status</param>
        public void AssertSectionStatus(string sectionName, string status)
        {
            var section = driver.FindElements(Objects.Pages.Dashboard.Sections)
                .Where(s => s.ContainsElement(Objects.Pages.Dashboard.SectionTitle))
                .Single(s => s.FindElement(Objects.Pages.Dashboard.SectionTitle).Text == sectionName);
            section.FindElement(Objects.Pages.Dashboard.Statuses).Text.Should().Be(status);
        }

        /// <summary>
        ///     Gets all mandatory sections
        /// </summary>
        public IList<IWebElement> GetMandatorySections()
        {
            return driver.FindElements(Objects.Pages.Dashboard.Sections)
                .Where(section => section.ContainsElement(Objects.Pages.Dashboard.Requirement))
                .Where(section => section.FindElement(Objects.Pages.Dashboard.Requirement).Text.Equals("Mandatory"))
                .ToList();
        }

        /// <summary>
        ///     returns a list of all section names labeled as mandatory in alphabetical order
        /// </summary>
        /// <returns></returns>
        public IList<string> GetMandatorySectionsNames()
        {
            return driver.FindElements(Objects.Pages.Dashboard.Sections)
                .Where(section => section.ContainsElement(Objects.Pages.Dashboard.Requirement))
                .Where(section => section.FindElement(Objects.Pages.Dashboard.Requirement).Text.Equals("Mandatory"))
                .Select(section => section.FindElement(Objects.Pages.Dashboard.SectionTitle).Text)
                .OrderBy(name => name.ToLower())
                .ToList();
        }

        private int GetNumberOfRequiredFields()
        {
            var fields = driver.FindElements(Objects.Pages.Common.MandatoryFieldSymbol).ToList();
            fields.RemoveAll(field => !field.Text.Trim().Contains("*"));
            return fields.Count;
        }

        public void ConstructSectionToNumFieldsMapping(string url)
        {
            var mandatorySectionNames = GetMandatorySectionsNames();

            foreach (var section in mandatorySectionNames)
            {
                driver.FindElements(Objects.Pages.Dashboard.Sections)
                    .Single(s => s.FindElement(Objects.Pages.Dashboard.SectionTitle).Text.Equals(section))
                    .FindElement(Objects.Pages.Dashboard.SectionTitle).Click();

                wait.Until(s => s.FindElement(Objects.Pages.Common.PageTitle).Text.ToLower().Contains(section.ToLower()));

                SectionNameToNumOfMandatoryFields.Add(section, GetNumberOfRequiredFields());
                driver.Navigate().GoToUrl(url);
            }
        }

        public void SectionHasTitle(string title)
        {
            driver.FindElement(Objects.Pages.Common.PageTitle).Text.Should().Be(title);
        }
    }
}