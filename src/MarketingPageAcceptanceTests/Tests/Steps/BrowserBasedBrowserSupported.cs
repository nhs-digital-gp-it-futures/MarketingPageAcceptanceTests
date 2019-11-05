using MarketingPageAcceptanceTests.Utils;
using System;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile(@".\Tests\Gherkin\BrowserBasedBrowserSupported.txt")]
    public sealed class BrowserBasedBrowserSupported : UITest, IDisposable
    {
        int browsersSupportedCount;
        public BrowserBasedBrowserSupported(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that an answer is provided to all questions")]
        [Given("that data has been saved in this section")]
        public void AnswersProvidedAllQuestions()
        {
            pages.Dashboard.NavigateToSection("Client application type");
            pages.ClientApplicationTypes.SelectCheckbox("Browser based");
            pages.ClientApplicationTypes.SaveAndReturn();
            pages.Dashboard.NavigateToSection("Browser based", true);
            pages.BrowserSubDashboard.OpenSection("Browsers supported");

            browsersSupportedCount = new Random().Next(8);
            pages.BrowsersSupported.SelectRandomCheckboxes(browsersSupportedCount);
            pages.BrowsersSupported.SelectRandomRadioButton();
        }

        [When("a User saves the page")]
        public void SavesPage()
        {
            pages.BrowsersSupported.SaveAndReturn();
        }

        [Then("the Section is marked as 'complete' on the Browser Based Client Type Sub-Form")]
        public void SectionMarkedComplete()
        {
            pages.Dashboard.SectionCompleteStatus("Browsers supported");
        }

        [Given("that an answer is not provided to both questions")]
        [Given("that a User has not provided answers for both questions")]
        public void AnswersNotProvided()
        {
            pages.Dashboard.NavigateToSection("Client application type");
            pages.ClientApplicationTypes.SelectCheckbox("Browser based");
            pages.ClientApplicationTypes.SaveAndReturn();
            pages.Dashboard.NavigateToSection("Browser based", true);

            pages.BrowserSubDashboard.OpenSection("Browsers supported");
        }

        [Then("the Section is marked as 'incomplete' on the Browser Based Client Type Sub-Form")]
        public void SectionMarkedIncomplete()
        {
            pages.Dashboard.SectionIncomplete("Browsers supported");
        }

        [Then("data will be presented on the Preview of the Marketing Page")]
        public void DataPresentedOnPreview()
        {
            throw new NotImplementedException();
        }

        [When("the User submits their Marketing Page for moderation")]
        public void MarketingPageSubmitted()
        {
            throw new NotImplementedException();
        }

        [Then("the Submission will trigger validation")]
        [Then("the Section is not saved because it is mandatory to answer both questions")]
        public void SubmissionTriggersValidation()
        {
            throw new NotImplementedException();
        }

        [And("the User will be informed that they need to answer the Browsers Supported section before they can submit")]
        [And("an indication is given to the Supplier as to why")]
        public void BrowserSupportedValidationMessageDisplayed()
        {
            throw new NotImplementedException();
        }

        
    }
}
