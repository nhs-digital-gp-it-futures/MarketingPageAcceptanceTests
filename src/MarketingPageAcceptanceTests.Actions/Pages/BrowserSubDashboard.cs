using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public class BrowserSubDashboard : PageAction
    {
        public BrowserSubDashboard(IWebDriver driver) : base(driver)
        {
        }

        public IList<string> GetSections()
        {
            return driver.FindElements(Objects.Pages.Dashboard.Sections)
                .Select(s => s.FindElement(Objects.Pages.Dashboard.SectionTitle).Text)
                .ToList();
        }

        public void SectionsHaveStatusIndicators()
        {
            var sections = GetSections();

            foreach (var section in sections)
                driver.FindElements(Objects.Pages.Dashboard.Sections)
                    .Single(s => s.FindElement(Objects.Pages.BrowserBasedDashboard.SectionTitle).Text == section)
                    .ContainsElement(Objects.Pages.BrowserBasedDashboard.StatusIndicator).Should().BeTrue();
        }

        public void OpenSection(string sectionName)
        {
            wait.Until(d => d.FindElements(By.LinkText(sectionName)).Count == 1);
            driver.FindElement(By.LinkText(sectionName)).Click();
            wait.Until(s =>
                s.FindElement(Objects.Pages.Common.PageTitle).Text
                    .Contains(sectionName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
