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

        [Then(@"the Roadmap section is presented")]
        public void ThenTheRoadmapSectionIsPresented()
        {
            _test.pages.PreviewPage.RoadmapSectionDisplayed().Should().BeTrue();
        }
    }
}
