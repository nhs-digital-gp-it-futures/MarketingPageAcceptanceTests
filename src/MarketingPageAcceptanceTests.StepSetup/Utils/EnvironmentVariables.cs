﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MarketingPageAcceptanceTests.StepSetup.Utils
{
    internal static class EnvironmentVariables
    {
        internal static (string, string, string, string, string, string, string) Get()
        {
            var url = Url();
            var hubUrl = HubUrl();
            var browser = Browser();

            var (serverUrl, databaseName, dbUser, dbPassword) = DbConnectionDetails();

            return (url, hubUrl, browser, serverUrl, databaseName, dbUser, dbPassword);
        }

        internal static string HubUrl()
        {
            return Environment.GetEnvironmentVariable("HUBURL") ?? "http://localhost:4444/wd/hub";
        }

        internal static string Url()
        {
            var uri = Environment.GetEnvironmentVariable("MPURL") ?? DefaultUri();
            return uri.TrimEnd('/');
        }

        internal static string Browser()
        {
            return Environment.GetEnvironmentVariable("BROWSER") ?? "ChromeLocal";
        }

        internal static (string serverUrl, string databaseName, string dbUser, string dbPassword) DbConnectionDetails()
        {
            var serverUrl = Environment.GetEnvironmentVariable("SERVERURL") ?? "127.0.0.1,1450";
            var databaseName = Environment.GetEnvironmentVariable("DATABASENAME") ?? "buyingcatalogue";
            var dbUser = JsonConfigValues("user", "NHSD");
            var dbPassword = JsonConfigValues("password", "DisruptTheMarket1!");

            return (serverUrl, databaseName, dbUser, dbPassword);
        }

        internal static string DbConnectionString()
        {
            var (serverUrl, databaseName, dbUser, dbPassword) = DbConnectionDetails();

            return string.Format(ConnectionString.GPitFutures, serverUrl, databaseName, dbUser, dbPassword);
        }

        internal static string AzureBlobStorageConnectionString()
        {
            return JsonConfigValues("AzureBlobStorageConnectionString", @"UseDevelopmentStorage=true");
        }

        internal static string AzureContainerName()
        {
            return Environment.GetEnvironmentVariable("CONTAINER_NAME") ?? "container-1";
        }

        private static string JsonConfigValues(string section, string defaultValue)
        {
            var path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Utils",
                "tokens.json");
            var jsonSection = JObject.Parse(File.ReadAllText(path))[section];

            var dbValues = jsonSection.ToObject<Dictionary<string, string>>();

            var result = dbValues.Values
                .FirstOrDefault(s => !s.Contains("#{"));

            return string.IsNullOrEmpty(result) ? defaultValue : result;
        }

        private static string DefaultUri()
        {
            var uri = "https://host.docker.internal/marketing/supplier/solution/";

            return uri;
        }
    }


    public static class ConnectionString
    {
        internal const string GPitFutures =
            @"Server={0};Initial Catalog={1};Persist Security Info=false;User Id={2};Password={3}";
    }
}