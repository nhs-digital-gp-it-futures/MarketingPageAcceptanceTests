﻿namespace MarketingPageAcceptanceTests.Steps.Steps.Authority.Capabilities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentAssertions;
    using MarketingPageAcceptanceTests.Steps.Utils;
    using MarketingPageAcceptanceTests.TestData.Capabilities;
    using MarketingPageAcceptanceTests.TestData.Utils;
    using TechTalk.SpecFlow;

    [Binding]
    public class DisplaySolutionsCapabilities : TestBase
    {
        private IEnumerable<SolutionCapabilities> solutionCaps;
        private IEnumerable<EpicDto> solutionEpics;

        public DisplaySolutionsCapabilities(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that Capabilities have been provided for the Solution")]
        public async Task GivenThatCapabilitiesHaveBeenProvidedForTheSolutionAsync()
        {
            await GenerateCapabilitiesAndEpicsAsync();
            var csv = solutionCaps.ToCsv();

            test.Pages.Dashboard.NavigateToSection("Capabilities");

            test.Pages.Capabilities.EnterText(csv);

            test.Pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the Capability Name")]
        public void ThenTheCapabilityName()
        {
            test.Pages.Capabilities.GetCapabilityNames().Should().HaveCount(solutionCaps.Count());
        }

        [Then(@"Capability Version")]
        public void ThenCapabilityVersion()
        {
            test.Pages.Capabilities.GetCapabilityVersions().Should().HaveCount(solutionCaps.Count());
        }

        [Then(@"Capability Description")]
        public void ThenCapabilityDescription()
        {
            test.Pages.Capabilities.GetCapabilityDescriptions().Should().HaveCount(solutionCaps.Count());
        }

        [Then(@"'(?:.*)' Capability URL")]
        public void ThenCapabilityURL()
        {
            Actions.Pages.Capabilities.GetCapabilityUrls().Should().HaveCount(solutionCaps.Count());
        }

        [Then(@"the Capability URL will direct to a page that contains more content about the Capability")]
        public void ThenTheCapabilityURLWillDirectToAPageThatContainsMoreContentAboutTheCapability()
        {
            context.Pending();
        }

        [Given(@"that Epics for the Capability are provided")]
        [Given(@"that Epic Pass or Fail Statuses have been provided for each Epic")]
        public async Task GivenThatEpicsForTheCapabilityAreProvidedAsync()
        {
            await GivenThatCapabilitiesHaveBeenProvidedForTheSolutionAsync();
            var csv = solutionEpics.ToCsv();

            test.Pages.Dashboard.NavigateToSection("Epics");

            test.Pages.Capabilities.EnterText(csv);

            test.Pages.Common.SectionSaveAndReturn();
        }

        [Then(@"the Epic titles are visible")]
        public void ThenTheEpicTitlesAreVisible()
        {
            test.Pages.PreviewPage.OpenCapabilityAccordians();
        }

        [Then(@"the Epic pass or fail status is visible")]
        public void ThenTheEpicPassOrFailStatusIsVisible()
        {
            test.Pages.PreviewPage.EpicsHaveStatusSymbols(solutionEpics.Count());
        }

        [Then(@"the Epic IDs are displayed")]
        public void ThenTheEpicIDsAreDisplayed()
        {
            test.Pages.PreviewPage.EpicIdsDisplayed(solutionEpics.Select(s => s.Id));
        }

        [Then(@"the Epics are displayed as Must or May Epics")]
        public void ThenTheEpicsAreDisplayedAsMustOrMayEpics()
        {
            test.Pages.PreviewPage.MustSectionCount(solutionCaps.Count());
            test.Pages.PreviewPage.MaySectionCount(solutionCaps.Count());
        }

        [Given(@"that Epics are provided for Capabilities not provided")]
        public async Task GivenThatEpicsAreProvidedForCapabilitiesNotProvidedAsync()
        {
            await GenerateCapabilitiesAndEpicsAsync();
            await GivenThatCapabilitiesHaveBeenProvidedForTheSolutionAsync();

            var csv = (await CapabilitiesGenerator.GenerateEpicsForCapabilityNotSelectedAsync(test.ConnectionString, solutionCaps))
                .ToCsv();

            test.Pages.Dashboard.NavigateToSection("Epics");

            test.Pages.Capabilities.EnterText(csv);
        }

        [Then(@"the User remains on the Epics page")]
        public void ThenTheUserRemainsOnTheEpicsPage()
        {
            test.Pages.Dashboard.SectionHasTitle("Epics");
        }

        private async Task GenerateCapabilitiesAndEpicsAsync(int numCaps = 5)
        {
            solutionCaps = await CapabilitiesGenerator.GenerateListOfSolutionCapabilitiesAsync(
                    test.ConnectionString,
                    test.Solution.Id,
                    numCaps);
            solutionEpics = await CapabilitiesGenerator.GenerateCapabilityEpicsAsync(test.ConnectionString, solutionCaps);
        }
    }
}
