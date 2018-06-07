using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class Products
    {
        /// <summary>
        /// Get all the product from a table
        /// </summary>
        /// <returns></returns>
        public static DataTable GetProducts()
        {
            DataTable dt = DataLayer.ExecuteTable("usp_ProductSelect", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable GetProductById(string id)
        {
            DataTable dt = DataLayer.ExecuteTable("usp_ProductSelectById", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ProductId", SqlDbType.NVarChar, id));
            return dt;
        }

        public static DataTable SearchProduct(string searchType, string searchKeyword)
        {
            string query = "";
            switch (searchType)
            {
                case "Id":
                    query = "usp_SearchProductById";
                    break;
                case "Sn":
                    query = "usp_SearchProductBySN";
                    break;
                case "Name":
                    query = "usp_SearchProductByName";
                    break;
            }
            DataTable dt = DataLayer.ExecuteTable(query, CommandType.StoredProcedure,
                DataLayer.CreateParameter("@SEARCH", SqlDbType.NVarChar, searchKeyword));
            return dt;
        }
        public static async Task<int> InsertProduct(string productId, int? categoryId, int? vendorId, int? manufacturerId, string name,
            string serialNumber, bool isActive, DateTime startDate, DateTime enddate, DateTime supportStartDate, DateTime supportEndDate,
            decimal? unitPrice, decimal? tva, byte[] imgProduit, string description, int qteStock, decimal? commissionRate)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_ProductInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ProductId", SqlDbType.NVarChar, productId),
                DataLayer.CreateParameter("@CategoryId", SqlDbType.Int, categoryId),
                DataLayer.CreateParameter("@VendorId", SqlDbType.Int, vendorId),
                DataLayer.CreateParameter("@ManufacturerId", SqlDbType.Int, manufacturerId),
                DataLayer.CreateParameter("@ProductName", SqlDbType.NVarChar, name),
                DataLayer.CreateParameter("@SeriaNumber", SqlDbType.NVarChar, serialNumber),
                DataLayer.CreateParameter("@IsActive", SqlDbType.Bit, isActive),
                DataLayer.CreateParameter("@StartDate", SqlDbType.Date, startDate),
                DataLayer.CreateParameter("@ENDdATE", SqlDbType.Date, enddate),
                DataLayer.CreateParameter("@SupportStartDate", SqlDbType.Date, supportStartDate),
                DataLayer.CreateParameter("@SupportEndDate", SqlDbType.Date, supportEndDate),
                DataLayer.CreateParameter("@UnitPrice", SqlDbType.Decimal, unitPrice),
                DataLayer.CreateParameter("@TVA", SqlDbType.Decimal, tva),
                DataLayer.CreateParameter("@Img_Produit", SqlDbType.Image, imgProduit),
                DataLayer.CreateParameter("@Descriptions", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@QtyStock", SqlDbType.Int, qteStock),
                DataLayer.CreateParameter("@CommissionRate", SqlDbType.Decimal, commissionRate)
                );
            return result;
        }
        public static async Task<int> UpdateProduct(string productId, int? categoryId, int? vendorId, int? manufacturerId, string name,
            string serialNumber, bool isActive, DateTime startDate, DateTime enddate, DateTime supportStartDate, DateTime supportEndDate,
            decimal? unitPrice, decimal? tva, byte[] imgProduit, string description, int qteStock, decimal? commissionRate)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_ProductUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@productId", SqlDbType.NVarChar, productId),
                DataLayer.CreateParameter("@CategoryId", SqlDbType.Int, categoryId),
                DataLayer.CreateParameter("@VendorId", SqlDbType.Int, vendorId),
                DataLayer.CreateParameter("@ManufacturerId", SqlDbType.Int, manufacturerId),
                DataLayer.CreateParameter("@ProductName", SqlDbType.NVarChar, name),
                DataLayer.CreateParameter("@SeriaNumber", SqlDbType.NVarChar, serialNumber),
                DataLayer.CreateParameter("@IsActive", SqlDbType.Bit, isActive),
                DataLayer.CreateParameter("@StartDate", SqlDbType.Date, startDate),
                DataLayer.CreateParameter("@ENDdATE", SqlDbType.Date, enddate),
                DataLayer.CreateParameter("@SupportStartDate", SqlDbType.Date, supportStartDate),
                DataLayer.CreateParameter("@SupportEndDate", SqlDbType.Date, supportEndDate),
                DataLayer.CreateParameter("@UnitPrice", SqlDbType.Decimal, unitPrice),
                DataLayer.CreateParameter("@TVA", SqlDbType.Decimal, tva),
                DataLayer.CreateParameter("@Img_Produit", SqlDbType.Image, imgProduit),
                DataLayer.CreateParameter("@Descriptions", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@QtyStock", SqlDbType.Int, qteStock),
                DataLayer.CreateParameter("@CommissionRate", SqlDbType.Decimal, commissionRate)
            );
            return result;
        }

        public static async Task<int> DeleteProduct(string productId)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_ProductDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ProductId", SqlDbType.NVarChar, productId));
            return result;
        }

        
    }
}
