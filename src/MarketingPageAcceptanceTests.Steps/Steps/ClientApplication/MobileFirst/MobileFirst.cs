using MarketingPageAcceptanceTestsSpecflow.Steps.Utils;
using System;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.Steps.ClientApplication.MobileFirst
{
    [Binding]
    public class MobileFirst : TestBase
    {

        public MobileFirst(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"that an answer is provided to the (.*) mobile first question")]
        public void GivenThatAnAnswerIsProvidedToTheMobileFirstQuestion(string subDashboard)
        {
            _test.pages.Dashboard.NavigateToSection(subDashboard, true);
            _test.pages.BrowserBasedSections.BrowserSubDashboard.OpenSection("Mobile first");

            var choice = new Random().Next() > (int.MaxValue / 2) ? "Yes" : "No";

            _test.pages.BrowserBasedSections.MobileFirst.SelectRadioButton(choice);
        }
    }
}
