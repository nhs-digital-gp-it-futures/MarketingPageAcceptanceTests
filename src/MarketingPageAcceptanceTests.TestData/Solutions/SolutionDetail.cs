using System;

namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public sealed class SolutionDetail
    {
        public Guid SolutionDetailId { get; set; }
        public string SolutionId { get; set; }
        public string AboutUrl { get; set; }
        public string Features { get; set; }
        public string ClientApplication { get; set; }
        public string Summary { get; set; }
        public string FullDescription { get; set; }

        public override string ToString()
        {
            return $"SolutionDetailId: {SolutionDetailId},\nSolutionId: {SolutionId},\nAboutUrl: {AboutUrl},\nFeatures: {Features},\nClientApplication: {ClientApplication}";
        }
    }
}
