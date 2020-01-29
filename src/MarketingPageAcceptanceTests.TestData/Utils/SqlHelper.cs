using MarketingPageAcceptanceTests.TestData.ContactDetails;
using MarketingPageAcceptanceTests.TestData.Solutions;
using MarketingPageAcceptanceTests.TestData.Suppliers;
using MarketingPageAcceptanceTests.TestData.Utils.SqlDataReaders;
using System;
using System.Data.SqlClient;

namespace MarketingPageAcceptanceTests.TestData.Utils
{
    public static class SqlHelper
    {
        public static string GetSolutionFeatures(string solutionId, string connectionString)
        {
            var query = Queries.GetSolutionDetail;
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

        public static void CreateBlankSolution(Solution solution, SolutionDetail solutionDetail, string connectionString)
        {
            // Create a new solution that is absolutely bare bones
            var solutionQuery = Queries.CreateNewSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solution.Id),
                new SqlParameter("@solutionName", solution.Name),
                new SqlParameter("@solutionVersion", solution.Version),
                new SqlParameter("@supplierId", solution.SupplierId),
                new SqlParameter("@lastUpdatedBy", Guid.Empty),
                new SqlParameter("@lastUpdated", DateTime.Now)
            };

            SqlReader.Read(connectionString, solutionQuery, parameters, DataReaders.NoReturn);

            // Create a record in the SolutionDetail table for the new solution
            var solutionDetailQuery = Queries.CreateSolutionDetail;

            SqlParameter[] newParameters = new SqlParameter[] {
                new SqlParameter("@solutionDetailId", solutionDetail.SolutionDetailId),
                new SqlParameter("@solutionId", solutionDetail.SolutionId),
                new SqlParameter("@lastUpdatedBy", Guid.Empty),
                new SqlParameter("@lastUpdated", DateTime.Now)
            };

            SqlReader.Read(connectionString, solutionDetailQuery, newParameters, DataReaders.NoReturn);

            var updateSolutionDetail = Queries.UpdateSolutionSolutionDetailId;
            SqlParameter[] updateSolId = new SqlParameter[] {
                new SqlParameter("@solutionDetailId", solutionDetail.SolutionDetailId),
                new SqlParameter("@solutionId", solution.Id)
            };

            SqlReader.Read(connectionString, updateSolutionDetail, updateSolId, DataReaders.NoReturn);
        }

        public static void UpdateSolutionDetails(SolutionDetail solutionDetail, string connectionString)
        {
            var query = Queries.UpdateSolutionDetail;

            SqlParameter[] newParameters = new SqlParameter[]
            {
                new SqlParameter("@summary", solutionDetail.Summary),
                new SqlParameter("@solutionDetailsId", solutionDetail.SolutionDetailId),
                new SqlParameter("@solutionId", solutionDetail.SolutionId),
                new SqlParameter("@clientApplication", solutionDetail.ClientApplication),
                new SqlParameter("@features", solutionDetail.Features),
                new SqlParameter("@aboutUrl", solutionDetail.AboutUrl),
                new SqlParameter("@fullDescription", solutionDetail.FullDescription),
                new SqlParameter("@roadMap", solutionDetail.RoadMap),
                new SqlParameter("@hostingTypes", solutionDetail.HostingTypes)
            };            

            SqlReader.Read(connectionString, query, newParameters, DataReaders.NoReturn);
        }

        public static void UpdateLastUpdated(DateTime lastUpdated, string table, string whereKey, string whereValue, string connectionString)
        {
            var query = Queries.UpdateLastUpdated;
            //cant do table names as parameters
            //https://stackoverflow.com/questions/14003241/must-declare-the-table-variable-table
            //can't do the key as a parameter either as it treats it as a string with quotes
            query = query.Replace("@table", table).Replace("@whereKey", whereKey);

            SqlParameter[] newParameters = new SqlParameter[]
            {
                new SqlParameter("@lastUpdated", lastUpdated),
                new SqlParameter("@whereValue", whereValue)
            };

            SqlReader.Read(connectionString, query, newParameters, DataReaders.NoReturn);
        }

        public static DateTime GetLastUpdated(string table, string whereKey, string whereValue, string connectionString)
        {
            var query = Queries.GetLastUpdated;
            query = query.Replace("@table", table).Replace("@whereKey", whereKey);

            SqlParameter[] newParameters = new SqlParameter[]
            {
                new SqlParameter("@whereValue", whereValue)
            };

            var result = SqlReader.Read(connectionString, query, newParameters, DataReaders.GetLastUpdated);
            return result;
        }

