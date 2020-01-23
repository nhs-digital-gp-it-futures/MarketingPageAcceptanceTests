using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MarketingPageAcceptanceTestsSpecflow.Utils
{
    internal static class EnvironmentVariables
    {
        internal static (string, string, string, string, string, string, string) Get()
        {
            var url = GetUrl();
            var hubUrl = GetHubUrl();
            var browser = GetBrowser();

            var (serverUrl, databaseName, dbUser, dbPassword) = GetDbConnectionDetails();

            return (url, hubUrl, browser, serverUrl, databaseName, dbUser, dbPassword);
        }

        internal static string GetHubUrl()
        {
            return Environment.GetEnvironmentVariable("HUBURL") ?? "http://localhost:4444/wd/hub";
        }

        internal static string GetUrl()
        {
            string uri = Environment.GetEnvironmentVariable("MPURL") ?? "http://host.docker.internal:3002/solution/";

            return uri.TrimEnd('/');
        }

        internal static string GetBrowser()
        {
            return Environment.GetEnvironmentVariable("BROWSER") ?? "chrome-local";
        }

        internal static (string serverUrl, string databaseName, string dbUser, string dbPassword) GetDbConnectionDetails()
        {
            var serverUrl = Environment.GetEnvironmentVariable("SERVERURL") ?? "127.0.0.1,1433";
            var databaseName = Environment.GetEnvironmentVariable("DATABASENAME") ?? "buyingcatalogue";
            var dbUser = Environment.GetEnvironmentVariable("DBUSER") ?? "NHSD";
            var dbPassword = Environment.GetEnvironmentVariable("gpitdevsqladminpassword") ?? "DisruptTheMarket1!";

            var path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Utils", "tokens.json");
            JObject o1 = JObject.Parse(File.ReadAllText(path));
            var value = o1.SelectToken("gpitdevsqladminpassword").Value<string>();
            Console.WriteLine(value);
            dbPassword = value;

            return (serverUrl, databaseName, dbUser, dbPassword);
        }

        internal static string GetConnectionString()
        {
            var (serverUrl, databaseName, dbUser, dbPassword) = GetDbConnectionDetails();

            return string.Format(ConnectionString.GPitFutures, serverUrl, databaseName, dbUser, dbPassword);
        }
    }


    public static class ConnectionString
    {
        internal const string GPitFutures = @"Server={0};Initial Catalog={1};Persist Security Info=false;User Id={2};Password={3}";
    }
}