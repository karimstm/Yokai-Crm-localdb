using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class Category
    {
        public static DataTable GetCategory()
        {
            string query = "SELECT CategoryId, CategoryName FROM Category";
            DataTable dt = DataLayer.ExecuteTable(query, CommandType.Text);
            return dt;
        }

        public static async Task<int> InsertCategory(string _name)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_CategoryInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@CategoryName", SqlDbType.NVarChar, _name));
            return result;
        }
        public static async Task<int> UpdateCategory(int _id, string _name)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_CategoryUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@CategoryId", SqlDbType.Int, _id),
                DataLayer.CreateParameter("@CategoryName", SqlDbType.NVarChar, _name));
            return result;
        }

        public static async Task<int> DeleteCategory(int _id)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_CategoryDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@CategoryId", SqlDbType.Int, _id));
            return result;
        }
    }
}
