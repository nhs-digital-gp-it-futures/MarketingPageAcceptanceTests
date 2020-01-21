using System;
using System.Collections.Generic;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public static class ClientApplicationStringBuilder
    {
        static readonly Dictionary<string, (string conversion, string clientAppString, Func<string, string> parseString)> clientAppTypes = new Dictionary<string, (string, string, Func<string, string>)>()
        {
            { "Browser based", ( "browser-based", ClientApplicationStrings.BrowserBasedComplete, ParseBrowserBased ) },
            { "Native mobile or tablet", ("native-mobile", ClientApplicationStrings.NativeMobileComplete, ParseNativeMobile) },
            { "Native desktop", ("native-desktop", ClientApplicationStrings.NativeDesktopComplete, ParseNativeDesktop) }
        };

        public static string GetClientAppString(string ignoredSection = null, string clientApplicationTypes = "Browser based")
        {
            List<string> clientAppString = new List<string>();

            string finishedString = string.Empty;

            if (string.IsNullOrEmpty(ignoredSection))
            {
                foreach (var appType in clientAppTypes)
                {
                    if (clientApplicationTypes.Contains(appType.Key))
                    {
                        clientAppString.Add(appType.Value.clientAppString);
                    }
                }
                finishedString = string.Join(',', clientAppString);
            }
            else
            {
                foreach (var appType in clientAppTypes)
                {
                    if (clientApplicationTypes.Contains(appType.Key))
                    {
                        finishedString += appType.Value.parseString(ignoredSection);
                    }
                }
            }

            return BuildClientApplicationString(clientApplicationTypes, finishedString);
        }

        private static string BuildClientApplicationString(string clientApplicationType, string clientAppString)
        {
            string converted = string.Empty;

            foreach (string key in clientAppTypes.Keys)
            {
                if (clientApplicationType.Contains(key))
                {
                    converted += clientAppTypes[key].conversion;
                }
            }

            string completeClientApplicationString = string.Format("{{\"ClientApplicationTypes\":[\"{0}\"],{1}}}", converted, clientAppString);
            return completeClientApplicationString;
        }

        private static string ParseBrowserBased(string ignoredSection)
        {
            return ClientApplicationStrings.BrowserBasedComplete.Replace(ClientApplicationStrings.BrowserSections[ignoredSection], "");
        }

        private static string ParseNativeMobile(string ignoredSection)
        {
            return ClientApplicationStrings.NativeMobileComplete.Replace(ClientApplicationStrings.NativeMobileSections[ignoredSection], "");
        }

        private static string ParseNativeDesktop(string ignoredSection)
        {
            return ClientApplicationStrings.NativeDesktopComplete.Replace(ClientApplicationStrings.NativeDesktopSections[ignoredSection], "");
        }
    }
}
