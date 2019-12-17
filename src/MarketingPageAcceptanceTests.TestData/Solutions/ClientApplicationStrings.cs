using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public static class ClientApplicationStrings
    {
        const string clientApplicationCompleted = "{\"ClientApplicationTypes\":[\"browser-based\"],\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true,\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"\"},\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\",\"HardwareRequirements\":null,\"AdditionalInformation\":null,\"MobileFirstDesign\":true}";
        const string clientAppStringTemplate = "{{\"ClientApplicationTypes\":[\"browser-based\"],{0}{1}{2}\"HardwareRequirements\":null,\"AdditionalInformation\":null}}";

        public static string GetClientAppString(string ignoredSection = null)
        {
            if (string.IsNullOrEmpty(ignoredSection))
            {
                return clientApplicationCompleted;
            }

            var browsersSupported = "\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true,";
            var plugins = "\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"\"},";
            var connectivityAndResolution = "\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\",";
            var mobileFirstDesign = "\"MobileFirstDesign\":true,";

            string clientAppString = string.Empty;

            switch (ignoredSection)
            {
                case "Browsers supported":
                    clientAppString = string.Format(clientAppStringTemplate, plugins, connectivityAndResolution, mobileFirstDesign);
                    break;
                case "Plug-ins or extensions":
                    clientAppString = string.Format(clientAppStringTemplate, browsersSupported, connectivityAndResolution, mobileFirstDesign);
                    break;
                case "Connectivity and resolution":
                    clientAppString = string.Format(clientAppStringTemplate, browsersSupported, plugins, mobileFirstDesign);
                    break;
                case "Mobile first":
                    clientAppString = string.Format(clientAppStringTemplate, browsersSupported, plugins, connectivityAndResolution);
                    break;
            }

            return clientAppString;
        }
    }
}
