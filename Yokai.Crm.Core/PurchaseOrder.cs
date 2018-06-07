using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class PurchaseOrder
    {
        public static async Task<int> PurchaseOrderInser(string id, int? vendorId, int orderStatus, int? contactId,
            string subject, string requisitionNumber, string sn, DateTime poDate, DateTime dueDate, string carrier, decimal exciseDuty,
            decimal salesCommission, decimal total, string terms, string description, string billingstreet,
            string billingcity, string billingcode, string billingcountry,
            string shippingstreet, string shippingcity, string shippingcode,
            string shippingcoutry, DataTable productDetail)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_PurchaseOrderInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@PurchaseOrderId", SqlDbType.NVarChar, id),
                DataLayer.CreateParameter("@VendorId", SqlDbType.Int, vendorId),
                DataLayer.CreateParameter("@OrderStatusId", SqlDbType.Int, orderStatus),
                DataLayer.CreateParameter("@ContactId", SqlDbType.Int, contactId),
                DataLayer.CreateParameter("@Subjects", SqlDbType.NVarChar, subject),
                DataLayer.CreateParameter("@RequisitionNumber", SqlDbType.NVarChar, requisitionNumber),
                DataLayer.CreateParameter("@SerialNumber", SqlDbType.NVarChar, sn),
                DataLayer.CreateParameter("@PODate", SqlDbType.DateTime, poDate),
                DataLayer.CreateParameter("@DueDate", SqlDbType.Date, dueDate),
                DataLayer.CreateParameter("@Carrier", SqlDbType.NVarChar, carrier),
                DataLayer.CreateParameter("@ExciseDuty", SqlDbType.Decimal, exciseDuty),
                DataLayer.CreateParameter("@SalesCommission", SqlDbType.Decimal, salesCommission),
                DataLayer.CreateParameter("@Total", SqlDbType.Decimal, total),
                DataLayer.CreateParameter("@TermsAndConditions", SqlDbType.NVarChar, terms),
                DataLayer.CreateParameter("@Descriptions", SqlDbType.NVarChar, description),
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

        public static DataTable GetPurchaseStatus()
        {
            DataTable dt = DataLayer.ExecuteTable("SELECT OrderStatusId, OrderStatusName FROM OrderStatus",
                CommandType.Text);
            return dt;
        }

        public static DataTable GetAddress(int contactId)
        {
            var dt = DataLayer.ExecuteTable("usp_ContactPersonAddressSelect", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@contactId", SqlDbType.Int, contactId));
            return dt;
        }

        public static DataTable GET_PURCHASE_ORDER()
        {
            var dt = DataLayer.ExecuteTable("GET_PURCHASE_ORDER", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable PURCHASEORDER_SELECT_BY_ID(string id)
        {
            var dt = DataLayer.ExecuteTable("PURCHASEORDER_SELECT_BY_ID", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.NVarChar, id));
            return dt;
        }

        public static DataTable Get_PurchaseOrderDetails_Product(string id)
        {
            var dt = DataLayer.ExecuteTable("Get_PurchaseOrderDetails_Product", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.NVarChar, id));
            return dt;
        }

        public static async Task<int> PurchaseOrderUpdate(string id, int? vendorId, int orderStatus, int? contactId,
            string subject, string requisitionNumber, string sn, DateTime poDate, DateTime dueDate, string carrier, decimal exciseDuty,
            decimal salesCommission, decimal total, string terms, string description, string billingstreet,
            string billingcity, string billingcode, string billingcountry,
            string shippingstreet, string shippingcity, string shippingcode,
            string shippingcoutry, DataTable productDetail)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_PurchaseOrderUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@PurchaseOrderId", SqlDbType.NVarChar, id),
                DataLayer.CreateParameter("@VendorId", SqlDbType.Int, vendorId),
                DataLayer.CreateParameter("@OrderStatusId", SqlDbType.Int, orderStatus),
                DataLayer.CreateParameter("@ContactId", SqlDbType.Int, contactId),
                DataLayer.CreateParameter("@Subjects", SqlDbType.NVarChar, subject),
                DataLayer.CreateParameter("@RequisitionNumber", SqlDbType.NVarChar, requisitionNumber),
                DataLayer.CreateParameter("@SerialNumber", SqlDbType.NVarChar, sn),
                DataLayer.CreateParameter("@PODate", SqlDbType.DateTime, poDate),
                DataLayer.CreateParameter("@DueDate", SqlDbType.Date, dueDate),
                DataLayer.CreateParameter("@Carrier", SqlDbType.NVarChar, carrier),
                DataLayer.CreateParameter("@ExciseDuty", SqlDbType.Decimal, exciseDuty),
                DataLayer.CreateParameter("@SalesCommission", SqlDbType.Decimal, salesCommission),
                DataLayer.CreateParameter("@Total", SqlDbType.Decimal, total),
                DataLayer.CreateParameter("@TermsAndConditions", SqlDbType.NVarChar, terms),
                DataLayer.CreateParameter("@Descriptions", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@BillingStreet", SqlDbType.NVarChar, billingstreet),
                DataLayer.CreateParameter("@BillingCity", SqlDbType.NVarChar, billingcity),
                DataLayer.CreateParameter("@BillingCode", SqlDbType.NVarChar, billingcode),
                DataLayer.CreateParameter("@BillingCountry", SqlDbType.NVarChar, billingcountry),
                DataLayer.CreateParameter("@ShippingStreet", SqlDbType.NVarChar, shippingstreet),
                DataLayer.CreateParameter("@ShippingCity", SqlDbType.NVarChar, shippingcity),
                DataLayer.CreateParameter("@ShippingCode", SqlDbType.NVarChar, shippingcode),
                DataLayer.CreateParameter("@ShippingCoutry", SqlDbType.NVarChar, shippingcoutry),
                DataLayer.CreateParameter("@PurchaseOrderDetails", SqlDbType.Structured, productDetail));
            return result;
        }

        public static async Task<int> PurchaseOrderDelete(string id)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_PurchaseOrderDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@PurchaseOrderId", SqlDbType.NVarChar, id));
            return result;
        }

        public static object VERIFY_QTE(string id)
        {
            var result = DataLayer.ExecuteScalar("VERIFY_QTE", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.NVarChar, id));
            return result;
        }

        public static DataTable SearchPurchaseOrder(string searchType, string searchKeyword)
        {
            string query = "";
            switch (searchType)
            {
                case "Id":
                    query = "usp_SearchPurchaseById";
                    break;
                case "Serie":
                    query = "usp_SearchPurchaseBySerie";
                    break;
            }
            DataTable dt = DataLayer.ExecuteTable(query, CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.NVarChar, searchKeyword));
            return dt;
        }
        public static DataTable SearchPurchaseOrderByDate(DateTime date1, DateTime date2)
        {
            var dt = DataLayer.ExecuteTable("usp_SearchPurchaseByDate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@DATE1", SqlDbType.DateTime, date1),
                DataLayer.CreateParameter("@DATE2", SqlDbType.DateTime, date2));
            return dt;
        }


    }
}
