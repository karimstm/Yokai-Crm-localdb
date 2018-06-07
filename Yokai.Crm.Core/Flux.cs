using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class Flux
    {
        public static DataTable GetFlux()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_FluxSelect", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable GetFluxByUsername(string username)
        {
            DataTable dt = DataLayer.ExecuteTable("usp_FluxSelectByUsername", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@username", SqlDbType.NVarChar, username));
            return dt;
        }

        public static async Task<int> InsertFlux(string title, string message, DateTime date, string username)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_FluxInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@title", SqlDbType.NVarChar, title),
                DataLayer.CreateParameter("@message", SqlDbType.NVarChar, message),
                DataLayer.CreateParameter("@addedDate", SqlDbType.DateTime, date),
                DataLayer.CreateParameter("@username", SqlDbType.NVarChar, username)
            );
            return result;
        }

        public static async Task<int> UpdateFlux(int id, string title, string message, DateTime date, string username)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_FluxUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@id", SqlDbType.Int, id),
                DataLayer.CreateParameter("@title", SqlDbType.NVarChar, title),
                DataLayer.CreateParameter("@message", SqlDbType.NVarChar, message),
                DataLayer.CreateParameter("@addedDate", SqlDbType.DateTime, date),
                DataLayer.CreateParameter("@username", SqlDbType.NVarChar, username)
            );
            return result;
        }

        public static async Task<int> DeleteFlux(int id)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_FluxDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@id", SqlDbType.Int, id)
            );
            return result;
        }
    }
}
