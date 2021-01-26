namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    using System.ComponentModel.DataAnnotations;

    public sealed class SolutionCapabilityEpics
    {
        [Display(Name = "Supplier ID")]
        public string SupplierID { get; set; }

        [Display(Name = "Solution ID")]
        public string SolutionID { get; set; }

        [Display(Name = "Additional Service ID")]
        public string AdditionalServiceID { get; set; } = string.Empty;

        [Display(Name = "Capability ID")]
        public string CapabilityID { get; set; }

        [Display(Name = "Epic ID")]
        public string EpicID { get; set; }

        public string Level { get; set; }

        [Display(Name = "Epic Final Assessment Result")]
        public string EpicFinalAssessmentResult { get; set; }
    }
}
