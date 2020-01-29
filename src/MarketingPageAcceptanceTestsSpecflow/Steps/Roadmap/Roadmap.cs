using FluentAssertions;
using MarketingPageAcceptanceTestsSpecflow.Utils;
using System;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.Roadmap
{
    [Binding]
    public class Roadmap : TestBase
    {
        public Roadmap(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Then(@"the (.*) section is presented")]
        public void ThenTheSectionIsPresented(string section)
        {
            _test.pages.PreviewPage.MainSectionDisplayed(section).Should().BeTrue();
        }
    }
}
