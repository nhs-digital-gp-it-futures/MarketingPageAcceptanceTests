namespace MarketingPageAcceptanceTests.Steps.Steps.Preview
{
    using System.Threading.Tasks;
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using MarketingPageAcceptanceTests.TestData.ContactDetails;
    using MarketingPageAcceptanceTests.TestData.Solutions;
    using TechTalk.SpecFlow;

    [Binding]
    public class AppearOnPreview : TestBase
    {
        public AppearOnPreview(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"a solution has been created with all data complete")]
        public async Task GivenASolutionHasBeenCreatedWithAllDataCompleteAsync()
        {
            await test.Solution.DeleteAsync(test.ConnectionString);
            test.Solution = GenerateSolution.GenerateCompleteSolution(test.CatalogueItem.CatalogueItemId);
            await test.Solution.CreateAsync(test.ConnectionString);
            var contactDetails = GenerateContactDetails.NewContactDetail(test.Solution.Id);
            await contactDetails.CreateAsync(test.ConnectionString);
            test.CatalogueItem.PublishedStatusId = 3;
            await test.CatalogueItem.UpdateAsync(test.ConnectionString);
            await test.FrameworkSolution.Delete(test.ConnectionString);
            test.FrameworkSolution = new FrameworkSolution { SolutionId = test.Solution.Id, FrameworkId = "NHSDGP001", IsFoundation = false };
            await test.FrameworkSolution.Create(test.ConnectionString);
        }

        [StepDefinition(@"the (.*) section is presented")]
        public void ThenTheSectionIsPresented(string section)
        {
            test.Pages.PreviewPage.MainSectionDisplayed(section).Should().BeTrue();
        }

        [StepDefinition(@"the (.*) section is not presented")]
        public void ThenTheSectionIsNotPresented(string section)
        {
            test.Pages.PreviewPage.MainSectionDisplayed(section).Should().BeFalse();
        }

        [Then(@"there is no call to action to download a file in the Roadmap section")]
        public void ThenThereIsNoCallToActionToDownloadAFileInTheRoadmapSection()
        {
            test.Pages.PreviewPage.DownloadRoadmapDocumentLinkIsDisplayed().Should().BeFalse();
        }

        [Then(@"there is no call to action to download a file in the Integrations section")]
        public void ThenThereIsNoCallToActionToDownloadAFileInTheIntegrationsSection()
        {
            test.Pages.PreviewPage.DownloadNhsAssuredIntegrationsDocumentLinkIsDisplayed().Should().BeFalse();
        }
    }
}
