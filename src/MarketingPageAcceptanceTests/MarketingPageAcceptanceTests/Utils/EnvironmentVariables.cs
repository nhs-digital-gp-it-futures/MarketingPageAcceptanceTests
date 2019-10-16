using System;

namespace MarketingPageAcceptanceTests.Utils
{
    internal class EnvironmentVariables
    {
        internal static (string, string, string, string, string, string) Get()
        {
            var url = Environment.GetEnvironmentVariable("MPURL") ?? "http://10.0.75.1:3001/S100000-001";
            var hubUrl = Environment.GetEnvironmentVariable("HUBURL") ?? "http://localhost:4444/wd/hub";
            var browser = Environment.GetEnvironmentVariable("BROWSER") ?? "chrome-local";
            var apiUrl = Environment.GetEnvironmentVariable("APIURL") ?? "http://10.0.75.1:8080";

            var databaseName = Environment.GetEnvironmentVariable("DATABASENAME") ?? "localhost";
            var dbPassword = Environment.GetEnvironmentVariable("DBPASSWORD") ?? "DisruptTheMarket1!";

            return (url, hubUrl, browser, apiUrl, databaseName, dbPassword);
        }
    }
    public static class ConnectionString
    {
        internal const string GPitFutures = @"Server={0};Initial Catalog=buyingcatalogue;Persist Security Info=false;User Id=NHSD;Password={1}";
    }
}