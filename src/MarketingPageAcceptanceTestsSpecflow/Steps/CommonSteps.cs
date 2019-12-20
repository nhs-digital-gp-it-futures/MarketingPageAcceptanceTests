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

        [When(@"a User saves the page")]
        public void WhenAUserSavesThePage()
        {
            _test.pages.Common.SectionSaveAndReturn();
        }

        [Then(@"(.*) will be presented on the Preview of the Marketing Page")]
        public void ThenSectionWillBePresentedOnThePreviewOfTheMarketingPage(string section)
        {
            _test.pages.PreviewPage.OpenBrowserBasedSection();
            _test.pages.PreviewPage.SectionDisplayed(section);
        }

        [Then(@"(.*) will be presented in (.*) on the Preview of the Marketing Page")]
        public void ThenSupportedOperatingSystemsWillBePresentedInNativeMobileOrTabletOnThePreviewOfTheMarketingPage(string section, string subDashboard)
        {
            _test.pages.PreviewPage.ExpandSection(subDashboard);
            _test.pages.PreviewPage.SectionDisplayed(section);
        }


        [When(@"the User exits the page")]
        public void WhenTheUserExitsThePage()
        {
            _test.pages.Common.ClickSectionBackLink();
        }

        [StepDefinition(@"the User attempts to save")]
        public void WhenTheUserAttemptsToSave()
        {
            _test.pages.Common.SectionSaveAndReturn();
        }
    }
}
