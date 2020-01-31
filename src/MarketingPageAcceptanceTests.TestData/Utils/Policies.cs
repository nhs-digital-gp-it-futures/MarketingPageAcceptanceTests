using Polly;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MarketingPageAcceptanceTests.TestData.Utils
{
    internal static class Policies
    {
        internal static ISyncPolicy RetryPolicy()
        {
            return Policy.Handle<SqlException>()
                .Or<TimeoutException>()
                .WaitAndRetry(3, retryAttempt => TimeSpan.FromMilliseconds(500));
        }
    }
}
