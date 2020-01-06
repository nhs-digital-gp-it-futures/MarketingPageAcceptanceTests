namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public static class ClientApplicationStrings
    {
        const string clientApplicationCompleted = "{\"ClientApplicationTypes\":[\"browser-based\"],\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true,\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"\"},\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\",\"HardwareRequirements\":null,\"NativeMobileHardwareRequirements\":null,\"AdditionalInformation\":null,\"MobileFirstDesign\":true,\"NativeMobileFirstDesign\":true,\"MobileOperatingSystems\":{\"OperatingSystems\":[\"Apple IOS\",\"Android\"],\"OperatingSystemsDescription\":\"\"},\"MobileConnectionDetails\":{\"MinimumConnectionSpeed\":\"\",\"ConnectionType\":[],\"Description\":\"\"},\"MobileMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"Description\":\"Some storage description details\"},\"MobileThirdParty\":{\"ThirdPartyComponents\":\"\",\"DeviceCapabilities\":\"\"},\"NativeMobileAdditionalInformation\":null}";
        const string clientAppStringTemplate = "{{\"ClientApplicationTypes\":[\"browser-based\"],{0}{1}{2}{3}\"HardwareRequirements\":null,\"NativeMobileHardwareRequirements\":null,\"AdditionalInformation\":null,{4}{5}\"MobileConnectionDetails\":{{\"MinimumConnectionSpeed\":\"\",\"ConnectionType\":[],\"Description\":\"\"}},{6}\"MobileThirdParty\":{{\"ThirdPartyComponents\":\"\",\"DeviceCapabilities\":\"\"}},\"NativeMobileAdditionalInformation\":null}}";

        public static string GetClientAppString(string ignoredSection = null, string clientApplicationTypes = "Browser based")
        {
            if (string.IsNullOrEmpty(ignoredSection))
            {
                return parseClientApplicationType(clientApplicationTypes, clientApplicationCompleted);
            }

            var browsersSupported = "\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true,";
            var plugins = "\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"\"},";
            var connectivityAndResolution = "\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\",";
            var mobileFirstDesign = "\"MobileFirstDesign\":true,";

            var mobileOperatingSystemsSupported = "\"MobileOperatingSystems\":{\"OperatingSystems\":[\"Apple IOS\",\"Android\"],\"OperatingSystemsDescription\":\"\"},";
            var nativeMobileFirstDesign = "\"NativeMobileFirstDesign\":true,";
            var mobileMemoryAndStorage = "\"MobileMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"Description\":\"Some storage description details\"},";

            string clientAppString = string.Empty;

            //to differentiate between browser and native mobile 'mobile first' sections
            if (ignoredSection.Equals("Mobile first") && clientApplicationTypes.Contains("Native mobile"))
            {
                ignoredSection = "Native mobile first";
            }

            switch (ignoredSection)
            {
                case "Browsers supported":
                    clientAppString = string.Format(clientAppStringTemplate, "", plugins, connectivityAndResolution, mobileFirstDesign, nativeMobileFirstDesign, mobileOperatingSystemsSupported, mobileMemoryAndStorage);
                    break;
                case "Plug-ins or extensions":
                    clientAppString = string.Format(clientAppStringTemplate, browsersSupported, "", connectivityAndResolution, mobileFirstDesign, nativeMobileFirstDesign, mobileOperatingSystemsSupported, mobileMemoryAndStorage);
                    break;
                case "Connectivity and resolution":
                    clientAppString = string.Format(clientAppStringTemplate, browsersSupported, plugins, "", mobileFirstDesign, nativeMobileFirstDesign, mobileOperatingSystemsSupported, mobileMemoryAndStorage);
                    break;
                case "Mobile first":
                    clientAppString = string.Format(clientAppStringTemplate, browsersSupported, plugins, connectivityAndResolution, "", nativeMobileFirstDesign, mobileOperatingSystemsSupported, mobileMemoryAndStorage);
                    break;
                case "Native mobile first":
                    clientAppString = string.Format(clientAppStringTemplate, browsersSupported, plugins, connectivityAndResolution, mobileFirstDesign, "", mobileOperatingSystemsSupported, mobileMemoryAndStorage);
                    break;
                case "Supported operating systems":
                    clientAppString = string.Format(clientAppStringTemplate, browsersSupported, plugins, connectivityAndResolution, mobileFirstDesign, nativeMobileFirstDesign, "", mobileMemoryAndStorage);
                    break;
                case "Memory and storage":
                    clientAppString = string.Format(clientAppStringTemplate, browsersSupported, plugins, connectivityAndResolution, mobileFirstDesign, nativeMobileFirstDesign, mobileOperatingSystemsSupported, "");
                    break;
            }

            return parseClientApplicationType(clientApplicationTypes, clientAppString);
        }

        private static string parseClientApplicationType(string clientApplicationType, string clientAppString)
        {
            clientApplicationType = clientApplicationType.Replace("Browser based", "browser-based");
            clientApplicationType = clientApplicationType.Replace("Native mobile or tablet", "native-mobile");
            clientApplicationType = clientApplicationType.Replace("Native desktop", "native-desktop");
            string newFormattedClientApplicationType = string.Format("\"ClientApplicationTypes\":[\"{0}\"]", clientApplicationType);
            string formattedClientApplicationString = clientAppString.Replace("\"ClientApplicationTypes\":[\"browser-based\"]", newFormattedClientApplicationType);
            return formattedClientApplicationString;
        }
    }
}
