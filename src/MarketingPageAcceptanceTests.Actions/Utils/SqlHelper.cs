using System;
using System.Data;
using System.Data.SqlClient;

namespace MarketingPageAcceptanceTests.Actions.Utils
{
    public static class SqlHelper
    {
        public static string GetSolutionFeatures(string solutionId, string connectionString)
        {
            var query = Queries.GetMarketingDetail;
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read<string>(connectionString, query, parameters, GetFeatures);

            return result;
        }

        public static string GetSolutionSummary(string solutionId, string connectionString)
        {
            var query = Queries.GetSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read<string>(connectionString, query, parameters, GetSolutionSummary);

            return result;
        }

        public static string GetSolutionDescription(string solutionId, string connectionString)
        {
            var query = Queries.GetSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read<string>(connectionString, query, parameters, GetSolutionDescription);

            return result;
        }

        public static void CreateBlankSolution(Solution solution, string connectionString)
        {
            // Create a new solution that is absolutely bare bones
            var solutionQuery = Queries.CreateNewSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solution.Id),
                new SqlParameter("@solutionName", solution.Name),
                new SqlParameter("@solutionVersion", solution.Version)
            };

            SqlReader.Read<string>(connectionString, solutionQuery, parameters, NewSolution);

            // Create a record in the MarketingDetail table for the new solution
            var marketingDetailQuery = Queries.CreateMarketingDetail;

            SqlParameter[] newParameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solution.Id)
            };

            SqlReader.Read<string>(connectionString, marketingDetailQuery, newParameters, NewSolution);
        }

        public static void DeleteSolution(string solutionId, string connectionString)
        {
            // Remove automated solution
            var solutionQuery = Queries.DeleteSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            SqlReader.Read<string>(connectionString, solutionQuery, parameters, NewSolution);

            // remove marketing detail related to the above solution
            var marketingDetailQuery = Queries.DeleteMarketingDetail;

            SqlParameter[] newParameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            SqlReader.Read<string>(connectionString, marketingDetailQuery, newParameters, NewSolution);
        }

        private static string NewSolution(IDataReader dr)
        {
            dr.Read();
            return dr.ToString();
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
            var query = Queries.GetMarketingDetail;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read<string>(connectionString, query, parameters, GetAboutUrl);

            return result;
        }

        public static int GetSolutionStatus(string solutionId, string connectionString)
        {
            var query = Queries.GetSolution;

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
