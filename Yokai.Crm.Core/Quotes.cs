using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class Quotes
    {
        public static DataTable GetQuotes()
        {
            var dt = DataLayer.ExecuteTable("usp_QuoteSelect", CommandType.StoredProcedure);
            return dt;
        }

        public static async Task<int> QuoteInsert(int? contactid, int? accountid, int? apportunityid,
            string quotesubject, string quotestage, string quoteteam, string quotecarrier,
            DateTime quotevaliduntil, string description, decimal total, string tearmandcondition,
            string billingcity, string billingcode, string billingcountry, string billingstreet,
            string shippingstreet, string shippingcity, string shippingcode,
            string shippingcoutry, DataTable quoteDetail)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_QuoteInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ContactId", SqlDbType.Int, contactid),
                DataLayer.CreateParameter("@AccountId", SqlDbType.Int, accountid),
                DataLayer.CreateParameter("@OpportunityId", SqlDbType.Int, apportunityid),
                DataLayer.CreateParameter("@QuoteSubject", SqlDbType.NVarChar, quotesubject),
                DataLayer.CreateParameter("@QuoteStage", SqlDbType.NVarChar, quotestage),
                DataLayer.CreateParameter("@QuoteTeam", SqlDbType.NVarChar, quoteteam),
                DataLayer.CreateParameter("@QuoteCarrier", SqlDbType.NVarChar, quotecarrier),
                DataLayer.CreateParameter("@QuoteValidUntil", SqlDbType.DateTime, quotevaliduntil),
                DataLayer.CreateParameter("@Descriptions", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@Total", SqlDbType.Decimal, total),
                DataLayer.CreateParameter("@TermsAndConditions", SqlDbType.NVarChar, tearmandcondition),
                DataLayer.CreateParameter("@BillingStreet", SqlDbType.NVarChar, billingstreet),
                DataLayer.CreateParameter("@BillingCity", SqlDbType.NVarChar, billingcity),
                DataLayer.CreateParameter("@BillingCode", SqlDbType.NVarChar, billingcode),
                DataLayer.CreateParameter("@BillingCountry", SqlDbType.NVarChar, billingcountry),
                DataLayer.CreateParameter("@ShippingStreet", SqlDbType.NVarChar, shippingstreet),
                DataLayer.CreateParameter("@ShippingCity", SqlDbType.NVarChar, shippingcity),
                DataLayer.CreateParameter("@ShippingCode", SqlDbType.NVarChar, shippingcode),
                DataLayer.CreateParameter("@ShippingCountry", SqlDbType.NVarChar, shippingcoutry),
                DataLayer.CreateParameter("@QuoteTable", SqlDbType.Structured, quoteDetail)
                );
            return result;
        }

        public static DataTable QuoteById(int id)
        {
            var dt = DataLayer.ExecuteTable("QuoteSelectById", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.Int, id));
            return dt;
        }

        public static async Task<int> QuoteUpdate(int? quoteid,int? contactid, int? accountid, int? apportunityid,
            string quotesubject, string quotestage, string quoteteam, string quotecarrier,
            DateTime quotevaliduntil, int? personaddressid, string description, decimal total, string tearmandcondition,
            string billingcity, string billingcode, string billingcountry, string billingstreet,
            string shippingstreet, string shippingcity, string shippingcode,
            string shippingcoutry, DataTable quoteDetail)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_QuoteUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@QuoteId", SqlDbType.Int, quoteid),
                DataLayer.CreateParameter("@ContactId", SqlDbType.Int, contactid),
                DataLayer.CreateParameter("@AccountId", SqlDbType.Int, accountid),
                DataLayer.CreateParameter("@OpportunityId", SqlDbType.Int, apportunityid),
                DataLayer.CreateParameter("@QuoteSubject", SqlDbType.NVarChar, quotesubject),
                DataLayer.CreateParameter("@QuoteStage", SqlDbType.NVarChar, quotestage),
                DataLayer.CreateParameter("@QuoteTeam", SqlDbType.NVarChar, quoteteam),
                DataLayer.CreateParameter("@QuoteCarrier", SqlDbType.NVarChar, quotecarrier),
                DataLayer.CreateParameter("@QuoteValidUntil", SqlDbType.DateTime, quotevaliduntil),
                DataLayer.CreateParameter("@PersonAddress", SqlDbType.Int, personaddressid),
                DataLayer.CreateParameter("@Description", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@Total", SqlDbType.Decimal, total),
                DataLayer.CreateParameter("@TermsAndConditions", SqlDbType.NVarChar, tearmandcondition),
                DataLayer.CreateParameter("@BillingStreet", SqlDbType.NVarChar, billingstreet),
                DataLayer.CreateParameter("@BillingCity", SqlDbType.NVarChar, billingcity),
                DataLayer.CreateParameter("@BillingCode", SqlDbType.NVarChar, billingcode),
                DataLayer.CreateParameter("@BillingCountry", SqlDbType.NVarChar, billingcountry),
                DataLayer.CreateParameter("@ShippingStreet", SqlDbType.NVarChar, shippingstreet),
                DataLayer.CreateParameter("@ShippingCity", SqlDbType.NVarChar, shippingcity),
                DataLayer.CreateParameter("@ShippingCode", SqlDbType.NVarChar, shippingcode),
                DataLayer.CreateParameter("@ShippingCoutry", SqlDbType.NVarChar, shippingcoutry),
                DataLayer.CreateParameter("@QuoteDetails", SqlDbType.Structured, quoteDetail)
                );
            return result;
        }

        public static DataTable Get_QuoteDetail_Product(int id)
        {
            var dt = DataLayer.ExecuteTable("Get_QuoteDetail_Product", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.Int, id));
            return dt;
        }
        public static async Task<int> QuoteDelete(int id)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_QuoteDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@QuoteId", SqlDbType.Int, id));
            return result;
        }
        public static DataTable QuoteSearch(string id)
        {
            var dt = DataLayer.ExecuteTable("usp_QuoteSearch", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.NVarChar, id));
            return dt;
        }
    }
}
