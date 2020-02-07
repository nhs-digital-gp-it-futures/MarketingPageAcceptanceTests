using MarketingPageAcceptanceTests.Steps.Utils;
using MarketingPageAcceptanceTests.TestData.Capabilities;
using MarketingPageAcceptanceTests.TestData.Utils;
using System.Collections.Generic;
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
            _context.Pending();
        }
        
        [Then(@"Capability Version")]
        public void ThenCapabilityVersion()
        {
            _context.Pending();
        }
        
        [Then(@"Capability Description")]
        public void ThenCapabilityDescription()
        {
            _context.Pending();
        }
        
        [Then(@"'(.*)' Capability URL")]
        public void ThenCapabilityURL(string p0)
        {
            _context.Pending();
        }
        
        [Then(@"the Capability URL will direct to a page that contains more content about the Capability")]
        public void ThenTheCapabilityURLWillDirectToAPageThatContainsMoreContentAboutTheCapability()
        {
            _context.Pending();
        }
    }
}
