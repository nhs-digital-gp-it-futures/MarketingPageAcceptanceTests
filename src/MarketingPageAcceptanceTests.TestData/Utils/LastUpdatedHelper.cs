using System;
using System.Linq;

namespace MarketingPageAcceptanceTests.TestData.Utils
{
    public static class LastUpdatedHelper
    {
        public static void UpdateLastUpdated(DateTime lastUpdated, string table, string whereKey, string whereValue, string connectionString)
        {
            var query = Queries.UpdateLastUpdated;
            query = query.Replace("@table", table).Replace("@whereKey", whereKey);
            SqlReader.Read<object>(connectionString, query, new { whereValue, lastUpdated });
        }

        public static DateTime GetLastUpdated(string table, string whereKey, string whereValue, string connectionString)
        {
            var query = Queries.GetLastUpdated;
            query = query.Replace("@table", table).Replace("@whereKey", whereKey);
            return SqlReader.Read<DateTime>(connectionString, query, new { whereValue }).Single();
        }
    }
}
