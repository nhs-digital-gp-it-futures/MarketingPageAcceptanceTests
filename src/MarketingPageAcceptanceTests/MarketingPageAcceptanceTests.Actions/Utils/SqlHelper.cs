using System;
using System.Data;
using System.Data.SqlClient;

namespace MarketingPageAcceptanceTests.Actions.Utils
{
    public static class SqlHelper
    {
        public static string GetSolutionFeatures(string solutionId, string connectionString)
        {
            var query = "SELECT Features from [dbo].[MarketingDetail] where SolutionId=@solutionId";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read<string>(connectionString, query, parameters, GetFeatures);

            return result;
        }

        private static string GetFeatures(IDataReader dr)
        {
            dr.Read();
            return dr["Features"].ToString();
        }

        internal static string GetSolutionAboutLink(string solutionId, string connectionString)
        {
            var query = "SELECT AboutUrl from[dbo].[MarketingDetail] where SolutionId=@solutionId";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read<string>(connectionString, query, parameters, GetAboutUrl);

            return result;
        }

        private static string GetAboutUrl(IDataReader dr)
        {
            dr.Read();
            return dr["AboutUrl"].ToString();
        }
    }

    public static class SqlReader
    {
        public static T Read<T>(string connectionString, string query, SqlParameter[] sqlParameters, Func<IDataReader, T> mapDataReader)
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
                        return mapDataReader(reader);
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }

        }
    }

}
