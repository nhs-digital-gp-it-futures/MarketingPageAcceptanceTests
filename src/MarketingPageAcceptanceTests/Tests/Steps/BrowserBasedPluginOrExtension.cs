using MarketingPageAcceptanceTests.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace MarketingPageAcceptanceTests.Tests.Steps
{
    public sealed class BrowserBasedPluginOrExtension : UITest, IDisposable
    {
        public BrowserBasedPluginOrExtension(ITestOutputHelper helper) : base(helper)
        {
        }
    }
}
