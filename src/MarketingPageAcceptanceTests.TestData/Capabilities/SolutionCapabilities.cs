using System;
using System.ComponentModel.DataAnnotations;

namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    public sealed class SolutionCapabilities
    {
        [Display(Name = "SolutionID")]
        public string SolutionID { get; set; }
        [Display(Name = "Capability ID")]
        public Guid CapabilityId { get; set; }
    }
}
