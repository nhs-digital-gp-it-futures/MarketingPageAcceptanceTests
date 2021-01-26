namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using OpenQA.Selenium;
    using static MarketingPageAcceptanceTests.Actions.Utils.ElementExtensions;

    public sealed class Dashboard : PageAction
    {
        public Dashboard(IWebDriver driver)
            : base(driver)
        {
            SectionNameToNumOfMandatoryFields = new Dictionary<string, int>();
        }

        public IDictionary<string, int> SectionNameToNumOfMandatoryFields { get; internal set; }

        public void PageDisplayed()
        {
            Wait.Until(s => s.FindElements(Objects.Pages.Dashboard.Sections).Count > 0);
        }

        public void AllSectionsContainStatus()
        {
            var sections = Driver.FindElements(Objects.Pages.Dashboard.Sections);

            // Assert that each section has a status displayed (does not consider the content of the status)
            foreach (var section in sections)
            {
                if (!section.ContainsElement(Objects.Pages.Dashboard.DefaultMessage))
                {
                    section.FindElement(Objects.Pages.Dashboard.Statuses).Displayed.Should().BeTrue();
                }
            }
        }

        public void SubmitForModeration()
        {
            Driver.FindElement(Objects.Pages.Dashboard.SubmitForModerationButton).Click();
        }

        public bool SectionsAvailable(IList<string> checkboxesSelected)
        {
            var resultCount = 0;
            foreach (var cb in checkboxesSelected)
            {
                // Find link that has the saved checkbox value in the href attribute. Return false if any are not found
                var sectionTitle = Driver.FindElements(Objects.Pages.Dashboard.SectionTitle)
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
                    Driver.FindElements(Objects.Pages.Dashboard.Sections)
                        .Single(s => s.FindElement(Objects.Pages.Dashboard.SectionTitle).Text.ToLower().Contains(cb.ToLower()))
                        .FindElement(Objects.Pages.Dashboard.Statuses);
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
            return Driver.FindElements(Objects.Pages.Dashboard.Sections)
                .Where(s => s.ContainsElement(Objects.Pages.Dashboard.SectionTitle))
                .Single(s =>
                    s.FindElement(Objects.Pages.Dashboard.SectionTitle).Text.ToLower().Contains(sectionTitle.ToLower()))
                .FindElement(Objects.Pages.Dashboard.DefaultMessage).Text;
        }

        /// <summary>
        ///     Navigate to a section.
        /// </summary>
        /// <param name="sectionTitle">Case sensitive name of a section.</param>
        /// <param name="subDashboard"></param>
        public void NavigateToSection(string sectionTitle, bool subDashboard = false)
        {
            PageDisplayed();
            Driver.FindElements(Objects.Pages.Dashboard.SectionTitle)
                .Single(s => s.Text.Contains(sectionTitle))
                .FindElement(By.TagName("a"))
                .Click();
            if (subDashboard)
            {
                Wait.Until(s => s.FindElement(Objects.Pages.Common.SubDashboardTitle).Text.Contains(sectionTitle));
            }
            else
            {
                Wait.Until(s =>
                    s.FindElement(Objects.Pages.Common.PageTitle).Text
                    .Contains(sectionTitle, StringComparison.OrdinalIgnoreCase));
            }
        }

        public void NavigateToPreviewPage()
        {
            Wait.Until(s =>
                s.FindElement(Objects.Pages.Dashboard.PreviewPage).Displayed &&
                s.FindElement(Objects.Pages.Dashboard.PreviewPage).Enabled);
            Driver.FindElement(Objects.Pages.Dashboard.PreviewPage).Click();
            new PreviewPage(Driver).PageDisplayed();
        }

        public bool SectionHasStatus(string section)
        {
            try
            {
                Driver.FindElements(Objects.Pages.Dashboard.Sections)
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

        public void SectionCompleteStatus(string sectionName)
        {
            AssertSectionStatus(sectionName, "COMPLETE");
        }

        public void ShouldDisplaySections()
        {
            var sections = Driver.FindElements(Objects.Pages.Dashboard.Sections);

            sections.Should().HaveCountGreaterThan(0);
        }

        public void SectionIncompleteStatus(string sectionName)
        {
            AssertSectionStatus(sectionName, "INCOMPLETE");
        }

        public void AssertSectionStatus(string sectionName, string status)
        {
            var section = Driver.FindElements(Objects.Pages.Dashboard.Sections)
                .Where(s => s.ContainsElement(Objects.Pages.Dashboard.SectionTitle))
                .Single(s => s.FindElement(Objects.Pages.Dashboard.SectionTitle).Text == sectionName);
            section.FindElement(Objects.Pages.Dashboard.Statuses).Text.Should().Be(status);
        }

        public IList<IWebElement> GetMandatorySections()
        {
            return Driver.FindElements(Objects.Pages.Dashboard.Sections)
                .Where(section => section.ContainsElement(Objects.Pages.Dashboard.Requirement))
                .Where(section => section.FindElement(Objects.Pages.Dashboard.Requirement).Text.Equals("Mandatory"))
                .ToList();
        }

        public IList<string> GetMandatorySectionsNames()
        {
            return Driver.FindElements(Objects.Pages.Dashboard.Sections)
                .Where(section => section.ContainsElement(Objects.Pages.Dashboard.Requirement))
                .Where(section => section.FindElement(Objects.Pages.Dashboard.Requirement).Text.Equals("Mandatory"))
                .Select(section => section.FindElement(Objects.Pages.Dashboard.SectionTitle).Text)
                .OrderBy(name => name.ToLower())
                .ToList();
        }

        public void ConstructSectionToNumFieldsMapping(string url)
        {
            var mandatorySectionNames = GetMandatorySectionsNames();

            foreach (var section in mandatorySectionNames)
            {
                Driver.FindElements(Objects.Pages.Dashboard.Sections)
                    .Single(s => s.FindElement(Objects.Pages.Dashboard.SectionTitle).Text.Equals(section))
                    .FindElement(Objects.Pages.Dashboard.SectionTitle).Click();

                Wait.Until(s => s.FindElement(Objects.Pages.Common.PageTitle).Text.ToLower().Contains(section.ToLower()));

                SectionNameToNumOfMandatoryFields.Add(section, GetNumberOfRequiredFields());
                Driver.Navigate().GoToUrl(url);
            }
        }

        public void SectionHasTitle(string title)
        {
            Driver.FindElement(Objects.Pages.Common.PageTitle).Text.Should().Be(title);
        }

        private int GetNumberOfRequiredFields()
        {
            var fields = Driver.FindElements(Objects.Pages.Common.MandatoryFieldSymbol).ToList();
            fields.RemoveAll(field => !field.Text.Trim().Contains("*"));
            return fields.Count;
        }
    }
}
