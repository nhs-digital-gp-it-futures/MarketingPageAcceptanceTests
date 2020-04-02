﻿using FluentAssertions;
using MarketingPageAcceptanceTests.StepSetup.Utils;
using MarketingPageAcceptanceTests.TestData.ContactDetails;
using MarketingPageAcceptanceTests.TestData.Solutions;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.Preview
{
    [Binding]
    public class AppearOnPreview : TestBase
    {
        public AppearOnPreview(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"a solution has been created with all data complete")]
        public void GivenASolutionHasBeenCreatedWithAllDataComplete()
        {
            _test.solutionDetail =
                GenerateSolutionDetails.CreateCompleteSolutionDetail(_test.solution.Id,
                    _test.solutionDetail.SolutionDetailId);
            _test.solutionDetail.Update(_test.ConnectionString);
            var contactDetails = GenerateContactDetails.NewContactDetail(_test.solution.Id);
            contactDetails.Create(_test.ConnectionString);
            _test.solution.PublishedStatusId = 3;
            _test.solution.Update(_test.ConnectionString);
        }


        [StepDefinition(@"the (.*) section is presented")]
        public void ThenTheSectionIsPresented(string section)
        {
            _test.Pages.PreviewPage.MainSectionDisplayed(section).Should().BeTrue();
        }

        [StepDefinition(@"the (.*) section is not presented")]
        public void ThenTheSectionIsNotPresented(string section)
        {
            _test.Pages.PreviewPage.MainSectionDisplayed(section).Should().BeFalse();
        }

        [Then(@"there is no call to action to download a file in the Roadmap section")]
        public void ThenThereIsNoCallToActionToDownloadAFileInTheRoadmapSection()
        {
            _test.Pages.PreviewPage.DownloadRoadmapDocumentLinkIsDisplayed().Should().BeFalse();
        }

        [Then(@"there is no call to action to download a file in the Integrations section")]
        public void ThenThereIsNoCallToActionToDownloadAFileInTheIntegrationsSection()
        {
            _test.Pages.PreviewPage.DownloadNhsAssuredIntegrationsDocumentLinkIsDisplayed().Should().BeFalse();
        }
    }
}