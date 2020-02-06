using FluentAssertions;
using MarketingPageAcceptanceTests.TestData.ContactDetails;
using MarketingPageAcceptanceTests.TestData.Utils;
using MarketingPageAcceptanceTests.Steps.Utils;
using System;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.AboutSolution
{
    [Binding]
    public class LastUpdatedDate : TestBase
    {
        DateTime oldDate = new DateTime(2001, 02, 03);
        public LastUpdatedDate(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that the Solution Summary is updated")]
        public void GivenThatTheSolutionSummaryIsUpdated()
        {
            SqlHelper.UpdateLastUpdated(oldDate, "SolutionDetail", "SolutionId", _test.solution.Id, _test.connectionString);
            _test.pages.Dashboard.NavigateToSection("Solution description");
            _test.pages.SolutionDescription.SummaryAddText(300);
        }

        [Given(@"that the About Solution URL is updated")]
        public void GivenThatTheAboutSolutionURLIsUpdated()
        {
            GivenThatTheSolutionSummaryIsUpdated();
            _test.pages.SolutionDescription.LinkAddText(0, _test.solutionDetail.AboutUrl);
        }

        [Given(@"that the Contact details are updated")]
        public void GivenThatTheContactDetailsAreUpdated()
        {
            var firstContact = GenerateContactDetails.NewContactDetail();
            SqlHelper.CreateContactDetails(_test.solution.Id, firstContact, _test.connectionString);
            SqlHelper.UpdateLastUpdated(oldDate, "MarketingContact", "SolutionId", _test.solution.Id, _test.connectionString);
            var updatedContact = GenerateContactDetails.NewContactDetail();
            _test.pages.Dashboard.NavigateToSection("Contact details");
            _test.pages.ContactDetails.EnterAllData(updatedContact, null, true);
        }

        [When(@"the content has been updated")]
        public void WhenTheContentHasBeenUpdated()
        {
            _test.pages.Common.SectionSaveAndReturn();
            _test.pages.Common.WaitUntilSectionPageNotShownAnymore();
        }

        [Then(@"the Last Changed Date is updated in the (.*) table")]
        public void ThenTheLastChangedDateIsUpdated(string tableName)
        {
            var actualValueFromDB = SqlHelper.GetLastUpdated(tableName, "SolutionId", _test.solution.Id, _test.connectionString);
            actualValueFromDB.Should().BeAfter(oldDate);
        }

    }
}
