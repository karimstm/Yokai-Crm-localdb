using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Http.Headers;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class Account
    {
        /// <summary>
        /// Return all the accounts from the database
        /// </summary>
        /// <returns></returns>
        public static DataTable GetGridAccount()
        {
            var dt = DataLayer.ExecuteTable("GetGridAccount", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable GetAccountsById(int id)
        {
            var dt = DataLayer.ExecuteTable("usp_AccountSelectById", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@AccountId", SqlDbType.Int, id));
            return dt;
        }

        /// <summary>
        /// Insert an account and return the number of rows affected
        /// </summary>
        /// <returns></returns>
        public static async Task<int> InsertAccount(string accountname, string primaryemail,
            string primaryphone, string website, string fax, int numberemployees, int typeeid,
            string tickersymbol, string assignedto, string descriptions, string billingstreet,
            string billingcity, string billingstate, string billingcode, string billingcountry,
            string shippingstreet, string shippingcity, string shippingstate, string shippingcode,
            string shippingcoutry)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_AccountInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@AccountName", SqlDbType.NVarChar, accountname),
                DataLayer.CreateParameter("@PrimaryEmail", SqlDbType.NVarChar, primaryemail),
                DataLayer.CreateParameter("@PrimaryPhone", SqlDbType.NVarChar, primaryphone),
                DataLayer.CreateParameter("@WebSite", SqlDbType.NVarChar, website),
                DataLayer.CreateParameter("@Fax", SqlDbType.NVarChar, fax),
                DataLayer.CreateParameter("@NumberEmployees", SqlDbType.Int, numberemployees),
                DataLayer.CreateParameter("@TypeeId", SqlDbType.Int, typeeid),
                DataLayer.CreateParameter("@TickerSymbol", SqlDbType.NVarChar, tickersymbol),
                DataLayer.CreateParameter("@AssignedTo", SqlDbType.NVarChar, assignedto),
                DataLayer.CreateParameter("@Descriptions", SqlDbType.NVarChar, descriptions),
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
        public static async Task<int> UpdateAccount(int id, string accountname, string primaryemail,
            string primaryphone, string website, string fax, int numberemployees, int typeeid,
            string tickersymbol, string assignedto, string descriptions, string billingstreet,
            string billingcity, string billingstate, string billingcode, string billingcountry,
            string shippingstreet, string shippingcity, string shippingstate, string shippingcode,
            string shippingcoutry)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_AccountUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@AccountId", SqlDbType.Int, id),
                DataLayer.CreateParameter("@AccountName", SqlDbType.NVarChar, accountname),
                DataLayer.CreateParameter("@PrimaryEmail", SqlDbType.NVarChar, primaryemail),
                DataLayer.CreateParameter("@PrimaryPhone", SqlDbType.NVarChar, primaryphone),
                DataLayer.CreateParameter("@WebSite", SqlDbType.NVarChar, website),
                DataLayer.CreateParameter("@Fax", SqlDbType.NVarChar, fax),
                DataLayer.CreateParameter("@NumberEmployees", SqlDbType.Int, numberemployees),
                DataLayer.CreateParameter("@TypeeId", SqlDbType.Int, typeeid),
                DataLayer.CreateParameter("@TickerSymbol", SqlDbType.NVarChar, tickersymbol),
                DataLayer.CreateParameter("@AssignedTo", SqlDbType.NVarChar, assignedto),
                DataLayer.CreateParameter("@Descriptions", SqlDbType.NVarChar, descriptions),
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

        public static async Task<int> AccountDelete(int id)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_AccountDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@AccountId", SqlDbType.Int, id));
            return result;
        }

        public static DataTable GetSearchAccount(string id)
        {
            DataTable dt = DataLayer.ExecuteTable("SearchAccount", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.NVarChar, id));
            return dt;
        }
    }
}
