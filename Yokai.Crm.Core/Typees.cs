using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class Typees
    {
        public static DataTable GetAll()
        {
            string Query = "select TypeeId, TypeName from Typee";
            var dt = DataLayer.ExecuteTable(Query, CommandType.Text);
            return dt;
        }

        public static async Task<int> InsertType(string _name)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_TypeeInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@TypeName", SqlDbType.NVarChar, _name));
            return result;
        }
        public static async Task<int> UpdateType(int _id, string _name)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_TypeeUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@TypeeId", SqlDbType.Int, _id),
                DataLayer.CreateParameter("@TypeName", SqlDbType.NVarChar, _name));
            return result;
        }

        public static async Task<int> DeleteType(int _id)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_TypeeDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@TypeeId", SqlDbType.Int, _id));
            return result;
        }
    }
}
