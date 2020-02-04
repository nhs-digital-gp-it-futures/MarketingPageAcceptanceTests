using FluentAssertions;
using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using static MarketingPageAcceptanceTests.Actions.Utils.ElementExtensions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class Dashboard : PageAction
    {
        public IDictionary<string, int> SectionNameToNumOfMandatoryFields { get; internal set; }

        public Dashboard(IWebDriver driver) : base(driver)
        {
            SectionNameToNumOfMandatoryFields = new Dictionary<string, int>();
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
            foreach (var section in sections)
            {
                if (!section.ContainsElement(pages.Dashboard.DefaultMessage))
                {
                    section.FindElement(pages.Dashboard.Statuses).Displayed.Should().BeTrue();
                }
            }
        }

        public void SubmitForModeration()
        {
            driver.FindElement(pages.Dashboard.SubmitForModerationButton).Click();
        }

        public bool SectionsAvailable(IList<string> checkboxesSelected)
        {
            var resultCount = 0;
            foreach (var cb in checkboxesSelected)
            {
                // Find link that has the saved checkbox value in the href attribute. Return false if any are not found
                var sectionTitle = driver.FindElements(pages.Dashboard.SectionTitle)
                    .Single(s => s.Text.Contains(cb));
                var child = sectionTitle.FindElements(By.CssSelector("a"));
                if (child.Count > 0)
                {
                    resultCount++;
                }
            }
            return resultCount == checkboxesSelected.Count;
        }

        public bool SectionsHaveStatusIndicator(IList<string> checkboxesSelected)
        {
            foreach (var cb in checkboxesSelected)
            {
                try
                {
                    // Find Status indicator on chosen section
                    driver.FindElements(pages.Dashboard.Sections)
                        .Single(s => s.FindElement(pages.Dashboard.SectionTitle).Text.ToLower().Contains(cb.ToLower()))
                        .FindElement(pages.Dashboard.Statuses);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public void SectionsContainDefaultMessage(IList<string> allAppTypes, string message)
        {
            foreach (var section in allAppTypes)
            {
                GetSectionDefaultMessage(section).Should().Be(message);
            }
        }

        public string GetSectionDefaultMessage(string sectionTitle)
        {
            return driver.FindElements(pages.Dashboard.Sections)
                .Where(s => s.ContainsElement(pages.Dashboard.SectionTitle))
                .Single(s => s.FindElement(pages.Dashboard.SectionTitle).Text.ToLower().Contains(sectionTitle.ToLower()))
                .FindElement(pages.Dashboard.DefaultMessage).Text;
        }

        /// <summary>
        /// Navigate to a section
        /// </summary>
        /// <param name="sectionTitle">Case sensitive name of a section</param>
        public void NavigateToSection(string sectionTitle, bool subDashboard = false)
        {
            PageDisplayed();
            driver.FindElements(pages.Dashboard.SectionTitle)
                .Single(s => s.Text.Contains(sectionTitle))
                .FindElement(By.TagName("a"))
                .Click();

            if (subDashboard)
            {
                wait.Until(s => s.FindElement(pages.Common.SubDashboardTitle).Text.Contains(sectionTitle));
            }
            else
            {
                wait.Until(s => s.FindElement(pages.Common.PageTitle).Text.Contains(sectionTitle, System.StringComparison.OrdinalIgnoreCase));
            }
        }

        /// <summary>
        /// Navigate to the PreviewPage
        /// </summary>
        public void NavigateToPreviewPage()
        {
            driver.FindElement(pages.Dashboard.PreviewPage).Click();
            new PreviewPage(driver).PageDisplayed();
        }

        public bool SectionHasStatus(string section)
        {
            try
            {
                driver.FindElements(pages.Dashboard.Sections)
                    .Where(s => s.ContainsElement(pages.Dashboard.SectionTitle))
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
            AssertSectionStatus(sectionName, "COMPLETE");
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
        public void SectionIncompleteStatus(string sectionName)
        {
            AssertSectionStatus(sectionName, "INCOMPLETE");
        }

        /// <summary>
        /// Helper function that checks for a given status on a named section
        /// </summary>
        /// <param name="sectionName">Case sensitive name of a section</param>
        /// <param name="status">Case sensitive expected status</param>
        public void AssertSectionStatus(string sectionName, string status)
        {
            var section = driver.FindElements(pages.Dashboard.Sections)
                .Where(s => s.ContainsElement(pages.Dashboard.SectionTitle))
                .Single(s => s.FindElement(pages.Dashboard.SectionTitle).Text == sectionName);
            section.FindElement(pages.Dashboard.Statuses).Text.Should().Be(status);
        }

        /// <summary>
        /// Gets all mandatory sections
        /// </summary>
        public IList<IWebElement> GetMandatorySections()
        {
            return driver.FindElements(pages.Dashboard.Sections)
                .Where(section => section.ContainsElement(pages.Dashboard.Requirement))
                .Where(section => section.FindElement(pages.Dashboard.Requirement).Text.Equals("Mandatory"))
                .ToList();
        }

        /// <summary>
        /// returns a list of all section names labeled as mandatory in alphabetical order
        /// </summary>
        /// <returns></returns>
        public IList<string> GetMandatorySectionsNames()
        {
            return driver.FindElements(pages.Dashboard.Sections)
                .Where(section => section.ContainsElement(pages.Dashboard.Requirement))
                .Where(section => section.FindElement(pages.Dashboard.Requirement).Text.Equals("Mandatory"))
                .Select(section => section.FindElement(pages.Dashboard.SectionTitle).Text)
                .OrderBy(name => name.ToLower())
                .ToList();
        }

        private int GetNumberOfRequiredFields()
        {
            List<IWebElement> fields = driver.FindElements(pages.Common.MandatoryFieldSymbol).ToList();
            fields.RemoveAll(field => !field.Text.Trim().Contains("*"));
            return fields.Count;
        }

        public void ConstructSectionToNumFieldsMapping(string url)
        {
            var mandatorySectionNames = GetMandatorySectionsNames();

            foreach (var section in mandatorySectionNames)
            {
                driver.FindElements(pages.Dashboard.Sections)
                    .Single(s => s.FindElement(pages.Dashboard.SectionTitle).Text.Equals(section))
                    .FindElement(pages.Dashboard.SectionTitle).Click();

                wait.Until(s => s.FindElement(pages.Common.PageTitle).Text.ToLower().Contains(section.ToLower()));

                SectionNameToNumOfMandatoryFields.Add(section, GetNumberOfRequiredFields());
                driver.Navigate().GoToUrl(url);
            }
        }


    }
}