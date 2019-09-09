using System;

namespace MarketingPageAcceptanceTests.Utils
{
    internal class EnvironmentVariables
    {
        internal static (string, string, string) Get()
        {
            var url = Environment.GetEnvironmentVariable("MPURL", EnvironmentVariableTarget.Process) ?? "http://10.0.75.1:3000";
            var hubUrl = Environment.GetEnvironmentVariable("HUBURL", EnvironmentVariableTarget.Process) ?? "http://localhost:4444/wd/hub";
            var browser = Environment.GetEnvironmentVariable("BROWSER", EnvironmentVariableTarget.Process) ?? "chrome-local";

            return (url, hubUrl, browser);
        }
    }
}