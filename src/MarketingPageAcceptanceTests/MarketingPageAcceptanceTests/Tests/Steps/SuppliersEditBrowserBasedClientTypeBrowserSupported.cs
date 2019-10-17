using MarketingPageAcceptanceTests.Utils;
using System;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    [FeatureFile(@".\Tests\Gherkin\SuppliersEditBrowserBasedClientTypeBrowserSupported.txt")]
    public sealed class SuppliersEditBrowserBasedClientTypeBrowserSupported : UITest, IDisposable
    {
        public SuppliersEditBrowserBasedClientTypeBrowserSupported(ITestOutputHelper helper) : base(helper)
        {
        }

        [Given("that an answer is provided to all questions")]
        public void AnswersProvidedAllQuestions()
        {
            throw new NotImplementedException();
        }

        [When("a User saves the page")]
        public void SavesPage()
        {
            throw new NotImplementedException();
        }

        [Then("the Section is marked as 'complete' on the Browser Based Client Type Sub-Form")]
        public void SectionMarkedComplete()
        {
            throw new NotImplementedException();
        }

        [Given("that an answer is not provided to both questions")]
        [Given("that a User has not provided answers for both questions")]
        public void AnswersNotProvided()
        {
            throw new NotImplementedException();
        }

        [Then("the Section is marked as 'incomplete' on the Browser Based Client Type Sub-Form")]
        public void SectionMarkedIncomplete()
        {
            throw new NotImplementedException();
        }

        [Given("that data has been saved in this section")]
        public void DataSavedInSection()
        {
            throw new NotImplementedException();
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
        public void SubmissionTriggersValidation()
        {
            throw new NotImplementedException();
        }

        [And("the User will be informed that they need to answer the Browsers Supported section before they can submit")]
        public void BrowserSupportedValidationMessageDisplayed()
        {
            throw new NotImplementedException();
        }
    }
}
