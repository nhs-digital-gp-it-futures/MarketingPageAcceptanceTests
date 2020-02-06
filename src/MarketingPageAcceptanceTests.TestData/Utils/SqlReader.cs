using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MarketingPageAcceptanceTests.TestData.Utils
{
    internal static class SqlReader
    {
        internal static IEnumerable<T> Read<T>(string connectionString, string query, object param)
        {
            IEnumerable<T> returnValue = null;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Policies.RetryPolicy().Execute(() =>
                {
                    returnValue = connection.Query<T>(query, param);
                });
            }

            return returnValue;
        }

        internal static int ReadCount(string connectionString, string query, object param)
        {
            int result = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Policies.RetryPolicy().Execute(() =>
                {
                    result = connection.ExecuteScalar<int>(query, param);
                });
            }

            return result;
        }
    }
}
