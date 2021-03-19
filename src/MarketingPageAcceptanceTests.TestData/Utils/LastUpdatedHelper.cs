namespace MarketingPageAcceptanceTests.TestData.Utils
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public static class LastUpdatedHelper
    {
        public static async Task UpdateLastUpdatedAsync(
            DateTime lastUpdated,
            string table,
            string whereKey,
            string whereValue,
            string connectionString)
        {
            var query = @"UPDATE @table SET LastUpdated=@lastUpdated WHERE @whereKey=@whereValue";
            query = query.Replace("@table", table).Replace("@whereKey", whereKey);
            await SqlExecutor.ExecuteAsync<object>(connectionString, query, new { whereValue, lastUpdated });
        }

        public static async Task<DateTime> GetLastUpdatedAsync(string table, string whereKey, string whereValue, string connectionString)
        {
            var query = @"SELECT LastUpdated FROM @table WHERE @whereKey=@whereValue";
            query = query.Replace("@table", table).Replace("@whereKey", whereKey);
            return (await SqlExecutor.ExecuteAsync<DateTime>(connectionString, query, new { whereValue })).Single();
        }
    }
}
