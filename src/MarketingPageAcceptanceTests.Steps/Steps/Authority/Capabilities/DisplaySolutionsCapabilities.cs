using FluentAssertions;
using MarketingPageAcceptanceTests.StepSetup.Utils;
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
        private IEnumerable<SolutionCapabilities> solutionCaps;
        private IEnumerable<EpicDto> solutionEpics;

        public DisplaySolutionsCapabilities(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that Capabilities have been provided for the Solution")]
        public void GivenThatCapabilitiesHaveBeenProvidedForTheSolution()
        {
            GenerateCapabilitiesAndEpics();
            var csv = solutionCaps.ToCsv();

            _test.Pages.Dashboard.NavigateToSection("Capabilities");

            _test.Pages.Capabilities.EnterText(csv);

            _test.Pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the Capability Name")]
        public void ThenTheCapabilityName()
        {
            _test.Pages.Capabilities.GetCapabilityNames().Should().HaveCount(solutionCaps.Count());
        }

        [Then(@"Capability Version")]
        public void ThenCapabilityVersion()
        {
            _test.Pages.Capabilities.GetCapabilityVersions().Should().HaveCount(solutionCaps.Count());
        }

        [Then(@"Capability Description")]
        public void ThenCapabilityDescription()
        {
            _test.Pages.Capabilities.GetCapabilityDescriptions().Should().HaveCount(solutionCaps.Count());
        }

        [Then(@"'(.*)' Capability URL")]
        public void ThenCapabilityURL(string p0)
        {
            _test.Pages.Capabilities.GetCapabilityUrls().Should().HaveCount(solutionCaps.Count());
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

            _test.Pages.Dashboard.NavigateToSection("Epics");

            _test.Pages.Capabilities.EnterText(csv);

            _test.Pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the Epic titles are visible")]
        public void ThenTheEpicTitlesAreVisible()
        {
            _test.Pages.PreviewPage.OpenCapabilityAccordians();
        }

        [Then(@"the Epic pass or fail status is visible")]
        public void ThenTheEpicPassOrFailStatusIsVisible()
        {
            _test.Pages.PreviewPage.EpicsHaveStatusSymbols(solutionEpics.Count());
        }

        [Then(@"the Epic IDs are displayed")]
        public void ThenTheEpicIDsAreDisplayed()
        {
            _test.Pages.PreviewPage.EpicIdsDisplayed(solutionEpics.Select(s => s.Id));
        }

        [Then(@"the Epics are displayed as Must or May Epics")]
        public void ThenTheEpicsAreDisplayedAsMustOrMayEpics()
        {
            _test.Pages.PreviewPage.MustSectionCount(solutionCaps.Count());
            _test.Pages.PreviewPage.MaySectionCount(solutionCaps.Count());
        }

        [Given(@"that Epics are provided for Capabilities not provided")]
        public void GivenThatEpicsAreProvidedForCapabilitiesNotProvided()
        {
            GenerateCapabilitiesAndEpics();
            GivenThatCapabilitiesHaveBeenProvidedForTheSolution();

            var csv = CapabilitiesGenerator.GenerateEpicsForCapabilityNotSelected(_test.ConnectionString, solutionCaps)
                .ToCsv();

            _test.Pages.Dashboard.NavigateToSection("Epics");

            _test.Pages.Capabilities.EnterText(csv);
        }

        [Then(@"the User remains on the Epics page")]
        public void ThenTheUserRemainsOnTheEpicsPage()
        {
            _test.Pages.Dashboard.SectionHasTitle("Epics");
        }


        private void GenerateCapabilitiesAndEpics(int numCaps = 5)
        {
            solutionCaps =
                CapabilitiesGenerator.GenerateListOfSolutionCapabilities(_test.ConnectionString, _test.solution.Id,
                    numCaps);
            solutionEpics = CapabilitiesGenerator.GenerateCapabilityEpics(_test.ConnectionString, solutionCaps);
        }
    }
}