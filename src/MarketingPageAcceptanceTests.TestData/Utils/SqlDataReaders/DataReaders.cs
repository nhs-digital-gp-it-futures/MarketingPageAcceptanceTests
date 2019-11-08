using System.Data;

namespace MarketingPageAcceptanceTests.TestData.Utils.SqlDataReaders
{
    public static class DataReaders
    {
        internal static object NoReturn(IDataReader dr)
        {
            dr.Read();
            return null;
        }

        internal static string GetSolutionSummary(IDataReader dr)
        {
            dr.Read();
            return dr["Summary"].ToString();
        }

        internal static string GetSolutionDescription(IDataReader dr)
        {
            dr.Read();
            return dr["FullDescription"].ToString();
        }

        internal static string GetFeatures(IDataReader dr)
        {
            dr.Read();
            return dr["Features"].ToString();
        }

        internal static int GetSupplierStatus(IDataReader dr)
        {
            dr.Read();
            int.TryParse(dr["SupplierStatusId"].ToString(), out int result);
            return result;
        }

        internal static string GetAboutUrl(IDataReader dr)
        {
            dr.Read();
            return dr["AboutUrl"].ToString();
        }
    }
}
