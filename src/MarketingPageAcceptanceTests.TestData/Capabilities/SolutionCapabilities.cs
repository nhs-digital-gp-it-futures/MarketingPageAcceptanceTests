namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    using System.ComponentModel.DataAnnotations;

    public sealed class SolutionCapabilities
    {
        public string SolutionID { get; set; }

        [Display(Name = "Capability ID")]
        public string CapabilityId { get; set; }
    }
}
