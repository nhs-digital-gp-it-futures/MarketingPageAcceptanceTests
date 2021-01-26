﻿namespace MarketingPageAcceptanceTests.TestData.Utils
{
    using System;
    using System.Data.SqlClient;
    using Polly;

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
