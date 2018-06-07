using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Yokai.Crm.DataAccess;


namespace Yokai.Crm.Core
{
    public class Contact
    {
        /// <summary>
        /// Insert a new contact info
        /// </summary>
        /// <returns></returns>
        public static async Task<int> ContactInsert(int? accountId, string firstName, string lastName, int? Prospectsource,
            int? prospectStatus, string departement, string email, string phone, string title, string mobile, string homephone, string fax,
            DateTime dateOfbirth, string skypeId, int? vendor, string description, string billingstreet,
            string billingcity, string billingstate, string billingcode, string billingcountry,
            string shippingstreet, string shippingcity, string shippingstate, string shippingcode,
            string shippingcoutry)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_ContactInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@AccountId", SqlDbType.Int, accountId),
                DataLayer.CreateParameter("@FirstName", SqlDbType.NVarChar, firstName),
                DataLayer.CreateParameter("@LastName", SqlDbType.NVarChar, lastName),
                DataLayer.CreateParameter("@ProspectSourceId", SqlDbType.Int, Prospectsource),
                DataLayer.CreateParameter("@ProspectStatusId", SqlDbType.Int, prospectStatus),
                DataLayer.CreateParameter("@Departememt", SqlDbType.NVarChar, departement),
                DataLayer.CreateParameter("@Email", SqlDbType.NVarChar, email),
                DataLayer.CreateParameter("@Phone", SqlDbType.NVarChar, phone),
                DataLayer.CreateParameter("@Title ", SqlDbType.NVarChar, title),
                DataLayer.CreateParameter("@Mobile", SqlDbType.NVarChar, mobile),
                DataLayer.CreateParameter("@HomePhone", SqlDbType.NVarChar, homephone),
                DataLayer.CreateParameter("@Fax", SqlDbType.NVarChar, fax),
                DataLayer.CreateParameter("@DateOfBirth", SqlDbType.Date, dateOfbirth),
                DataLayer.CreateParameter("@SkypeId", SqlDbType.NVarChar, skypeId),
                DataLayer.CreateParameter("@VendorId", SqlDbType.Int, vendor),
                DataLayer.CreateParameter("@Description", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@BillingStreet", SqlDbType.NVarChar, billingstreet),
                DataLayer.CreateParameter("@BillingCity", SqlDbType.NVarChar, billingcity),
                DataLayer.CreateParameter("@BillingState", SqlDbType.NVarChar, billingstate),
                DataLayer.CreateParameter("@BillingCode", SqlDbType.NVarChar, billingcode),
                DataLayer.CreateParameter("@BillingCountry", SqlDbType.NVarChar, billingcountry),
                DataLayer.CreateParameter("@ShippingStreet", SqlDbType.NVarChar, shippingstreet),
                DataLayer.CreateParameter("@ShippingCity", SqlDbType.NVarChar, shippingcity),
                DataLayer.CreateParameter("@ShippingState", SqlDbType.NVarChar, shippingstate),
                DataLayer.CreateParameter("@ShippingCode", SqlDbType.NVarChar, shippingcode),
                DataLayer.CreateParameter("@ShippingCoutry", SqlDbType.NVarChar, shippingcoutry)
            );
            return result;
        }
        /// <summary>
        /// Update contact informations
        /// </summary>  
        /// <returns></returns>
        public static async Task<int> ContactUpdate(int id, int? accountId, string firstName, string lastName, int? Prospectsource,
            int? prospectStatus, string departement, string email, string phone, string title, string mobile, string homephone, string fax,
            DateTime dateOfbirth, string skypeId, int? vendor, string description, string billingstreet,
            string billingcity, string billingstate, string billingcode, string billingcountry,
            string shippingstreet, string shippingcity, string shippingstate, string shippingcode,
            string shippingcoutry)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_ContactUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ContactId", SqlDbType.Int, id),
                DataLayer.CreateParameter("@AccountId", SqlDbType.Int, accountId),
                DataLayer.CreateParameter("@FirstName", SqlDbType.NVarChar, firstName),
                DataLayer.CreateParameter("@LastName", SqlDbType.NVarChar, lastName),
                DataLayer.CreateParameter("@ProspectSourceId", SqlDbType.Int, Prospectsource),
                DataLayer.CreateParameter("@ProspectStatusId", SqlDbType.Int, prospectStatus),
                DataLayer.CreateParameter("@Departememt", SqlDbType.NVarChar, departement),
                DataLayer.CreateParameter("@Email", SqlDbType.NVarChar, email),
                DataLayer.CreateParameter("@Phone", SqlDbType.NVarChar, phone),
                DataLayer.CreateParameter("@Title ", SqlDbType.NVarChar, title),
                DataLayer.CreateParameter("@Mobile", SqlDbType.NVarChar, mobile),
                DataLayer.CreateParameter("@HomePhone", SqlDbType.NVarChar, homephone),
                DataLayer.CreateParameter("@Fax", SqlDbType.NVarChar, fax),
                DataLayer.CreateParameter("@DateOfBirth", SqlDbType.Date, dateOfbirth),
                DataLayer.CreateParameter("@SkypeId", SqlDbType.NVarChar, skypeId),
                DataLayer.CreateParameter("@VendorId", SqlDbType.Int, vendor),
                DataLayer.CreateParameter("@Description", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@BillingStreet", SqlDbType.NVarChar, billingstreet),
                DataLayer.CreateParameter("@BillingCity", SqlDbType.NVarChar, billingcity),
                DataLayer.CreateParameter("@BillingState", SqlDbType.NVarChar, billingstate),
                DataLayer.CreateParameter("@BillingCode", SqlDbType.NVarChar, billingcode),
                DataLayer.CreateParameter("@BillingCountry", SqlDbType.NVarChar, billingcountry),
                DataLayer.CreateParameter("@ShippingStreet", SqlDbType.NVarChar, shippingstreet),
                DataLayer.CreateParameter("@ShippingCity", SqlDbType.NVarChar, shippingcity),
                DataLayer.CreateParameter("@ShippingState", SqlDbType.NVarChar, shippingstate),
                DataLayer.CreateParameter("@ShippingCode", SqlDbType.NVarChar, shippingcode),
                DataLayer.CreateParameter("@ShippingCoutry", SqlDbType.NVarChar, shippingcoutry)
            );
            return result;
        }
        public static DataTable GetContact()
        {
            string query = "usp_ContactSelect";
            DataTable dt = DataLayer.ExecuteTable(query, CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable GetContactById(int id)
        {
            string query = "usp_ContactSelectById";
            DataTable dt = DataLayer.ExecuteTable(query, CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ContactId", SqlDbType.Int, id));
            return dt;
        }

        public static async Task<int> DeleteContact(int id)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_ContactDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ContactId", SqlDbType.Int, id));
            return result;
        }

        public static DataTable SearchByStautSource(int sourceid, int statuid)
        {
            var dt = DataLayer.ExecuteTable("SearchByStautSource", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@SourceId", SqlDbType.Int, sourceid),
                DataLayer.CreateParameter("@StatusId", SqlDbType.Int, statuid));
            return dt;
        }
        public static DataTable SearchBySkipId(string skipeid)
        {
            var dt = DataLayer.ExecuteTable("SearchBySkipId", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@SkipId", SqlDbType.NVarChar, skipeid));
            return dt;
        }
        public static DataTable SearchByName(string FirstName, string LastName)
        {
            var dt = DataLayer.ExecuteTable("SearchByName", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@FirstName", SqlDbType.NVarChar, FirstName),
                DataLayer.CreateParameter("@LastName", SqlDbType.NVarChar, LastName));
            return dt;
        }
        public static DataTable SearchByContactId(string ContactId)
        {
            var dt = DataLayer.ExecuteTable("SearchByContactId", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ContactId", SqlDbType.NVarChar, ContactId));
            return dt;
        }
    }
}
