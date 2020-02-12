using FluentAssertions;
using MarketingPageAcceptanceTests.Steps.Utils;
using MarketingPageAcceptanceTests.TestData.Capabilities;
using MarketingPageAcceptanceTests.TestData.Utils;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.Steps.Steps.Authority.Capabilities
{
    [Binding]
    public class DisplaySolutionsCapabilities : TestBase
    {
        IEnumerable<SolutionCapabilities> solutionCaps;

        public DisplaySolutionsCapabilities(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that Capabilities have been provided for the Solution")]
        public void GivenThatCapabilitiesHaveBeenProvidedForTheSolution()
        {
            solutionCaps = CapabilitiesGenerator.GenerateListOfSolutionCapabilities(_test.connectionString, _test.solution.Id);
            var csv = solutionCaps.ToCsv();

            _test.pages.Dashboard.NavigateToSection("Capabilities");

            _test.pages.Capabilities.EnterText(csv);

            _test.pages.Common.SectionSaveAndReturn();
        }
        
        [Then(@"the Capability Name")]
        public void ThenTheCapabilityName()
        {
            _test.pages.Capabilities.GetCapabilityNames().Should().HaveCount(solutionCaps.Count());
        }
        
        [Then(@"Capability Version")]
        public void ThenCapabilityVersion()
        {
            _test.pages.Capabilities.GetCapabilityVersions().Should().HaveCount(solutionCaps.Count());
        }
        
        [Then(@"Capability Description")]
        public void ThenCapabilityDescription()
        {
            _test.pages.Capabilities.GetCapabilityDescriptions().Should().HaveCount(solutionCaps.Count());
        }
        
        [Then(@"'(.*)' Capability URL")]
        public void ThenCapabilityURL(string p0)
        {
            _test.pages.Capabilities.GetCapabilityUrls().Should().HaveCount(solutionCaps.Count());
        }
        
        [Then(@"the Capability URL will direct to a page that contains more content about the Capability")]
        public void ThenTheCapabilityURLWillDirectToAPageThatContainsMoreContentAboutTheCapability()
        {
            _context.Pending();
        }

        [Given(@"that Epics for the Capability are provided")]
        public void GivenThatEpicsForTheCapabilityAreProvided()
        {
            _context.Pending();
        }

        [Then(@"the Epic titles are visible")]
        public void ThenTheEpicTitlesAreVisible()
        {
            _context.Pending();
        }

        [Given(@"that Epic Pass or Fail Statuses have been provided for each Epic")]
        public void GivenThatEpicPassOrFailStatusesHaveBeenProvidedForEachEpic()
        {
            _context.Pending();
        }

        [Then(@"the Epic pass or fail status is visible")]
        public void ThenTheEpicPassOrFailStatusIsVisible()
        {
            _context.Pending();
        }

        [Then(@"the Epic IDs are displayed")]
        public void ThenTheEpicIDsAreDisplayed()
        {
            _context.Pending();
        }

        [Then(@"the Epics are displayed as Must or May Epics")]
        public void ThenTheEpicsAreDisplayedAsMustOrMayEpics()
        {
            _context.Pending();
        }
    }
}
