using FluentAssertions;
using MarketingPageAcceptanceTests.StepSetup.Utils;
using MarketingPageAcceptanceTests.TestData.ContactDetails;
using MarketingPageAcceptanceTests.TestData.Utils;
using System;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.AboutSolution
{
    [Binding]
    public class LastUpdatedDate : TestBase
    {
        private readonly DateTime oldDate = new DateTime(2001, 02, 03);

        public LastUpdatedDate(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that the Solution Summary is updated")]
        public void GivenThatTheSolutionSummaryIsUpdated()
        {
            LastUpdatedHelper.UpdateLastUpdated(oldDate, "SolutionDetail", "SolutionId", _test.solution.Id,
                _test.ConnectionString);
            _test.Pages.Dashboard.NavigateToSection("Solution description");
            _test.Pages.SolutionDescription.SummaryAddText(300);
        }

        [Given(@"that the About Solution URL is updated")]
        public void GivenThatTheAboutSolutionURLIsUpdated()
        {
            GivenThatTheSolutionSummaryIsUpdated();
            _test.Pages.SolutionDescription.LinkAddText(0, _test.solution.AboutUrl);
        }

        [Given(@"that the Contact details are updated")]
        public void GivenThatTheContactDetailsAreUpdated()
        {
            var firstContact = GenerateContactDetails.NewContactDetail(_test.solution.Id);
            firstContact.Create(_test.ConnectionString);
            LastUpdatedHelper.UpdateLastUpdated(oldDate, "MarketingContact", "SolutionId", _test.solution.Id,
                _test.ConnectionString);
            var updatedContact = GenerateContactDetails.NewContactDetail(_test.solution.Id);
            _test.Pages.Dashboard.NavigateToSection("Contact details");
            _test.Pages.ContactDetails.EnterAllData(updatedContact, null, true);
        }

        [When(@"the content has been updated")]
        public void WhenTheContentHasBeenUpdated()
        {
            _test.Pages.Common.SectionSaveAndReturn();
            _test.Pages.Common.WaitUntilSectionPageNotShownAnymore();
        }

        [Then(@"the Last Changed Date is updated in the (.*) table")]
        public void ThenTheLastChangedDateIsUpdated(string tableName)
        {
            var actualValueFromDB =
                LastUpdatedHelper.GetLastUpdated(tableName, "SolutionId", _test.solution.Id, _test.ConnectionString);
            actualValueFromDB.Should().BeAfter(oldDate);
        }
    }
}