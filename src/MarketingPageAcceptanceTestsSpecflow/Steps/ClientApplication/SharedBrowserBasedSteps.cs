using MarketingPageAcceptanceTestsSpecflow.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication
{
    public sealed class SharedBrowserBasedSteps
    {
        private UITest _test;
        private ScenarioContext _context;

        public SharedBrowserBasedSteps(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }

        [Then(@"the (.*) section is marked as (COMPLETE|INCOMPLETE) on the Browser Based Client Type Sub-Form")]
        public void ThenTheSectionIsMarkedAsOnTheBrowserBasedClientTypeSub_Form(string section, string status)
        {
            _test.pages.Dashboard.AssertSectionStatus(section, status);
        }
    }
}
