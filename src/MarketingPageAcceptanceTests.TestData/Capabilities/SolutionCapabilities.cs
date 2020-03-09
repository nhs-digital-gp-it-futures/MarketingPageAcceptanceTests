using System.ComponentModel.DataAnnotations;

namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    public sealed class SolutionCapabilities
    {
        public string SolutionID { get; set; }
        [Display(Name = "Capability ID")] public string CapabilityId { get; set; }
    }
}