        public static void DeleteSolution(string solutionId, string connectionString)
        {
            // Remove automated solution
            var solutionQuery = Queries.DeleteSolution;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            SqlReader.Read(connectionString, solutionQuery, parameters, DataReaders.NoReturn);

            // remove solution detail related to the above solution
            var solututionDetailQuery = Queries.DeleteSolutionDetail;

            SqlParameter[] newParameters = new SqlParameter[] {
                new SqlParameter("@solutionId", solutionId)
            };

            SqlReader.Read(connectionString, solututionDetailQuery, newParameters, DataReaders.NoReturn);
        }

        public static string GetSolutionAboutLink(string solutionId, string connectionString)
        {
            var query = Queries.GetSolutionDetail;

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

        public static IContactDetail GetContactDetail(string solutionId, string connectionString)
        {
            var query = Queries.GetMarketingContacts;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetContactDetails);

            return result;
        }

        public static int GetNumberOfContacts(string solutionId, string connectionString)
        {
            var query = Queries.GetNumberOfMarketingContactsForSolution;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetCount);

            return result;
        }

        public static void DeleteContactDetailsForSolution(string solutionId, string connectionString)
        {
            var query = Queries.DeleteMarketingContact;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@solutionId", solutionId)
            };

            SqlReader.Read(connectionString, query, parameters, DataReaders.NoReturn);
        }

        public static void CreateContactDetails(string solutionId, IContactDetail contactDetail, string connectionString)
        {
            var query = Queries.CreateMarketingContact;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@solutionId", solutionId),
                new SqlParameter("@firstName", contactDetail.FirstName),
                new SqlParameter("@lastName", contactDetail.LastName),
                new SqlParameter("@email", contactDetail.EmailAddress),
                new SqlParameter("@phoneNumber", contactDetail.PhoneNumber),
                new SqlParameter("@department", contactDetail.JobSector)
            };

            SqlReader.Read(connectionString, query, parameters, DataReaders.NoReturn);
        }

        public static void CreateSupplier(Supplier supplier, string connectionString)
        {
            var query = Queries.CreateNewSupplier;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@supplierId", supplier.Id),
                new SqlParameter("@name", supplier.Name),
                new SqlParameter("@legalName", supplier.LegalName),
                new SqlParameter("@summary", supplier.Summary),
                new SqlParameter("@supplierUrl", supplier.SupplierUrl),
                new SqlParameter("@lastUpdatedBy", Guid.Empty),
                new SqlParameter("@lastUpdated", DateTime.Now)
            };

            SqlReader.Read(connectionString, query, parameters, DataReaders.NoReturn);
        }

        public static void UpdateSolutionSupplierId(string solutionId, string supplierId, string connectionString)
        {
            var updateSolutionDetail = Queries.UpdateSolutionSupplierlId;
            SqlParameter[] updateSolId = new SqlParameter[] {
                new SqlParameter("@supplierId", supplierId),
                new SqlParameter("@solutionId", solutionId)
            };

            SqlReader.Read(connectionString, updateSolutionDetail, updateSolId, DataReaders.NoReturn);
        }

        public static void DeleteSupplier(string supplierId, string connectionString)
        {
            var solutionQuery = Queries.DeleteSupplier;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@supplierId", supplierId)
            };

            SqlReader.Read(connectionString, solutionQuery, parameters, DataReaders.NoReturn);
        }

        public static Supplier GetSupplier(string supplierId, string connectionString)
        {
            var query = Queries.GetSupplier;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@supplierId", supplierId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetSupplier);
            return result;
        }

        public static Supplier GetSupplierForSolution(string solutionId, string connectionString)
        {
            var query = Queries.GetSupplierForSolution;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@solutionId", solutionId)
            };

            var result = SqlReader.Read(connectionString, query, parameters, DataReaders.GetSupplier);
            return result;
        }

        public static void UpdateSupplier(Supplier supplier, string connectionString)
        {
            var query = Queries.UpdateSupplier;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@supplierId", supplier.Id),
                new SqlParameter("@name", supplier.Name),
                new SqlParameter("@legalName", supplier.LegalName),
                new SqlParameter("@summary", supplier.Summary),
                new SqlParameter("@supplierUrl", supplier.SupplierUrl),
                new SqlParameter("@lastUpdatedBy", Guid.Empty),
                new SqlParameter("@lastUpdated", DateTime.Now)
            };

            SqlReader.Read(connectionString, query, parameters, DataReaders.NoReturn);
        }
    }
}
