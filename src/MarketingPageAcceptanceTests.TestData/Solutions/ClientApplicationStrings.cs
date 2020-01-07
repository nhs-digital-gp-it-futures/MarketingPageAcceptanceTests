namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public static class ClientApplicationStrings
    {
        const string browserBased = "Browser based";
        const string nativeMobile = "Native mobile";
        const string nativeDesktop = "Native desktop";

        public static string GetClientAppString(string ignoredSection = null, string clientApplicationTypes = "Browser based")
        {
            string clientAppString = string.Empty;
            if (string.IsNullOrEmpty(ignoredSection))
            {
                if(clientApplicationTypes.Contains(browserBased))
                {
                    clientAppString += getMinimumCompleteBrowserBasedClientApplicationDetails();
                }

                if (clientApplicationTypes.Contains(nativeMobile))
                {
                    clientAppString += getMinimumCompleteNativeMobileClientApplicationDetails();
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

            return buildClientApplicationString(clientApplicationTypes, clientAppString);
        }

        private static string buildClientApplicationString(string clientApplicationType, string clientAppString)
        {
            clientApplicationType = clientApplicationType.Replace("Browser based", "browser-based");
            clientApplicationType = clientApplicationType.Replace("Native mobile or tablet", "native-mobile");
            clientApplicationType = clientApplicationType.Replace("Native desktop", "native-desktop");
            string completeClientApplicationString = string.Format("{{\"ClientApplicationTypes\":[\"{0}\"],{1}}}", clientApplicationType, clientAppString);
            return completeClientApplicationString;
        }

        private static string getMinimumCompleteBrowserBasedClientApplicationDetails()
        {
            return "\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true,\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"\"},\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\",\"HardwareRequirements\":null,\"AdditionalInformation\":null,\"MobileFirstDesign\":true";
        }

        private static string getMinimumCompleteNativeMobileClientApplicationDetails()
        {
            return "\"NativeMobileHardwareRequirements\":null,\"NativeMobileFirstDesign\":true,\"MobileOperatingSystems\":{\"OperatingSystems\":[\"Apple IOS\",\"Android\"],\"OperatingSystemsDescription\":\"\"},\"MobileConnectionDetails\":{\"MinimumConnectionSpeed\":\"\",\"ConnectionType\":[],\"Description\":\"\"},\"MobileMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"Description\":\"Some storage description details\"},\"MobileThirdParty\":{\"ThirdPartyComponents\":\"\",\"DeviceCapabilities\":\"\"},\"NativeMobileAdditionalInformation\":null";
        }

        private static string parseBrowserBasedTemplate(string ignoredSection)
        {
            string clientAppStringTemplate = "{0}{1}{2}{3}\"HardwareRequirements\":null,\"AdditionalInformation\":null";
            string formattedString = string.Empty;

            var browsersSupported = "\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true,";
            var plugins = "\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"\"},";
            var connectivityAndResolution = "\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\",";
            var mobileFirstDesign = "\"MobileFirstDesign\":true,";

            switch (ignoredSection)
            {
                case "Browsers supported":
                    formattedString = string.Format(clientAppStringTemplate, "", plugins, connectivityAndResolution, mobileFirstDesign);
                    break;
                case "Plug-ins or extensions":
                    formattedString = string.Format(clientAppStringTemplate, browsersSupported, "", connectivityAndResolution, mobileFirstDesign);
                    break;
                case "Connectivity and resolution":
                    formattedString = string.Format(clientAppStringTemplate, browsersSupported, plugins, "", mobileFirstDesign);
                    break;
                case "Mobile first":
                    formattedString = string.Format(clientAppStringTemplate, browsersSupported, plugins, connectivityAndResolution, "");
                    break;
            }

            return formattedString;            
        }

        private static string parseNativeMobileTemplate(string ignoredSection)
        {
            string clientAppStringTemplate = "\"NativeMobileHardwareRequirements\":null,{0}{1}\"MobileConnectionDetails\":{{\"MinimumConnectionSpeed\":\"\",\"ConnectionType\":[],\"Description\":\"\"}},{2}\"MobileThirdParty\":{{\"ThirdPartyComponents\":\"\",\"DeviceCapabilities\":\"\"}},\"NativeMobileAdditionalInformation\":null";
            string formattedString = string.Empty;

            var mobileOperatingSystemsSupported = "\"MobileOperatingSystems\":{\"OperatingSystems\":[\"Apple IOS\",\"Android\"],\"OperatingSystemsDescription\":\"\"},";
            var nativeMobileFirstDesign = "\"NativeMobileFirstDesign\":true,";
            var mobileMemoryAndStorage = "\"MobileMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"Description\":\"Some storage description details\"},";

            switch (ignoredSection)
            {
                case "Mobile first":
                    formattedString = string.Format(clientAppStringTemplate, "", mobileOperatingSystemsSupported, mobileMemoryAndStorage);
                    break;
                case "Supported operating systems":
                    formattedString = string.Format(clientAppStringTemplate, nativeMobileFirstDesign, "", mobileMemoryAndStorage);
                    break;
                case "Memory and storage":
                    formattedString = string.Format(clientAppStringTemplate, nativeMobileFirstDesign, mobileOperatingSystemsSupported, "");
                    break;
            }

            return formattedString;            
        }
    }
}
