namespace MarketingPageAcceptanceTests.Steps.Steps.AboutSolution
{
    using System;
    using System.Threading.Tasks;
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using MarketingPageAcceptanceTests.TestData.ContactDetails;
    using MarketingPageAcceptanceTests.TestData.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class LastUpdatedDate : TestBase
    {
        private readonly DateTime oldDate = new(2001, 02, 03);

        public LastUpdatedDate(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that the Solution Summary is updated")]
        public async Task GivenThatTheSolutionSummaryIsUpdatedAsync()
        {
            await LastUpdatedHelper.UpdateLastUpdatedAsync(
                oldDate,
                "Solution",
                "Id",
                test.Solution.Id,
                test.ConnectionString);
            test.Pages.Dashboard.NavigateToSection("Solution description");
            test.Pages.SolutionDescription.SummaryAddText(300);
        }

        [Given(@"that the About Solution URL is updated")]
        public async Task GivenThatTheAboutSolutionURLIsUpdatedAsync()
        {
            await GivenThatTheSolutionSummaryIsUpdatedAsync();
            test.Pages.SolutionDescription.LinkAddText(0, test.Solution.AboutUrl);
        }

        [Given(@"that the Contact details are updated")]
        public async Task GivenThatTheContactDetailsAreUpdatedAsync()
        {
            var firstContact = GenerateContactDetails.NewContactDetail(test.Solution.Id);
            await firstContact.CreateAsync(test.ConnectionString);
            await LastUpdatedHelper.UpdateLastUpdatedAsync(
                oldDate,
                "MarketingContact",
                "SolutionId",
                test.Solution.Id,
                test.ConnectionString);
            var updatedContact = GenerateContactDetails.NewContactDetail(test.Solution.Id);
            test.Pages.Dashboard.NavigateToSection("Contact details");
            test.Pages.ContactDetails.EnterAllData(updatedContact, null, true);
        }

        [When(@"the content has been updated")]
        public void WhenTheContentHasBeenUpdated()
        {
            test.Pages.Common.SectionSaveAndReturn();
            test.Pages.Common.WaitUntilSectionPageNotShownAnymore();
        }

        [Then(@"the Last Changed Date is updated in the (Solution) table")]
        public async Task ThenTheLastChangedDateSolutionIsUpdatedAsync(string tableName)
        {
            var actualValueFromDB =
                await LastUpdatedHelper.GetLastUpdatedAsync(tableName, "Id", test.Solution.Id, test.ConnectionString);
            actualValueFromDB.Should().BeAfter(oldDate);
        }

        [Then(@"the Last Changed Date is updated in the (MarketingContact) table")]
        public async Task ThenTheLastChangedDateMarketingContactIsUpdatedAsync(string tableName)
        {
            var actualValueFromDB =
                await LastUpdatedHelper.GetLastUpdatedAsync(tableName, "SolutionId", test.Solution.Id, test.ConnectionString);
            actualValueFromDB.Should().BeAfter(oldDate);
        }
    }
}
