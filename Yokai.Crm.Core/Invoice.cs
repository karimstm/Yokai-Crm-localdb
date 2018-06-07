using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Yokai.Crm.DataAccess;


namespace Yokai.Crm.Core
{
    public class Invoice
    {
        public static DataTable GetInvoice()
        {
            var dt = DataLayer.ExecuteTable("usp_InvoiceSecet", CommandType.StoredProcedure);
            return dt;
        }

        public static async Task<int> InvoiceInsert(int? accountid, int? contactid,
            string subject, DateTime dateinvoice, DateTime duedate, decimal salecommission,
            decimal total, decimal exciseduty, string termsandcondition,
            string description, int orderstatu,
            string billingcity, string billingcode, string billingcountry, string billingstreet,
            string shippingstreet, string shippingcity, string shippingcode,
            string shippingcoutry, DataTable invoiceDetail, string purchaseorderid, string salesorderid)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_InvoiceInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@AccountId", SqlDbType.Int, accountid),
                DataLayer.CreateParameter("@ContactId", SqlDbType.Int, contactid),
                DataLayer.CreateParameter("@OrderStatusId", SqlDbType.Int, orderstatu),
                DataLayer.CreateParameter("@Subject", SqlDbType.NVarChar, subject),
                DataLayer.CreateParameter("@DateInvoice", SqlDbType.DateTime, dateinvoice),
                DataLayer.CreateParameter("@DueDate", SqlDbType.DateTime, duedate),
                DataLayer.CreateParameter("@SaleCommission", SqlDbType.Money, salecommission),
                DataLayer.CreateParameter("@Total", SqlDbType.Decimal, total),
                DataLayer.CreateParameter("@ExciseDuty", SqlDbType.Decimal, exciseduty),
                DataLayer.CreateParameter("@TermsAndConditions", SqlDbType.NVarChar, termsandcondition),
                DataLayer.CreateParameter("@Description", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@BillingStreet", SqlDbType.NVarChar, billingstreet),
                DataLayer.CreateParameter("@BillingCity", SqlDbType.NVarChar, billingcity),
                DataLayer.CreateParameter("@BillingCode", SqlDbType.NVarChar, billingcode),
                DataLayer.CreateParameter("@BillingCountry", SqlDbType.NVarChar, billingcountry),
                DataLayer.CreateParameter("@ShippingStreet", SqlDbType.NVarChar, shippingstreet),
                DataLayer.CreateParameter("@ShippingCity", SqlDbType.NVarChar, shippingcity),
                DataLayer.CreateParameter("@ShippingCode", SqlDbType.NVarChar, shippingcode),
                DataLayer.CreateParameter("@ShippingCountry", SqlDbType.NVarChar, shippingcoutry),
                DataLayer.CreateParameter("@InvoiceTable", SqlDbType.Structured, invoiceDetail),
                DataLayer.CreateParameter("@PurchaseOrderId", SqlDbType.NVarChar, purchaseorderid),
                DataLayer.CreateParameter("@SalesOrderId", SqlDbType.NVarChar, salesorderid)
                );
            return result;

        }

        public static DataTable InvoiceById(int id)
        {
            var dt = DataLayer.ExecuteTable("usp_InvoiceSelectById", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@InvoiceId", SqlDbType.Int, id));
            return dt;
        }

        public static DataTable InvoiceDetails_Product(int id)
        {
            var dt = DataLayer.ExecuteTable("InvoiceDetails_Product", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.Int, id));
            return dt; 
        }

