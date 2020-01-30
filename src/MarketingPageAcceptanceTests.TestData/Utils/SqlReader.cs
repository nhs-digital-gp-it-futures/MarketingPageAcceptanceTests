using Polly;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MarketingPageAcceptanceTests.TestData.Utils
{
    internal static class SqlReader
    {
        internal static T Read<T>(string connectionString, string query, SqlParameter[] sqlParameters, Func<IDataReader, T> mapDataReader)
        {
            T returnValue = default;

            Policy.Handle<SqlException>()
                .Or<TimeoutException>()
                .WaitAndRetry(3, retryAttempt => TimeSpan.FromMilliseconds(500))
                .Execute(() =>
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (var command = new SqlCommand(query, connection))
                        {
                            //add the params
                            command.Parameters.AddRange(sqlParameters);

                            SqlDataReader reader = command.ExecuteReader();
                            try
                            {
                                returnValue = mapDataReader(reader);
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                }
            );

            return returnValue;
        }
    }
}
