using FluentAssertions;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps
{
    [Binding]
    public sealed class CommonSteps : TestBase
    {
        public CommonSteps(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"the user has set (.*) application type")]
        public void GivenTheUserHasSetBrowserBasedApplicationType(string clientType)
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.SelectCheckbox(clientType);
            _test.pages.ClientApplicationTypes.SaveAndReturn();
        }

        [Given(@"validation has been triggered on (.*) section")]
        public void GivenValidationHasBeenTriggeredOnSection(string section)
        {
            _test.pages.Dashboard.NavigateToSection(section);
            _test.pages.SolutionDescription.SaveAndReturn();
            _test.pages.Common.ErrorMessageDisplayed();
        }

        [When(@"the User selects an error link in the Error Summary")]
        public void WhenTheUserSelectsAnErrorLinkInTheErrorSummary()
        {
            _test.ExpectedSectionLinkInErrorMessage = _test.pages.Common.ClickOnErrorLink();
        }

        [When("the Marketing Page Form is presented")]
        public void MarketingPageFormPresented()
        {
            _test.pages.Dashboard.PageDisplayed();
        }

        [Then(@"(.*) will be presented in the (.*) section on the Preview of the Marketing Page")]
        public void ThenSectionWillBePresentedOnThePreviewOfTheMarketingPage(string section, string subSection)
        {
            _test.pages.PreviewPage.ExpandSection(subSection);
            _test.pages.PreviewPage.SectionDisplayed(section);
        }

        [Then(@"(.*) will be presented in (.*) on the Preview of the Marketing Page")]
        public void ThenSupportedOperatingSystemsWillBePresentedInNativeMobileOrTabletOnThePreviewOfTheMarketingPage(string section, string subDashboard)
        {
            _test.pages.PreviewPage.ExpandSection(subDashboard);
            _test.pages.PreviewPage.SectionDisplayed(section);
        }

        [Then(@"(.*) will not be presented in (.*) on the Preview of the Marketing Page")]
        public void ThenSupportedOperatingSystemsWillNotBePresentedInNativeMobileOrTabletOnThePreviewOfTheMarketingPage(string section, string subDashboard)
        {
            _test.pages.PreviewPage.ExpandSection(subDashboard);
            _test.pages.PreviewPage.SectionNotDisplayed(section);
        }

        [When(@"the User exits the page")]
        public void WhenTheUserExitsThePage()
        {
            _test.pages.Common.ClickSectionBackLink();
        }

        [When(@"a User saves the page")]
        [StepDefinition(@"the User attempts to save")]
        public void WhenTheUserAttemptsToSave()
        {
            _test.pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the (.*) content validation status is displayed")]
        public void ThenTheClientApplicationTypeContentValidationStatusIsDisplayed(string section)
        {
            _test.pages.Dashboard.SectionHasStatus(section).Should().BeTrue();
        }

        [Then(@"the (Supplier|User) is able to manage the (.*) Marketing Page (Dashboard|Form Section)")]
        public void ThenTheSupplierIsAbleToManageTheMarketingPageFormSection(string user, string section, string pageType)
        {
            _test.pages.Dashboard.NavigateToSection(section, pageType == "Dashboard");
        }

        [Then(@"the (.*) (Sub-Section|section) is marked as (Incomplete|Complete)")]
        public void ThenTheBrowserBasedClientApplicationTypeSub_SectionIsMarkedAsStatus(string sectionName, string sectionOrSubSection, string status)
        {
            _test.pages.Dashboard.AssertSectionStatus(sectionName, status.ToUpper());
        }
    }
}
