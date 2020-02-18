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
        IEnumerable<EpicDto> solutionEpics;

        public DisplaySolutionsCapabilities(UITest test, ScenarioContext context) : base(test, context)
        {   
        }

        [Given(@"that Capabilities have been provided for the Solution")]
        public void GivenThatCapabilitiesHaveBeenProvidedForTheSolution()
        {
            GenerateCapabilitiesAndEpics();
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
        [Given(@"that Epic Pass or Fail Statuses have been provided for each Epic")]
        public void GivenThatEpicsForTheCapabilityAreProvided()
        {   
            GivenThatCapabilitiesHaveBeenProvidedForTheSolution();
            var csv = solutionEpics.ToCsv();

            _test.pages.Dashboard.NavigateToSection("Epics");

            _test.pages.Capabilities.EnterText(csv);

            _test.pages.Common.SectionSaveAndReturn();            
        }

        [Then(@"the Epic titles are visible")]
        public void ThenTheEpicTitlesAreVisible()
        {
            _test.pages.PreviewPage.OpenCapabilityAccordians();
        }        

        [Then(@"the Epic pass or fail status is visible")]
        public void ThenTheEpicPassOrFailStatusIsVisible()
        {
            _test.pages.PreviewPage.EpicsHaveStatusSymbols(solutionEpics.Count());
        }

        [Then(@"the Epic IDs are displayed")]
        public void ThenTheEpicIDsAreDisplayed()
        {
            _test.pages.PreviewPage.EpicIdsDisplayed(solutionEpics.Select(s => s.Id));
        }

        [Then(@"the Epics are displayed as Must or May Epics")]
        public void ThenTheEpicsAreDisplayedAsMustOrMayEpics()
        {
            _test.pages.PreviewPage.MustSectionCount(solutionCaps.Count());
            _test.pages.PreviewPage.MaySectionCount(solutionCaps.Count());            
        }

        [Given(@"that Epics are provided for Capabilities not provided")]
        public void GivenThatEpicsAreProvidedForCapabilitiesNotProvided()
        {
            GenerateCapabilitiesAndEpics();
            GivenThatCapabilitiesHaveBeenProvidedForTheSolution();

            var csv = CapabilitiesGenerator.GenerateEpicsForCapabilityNotSelected(_test.connectionString, solutionCaps, _test.solution).ToCsv();

            _test.pages.Dashboard.NavigateToSection("Epics");

            _test.pages.Capabilities.EnterText(csv);
        }

        [Then(@"the User remains on the Epics page")]
        public void ThenTheUserRemainsOnTheEpicsPage()
        {
            _test.pages.Dashboard.SectionHasTitle("Epics");
        }



        private void GenerateCapabilitiesAndEpics(int numCaps = 5)
        {
            solutionCaps = CapabilitiesGenerator.GenerateListOfSolutionCapabilities(_test.connectionString, _test.solution.Id, numCaps);
            solutionEpics = CapabilitiesGenerator.GenerateCapabilityEpics(_test.connectionString, solutionCaps);
        }
    }
}
