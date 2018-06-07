using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class Manufacturer
    {
        public static DataTable GetManufacture()
        {
            string Query = "select ManufacturerId, ManufacturerName from Manufacturer";
            DataTable dt = DataLayer.ExecuteTable(Query, CommandType.Text);
            return dt;
        }
        public static async Task<int> InsertManufacturer(string _name)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_ManufacturerInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ManufacturerName", SqlDbType.NVarChar, _name));
            return result;
        }
        public static async Task<int> UpdateManufacturer(int _id, string _name)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_ManufacturerUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ManufacturerId", SqlDbType.Int, _id),
                DataLayer.CreateParameter("@ManufacturerName", SqlDbType.NVarChar, _name));
            return result;
        }

        public static async Task<int> DeleteManufacturer(int _id)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_ManufacturerDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ManufacturerId", SqlDbType.Int, _id));
            return result;
        }
    }
}
