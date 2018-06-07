using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;
using System.Data;

namespace Yokai.Crm.Core
{
    public class Vendor
    {
        public static async Task<int> VendorInsert(string nom, string email,
            string phone, string website, string street, string city, string state,
            string zipcode, string country, string description)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_VendorInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@VendorName", SqlDbType.NVarChar, nom),
                DataLayer.CreateParameter("@PrimaryEmail", SqlDbType.NVarChar, email),
                DataLayer.CreateParameter("@PrimaryPhone", SqlDbType.NVarChar, phone),
                DataLayer.CreateParameter("@WebSite", SqlDbType.NVarChar, website),
                DataLayer.CreateParameter("@Street", SqlDbType.NVarChar, street),
                DataLayer.CreateParameter("@City", SqlDbType.NVarChar, city),
                DataLayer.CreateParameter("@States", SqlDbType.NVarChar, state),
                DataLayer.CreateParameter("@PostalCode", SqlDbType.NVarChar, zipcode),
                DataLayer.CreateParameter("@Country", SqlDbType.NVarChar, country),
                DataLayer.CreateParameter("@Descriptions", SqlDbType.NVarChar, description));

            return result;
        }

        public static DataTable FillGrid()
        {
            var dt = DataLayer.ExecuteTable("FillGridVendor", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable VendorSelect(int Id)
        {
            var dt = DataLayer.ExecuteTable("usp_VendorSelect", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@VendorId", SqlDbType.Int, Id));
            return dt;
        }

        public static async Task<int> VendorUpdate(int id, string nom, string email,
            string phone, string website, string street, string city, string state,
            string zipcode, string country, string description)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_VendorUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@VendorId", SqlDbType.Int, id),
                DataLayer.CreateParameter("@VendorName", SqlDbType.NVarChar, nom),
                DataLayer.CreateParameter("@PrimaryEmail", SqlDbType.NVarChar, email),
                DataLayer.CreateParameter("@PrimaryPhone", SqlDbType.NVarChar, phone),
                DataLayer.CreateParameter("@WebSite", SqlDbType.NVarChar, website),
                DataLayer.CreateParameter("@Street", SqlDbType.NVarChar, street),
                DataLayer.CreateParameter("@City", SqlDbType.NVarChar, city),
                DataLayer.CreateParameter("@States", SqlDbType.NVarChar, state),
                DataLayer.CreateParameter("@PostalCode", SqlDbType.NVarChar, zipcode),
                DataLayer.CreateParameter("@Country", SqlDbType.NVarChar, country),
                DataLayer.CreateParameter("@Descriptions", SqlDbType.NVarChar, description));

            return result;
        }

        public static async Task<int> VendorDelete(int Id)
        {
            var dt = await DataLayer.ExecuteNonQueryAsync("usp_VendorDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@VendorId", SqlDbType.Int, Id));
            return dt;
        }

        public static DataTable SearchVendor(string id)
        {
            var dt = DataLayer.ExecuteTable("SearchVendor", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.NVarChar, id));
            return dt;
        }

    }
}
