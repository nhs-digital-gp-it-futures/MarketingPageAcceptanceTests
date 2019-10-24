using System;
using System.Collections.Generic;
using System.Linq;
using MarketingPageAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public class BrowserSubDashboard : PageAction
    {
        public BrowserSubDashboard(IWebDriver driver, ITestOutputHelper helper) : base(driver, helper)
        {
        }

        public IList<string> GetSections()
        {
            return driver.FindElements(pages.BrowserBasedDashboard.Sections)
                .Select(s => s.FindElement(pages.BrowserBasedDashboard.SectionTitle).Text)
                .ToList();
        }

        public void SectionsHaveStatusIndicators()
        {
            var sections = GetSections();

            foreach (var section in sections)
            {
                driver.FindElements(pages.BrowserBasedDashboard.Sections)
                .Single(s => s.FindElement(pages.BrowserBasedDashboard.SectionTitle).Text == section)
                .ContainsElement(pages.BrowserBasedDashboard.StatusIndicator);
            }
        }
    }
}