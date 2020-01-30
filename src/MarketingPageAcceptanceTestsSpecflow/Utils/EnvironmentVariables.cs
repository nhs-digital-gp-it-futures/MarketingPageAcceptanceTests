using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

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

            var dbUser = GetPartialEnvVar("gpit(.*)sqladminusername") ?? "NHSD";
            var dbPassword = GetPartialEnvVar("gpit(.*)sqladminpassword") ?? "DisruptTheMarket1!";

            TestContext.Out.WriteLine("User: " + dbUser);
            TestContext.Out.WriteLine("Password: " + dbPassword);

            return (serverUrl, databaseName, dbUser, dbPassword);
        }

        internal static string GetConnectionString()
        {
            var (serverUrl, databaseName, dbUser, dbPassword) = GetDbConnectionDetails();

            return string.Format(ConnectionString.GPitFutures, serverUrl, databaseName, dbUser, dbPassword);
        }

        private static string GetJsonConfigValues(string section, string defaultValue)
        {
            var path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Utils", "tokens.json");
            var jsonSection = JObject.Parse(File.ReadAllText(path))[section];

            Dictionary<string, string> dbValues = jsonSection.ToObject<Dictionary<string, string>>();

            var result = dbValues.Values
                .FirstOrDefault(s => !s.Contains("#{"));               

            return string.IsNullOrEmpty(result) ? defaultValue : result;
        }

        private static string GetPartialEnvVar(string pattern)
        {
            IDictionary variables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
            foreach (string variable in variables.Keys)
            {
                TestContext.Out.WriteLine(variable);
                var match = Regex.Match(variable, pattern).Value;
                if (!string.IsNullOrEmpty(match))
                {
                    return (string)variables[match];
                }
            }

            return null;
        }
    }


    public static class ConnectionString
    {
        internal const string GPitFutures = @"Server={0};Initial Catalog={1};Persist Security Info=false;User Id={2};Password={3}";
    }
}