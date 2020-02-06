﻿using MarketingPageAcceptanceTestsSpecflow.Steps.Utils;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTests.SupplierTests.Utils
{
    [Binding]
    public sealed class BeforeHook : TestBase
    {
        public BeforeHook(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _test.UserType = "supplier";
            _test.SetUrl();
            _test.GoToUrl();
        }
    }
}