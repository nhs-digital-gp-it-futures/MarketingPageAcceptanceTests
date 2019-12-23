﻿using MarketingPageAcceptanceTestsSpecflow.Utils;
using System;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Steps.ClientApplication.NativeMobileOrTablet
{
    [Binding]
    public sealed class MemoryAndStorage : TestBase
    {
        public MemoryAndStorage(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"the User selects a memory requirement")]
        public void GivenTheUserSelectsAMemoryRequirement()
        {
            _test.pages.NativeMobileSections.MemoryAndStorage.SelectRequirementFromList();
        }
    }
}
