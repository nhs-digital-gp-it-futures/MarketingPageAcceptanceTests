namespace MarketingPageAcceptanceTests.TestData.Solutions
{
    using System;
    using System.Threading.Tasks;
    using MarketingPageAcceptanceTests.TestData.Utils;

    public class FrameworkSolution
    {
        public string FrameworkId { get; set; }

        public string SolutionId { get; set; }

        public bool IsFoundation { get; set; }

        public Guid LastUpdatedBy { get; set; }

        public async Task Create(string connectionString)
        {
            var query = "INSERT INTO FrameworkSolutions (FrameworkId, SolutionId, IsFoundation, LastUpdated, LastUpdatedBy) VALUES (@FrameworkId, @SolutionId, @IsFoundation, GETUTCDATE(), @LastUpdatedBy);";
            await SqlExecutor.ExecuteAsync<FrameworkSolution>(connectionString, query, this);
        }

        public async Task Delete(string connectionString)
        {
            var query = "DELETE FROM FrameworkSolutions WHERE FrameworkId = @FrameworkId AND SolutionId = @SolutionId;";
            await SqlExecutor.ExecuteAsync<FrameworkSolution>(connectionString, query, this);
        }
    }
}
