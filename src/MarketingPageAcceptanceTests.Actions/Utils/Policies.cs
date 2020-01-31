using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Polly;

namespace MarketingPageAcceptanceTests.Actions.Utils
{
    internal static class Policies
    {
        internal static ISyncPolicy GetPolicy()
        {
            // Retry is 200ms, then 400ms, then 800ms, failing afterwards
            return Policy
                .Handle<WebDriverException>()
                .WaitAndRetry(3, s => Math.Pow(2, s) * TimeSpan.FromMilliseconds(100));
        }
    }
}
