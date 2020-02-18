using MarketingPageAcceptanceTests.TestData.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketingPageAcceptanceTests.TestData.Capabilities
{
    public sealed class EpicDto
    {
        [Display(Name = "Epic ID")]        
        public string Id { get; set; }        
        [Display(Name = "Epic Final Assessment Result")]
        public string EpicFinalAssessmentResult { get; set; }

        internal IEnumerable<EpicDto> GetAllByIdPrefix(string connectionString, string id)
        {
            var query = Queries.GetAllEpicsByCapabilityPrefix;
            return SqlExecutor.Execute<EpicDto>(connectionString, query, new { Id = id });
        }
    }
}
