﻿using System;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication.MobileFirst
{
    [Binding]
    public class MobileFirst : TestBase
    {

        public MobileFirst(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"that an answer is provided to the mobile first question")]
        public void GivenThatAnAnswerIsProvidedToTheMobileFirstQuestion()
        {
            _test.pages.Dashboard.NavigateToSection("Browser based", true);
            _test.pages.BrowserSubDashboard.OpenSection("Mobile first");

            var choice = new Random().Next() > (int.MaxValue / 2) ? "Yes" : "No";

            _test.pages.MobileFirst.SelectRadioButton(choice);
        }
    }
}
