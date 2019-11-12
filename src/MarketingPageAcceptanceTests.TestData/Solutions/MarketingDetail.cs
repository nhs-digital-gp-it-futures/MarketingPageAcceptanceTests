namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    public sealed class MarketingDetail
    {
        public string SolutionId { get; set; }
        public string AboutUrl { get; set; }
        public string Features { get; set; }
        public string ClientApplication { get; set; }

        public override string ToString()
        {
            return $"SolutionId: {SolutionId},\nAboutUrl: {AboutUrl},\nFeatures: {Features},\nClientApplication: {ClientApplication}";
        }
    }
}
