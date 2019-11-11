using FluentAssertions;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using System;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication.BrowserSupported
{
    [Binding]
    public sealed class BrowserSupported
    {
        private int browsersSupportedCount;
        private UITest _test;
        private ScenarioContext _context;

        public BrowserSupported(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Given(@"that an answer is provided to all Browser supported questions")]
        public void GivenThatAnAnswerIsProvidedToAllQuestions()
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.SelectCheckbox("Browser based");
            _test.pages.ClientApplicationTypes.SaveAndReturn();
            _test.pages.Dashboard.NavigateToSection("Browser based", true);
            _test.pages.BrowserSubDashboard.OpenSection("Browsers supported");

            browsersSupportedCount = new Random().Next(1, 8);
            _test.pages.BrowsersSupported.SelectRandomCheckboxes(browsersSupportedCount);
            _test.pages.BrowsersSupported.SelectRandomRadioButton();
        }

        [Given(@"that data has been saved for Browsers supported")]
        public void GivenThatDataHasBeenSavedInThisSection()
        {
            GivenThatAnAnswerIsProvidedToAllQuestions();
            _test.pages.Common.SectionSaveAndReturn();
            _test.pages.Common.ClickSubDashboardBackLink();
        }

        [Given(@"that an answer is not provided to both questions for Browsers supported")]
        public void GivenThatAnAnswerIsNotProvidedToBothQuestions()
        {
            _test.pages.Dashboard.NavigateToSection("Client application type");
            _test.pages.ClientApplicationTypes.SelectCheckbox("Browser based");
            _test.pages.ClientApplicationTypes.SaveAndReturn();
            _test.pages.Dashboard.NavigateToSection("Browser based", true);

            _test.pages.BrowserSubDashboard.OpenSection("Browsers supported");
        }

        [When(@"a User previews the Marketing Page")]
        public void WhenAUserPreviewsTheMarketingPage()
        {
            _test.pages.Dashboard.NavigateToPreviewPage();
        }

        [Then(@"on the Browser based dashboard")]
        public void NavigateToBrowserBased()
        {
            _test.pages.Dashboard.NavigateToSection("Browser based", true);
        }

        [Then(@"data will be presented on the Preview of the Marketing Page")]
        public void ThenDataWillBePresentedOnThePreviewOfTheMarketingPage()
        {
            _test.pages.PreviewPage.BrowserBasedSectionDisplayed();
            _test.pages.PreviewPage.OpenBrowserBasedSection();
            _test.pages.PreviewPage.SupportedBrowsersCount().Should().Be(browsersSupportedCount);
        }

        [When(@"the User submits their Marketing Page for moderation")]
        public void WhenTheUserSubmitsTheirMarketingPageForModeration()
        {
            _test.driver.Navigate().GoToUrl(_test.url);
            _test.pages.Dashboard.SubmitForModeration();
        }

        [Then(@"the Submission will trigger validation")]
        public void ThenTheSubmissionWillTriggerValidation()
        {
            _test.pages.Common.ErrorMessageDisplayed();
        }

        [Then(@"the User will be informed that they need to answer the Browsers Supported section before they can submit")]
        public void ThenTheUserWillBeInformedThatTheyNeedToAnswerTheBrowsersSupportedSectionBeforeTheyCanSubmit()
        {
            _test.pages.Common.ErrorMessageTextDisplayed("Browser based is a mandatory section");
        }

        [Then(@"the Section is not saved because it is mandatory to answer both questions")]
        public void ThenTheSectionIsNotSavedBecauseItIsMandatoryToAnswerBothQuestions()
        {
        }

        [Then(@"an indication is given to the Supplier as to why")]
        public void ThenAnIndicationIsGivenToTheSupplierAsToWhy()
        {
            _test.pages.Common.ErrorMessageDisplayed();
        }

    }
}
