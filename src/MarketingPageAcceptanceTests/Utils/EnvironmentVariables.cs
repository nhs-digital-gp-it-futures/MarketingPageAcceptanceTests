﻿using System;

namespace MarketingPageAcceptanceTests.Utils
{
    internal class EnvironmentVariables
    {
        internal static (string, string, string, string, string, string, string) Get()
        {
            var url = Environment.GetEnvironmentVariable("MPURL") ?? "http://10.0.75.1:3001";
            var hubUrl = Environment.GetEnvironmentVariable("HUBURL") ?? "http://localhost:4444/wd/hub";
            var browser = Environment.GetEnvironmentVariable("BROWSER") ?? "chrome-local";

            var serverUrl = Environment.GetEnvironmentVariable("SERVERURL") ?? "127.0.0.1,1433";
            var databaseName = Environment.GetEnvironmentVariable("DATABASENAME") ?? "buyingcatalogue";
            var dbUser = Environment.GetEnvironmentVariable("DBUSER") ?? "NHSD";
            var dbPassword = Environment.GetEnvironmentVariable("DBPASSWORD") ?? "DisruptTheMarket1!";

            return (url, hubUrl, browser, serverUrl, databaseName, dbUser, dbPassword);
        }
    }
    public static class ConnectionString
    {
        internal const string GPitFutures = @"Server={0};Initial Catalog={1};Persist Security Info=false;User Id={2};Password={3}";
    }
}