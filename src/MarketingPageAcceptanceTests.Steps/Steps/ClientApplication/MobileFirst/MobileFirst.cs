namespace MarketingPageAcceptanceTests.Steps.Steps.ClientApplication.MobileFirst
{
    using System;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class MobileFirst : TestBase
    {
        public MobileFirst(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that an answer is provided to the (.*) mobile first question")]
        public void GivenThatAnAnswerIsProvidedToTheMobileFirstQuestion(string subDashboard)
        {
            test.Pages.Dashboard.NavigateToSection(subDashboard, true);
            test.Pages.BrowserBasedSections.BrowserSubDashboard.OpenSection("Mobile first approach");

            var choice = new Random().Next() > int.MaxValue / 2 ? "Yes" : "No";

            test.Pages.BrowserBasedSections.MobileFirst.SelectRadioButton(choice);
        }
    }
}
