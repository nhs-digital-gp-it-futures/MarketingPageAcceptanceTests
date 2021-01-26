namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.BrowserSupported
{
    using System;
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class BrowserSupported : TestBase
    {
        private int browsersSupportedCount;

        public BrowserSupported(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that an answer is provided to all Browser supported questions")]
        public void GivenThatAnAnswerIsProvidedToAllQuestions()
        {
            test.Pages.Dashboard.NavigateToSection("Client application type");
            test.Pages.ClientApplicationTypes.SelectCheckbox("Browser-based");
            test.Pages.ClientApplicationTypes.SaveAndReturn();
            test.Pages.Dashboard.NavigateToSection("Browser-based", true);
            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection("Supported browsers");

            browsersSupportedCount = new Random().Next(1, 8);
            test.Pages.BrowserBasedSections.BrowsersSupported.SelectRandomCheckboxes(browsersSupportedCount);
            test.Pages.BrowserBasedSections.BrowsersSupported.SelectRandomRadioButton();
        }

        [Given(@"that data has been saved for Browsers supported")]
        public void GivenThatDataHasBeenSavedInThisSection()
        {
            GivenThatAnAnswerIsProvidedToAllQuestions();
            test.Pages.Common.SectionSaveAndReturn();
            test.Pages.Common.ClickSubDashboardBackLink();
        }

        [Given(@"that an answer is not provided to both questions for Browsers supported")]
        public void GivenThatAnAnswerIsNotProvidedToBothQuestions()
        {
            test.Pages.Dashboard.NavigateToSection("Client application type");
            test.Pages.ClientApplicationTypes.SelectCheckbox("Browser-based");
            test.Pages.ClientApplicationTypes.SaveAndReturn();
            test.Pages.Dashboard.NavigateToSection("Browser-based", true);

            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection("Supported browsers");
        }

        [StepDefinition(@"a User previews the Marketing Page")]
        public void WhenAUserPreviewsTheMarketingPage()
        {
            test.Pages.Dashboard.NavigateToPreviewPage();
        }

        [Then(@"on the (.*) dashboard")]
        public void NavigateToSubDashboard(string subDashboard)
        {
            test.Pages.Dashboard.NavigateToSection(subDashboard, true);
        }

        [Then(@"data will be presented on the Preview of the Marketing Page")]
        public void ThenDataWillBePresentedOnThePreviewOfTheMarketingPage()
        {
            test.Pages.PreviewPage.BrowserBasedSectionDisplayed();
            test.Pages.PreviewPage.OpenBrowserBasedSection();
            test.Pages.PreviewPage.SupportedBrowsersCount().Should().Be(browsersSupportedCount);
        }

        [When(@"the User submits their Marketing Page for moderation")]
        public void WhenTheUserSubmitsTheirMarketingPageForModeration()
        {
            test.Driver.Navigate().GoToUrl(test.Url);
            test.Pages.Dashboard.SubmitForModeration();
        }

        [Then(
            @"the User will be informed that they need to answer the Browsers Supported section before they can submit")]
        public void ThenTheUserWillBeInformedThatTheyNeedToAnswerTheBrowsersSupportedSectionBeforeTheyCanSubmit()
        {
            test.Pages.Common.ErrorMessageTextDisplayed("Provide mandatory information for browser-based application");
        }
    }
}
