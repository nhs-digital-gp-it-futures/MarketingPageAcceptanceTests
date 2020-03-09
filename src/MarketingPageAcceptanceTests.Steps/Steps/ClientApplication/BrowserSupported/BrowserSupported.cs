using System;
using FluentAssertions;
using MarketingPageAcceptanceTests.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.BrowserSupported
{
    [Binding]
    public sealed class BrowserSupported : TestBase
    {
        private int browsersSupportedCount;

        public BrowserSupported(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that an answer is provided to all Browser supported questions")]
        public void GivenThatAnAnswerIsProvidedToAllQuestions()
        {
            _test.Pages.Dashboard.NavigateToSection("Client application type");
            _test.Pages.ClientApplicationTypes.SelectCheckbox("Browser-based");
            _test.Pages.ClientApplicationTypes.SaveAndReturn();
            _test.Pages.Dashboard.NavigateToSection("Browser-based", true);
            _test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection("Supported browsers");

            browsersSupportedCount = new Random().Next(1, 8);
            _test.Pages.BrowserBasedSections.BrowsersSupported.SelectRandomCheckboxes(browsersSupportedCount);
            _test.Pages.BrowserBasedSections.BrowsersSupported.SelectRandomRadioButton();
        }

        [Given(@"that data has been saved for Browsers supported")]
        public void GivenThatDataHasBeenSavedInThisSection()
        {
            GivenThatAnAnswerIsProvidedToAllQuestions();
            _test.Pages.Common.SectionSaveAndReturn();
            _test.Pages.Common.ClickSubDashboardBackLink();
        }

        [Given(@"that an answer is not provided to both questions for Browsers supported")]
        public void GivenThatAnAnswerIsNotProvidedToBothQuestions()
        {
            _test.Pages.Dashboard.NavigateToSection("Client application type");
            _test.Pages.ClientApplicationTypes.SelectCheckbox("Browser-based");
            _test.Pages.ClientApplicationTypes.SaveAndReturn();
            _test.Pages.Dashboard.NavigateToSection("Browser-based", true);

            _test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection("Supported browsers");
        }

        [StepDefinition(@"a User previews the Marketing Page")]
        public void WhenAUserPreviewsTheMarketingPage()
        {
            _test.Pages.Dashboard.NavigateToPreviewPage();
        }

        [Then(@"on the (.*) dashboard")]
        public void NavigateToSubDashboard(string subDashboard)
        {
            _test.Pages.Dashboard.NavigateToSection(subDashboard, true);
        }

        [Then(@"data will be presented on the Preview of the Marketing Page")]
        public void ThenDataWillBePresentedOnThePreviewOfTheMarketingPage()
        {
            _test.Pages.PreviewPage.BrowserBasedSectionDisplayed();
            _test.Pages.PreviewPage.OpenBrowserBasedSection();
            _test.Pages.PreviewPage.SupportedBrowsersCount().Should().Be(browsersSupportedCount);
        }

        [When(@"the User submits their Marketing Page for moderation")]
        public void WhenTheUserSubmitsTheirMarketingPageForModeration()
        {
            _test.Driver.Navigate().GoToUrl(_test.url);
            _test.Pages.Dashboard.SubmitForModeration();
        }

        [Then(
            @"the User will be informed that they need to answer the Browsers Supported section before they can submit")]
        public void ThenTheUserWillBeInformedThatTheyNeedToAnswerTheBrowsersSupportedSectionBeforeTheyCanSubmit()
        {
            _test.Pages.Common.ErrorMessageTextDisplayed("Provide mandatory information for browser-based application");
        }

        [Then(@"the Section is not saved because it is mandatory to answer both questions")]
        public void ThenTheSectionIsNotSavedBecauseItIsMandatoryToAnswerBothQuestions()
        {
        }
    }
}