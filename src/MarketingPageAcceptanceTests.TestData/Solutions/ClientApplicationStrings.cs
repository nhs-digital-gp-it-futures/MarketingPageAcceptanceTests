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
        internal const string BrowserBased = "\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true,\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"\"},\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\",\"HardwareRequirements\":null,\"AdditionalInformation\":null,\"MobileFirstDesign\":true";
        internal const string BrowserBasedTemplate = "{0}{1}{2}{3}\"HardwareRequirements\":null,\"AdditionalInformation\":null";

        internal const string NativeMobile = "\"NativeMobileHardwareRequirements\":null,\"NativeMobileFirstDesign\":true,\"MobileOperatingSystems\":{\"OperatingSystems\":[\"Apple IOS\",\"Android\"],\"OperatingSystemsDescription\":\"\"},\"MobileConnectionDetails\":{\"MinimumConnectionSpeed\":\"\",\"ConnectionType\":[],\"Description\":\"\"},\"MobileMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"Description\":\"Some storage description details\"},\"MobileThirdParty\":{\"ThirdPartyComponents\":\"\",\"DeviceCapabilities\":\"\"},\"NativeMobileAdditionalInformation\":null";
        internal const string NativeMobileTemplate = "\"NativeMobileHardwareRequirements\":null,{0}{1}\"MobileConnectionDetails\":{{\"MinimumConnectionSpeed\":\"\",\"ConnectionType\":[],\"Description\":\"\"}},{2}\"MobileThirdParty\":{{\"ThirdPartyComponents\":\"\",\"DeviceCapabilities\":\"\"}},\"NativeMobileAdditionalInformation\":null";
    }
}
