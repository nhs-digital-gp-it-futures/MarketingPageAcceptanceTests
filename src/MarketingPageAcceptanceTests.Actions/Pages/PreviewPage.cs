using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MarketingPageAcceptanceTests.TestData.ContactDetails;
using OpenQA.Selenium;

namespace MarketingPageAcceptanceTests.Actions.Pages
{
    public sealed class PreviewPage : PageAction
    {
        public PreviewPage(IWebDriver driver) : base(driver)
        {

        }

        /// <summary>
        /// Assures the page is displayed
        /// </summary>
        public void PageDisplayed()
        {
            wait.Until(s => s.FindElement(pages.PreviewPage.PageTitle).Displayed);
        }

        /// <returns>value of mandatory field - summary of a solution</returns>
        public string GetSolutionSummaryText()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionSummarySection)
                .FindElement(pages.PreviewPage.SectionDataText).Text;
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
                .FindElement(pages.PreviewPage.SectionDataText).Text;
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
                .FindElement(pages.PreviewPage.SectionDataLink).Text;
        }

        public void SectionDisplayed(string section)
        {
            driver.FindElements(pages.PreviewPage.BrowserBasedSectionTitles)
                .Where(s => s.Text.ToLower().Contains(section.ToLower()))
                .Count().Should().BeGreaterThan(0);
        }

        public IWebElement GetSolutionLink()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionLinkSection)
                .FindElement(pages.PreviewPage.SectionDataLink);
        }

        /// <returns>list of features</returns>
        public IList<string> GetFeaturesText()
        {
            var features = driver.FindElement(pages.PreviewPage.FeaturesSection).FindElements(By.CssSelector("li label.nhsuk-label")).Select(s => s.Text);
            return features.ToList();
        }

        public IContactDetail ContactDisplayedOnPreview()
        {
            var contact = new ContactDetail();
            var fullName = driver.FindElement(pages.PreviewPage.ContactName).Text.Split(' ');
            contact.FirstName = fullName[0];
            contact.LastName = fullName[1];
            contact.JobSector = driver.FindElement(pages.PreviewPage.ContactDepartment).Text;
            contact.EmailAddress = driver.FindElement(pages.PreviewPage.ContactEmail).Text;
            contact.PhoneNumber = driver.FindElement(pages.PreviewPage.ContactPhoneNumber).Text;
            return contact;
        }

        /// <returns>title of the 'Solution description' section</returns>
        public string GetSolutionDescriptionContainerTitle()
        {
            return driver.FindElement(pages.PreviewPage.SolutionDescriptionContainer)
                .FindElement(By.ClassName("nhsuk_title")).Text;
        }

        public void BrowserBasedSectionDisplayed()
        {
            driver.FindElement(pages.PreviewPage.BrowserBasedSection).Displayed.Should().BeTrue();
        }

        public void OpenBrowserBasedSection()
        {
            driver.FindElement(pages.PreviewPage.BrowserBasedSection).Click();
        }

        public int SupportedBrowsersCount()
        {
            return driver.FindElements(pages.PreviewPage.SupportedBrowsers).Count;
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
            return $"[data-test-id=preview-{sectionName.ToLower().Replace(" ", "-")}";
        }

        public void AssertSectionHasMandatoryFields(string sectionName, int numFields)
        {
            GetSectionFieldsCount(sectionName).Should().Be(numFields);
        }

    }
}
