namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    using System;
    using System.Collections.Generic;

    public static class ClientApplicationStringBuilder
    {
        private static readonly Dictionary<string, (string Conversion, string ClientAppString, Func<string, string> ParseString)>
            ClientAppTypes = new()
            {
                { "Browser-based", ("browser-based", ClientApplicationStrings.BrowserBasedComplete, ParseBrowserBased) },
                {
                    "Native mobile or tablet",
                    ("native-mobile", ClientApplicationStrings.NativeMobileComplete, ParseNativeMobile)
                },
                {
                    "Native desktop",
                    ("native-desktop", ClientApplicationStrings.NativeDesktopComplete, ParseNativeDesktop)
                },
            };

        public static string GetClientAppString(
            string ignoredSection = null,
            string clientApplicationTypes = "Browser-based")
        {
            List<string> clientAppString = new();

            var finishedString = string.Empty;

            if (string.IsNullOrEmpty(ignoredSection))
            {
                foreach (var appType in ClientAppTypes)
                {
                    if (clientApplicationTypes.Contains(appType.Key))
                    {
                        clientAppString.Add(appType.Value.ClientAppString);
                    }
                }

                finishedString = string.Join(',', clientAppString);
            }
            else
            {
                foreach (var appType in ClientAppTypes)
                {
                    if (clientApplicationTypes.Contains(appType.Key))
                    {
                        finishedString += appType.Value.ParseString(ignoredSection);
                    }
                }
            }

            return BuildClientApplicationString(clientApplicationTypes, finishedString);
        }

        private static string BuildClientApplicationString(string clientApplicationType, string clientAppString)
        {
            List<string> converted = new();

            foreach (var key in ClientAppTypes.Keys)
            {
                if (clientApplicationType.Contains(key))
                {
                    converted.Add($"\"{ClientAppTypes[key].Conversion}\"");
                }
            }

            return string.Format(
                "{{\"ClientApplicationTypes\":[{0}],{1}}}",
                string.Join(',', converted),
                clientAppString);
        }

        private static string ParseBrowserBased(string ignoredSection)
        {
            return ClientApplicationStrings.BrowserBasedComplete.Replace(
                ClientApplicationStrings.BrowserSections[ignoredSection], string.Empty);
        }

        private static string ParseNativeMobile(string ignoredSection)
        {
            return ClientApplicationStrings.NativeMobileComplete.Replace(
                ClientApplicationStrings.NativeMobileSections[ignoredSection], string.Empty);
        }

        private static string ParseNativeDesktop(string ignoredSection)
        {
            return ClientApplicationStrings.NativeDesktopComplete.Replace(
                ClientApplicationStrings.NativeDesktopSections[ignoredSection], string.Empty);
        }
    }
}
