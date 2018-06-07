using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class Statistic
    {
        public static DataTable SalesForAccount()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_SalesForEachAccount", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable LeadBySource()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_LeadBySource", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable LeadByStatus()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_GetLeadsByStatus", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable GetBySaleStage()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_GetBySaleStage", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable GetByProbability()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_GetByProbability", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable GetByType()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_GetByType", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable GetByCategorie()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_GetByProduct", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable GetCampainsNumber()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_NumberOfCampaing", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable GetNumberOfPurchaseVendor()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_GetNumberOfPurchaseOfvendor", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable GetNumberOfSaleOrder()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_GetNumberOfSaleOrder", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable GetNumberOfPurchaseOrder()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_GetNumberOfPurchaseOrder", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable GetNumberOfStatus()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_GetNumberOfStatus", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable GetNumberOfInvoice()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_GetNumberOfInvoice", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable GetNumberOfStatusInvoice()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_GetNumberOfStatusInvoice", CommandType.StoredProcedure);
            return dt;
        }



    }
}
