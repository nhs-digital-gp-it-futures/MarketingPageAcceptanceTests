using FluentAssertions;
using MarketingPageAcceptanceTests.Actions.Pages.Utils;
using MarketingPageAcceptanceTests.TestData.ContactDetails;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class PreviewPage : PageAction
    {
        public PreviewPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        ///     Assures the page is displayed
        /// </summary>
        public void PageDisplayed()
        {
            wait.Until(s => s.FindElement(Objects.Pages.PreviewPage.PageTitle).Displayed);
        }

        /// <returns>value of mandatory field - summary of a solution</returns>
        public string GetSolutionSummaryText()
        {
            return driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionSummarySection)
                .FindElement(Objects.Pages.PreviewPage.SectionDataText).Text;
        }

        /// <returns>the title of the mandatory field</returns>
        public string GetSolutionSummaryTitle()
        {
            return driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionSummarySection)
                .FindElement(Objects.Pages.PreviewPage.SectionTitle).Text;
        }

        /// <returns>value of non-mandatory field - About the solution</returns>
        public string GetSolutionAboutText()
        {
            return driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionAboutSection)
                .FindElement(Objects.Pages.PreviewPage.SectionDataText).Text;
        }

        /// <returns>the title of a non-mandatory field - About the solution</returns>
        public string GetSolutionAboutTitle()
        {
            return driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionAboutSection)
                .FindElement(Objects.Pages.PreviewPage.SectionTitle).Text;
        }

        /// <returns>value of non-mandatory field - link</returns>
        public string GetSolutionLinkText()
        {
            return driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionLinkSection)
                .FindElement(Objects.Pages.PreviewPage.SectionDataLink).Text;
        }

        public void SectionDisplayed(string section)
        {
            driver.FindElements(Objects.Pages.PreviewPage.BrowserBasedSectionTitles)
                .Count(s => s.Text.ToLower().Contains(section.ToLower()))
                .Should().BeGreaterThan(0);
        }

        public void SectionNotDisplayed(string section)
        {
            driver.FindElements(Objects.Pages.PreviewPage.BrowserBasedSectionTitles)
                .Where(s => s.Text.ToLower().Contains(section.ToLower()))
                .Count().Should().Be(0);
        }

        public void ExpandSection(string subDashboard)
        {
            driver.FindElements(Objects.Pages.PreviewPage.ExpandingSections)
                .Select(s => s.FindElement(By.TagName("summary")))
                .Single(s => s.Text.Contains(subDashboard))
                .Click();
        }

        public void OpenCapabilityAccordians()
        {
            var capabilities = driver.FindElements(Objects.Pages.PreviewPage.Capabilities);
            foreach (var capability in capabilities)
                capability.FindElement(Objects.Pages.PreviewPage.CapabilityAccordian).Click();
        }

        public void EpicsHaveStatusSymbols(int expected)
        {
            driver.FindElements(Objects.Pages.PreviewPage.CapabilityEpicsStatusSymbol).Should().HaveCount(expected);
        }

        public IWebElement GetSolutionLink()
        {
            return driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionLinkSection)
                .FindElement(Objects.Pages.PreviewPage.SectionDataLink);
        }

        public void EpicIdsDisplayed(IEnumerable<string> epicIds)
        {
            var epicTitles = driver.FindElements(Objects.Pages.PreviewPage.EpicTitles)
                .Select(s => s.Text.Split('(').Last().Trim(')')).OrderBy(s => s)
                .ToList(); // Strip the Epic Id from the string for comparison

            foreach (var id in epicIds) epicTitles.Should().Contain(id);
        }

        public void MustSectionCount(int expected)
        {
            driver.FindElements(Objects.Pages.PreviewPage.CapabilityEpicsMustSection).Should().HaveCountLessOrEqualTo(expected);
        }

        public void MaySectionCount(int expected)
        {
            driver.FindElements(Objects.Pages.PreviewPage.CapabilityEpicsMaySection).Should().HaveCountLessOrEqualTo(expected);
        }

        /// <returns>list of features</returns>
        public IList<string> GetFeaturesText()
        {
            var features = driver.FindElement(Objects.Pages.PreviewPage.FeaturesSection)
                .FindElements(By.CssSelector("li label.nhsuk-label")).Select(s => s.Text);
            return features.ToList();
        }

        public IContactDetail ContactDisplayedOnPreview()
        {
            var contact = new ContactDetail();
            var fullName = driver.FindElement(Objects.Pages.PreviewPage.ContactName).Text.Split(' ');
            contact.FirstName = fullName[0];
            contact.LastName = fullName[1];
            contact.Department = driver.FindElement(Objects.Pages.PreviewPage.ContactDepartment).Text;
            contact.Email = driver.FindElement(Objects.Pages.PreviewPage.ContactEmail).Text;
            contact.PhoneNumber = driver.FindElement(Objects.Pages.PreviewPage.ContactPhoneNumber).Text;
            return contact;
        }

        /// <returns>title of the 'Solution description' section</returns>
        public string GetSolutionDescriptionContainerTitle()
        {
            return driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionContainer)
                .FindElement(By.ClassName("nhsuk_title")).Text;
        }

        public void BrowserBasedSectionDisplayed()
        {
            driver.FindElement(Objects.Pages.PreviewPage.BrowserBasedSection).Displayed.Should().BeTrue();
        }

        public void OpenBrowserBasedSection()
        {
            driver.FindElement(Objects.Pages.PreviewPage.BrowserBasedSection).Click();
        }

        public int SupportedBrowsersCount()
        {
            return driver.FindElements(Objects.Pages.PreviewPage.SupportedBrowsers).Count;
        }

        private int GetSectionFieldsCount(string sectionName)
        {
            return driver.FindElement(
                    By.CssSelector(ConvertToSectionCssSelector(sectionName)))
                .FindElements(Objects.Pages.PreviewPage.SectionTitle)
                .Count;
        }

        private static string ConvertToSectionCssSelector(string sectionName)
        {
            return $"[data-test-id=preview-{sectionName.ToLower().Replace(" ", "-")}";
        }

        public void AssertSectionHasMandatoryFields(string sectionName, int numFields)
        {
            GetSectionFieldsCount(sectionName).Should().Be(numFields);
        }

        public string GetConnectivityRequirement()
        {
            return driver.FindElement(Objects.Pages.PreviewPage.ConnectivityRequirement).Text;
        }

        public string GetDesktopResolutionRequirement()
        {
            return driver.FindElement(Objects.Pages.PreviewPage.DesktopResolutionRequirement).Text;
        }

        public bool IsRequiresHscnDisplayed(string section)
        {
            return driver.FindElements(Objects.Pages.PreviewPage.ExpandingSections)
                .Single(s => s.Text.Contains(section))
                .FindElements(Objects.Pages.PreviewPage.RequiresHscn)
                .Count > 0;
        }

        public bool MainSectionDisplayed(string section)
        {
            return driver.FindElements(Objects.Pages.PreviewPage.PreviewHeaders).Select(s => s.Text.ToLower())
                .Contains(section.ToLower());
        }

        public void AboutSupplierSectionDisplayed()
        {
            MainSectionDisplayed("about supplier").Should().BeTrue();
            driver.FindElement(Objects.Pages.PreviewPage.AboutSupplierDescription).Displayed.Should().BeTrue();
            driver.FindElement(Objects.Pages.PreviewPage.AboutSupplierUrl).Displayed.Should().BeTrue();
        }

        public bool DownloadNhsAssuredIntegrationsDocumentLinkIsDisplayed()
        {
            return driver.FindElements(Objects.Pages.PreviewPage.DownloadNHSAssuredIntegrationsDocumentLink)
                .Count > 0;
        }

        public bool DownloadRoadmapDocumentLinkIsDisplayed()
        {
            return driver.FindElements(Objects.Pages.PreviewPage.DownloadRoadmapDocumentLink)
                .Count > 0;
        }

        public bool DownloadAuthorityProvidedDataDocumentLinkIsDisplayed()
        {
            return driver.FindElements(Objects.Pages.PreviewPage.DownloadAuthorityProvidedDataDocumentLink)
                .Count > 0;
        }

        public string GetNhsAssuredIntegrationsDownloadLinkUrl()
        {
            return driver.FindElement(Objects.Pages.PreviewPage.DownloadNHSAssuredIntegrationsDocumentLink)
                .GetAttribute("href");
        }

        public string GetRoadmapDownloadLinkUrl()
        {
            return driver.FindElement(Objects.Pages.PreviewPage.DownloadRoadmapDocumentLink)
                .GetAttribute("href");
        }

        public string GetAuthorityProvidedDataDownloadLinkUrl()
        {
            return driver.FindElement(Objects.Pages.PreviewPage.DownloadAuthorityProvidedDataDocumentLink)
                .GetAttribute("href");
        }
    }
}