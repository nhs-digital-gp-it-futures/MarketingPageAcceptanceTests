﻿using FluentAssertions;
using MarketingPageAcceptanceTests.TestData.ContactDetails;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Utils;
using MarketingPageAcceptanceTests.Steps.Utils;
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
            _test.solutionDetail = GenerateSolutionDetails.CreateCompleteSolutionDetail(_test.solution.Id, _test.solutionDetail.SolutionDetailId);
            _test.solutionDetail.Update(_test.connectionString);
            var contactDetails = GenerateContactDetails.NewContactDetail(_test.solution.Id);
            contactDetails.Create(_test.connectionString);
        }


        [StepDefinition(@"the (.*) section is presented")]
        public void ThenTheSectionIsPresented(string section)
        {
            _test.pages.PreviewPage.MainSectionDisplayed(section).Should().BeTrue();
        }

        [StepDefinition(@"the (.*) section is not presented")]
        public void ThenTheSectionIsNotPresented(string section)
        {
            _test.pages.PreviewPage.MainSectionDisplayed(section).Should().BeFalse();
        }

        [Then(@"there is no call to action to download a file in the (Roadmap) section")]
        public void ThenThereIsNoCallToActionToDownloadAFileInTheRoadmapSection(string section)
        {
            _test.pages.PreviewPage.DownloadLinkInSectionIsDisplayed(section).Should().BeFalse();
        }

    }
}
