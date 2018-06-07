using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class Campaign
    {
        public static DataTable GetCampaigns()
        {
            var dt = DataLayer.ExecuteTable("usp_CompagneSelect", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable GetCampaignById(int Id)
        {
            var dt = DataLayer.ExecuteTable("usp_CompagneSelectById", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.Int, Id));
            return dt;
        }

        public static async Task<int> InsertCampaign(string name, string type, string status,
            DateTime startDate, DateTime endDate, decimal? expectedRevenue, decimal? budgetCost, decimal? actualCost,
            decimal? expectedResponse, int numberSent, string description)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_CompagneInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@CampaignName", SqlDbType.NVarChar, name),
                DataLayer.CreateParameter("@Type", SqlDbType.NVarChar, type),
                DataLayer.CreateParameter("@Status", SqlDbType.NVarChar, status),
                DataLayer.CreateParameter("@StartDate", SqlDbType.Date, startDate),
                DataLayer.CreateParameter("@EndDate", SqlDbType.Date, endDate),
                DataLayer.CreateParameter("@ExpectedRevenue", SqlDbType.Decimal, expectedRevenue),
                DataLayer.CreateParameter("@BudgetedCost", SqlDbType.Decimal, budgetCost),
                DataLayer.CreateParameter("@ActualCost", SqlDbType.Decimal, actualCost),
                DataLayer.CreateParameter("@ExpectedResponse", SqlDbType.Decimal, expectedResponse),
                DataLayer.CreateParameter("@NumberSent", SqlDbType.Int, numberSent),
                DataLayer.CreateParameter("@Description", SqlDbType.NVarChar, description)
                );
            return result;
        }

        public static async Task<int> UpdateCampaign(int id, string name, string type, string status,
            DateTime startDate, DateTime endDate, decimal? expectedRevenue, decimal? budgetCost, decimal? actualCost,
            decimal? expectedResponse, int numberSent, string description)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_CompagneUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@CompagneId", SqlDbType.Int, id),
                DataLayer.CreateParameter("@CampaignName", SqlDbType.NVarChar, name),
                DataLayer.CreateParameter("@Type", SqlDbType.NVarChar, type),
                DataLayer.CreateParameter("@Status", SqlDbType.NVarChar, status),
                DataLayer.CreateParameter("@StartDate", SqlDbType.Date, startDate),
                DataLayer.CreateParameter("@EndDate", SqlDbType.Date, endDate),
                DataLayer.CreateParameter("@ExpectedRevenue", SqlDbType.Decimal, expectedRevenue),
                DataLayer.CreateParameter("@BudgetedCost", SqlDbType.Decimal, budgetCost),
                DataLayer.CreateParameter("@ActualCost", SqlDbType.Decimal, actualCost),
                DataLayer.CreateParameter("@ExpectedResponse", SqlDbType.Decimal, expectedResponse),
                DataLayer.CreateParameter("@NumberSent", SqlDbType.Int, numberSent),
                DataLayer.CreateParameter("@Description", SqlDbType.NVarChar, description)
            );
            return result;
        }

        public static async Task<int> DeleteCampaign(int id)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_CompagneDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@CompagneId", SqlDbType.Int, id));
            return result;
        }

        public static DataTable GetSearchedCampaign(string search)
        {
            var dt = DataLayer.ExecuteTable("usp_CompagneSearch", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@Search", SqlDbType.NVarChar, search));
            return dt;
        }
    }
}