        public static async Task<int> InvoiceUpdate(int invoiceid, int? accountid, int? contactid,
            string subject, DateTime dateinvoice, DateTime duedate, decimal salecommission,
            decimal total, decimal exciseduty, string termsandcondition,
            string description, int? personaddressid, int orderstatu,
            string billingcity, string billingcode, string billingcountry, string billingstreet,
            string shippingstreet, string shippingcity, string shippingcode,
            string shippingcoutry, DataTable invoiceDetail, string purchaseorderid, string salesorderid)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_InvoiceUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@InvoiceId", SqlDbType.Int, invoiceid),
                DataLayer.CreateParameter("@AccountId", SqlDbType.Int, accountid),
                DataLayer.CreateParameter("@ContactId", SqlDbType.Int, contactid),
                DataLayer.CreateParameter("@OrderStatusId", SqlDbType.Int, orderstatu),
                DataLayer.CreateParameter("@Subject", SqlDbType.NVarChar, subject),
                DataLayer.CreateParameter("@DateInvoice", SqlDbType.DateTime, dateinvoice),
                DataLayer.CreateParameter("@DueDate", SqlDbType.DateTime, duedate),
                DataLayer.CreateParameter("@SaleCommission", SqlDbType.Money, salecommission),
                DataLayer.CreateParameter("@Total", SqlDbType.Decimal, total),
                DataLayer.CreateParameter("@ExciseDuty", SqlDbType.Decimal, exciseduty),
                DataLayer.CreateParameter("@TermsAndConditions", SqlDbType.NVarChar, termsandcondition),
                DataLayer.CreateParameter("@Description", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@PersonAddressId", SqlDbType.Int, personaddressid),
                DataLayer.CreateParameter("@BillingStreet", SqlDbType.NVarChar, billingstreet),
                DataLayer.CreateParameter("@BillingCity", SqlDbType.NVarChar, billingcity),
                DataLayer.CreateParameter("@BillingCode", SqlDbType.NVarChar, billingcode),
                DataLayer.CreateParameter("@BillingCountry", SqlDbType.NVarChar, billingcountry),
                DataLayer.CreateParameter("@ShippingStreet", SqlDbType.NVarChar, shippingstreet),
                DataLayer.CreateParameter("@ShippingCity", SqlDbType.NVarChar, shippingcity),
                DataLayer.CreateParameter("@ShippingCode", SqlDbType.NVarChar, shippingcode),
                DataLayer.CreateParameter("@ShippingCountry", SqlDbType.NVarChar, shippingcoutry),
                DataLayer.CreateParameter("@InvoiceTable", SqlDbType.Structured, invoiceDetail),
                DataLayer.CreateParameter("@PurchaseOrderId", SqlDbType.NVarChar, purchaseorderid),
                DataLayer.CreateParameter("@SalesOrderId", SqlDbType.NVarChar, salesorderid));
            return result;

        }

        public static async Task<int> InvoiceDelete(int id)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_InvoiceDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@InvoiceId", SqlDbType.Int, id));
            return result;
        }

        public static DataTable SearchInvoice(string search)
        {
            var result = DataLayer.ExecuteTable("usp_SearchInvoice", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@search", SqlDbType.NVarChar, search));
            return result;
        }

        public static DataTable GetInvoiceByDates(DateTime startDate, DateTime endDate)
        {
            var result = DataLayer.ExecuteTable("usp_InvoiceBetweenDates", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@startDate", SqlDbType.Date, startDate),
                DataLayer.CreateParameter("@endDate", SqlDbType.Date, endDate));
            return result;
        }
        public static DataTable Get_InvoiceTowDate(DateTime startDate, DateTime endDate)
        {
            var result = DataLayer.ExecuteTable("usp_InvoiceTowDate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@DateInvoice", SqlDbType.Date, startDate),
                DataLayer.CreateParameter("@DueDate", SqlDbType.Date, endDate));
            return result;
        }

        public static object VERIFY_QTE(string id)
        {
            var result = DataLayer.ExecuteScalar("VERIFY_QTE", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.NVarChar, id));
            return result;
        }

        public static DataTable VERIFY_QTE_EGALE_ZERO(string id)
        {
            var dt = DataLayer.ExecuteTable("VERIFY_QTE_EGALE_ZERO", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.NVarChar, id));
            return dt;
        }


    }
}
