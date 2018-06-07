using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class SalesOrder
    {
        public static async Task<int> SalesOrderInser(string id, int? vendorId, int orderStatus, int? contactId,
            int? accountId, string subject, string requisitionNumber, int? quoteId, DateTime dueDate, string carrier, decimal exciseDuty,
            decimal salesCommission, decimal total, string terms, string description, string billingstreet,
            string billingcity, string billingcode, string billingcountry,
            string shippingstreet, string shippingcity, string shippingcode,
            string shippingcoutry, DataTable productDetail)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_SalesOrderInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@SalesOrderId", SqlDbType.NVarChar, id),
                DataLayer.CreateParameter("@VendorId", SqlDbType.Int, vendorId),
                DataLayer.CreateParameter("@OrderStatusId", SqlDbType.Int, orderStatus),
                DataLayer.CreateParameter("@ContactId", SqlDbType.Int, contactId),
                DataLayer.CreateParameter("@Subjects", SqlDbType.NVarChar, subject),
                DataLayer.CreateParameter("@RequisitionNumber", SqlDbType.NVarChar, requisitionNumber),
                DataLayer.CreateParameter("@QuoteId", SqlDbType.Int, quoteId),
                DataLayer.CreateParameter("@AccountId", SqlDbType.Int, accountId),
                DataLayer.CreateParameter("@DueDate", SqlDbType.Date, dueDate),
                DataLayer.CreateParameter("@Carrier", SqlDbType.NVarChar, carrier),
                DataLayer.CreateParameter("@ExciseDuty", SqlDbType.Decimal, exciseDuty),
                DataLayer.CreateParameter("@SalesCommission", SqlDbType.Decimal, salesCommission),
                DataLayer.CreateParameter("@Total", SqlDbType.Decimal, total),
                DataLayer.CreateParameter("@TermsAndConditions", SqlDbType.NVarChar, terms),
                DataLayer.CreateParameter("@Descriptins", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@BillingStreet", SqlDbType.NVarChar, billingstreet),
                DataLayer.CreateParameter("@BillingCity", SqlDbType.NVarChar, billingcity),
                DataLayer.CreateParameter("@BillingCode", SqlDbType.NVarChar, billingcode),
                DataLayer.CreateParameter("@BillingCountry", SqlDbType.NVarChar, billingcountry),
                DataLayer.CreateParameter("@ShippingStreet", SqlDbType.NVarChar, shippingstreet),
                DataLayer.CreateParameter("@ShippingCity", SqlDbType.NVarChar, shippingcity),
                DataLayer.CreateParameter("@ShippingCode", SqlDbType.NVarChar, shippingcode),
                DataLayer.CreateParameter("@ShippingCoutry", SqlDbType.NVarChar, shippingcoutry),
                DataLayer.CreateParameter("@ProductDetail", SqlDbType.Structured, productDetail));
            return result;
        }

        public static async Task<int> SalesOrderUpdate(string id, int? vendorId, int? AddressId, int orderStatus, int? contactId,
            int? accountId, string subject, string requisitionNumber, int? quoteId, DateTime dueDate, string carrier, decimal exciseDuty,
            decimal salesCommission, decimal total, string terms, string description, string billingstreet,
            string billingcity, string billingcode, string billingcountry,
            string shippingstreet, string shippingcity, string shippingcode,
            string shippingcoutry, DataTable productDetail)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_SalesOrderUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@SalesOrderId", SqlDbType.NVarChar, id),
                DataLayer.CreateParameter("@VendorId", SqlDbType.Int, vendorId),
                DataLayer.CreateParameter("PersonAddressId", SqlDbType.Int, AddressId),
                DataLayer.CreateParameter("@OrderStatusId", SqlDbType.Int, orderStatus),
                DataLayer.CreateParameter("@ContactId", SqlDbType.Int, contactId),
                DataLayer.CreateParameter("@Subjects", SqlDbType.NVarChar, subject),
                DataLayer.CreateParameter("@RequisitionNumber", SqlDbType.NVarChar, requisitionNumber),
                DataLayer.CreateParameter("@QuoteId", SqlDbType.Int, quoteId),
                DataLayer.CreateParameter("@AccountId", SqlDbType.Int, accountId),
                DataLayer.CreateParameter("@DueDate", SqlDbType.Date, dueDate),
                DataLayer.CreateParameter("@Carrier", SqlDbType.NVarChar, carrier),
                DataLayer.CreateParameter("@ExciseDuty", SqlDbType.Decimal, exciseDuty),
                DataLayer.CreateParameter("@SalesCommission", SqlDbType.Decimal, salesCommission),
                DataLayer.CreateParameter("@Total", SqlDbType.Decimal, total),
                DataLayer.CreateParameter("@TermsAndConditions", SqlDbType.NVarChar, terms),
                DataLayer.CreateParameter("@Descriptins", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@BillingStreet", SqlDbType.NVarChar, billingstreet),
                DataLayer.CreateParameter("@BillingCity", SqlDbType.NVarChar, billingcity),
                DataLayer.CreateParameter("@BillingCode", SqlDbType.NVarChar, billingcode),
                DataLayer.CreateParameter("@BillingCountry", SqlDbType.NVarChar, billingcountry),
                DataLayer.CreateParameter("@ShippingStreet", SqlDbType.NVarChar, shippingstreet),
                DataLayer.CreateParameter("@ShippingCity", SqlDbType.NVarChar, shippingcity),
                DataLayer.CreateParameter("@ShippingCode", SqlDbType.NVarChar, shippingcode),
                DataLayer.CreateParameter("@ShippingCoutry", SqlDbType.NVarChar, shippingcoutry),
                DataLayer.CreateParameter("@SalesOrderDetails", SqlDbType.Structured, productDetail));
            return result;
        }
        public static DataTable GetSalesOrder()
        {
            var dt = DataLayer.ExecuteTable("usp_SalesOrderSelect", CommandType.StoredProcedure);
            return dt;
        }
        public static async Task<int> SalesOrderDelete(string id)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_SalesOrderDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@SalesOrderId", SqlDbType.NVarChar, id));
            return result;
        }

        public static DataTable SalesOrderById(string id)
        {
            var dt = DataLayer.ExecuteTable("SalesOrder_SELECT_BY_ID", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.NVarChar, id));
            return dt;
        }

        public static DataTable Get_SalesOrderDetails_Product(string id)
        {
            var dt = DataLayer.ExecuteTable("Get_SalesOrderDetails_Product", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.NVarChar, id));
            return dt;
        }

        public static DataTable SearchSalesOrder(string TypeSearch, string tools)
        {
            string Stored_Proc = "";
            switch (TypeSearch)
            {
                case "ID":
                    Stored_Proc = "usp_SearchSalesOrder_ID";
                    break;
                case "Nom":
                    Stored_Proc = "usp_SearchSalesOrder_Name";
                    break;
            }

            var dt = DataLayer.ExecuteTable(Stored_Proc, CommandType.StoredProcedure,
                DataLayer.CreateParameter("@Search", SqlDbType.NVarChar, tools));
            return dt;
        }
    }
}
