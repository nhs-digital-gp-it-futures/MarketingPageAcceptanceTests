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

        [Given(@"the user has set Browser based application type")]
        public void GivenTheUserHasSetBrowserBasedApplicationType()
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.SelectCheckbox("Browser based");
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

    }
}
