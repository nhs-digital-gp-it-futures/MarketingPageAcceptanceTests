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

        public static string GetSolutionSummary(string solutionId, string connectionString)
        {
            var query = "SELECT Summary from [dbo].[Solution] where Id=@solutionId";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read<string>(connectionString, query, parameters, GetSolutionSummary);

            return result;
        }

        public static string GetSolutionDescription(string solutionId, string connectionString)
        {
            var query = "SELECT FullDescription from [dbo].[Solution] where Id=@solutionId";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read<string>(connectionString, query, parameters, GetSolutionDescription);

            return result;
        }

        private static string GetSolutionSummary(IDataReader dr)
        {
            dr.Read();
            return dr["Summary"].ToString();
        }

        private static string GetSolutionDescription(IDataReader dr)
        {
            dr.Read();
            return dr["FullDescription"].ToString();
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

        public static int GetSolutionStatus(string solutionId, string connectionString)
        {
            var query = "SELECT SupplierStatusId from [dbo].[Solution] where Id=@solutionId";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read<int>(connectionString, query, parameters, GetSupplierStatus);

            return result;
        }

        private static int GetSupplierStatus(IDataReader dr)
        {
            dr.Read();
            int.TryParse(dr["SupplierStatusId"].ToString(), out int result);
            return result;
        }

        public static void ResetSolutionStatus(string solutionId, string connectionString)
        {
            var query = $"UPDATE Solution set SupplierStatusId=1 where Id=@solutionId";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            SqlReader.Read(connectionString, query, parameters, NullReturn);
        }

        private static string GetAboutUrl(IDataReader dr)
        {
            dr.Read();
            return dr["AboutUrl"].ToString();
        }

        private static string NullReturn(IDataReader dr)
        {
            dr.Read();
            return dr.ToString();
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
