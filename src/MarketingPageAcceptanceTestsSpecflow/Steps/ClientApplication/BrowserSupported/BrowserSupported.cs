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

        [Given(@"that an answer is provided to all questions")]
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

        [Given(@"that data has been saved in this section")]
        public void GivenThatDataHasBeenSavedInThisSection()
        {
            GivenThatAnAnswerIsProvidedToAllQuestions();
            WhenAUserSavesThePage();
            _test.pages.Common.ClickSubDashboardBackLink();
        }

        [When(@"a User saves the page")]
        public void WhenAUserSavesThePage()
        {
            _test.pages.BrowsersSupported.SaveAndReturn();
        }

        [Then(@"the Section is marked as (COMPLETE|INCOMPLETE) on the Browser Based Client Type Sub-Form")]
        public void ThenTheSectionIsMarkedAsOnTheBrowserBasedClientTypeSub_Form(string status)
        {
            _test.pages.Dashboard.AssertSectionStatus("Browsers supported", status);
        }

        [Given(@"that an answer is not provided to both questions")]
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

        [Then(@"data will be presented on the Preview of the Marketing Page")]
        public void ThenDataWillBePresentedOnThePreviewOfTheMarketingPage()
        {
            _test.pages.PreviewPage.BrowserBasedSectionDisplayed();
            _test.pages.PreviewPage.OpenBrowserBasedSection();
            _test.pages.PreviewPage.SupportedBrowsersCount().Should().Be(browsersSupportedCount);
        }

        [Given(@"that a User has not provided answers for both questions")]
        public void GivenThatAUserHasNotProvidedAnswersForBothQuestions()
        {
            _context.Pending();
        }

        [When(@"the User submits their Marketing Page for moderation")]
        public void WhenTheUserSubmitsTheirMarketingPageForModeration()
        {
            _context.Pending();
        }

        [Then(@"the Submission will trigger validation")]
        public void ThenTheSubmissionWillTriggerValidation()
        {
            _context.Pending();
        }

        [Then(@"the User will be informed that they need to answer the Browsers Supported section before they can submit")]
        public void ThenTheUserWillBeInformedThatTheyNeedToAnswerTheBrowsersSupportedSectionBeforeTheyCanSubmit()
        {
            _context.Pending();
        }

        [Then(@"the Section is not saved because it is mandatory to answer both questions")]
        public void ThenTheSectionIsNotSavedBecauseItIsMandatoryToAnswerBothQuestions()
        {
            _context.Pending();
        }

        [Then(@"an indication is given to the Supplier as to why")]
        public void ThenAnIndicationIsGivenToTheSupplierAsToWhy()
        {
            _test.pages.Common.ErrorMessageDisplayed();
        }

    }
}
