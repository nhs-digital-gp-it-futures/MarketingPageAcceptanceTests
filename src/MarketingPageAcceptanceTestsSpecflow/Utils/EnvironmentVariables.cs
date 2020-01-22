using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;

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
            string uri = Environment.GetEnvironmentVariable("MPURL") ?? $"http://{GetLocalIp()}:3002/solution/";

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
            var dbPassword = Environment.GetEnvironmentVariable("DBPASSWORD") ?? "DisruptTheMarket1!";

            return (serverUrl, databaseName, dbUser, dbPassword);
        }

        internal static string GetConnectionString()
        {
            var (serverUrl, databaseName, dbUser, dbPassword) = GetDbConnectionDetails();

            return string.Format(ConnectionString.GPitFutures, serverUrl, databaseName, dbUser, dbPassword);
        }

        private static string GetLocalIp(NetworkInterfaceType networkType = NetworkInterfaceType.Wireless80211)
        {
            var output = string.Empty;
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == networkType && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
    }


    public static class ConnectionString
    {
        internal const string GPitFutures = @"Server={0};Initial Catalog={1};Persist Security Info=false;User Id={2};Password={3}";
    }
}