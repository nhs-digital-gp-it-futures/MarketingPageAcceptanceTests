namespace MarketingPageAcceptanceTests.Actions.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Actions.Pages.Utils;
    using MarketingPageAcceptanceTests.TestData.ContactDetails;
    using OpenQA.Selenium;

    public sealed class PreviewPage : PageAction
    {
        public PreviewPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void PageDisplayed()
        {
            Wait.Until(s => s.FindElement(Objects.Pages.PreviewPage.PageTitle).Displayed);
        }

        public string GetSolutionSummaryText()
        {
            return Driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionSummarySection)
                .FindElement(Objects.Pages.PreviewPage.SectionDataText).Text;
        }

        public string GetSolutionSummaryTitle()
        {
            return Driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionSummarySection)
                .FindElement(Objects.Pages.PreviewPage.SectionTitle).Text;
        }

        public string GetSolutionAboutText()
        {
            return Driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionAboutSection)
                .FindElement(Objects.Pages.PreviewPage.SectionDataText).Text;
        }

        public string GetSolutionAboutTitle()
        {
            return Driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionAboutSection)
                .FindElement(Objects.Pages.PreviewPage.SectionTitle).Text;
        }

        public string GetSolutionLinkText()
        {
            return Driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionLinkSection)
                .FindElement(Objects.Pages.PreviewPage.SectionDataLink).Text;
        }

        public void SectionDisplayed(string section)
        {
            Driver.FindElements(Objects.Pages.PreviewPage.BrowserBasedSectionTitles)
                .Count(s => s.Text.ToLower().Contains(section.ToLower()))
                .Should().BeGreaterThan(0);
        }

        public void SectionNotDisplayed(string section)
        {
            Driver.FindElements(Objects.Pages.PreviewPage.BrowserBasedSectionTitles)
                .Where(s => s.Text.ToLower().Contains(section.ToLower()))
                .Count().Should().Be(0);
        }

        public void ExpandSection(string subDashboard)
        {
            Driver.FindElements(Objects.Pages.PreviewPage.ExpandingSections)
                .Select(s => s.FindElement(By.TagName("summary")))
                .Single(s => s.Text.Contains(subDashboard))
                .Click();
        }

        public void OpenCapabilityAccordians()
        {
            var capabilities = Driver.FindElements(Objects.Pages.PreviewPage.Capabilities);
            foreach (var capability in capabilities)
            {
                capability.FindElement(Objects.Pages.PreviewPage.CapabilityAccordian).Click();
            }
        }

        public void EpicsHaveStatusSymbols(int expected)
        {
            Driver.FindElements(Objects.Pages.PreviewPage.CapabilityEpicsStatusSymbol).Should().HaveCount(expected);
        }

        public IWebElement GetSolutionLink()
        {
            return Driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionLinkSection)
                .FindElement(Objects.Pages.PreviewPage.SectionDataLink);
        }

        public void EpicIdsDisplayed(IEnumerable<string> epicIds)
        {
            var epicTitles = Driver.FindElements(Objects.Pages.PreviewPage.EpicTitles)
                .Select(s => s.Text.Split('(').Last().Trim(')')).OrderBy(s => s)
                .ToList(); // Strip the Epic Id from the string for comparison

            foreach (var id in epicIds)
            {
                epicTitles.Should().Contain(id);
            }
        }

        public void MustSectionCount(int expected)
        {
            Driver.FindElements(Objects.Pages.PreviewPage.CapabilityEpicsMustSection).Should().HaveCountLessOrEqualTo(expected);
        }

        public void MaySectionCount(int expected)
        {
            Driver.FindElements(Objects.Pages.PreviewPage.CapabilityEpicsMaySection).Should().HaveCountLessOrEqualTo(expected);
        }

        public IList<string> GetFeaturesText()
        {
            var features = Driver.FindElement(Objects.Pages.PreviewPage.FeaturesSection)
                .FindElements(By.CssSelector("li label.nhsuk-label")).Select(s => s.Text);
            return features.ToList();
        }

        public IContactDetail ContactDisplayedOnPreview()
        {
            var contact = new ContactDetail();
            var fullName = Driver.FindElement(Objects.Pages.PreviewPage.ContactName).Text.Split(' ');
            contact.FirstName = fullName[0];
            contact.LastName = fullName[1];
            contact.Department = Driver.FindElement(Objects.Pages.PreviewPage.ContactDepartment).Text;
            contact.Email = Driver.FindElement(Objects.Pages.PreviewPage.ContactEmail).Text;
            contact.PhoneNumber = Driver.FindElement(Objects.Pages.PreviewPage.ContactPhoneNumber).Text;
            return contact;
        }

        public string GetSolutionDescriptionContainerTitle()
        {
            return Driver.FindElement(Objects.Pages.PreviewPage.SolutionDescriptionContainer)
                .FindElement(By.ClassName("nhsuk_title")).Text;
        }

        public void BrowserBasedSectionDisplayed()
        {
            Driver.FindElement(Objects.Pages.PreviewPage.BrowserBasedSection).Displayed.Should().BeTrue();
        }

        public void OpenBrowserBasedSection()
        {
            Driver.FindElement(Objects.Pages.PreviewPage.BrowserBasedSection).Click();
        }

        public int SupportedBrowsersCount()
        {
            return Driver.FindElements(Objects.Pages.PreviewPage.SupportedBrowsers).Count;
        }

        public void AssertSectionHasMandatoryFields(string sectionName, int numFields)
        {
            GetSectionFieldsCount(sectionName).Should().Be(numFields);
        }

        public string GetConnectivityRequirement()
        {
            return Driver.FindElement(Objects.Pages.PreviewPage.ConnectivityRequirement).Text;
        }

        public string GetDesktopResolutionRequirement()
        {
            return Driver.FindElement(Objects.Pages.PreviewPage.DesktopResolutionRequirement).Text;
        }

        public bool IsRequiresHscnDisplayed(string section)
        {
            return Driver.FindElements(Objects.Pages.PreviewPage.ExpandingSections)
                .Single(s => s.Text.Contains(section))
                .FindElements(Objects.Pages.PreviewPage.RequiresHscn)
                .Count > 0;
        }

        public bool MainSectionDisplayed(string section)
        {
            return Driver.FindElements(Objects.Pages.PreviewPage.PreviewHeaders).Select(s => s.Text.ToLower())
                .Contains(section.ToLower());
        }

        public void AboutSupplierSectionDisplayed()
        {
            MainSectionDisplayed("about supplier").Should().BeTrue();
            Driver.FindElement(Objects.Pages.PreviewPage.AboutSupplierDescription).Displayed.Should().BeTrue();
            Driver.FindElement(Objects.Pages.PreviewPage.AboutSupplierUrl).Displayed.Should().BeTrue();
        }

        public bool DownloadNhsAssuredIntegrationsDocumentLinkIsDisplayed()
        {
            return Driver.FindElements(Objects.Pages.PreviewPage.DownloadNHSAssuredIntegrationsDocumentLink)
                .Count > 0;
        }

        public bool DownloadRoadmapDocumentLinkIsDisplayed()
        {
            return Driver.FindElements(Objects.Pages.PreviewPage.DownloadRoadmapDocumentLink)
                .Count > 0;
        }

        public bool DownloadAuthorityProvidedDataDocumentLinkIsDisplayed()
        {
            return Driver.FindElements(Objects.Pages.PreviewPage.DownloadAuthorityProvidedDataDocumentLink)
                .Count > 0;
        }

        public string GetNhsAssuredIntegrationsDownloadLinkUrl()
        {
            return Driver.FindElement(Objects.Pages.PreviewPage.DownloadNHSAssuredIntegrationsDocumentLink)
                .GetAttribute("href");
        }

        public string GetRoadmapDownloadLinkUrl()
        {
            return Driver.FindElement(Objects.Pages.PreviewPage.DownloadRoadmapDocumentLink)
                .GetAttribute("href");
        }

        public string GetAuthorityProvidedDataDownloadLinkUrl()
        {
            return Driver.FindElement(Objects.Pages.PreviewPage.DownloadAuthorityProvidedDataDocumentLink)
                .GetAttribute("href");
        }

        private static string ConvertToSectionCssSelector(string sectionName)
        {
            return $"[data-test-id=preview-{sectionName.ToLower().Replace(" ", "-")}";
        }

        private int GetSectionFieldsCount(string sectionName)
        {
            return Driver.FindElement(
                    By.CssSelector(ConvertToSectionCssSelector(sectionName)))
                .FindElements(Objects.Pages.PreviewPage.SectionTitle)
                .Count;
        }
    }
}
