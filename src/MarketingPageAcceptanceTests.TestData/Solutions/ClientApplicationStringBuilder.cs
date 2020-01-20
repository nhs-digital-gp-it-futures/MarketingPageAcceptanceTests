using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public static class ClientApplicationStringBuilder
    {
        const string browserBased = "Browser based";
        const string nativeMobile = "Native mobile or tablet";
        const string nativeDesktop = "Native desktop";

        static readonly Dictionary<string, (string clientAppString, Func<string, string> parseString)> clientAppTypes = new Dictionary<string, (string, Func<string, string>)>()
        {
            { "Browser based", ( ClientApplicationStrings.BrowserBased, ParseBrowserBasedTemplate ) },
            { "Native mobile or tablet", (ClientApplicationStrings.NativeMobile, ParseNativeMobileTemplate) },
            { "Native desktop", (ClientApplicationStrings.NativeDesktop, ParseNativeDesktopTemplate) }
        };

        public static string GetClientAppString(string ignoredSection = null, string clientApplicationTypes = "Browser based")
        {
            List<string> clientAppString = new List<string>();

            string finishedString = string.Empty;

            if (string.IsNullOrEmpty(ignoredSection))
            {
                foreach(var appType in clientAppTypes)
                {
                    if (clientApplicationTypes.Contains(appType.Key))
                    {
                        clientAppString.Add(appType.Value.clientAppString);
                    }
                }

                return BuildClientApplicationString(clientApplicationTypes, string.Join(',', clientAppString));
            }

            foreach (var appType in clientAppTypes)
            {
                if (clientApplicationTypes.Contains(appType.Key))
                {
                    finishedString += appType.Value.parseString(ignoredSection);
                }
            }

            return BuildClientApplicationString(clientApplicationTypes, finishedString);
        }

        private static string BuildClientApplicationString(string clientApplicationType, string clientAppString)
        {
            clientApplicationType = clientApplicationType.Replace(browserBased, "browser-based")
                                    .Replace(nativeMobile, "native-mobile")
                                    .Replace(nativeDesktop, "native-desktop");
            string completeClientApplicationString = string.Format("{{\"ClientApplicationTypes\":[\"{0}\"],{1}}}", clientApplicationType, clientAppString);
            return completeClientApplicationString;
        }

        private static string ParseBrowserBasedTemplate(string ignoredSection)
        {
            string formattedString = string.Empty;

            string browsersSupported = "\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true,";
            string plugins = "\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"\"},";
            string connectivityAndResolution = "\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\",";
            string mobileFirstDesign = "\"MobileFirstDesign\":true,";

            switch (ignoredSection)
            {
                case "Browsers supported":
                    formattedString = string.Format(ClientApplicationStrings.BrowserBasedTemplate, "", plugins, connectivityAndResolution, mobileFirstDesign);
                    break;
                case "Plug-ins or extensions":
                    formattedString = string.Format(ClientApplicationStrings.BrowserBasedTemplate, browsersSupported, "", connectivityAndResolution, mobileFirstDesign);
                    break;
                case "Connectivity and resolution":
                    formattedString = string.Format(ClientApplicationStrings.BrowserBasedTemplate, browsersSupported, plugins, "", mobileFirstDesign);
                    break;
                case "Mobile first":
                    formattedString = string.Format(ClientApplicationStrings.BrowserBasedTemplate, browsersSupported, plugins, connectivityAndResolution, "");
                    break;
            }

            return formattedString;            
        }

        private static string ParseNativeMobileTemplate(string ignoredSection)
        {
            string formattedString = string.Empty;

            string mobileOperatingSystemsSupported = "\"MobileOperatingSystems\":{\"OperatingSystems\":[\"Apple IOS\",\"Android\"],\"OperatingSystemsDescription\":\"\"},";
            string nativeMobileFirstDesign = "\"NativeMobileFirstDesign\":true,";
            string mobileMemoryAndStorage = "\"MobileMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"Description\":\"Some storage description details\"},";

            switch (ignoredSection)
            {
                case "Mobile first":
                    formattedString = string.Format(ClientApplicationStrings.NativeMobileTemplate, "", mobileOperatingSystemsSupported, mobileMemoryAndStorage);
                    break;
                case "Supported operating systems":
                    formattedString = string.Format(ClientApplicationStrings.NativeMobileTemplate, nativeMobileFirstDesign, "", mobileMemoryAndStorage);
                    break;
                case "Memory and storage":
                    formattedString = string.Format(ClientApplicationStrings.NativeMobileTemplate, nativeMobileFirstDesign, mobileOperatingSystemsSupported, "");
                    break;
            }

            return formattedString;            
        }

        private static string ParseNativeDesktopTemplate(string ignoredSection)
        {
            string formattedString = string.Empty;

            string desktopOperatingSystemsSupported = "\"NativeDesktopOperatingSystemsDescription\":\"Windows 7,8,10\r\nUbuntu\",";
            string connectionDetails = "\"NativeDesktopMinimumConnectionSpeed\":\"0.5Mbps\",";
            string memoryStorageProcessingAspectRatio = "\"NativeDesktopMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"StorageRequirementsDescription\":\"approximately 10MB, plus additional for cache\",\"MinimumCpu\":\"0.98hz\",\"RecommendedResolution\":\"16:9 - 640 x 360\"},";
            switch (ignoredSection)
            {
                case "Supported operating systems":
                    formattedString = string.Format(ClientApplicationStrings.NativeDesktopTemplate, "", connectionDetails, memoryStorageProcessingAspectRatio);
                    break;
                case "Connection details":
                    formattedString = string.Format(ClientApplicationStrings.NativeDesktopTemplate, desktopOperatingSystemsSupported, "", memoryStorageProcessingAspectRatio);
                    break;
                case "Memory, storage, processing and aspect ratio":
                    formattedString = string.Format(ClientApplicationStrings.NativeDesktopTemplate, desktopOperatingSystemsSupported, connectionDetails, "");
                    break;
            }

            return formattedString;
        }
    }
}
