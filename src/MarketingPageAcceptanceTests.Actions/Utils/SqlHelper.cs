using MarketingPageAcceptanceTests.TestData.Solutions;
using System;
using System.Data;
using System.Data.SqlClient;
using MarketingPageAcceptanceTests.Actions.Utils.SqlDataReaders;

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

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetFeatures);

            return result;
        }

        public static string GetSolutionSummary(string solutionId, string connectionString)
        {
            var query = Queries.GetSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetSolutionSummary);

            return result;
        }

        public static string GetSolutionDescription(string solutionId, string connectionString)
        {
            var query = Queries.GetSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetSolutionDescription);

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

            SqlReader.Read(connectionString, solutionQuery, parameters, DataReaders.NoReturn);

            // Create a record in the MarketingDetail table for the new solution
            var marketingDetailQuery = Queries.CreateMarketingDetail;

            SqlParameter[] newParameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solution.Id)
            };

            SqlReader.Read(connectionString, marketingDetailQuery, newParameters, DataReaders.NoReturn);
        }

        public static void UpdateMarketingDetails(MarketingDetail marketingDetail, string connectionString)
        {
            var query = Queries.UpdateMarketingDetail;

            SqlParameter[] newParameters = new SqlParameter[]
            {
                new SqlParameter("@solutionId", marketingDetail.SolutionId),
                new SqlParameter("@clientApplication", marketingDetail.ClientApplication),
                new SqlParameter("@features", marketingDetail.Features),
                new SqlParameter("@aboutUrl", marketingDetail.AboutUrl)
            };

            SqlReader.Read(connectionString, query, newParameters, DataReaders.NoReturn);
        }

        public static void DeleteSolution(string solutionId, string connectionString)
        {
            // Remove automated solution
            var solutionQuery = Queries.DeleteSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            SqlReader.Read(connectionString, solutionQuery, parameters, DataReaders.NoReturn);

            // remove marketing detail related to the above solution
            var marketingDetailQuery = Queries.DeleteMarketingDetail;

            SqlParameter[] newParameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            SqlReader.Read(connectionString, marketingDetailQuery, newParameters, DataReaders.NoReturn);
        }

        private static void NoReturn(IDataReader arg)
        {
            throw new NotImplementedException();
        }

        internal static string GetSolutionAboutLink(string solutionId, string connectionString)
        {
            var query = Queries.GetMarketingDetail;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetAboutUrl);

            return result;
        }

        public static int GetSolutionStatus(string solutionId, string connectionString)
        {
            var query = Queries.GetSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetSupplierStatus);

            return result;
        }
    }
}
