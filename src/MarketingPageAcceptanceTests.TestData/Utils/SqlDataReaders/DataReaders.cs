using MarketingPageAcceptanceTests.TestData.ContactDetails;
using System;
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

        internal static IContactDetail GetContactDetails(IDataReader dr)
        {
            dr.Read();
            return new ContactDetail
            {
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                EmailAddress = dr["Email"].ToString(),
                PhoneNumber = dr["PhoneNumber"].ToString(),
                JobSector = dr["Department"].ToString()
            };
        }

        internal static object CreateContactDetails(IDataReader arg)
        {
            throw new NotImplementedException();
        }
    }
}
