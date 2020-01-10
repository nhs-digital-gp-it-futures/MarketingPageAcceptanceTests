namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public static class ClientApplicationStringBuilder
    {
        const string browserBased = "Browser based";
        const string nativeMobile = "Native mobile or tablet";
        const string nativeDesktop = "Native desktop";

        public static string GetClientAppString(string ignoredSection = null, string clientApplicationTypes = "Browser based")
        {
            string clientAppString = string.Empty;
            if (string.IsNullOrEmpty(ignoredSection))
            {
                if(clientApplicationTypes.Contains(browserBased))
                {
                    clientAppString += ClientApplicationStrings.BrowserBased;
                }

                if (clientApplicationTypes.Contains(nativeMobile))
                {
                    if (!string.IsNullOrEmpty(clientAppString))
                    {
                        clientAppString += ",";
                    }
                    clientAppString += ClientApplicationStrings.NativeMobile;
                }

                if (clientApplicationTypes.Contains(nativeDesktop))
                {
                    if (!string.IsNullOrEmpty(clientAppString))
                    {
                        clientAppString += ",";
                    }
                    clientAppString += ClientApplicationStrings.NativeDesktop;
                }

                return buildClientApplicationString(clientApplicationTypes, clientAppString);
            }

            if (clientApplicationTypes.Contains(browserBased))
            {
                clientAppString += parseBrowserBasedTemplate(ignoredSection);
            }

            if (clientApplicationTypes.Contains(nativeMobile))
            {
                clientAppString += parseNativeMobileTemplate(ignoredSection);
            }

            if (clientApplicationTypes.Contains(nativeDesktop))
            {
                clientAppString += parseNativeDesktopTemplate(ignoredSection);
            }

            return buildClientApplicationString(clientApplicationTypes, clientAppString);
        }

        private static string buildClientApplicationString(string clientApplicationType, string clientAppString)
        {
            clientApplicationType = clientApplicationType.Replace(browserBased, "browser-based")
                                    .Replace(nativeMobile, "native-mobile")
                                    .Replace(nativeDesktop, "native-desktop");
            string completeClientApplicationString = string.Format("{{\"ClientApplicationTypes\":[\"{0}\"],{1}}}", clientApplicationType, clientAppString);
            return completeClientApplicationString;
        }

        private static string parseBrowserBasedTemplate(string ignoredSection)
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

        private static string parseNativeMobileTemplate(string ignoredSection)
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

        private static string parseNativeDesktopTemplate(string ignoredSection)
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
