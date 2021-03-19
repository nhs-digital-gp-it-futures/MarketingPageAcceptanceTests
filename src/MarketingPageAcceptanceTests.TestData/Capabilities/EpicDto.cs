namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using MarketingPageAcceptanceTests.TestData.Utils;

    public sealed class EpicDto
    {
        [Display(Name = "Epic ID")]
        public string Id { get; set; }

        [Display(Name = "Epic Final Assessment Result")]
        public string EpicFinalAssessmentResult { get; set; }

        internal static async Task<IEnumerable<EpicDto>> GetAllByIdPrefixAsync(string connectionString, string id)
        {
            var query = "SELECT * FROM Epic WHERE Id LIKE @ID";
            return await SqlExecutor.ExecuteAsync<EpicDto>(connectionString, query, new { Id = id + "%" });
        }
    }
}
