using FluentAssertions;
using MarketingPageAcceptanceTests.TestData.ContactDetails;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Utils;
using MarketingPageAcceptanceTestsSpecflow.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.Steps.Preview
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


        [Then(@"the (.*) section is presented")]
        public void ThenTheSectionIsPresented(string section)
        {
            _test.pages.PreviewPage.MainSectionDisplayed(section).Should().BeTrue();
        }
    }
}
