using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace MarketingPageAcceptanceTestsSpecflow.Utils
{
    public abstract class TestBase
    {
        internal readonly UITest _test;
        internal readonly ScenarioContext _context;

        public TestBase(UITest test, ScenarioContext context)
        {
            _test = test;
            _context = context;
        }
    }
}
