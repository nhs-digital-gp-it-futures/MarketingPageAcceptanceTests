using System;
using FluentAssertions;
using MarketingPageAcceptanceTests.TestData.Utils;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.AboutSolution
{
    [Binding]
    public class LastUpdatedDate
    {
        private UITest _test;
        private ScenarioContext _context;
        DateTime oldDate = new DateTime(2001, 02, 03);
        public LastUpdatedDate(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        private void SetLastUpdatedDateToAnOlderDate()
        {
            SqlHelper.UpdateLastUpdated(oldDate, "SolutionDetail", "SolutionId", _test.solution.Id, _test.connectionString);
        }

        [Given(@"that the Solution Summary is updated")]
        public void GivenThatTheSolutionSummaryIsUpdated()
        {
            SetLastUpdatedDateToAnOlderDate();
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
            _context.Pending();
        }
        
        [When(@"the content has been updated")]
        public void WhenTheContentHasBeenUpdated()
        {
            _test.pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the Last Changed Date is updated in the (.*) table")]
        public void ThenTheLastChangedDateIsUpdated(string tableName)
        {
            var actualValueFromDB = SqlHelper.GetLastUpdated(tableName, "SolutionId", _test.solution.Id, _test.connectionString);
            actualValueFromDB.Should().BeAfter(oldDate);
        }

    }
}
