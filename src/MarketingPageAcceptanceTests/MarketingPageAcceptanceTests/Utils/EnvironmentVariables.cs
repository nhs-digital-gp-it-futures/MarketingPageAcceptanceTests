﻿using System;

namespace MarketingPageAcceptanceTests.Utils
{
    internal class EnvironmentVariables
    {
        internal static (string, string, string, string, string) Get()
        {
            var url = Environment.GetEnvironmentVariable("MPURL") ?? "http://10.0.75.1:3001";
            var hubUrl = Environment.GetEnvironmentVariable("HUBURL") ?? "http://localhost:4444/wd/hub";
            var browser = Environment.GetEnvironmentVariable("BROWSER") ?? "chrome-local";

            var databaseName = Environment.GetEnvironmentVariable("DATABASENAME") ?? "127.0.0.1,1433";
            var dbPassword = Environment.GetEnvironmentVariable("DBPASSWORD") ?? "DisruptTheMarket1!";

            return (url, hubUrl, browser, databaseName, dbPassword);
        }
    }
    public static class ConnectionString
    {
        internal const string GPitFutures = @"Server={0};Initial Catalog=buyingcatalogue;Persist Security Info=false;User Id=NHSD;Password={1}";
    }
}