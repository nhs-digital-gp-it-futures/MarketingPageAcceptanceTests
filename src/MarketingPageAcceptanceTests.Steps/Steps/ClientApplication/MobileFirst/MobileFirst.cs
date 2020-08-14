using MarketingPageAcceptanceTests.Steps.Utils;
using System;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.MobileFirst
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
            _test.Pages.Dashboard.NavigateToSection(subDashboard, true);
            _test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection("Mobile first approach");

            var choice = new Random().Next() > int.MaxValue / 2 ? "Yes" : "No";

            _test.Pages.BrowserBasedSections.MobileFirst.SelectRadioButton(choice);
        }
    }
}