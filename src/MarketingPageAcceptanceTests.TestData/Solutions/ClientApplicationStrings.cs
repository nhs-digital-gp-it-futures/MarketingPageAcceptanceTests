using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    /// <summary>
    /// Class to hold the client application string details for given client application types
    /// Templates are used to swap out the mandatory details, while leaving optional fields with null or default data
    /// If you add or remove fields to a string, please update the template too as necessary
    /// 
    /// These strings are used by the ClientApplicationStringBuilder class
    /// </summary>
    internal static class ClientApplicationStrings
    {
        internal const string BrowserBasedComplete = "\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true,\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"\"},\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\",\"HardwareRequirements\":null,\"AdditionalInformation\":null,\"MobileFirstDesign\":true";
        internal const string NativeMobileComplete = "\"NativeMobileHardwareRequirements\":null,\"NativeMobileFirstDesign\":true,\"MobileOperatingSystems\":{\"OperatingSystems\":[\"Apple IOS\",\"Android\"],\"OperatingSystemsDescription\":\"\"},\"MobileConnectionDetails\":{\"MinimumConnectionSpeed\":\"\",\"ConnectionType\":[],\"Description\":\"\"},\"MobileMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"Description\":\"Some storage description details\"},\"MobileThirdParty\":{\"ThirdPartyComponents\":\"\",\"DeviceCapabilities\":\"\"},\"NativeMobileAdditionalInformation\":null";
        internal const string NativeDesktopComplete = "\"NativeDesktopOperatingSystemsDescription\":\"Windows 7,8,10\r\nUbuntu\",\"NativeDesktopMinimumConnectionSpeed\":\"0.5Mbps\",\"NativeDesktopThirdParty\":null,\"NativeDesktopMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"StorageRequirementsDescription\":\"approximately 10MB, plus additional for cache\",\"MinimumCpu\":\"0.98hz\",\"RecommendedResolution\":\"16:9 - 640 x 360\"},\"NativeDesktopHardwareRequirements\":null,\"NativeDesktopAdditionalInformation\":null";

        internal static Dictionary<string, string> BrowserSections = new Dictionary<string, string>() 
        {
            { "Browsers supported", "\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true,"},
            { "Plug-ins or extensions", "\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"\"}," },
            { "Connectivity and resolution", "\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\","},
            { "Mobile first", "\"MobileFirstDesign\":true," }
        };

        internal static Dictionary<string, string> NativeMobileSections = new Dictionary<string, string>()
        {
            { "Mobile first", "\"NativeMobileFirstDesign\":true," },
            { "Supported operating systems", "\"MobileOperatingSystems\":{\"OperatingSystems\":[\"Apple IOS\",\"Android\"],\"OperatingSystemsDescription\":\"\"}," },
            { "Memory and storage", "\"MobileMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"Description\":\"Some storage description details\"}," }
        };

        internal static Dictionary<string, string> NativeDesktopSections = new Dictionary<string, string>()
        {
            { "Supported operating systems", "\"NativeDesktopOperatingSystemsDescription\":\"Windows 7,8,10\r\nUbuntu\","},
            { "Connection details", "\"NativeDesktopMinimumConnectionSpeed\":\"0.5Mbps\"," },
            { "Memory, storage, processing and aspect ratio", "\"NativeDesktopMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"StorageRequirementsDescription\":\"approximately 10MB, plus additional for cache\",\"MinimumCpu\":\"0.98hz\",\"RecommendedResolution\":\"16:9 - 640 x 360\"}," }
        };
    }
}
