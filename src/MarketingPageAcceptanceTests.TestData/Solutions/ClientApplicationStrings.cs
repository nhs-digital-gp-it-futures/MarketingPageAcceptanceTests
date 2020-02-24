using System.Collections.Generic;

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
        internal const string BrowserBasedComplete = "\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true,\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"Plugins additional info\"},\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\",\"HardwareRequirements\":\"Hardware Requirements\",\"AdditionalInformation\":\"Additional Information\",\"MobileFirstDesign\":true";
        internal const string NativeMobileComplete = "\"NativeMobileHardwareRequirements\":\"Hardware Requirements\",\"NativeMobileFirstDesign\":true,\"MobileOperatingSystems\":{\"OperatingSystems\":[\"Apple IOS\",\"Android\"],\"OperatingSystemsDescription\":\"Operating System Description\"},\"MobileConnectionDetails\":{\"MinimumConnectionSpeed\":\"1Mbps\",\"ConnectionType\":[\"GPRS\",\"3G\",\"4G\",\"5G\",\"Wifi\"],\"Description\":\"Connection Details Description\"},\"MobileMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"Description\":\"Additional Storage Requirements\"},\"MobileThirdParty\":{\"ThirdPartyComponents\":\"Components Description\",\"DeviceCapabilities\":\"Device Capabilities Description\"},\"NativeMobileAdditionalInformation\":\"Additional Information\"";
        internal const string NativeDesktopComplete = "\"NativeDesktopHardwareRequirements\":\"Hardware requirements\",\"NativeDesktopOperatingSystemsDescription\":\"Windows 7,8,10\r\nUbuntu\",\"NativeDesktopMinimumConnectionSpeed\":\"0.5Mbps\",\"NativeDesktopThirdParty\":{\"ThirdPartyComponents\":\"Third party\",\"DeviceCapabilities\":\"Device Capabilities\"},\"NativeDesktopMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"StorageRequirementsDescription\":\"approximately 10MB, plus additional for cache\",\"MinimumCpu\":\"0.98hz\",\"RecommendedResolution\":\"16:9 - 640 x 360\"},\"NativeDesktopAdditionalInformation\":\"Additional Information\"";

        internal static Dictionary<string, string> BrowserSections = new Dictionary<string, string>()
        {
            { "Supported browsers", "\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true,"},
            { "Plug-ins or extensions required", "\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"Plugins additional info\"}," },
            { "Connectivity and resolution", "\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\","},
            { "Mobile first approach", "\"MobileFirstDesign\":true" },
            { "Hardware requirements",  "\"HardwareRequirements\":\"Hardware Requirements\","},
            {"Additional information",  "\"AdditionalInformation\":\"Additional Information\","}
        };

        internal static Dictionary<string, string> NativeMobileSections = new Dictionary<string, string>()
        {
            { "Mobile first approach", "\"NativeMobileFirstDesign\":true," },
            { "Supported operating systems", "\"MobileOperatingSystems\":{\"OperatingSystems\":[\"Apple IOS\",\"Android\"],\"OperatingSystemsDescription\":\"Operating System Description\"}," },
            { "Memory and storage", "\"MobileMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"Description\":\"Additional Storage Requirements\"}," },
            { "Hardware requirements", "\"NativeMobileHardwareRequirements\":\"Hardware Requirements\"," },
            { "Additional information", "\"NativeMobileAdditionalInformation\":\"Additional Information\"}" },
            { "Connectivity",  "\"MobileConnectionDetails\":{\"MinimumConnectionSpeed\":\"1Mbps\",\"ConnectionType\":[\"GPRS\",\"3G\",\"4G\",\"5G\",\"Wifi\"],\"Description\":\"Connection Details Description\"},"},

        };

        internal static Dictionary<string, string> NativeDesktopSections = new Dictionary<string, string>()
        {
            { "Supported operating systems", "\"NativeDesktopOperatingSystemsDescription\":\"Windows 7,8,10\r\nUbuntu\","},
            { "Connectivity", "\"NativeDesktopMinimumConnectionSpeed\":\"0.5Mbps\"," },
            { "Memory, storage, processing and resolution", "\"NativeDesktopMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"StorageRequirementsDescription\":\"approximately 10MB, plus additional for cache\",\"MinimumCpu\":\"0.98hz\",\"RecommendedResolution\":\"16:9 - 640 x 360\"}," }
        };
    }
}
