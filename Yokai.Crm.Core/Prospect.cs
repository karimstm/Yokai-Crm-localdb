using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class Prospect
    {
        public static async Task<int> InsertProspect(string firstName, string lastName, string company,
            string title, string email, string email2, string phone, string mobile, string fax, string website, decimal? annualRevenu,
            int? noEmployee, string skypeId, string street, string city, string state, string country, string description,
            string zipcode, int prospectSourceId, int prospectStatusId)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("usp_ProspectInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@FirstName", SqlDbType.NVarChar, firstName),
                DataLayer.CreateParameter("@LastName", SqlDbType.NVarChar, lastName),
                DataLayer.CreateParameter("@Company", SqlDbType.NVarChar, company),
                DataLayer.CreateParameter("@Title", SqlDbType.NVarChar, title),
                DataLayer.CreateParameter("@Email", SqlDbType.NVarChar, email),
                DataLayer.CreateParameter("@Email2", SqlDbType.NVarChar, email2),
                DataLayer.CreateParameter("@Phone", SqlDbType.NVarChar, phone),
                DataLayer.CreateParameter("@Mobile", SqlDbType.NVarChar, mobile),
                DataLayer.CreateParameter("@FAX", SqlDbType.NVarChar, fax),
                DataLayer.CreateParameter("@WebSite", SqlDbType.NVarChar, website),
                DataLayer.CreateParameter("@AnnualRevenue", SqlDbType.Decimal, annualRevenu),
                DataLayer.CreateParameter("@NoEmployees", SqlDbType.Int, noEmployee),
                DataLayer.CreateParameter("@SkypeId", SqlDbType.NVarChar, skypeId),
                DataLayer.CreateParameter("@Street", SqlDbType.NVarChar, street),
                DataLayer.CreateParameter("@City", SqlDbType.NVarChar, city),
                DataLayer.CreateParameter("@States", SqlDbType.NVarChar, state),
                DataLayer.CreateParameter("@Country", SqlDbType.NVarChar, country),
                DataLayer.CreateParameter("@Descriptions", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@ZipCode", SqlDbType.NVarChar, zipcode),
                DataLayer.CreateParameter("@ProspectSourceId", SqlDbType.Int, prospectSourceId),
                DataLayer.CreateParameter("@ProspectStatusId", SqlDbType.Int, prospectStatusId)
            );
            return result;
        }

        public static DataTable GetLead()
        {
            DataTable dt = DataLayer.ExecuteTable("GetLead", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable GetLeadById(int ProspectId)
        {
            DataTable dt = DataLayer.ExecuteTable("GET_GridProspect", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ProspectId", SqlDbType.Int, ProspectId));
            return dt;
        }
        public static async Task<int> UpdateProspect(int ProspectId, string firstName, string lastName, string company,
            string title, string email, string email2, string phone, string mobile, string fax, string website, decimal? annualRevenu,
            int? noEmployee, string skypeId, string street, string city, string state, string country, string description,
            string zipcode, int prospectSourceId, int prospectStatusId)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("ProspectUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ProspectId", SqlDbType.Int, ProspectId),
                DataLayer.CreateParameter("@FirstName", SqlDbType.NVarChar, firstName),
                DataLayer.CreateParameter("@LastName", SqlDbType.NVarChar, lastName),
                DataLayer.CreateParameter("@Company", SqlDbType.NVarChar, company),
                DataLayer.CreateParameter("@Title", SqlDbType.NVarChar, title),
                DataLayer.CreateParameter("@Email", SqlDbType.NVarChar, email),
                DataLayer.CreateParameter("@Email2", SqlDbType.NVarChar, email2),
                DataLayer.CreateParameter("@Phone", SqlDbType.NVarChar, phone),
                DataLayer.CreateParameter("@Mobile", SqlDbType.NVarChar, mobile),
                DataLayer.CreateParameter("@FAX", SqlDbType.NVarChar, fax),
                DataLayer.CreateParameter("@WebSite", SqlDbType.NVarChar, website),
                DataLayer.CreateParameter("@AnnualRevenue", SqlDbType.Decimal, annualRevenu),
                DataLayer.CreateParameter("@NoEmployees", SqlDbType.Int, noEmployee),
                DataLayer.CreateParameter("@SkypeId", SqlDbType.NVarChar, skypeId),
                DataLayer.CreateParameter("@Street", SqlDbType.NVarChar, street),
                DataLayer.CreateParameter("@City", SqlDbType.NVarChar, city),
                DataLayer.CreateParameter("@States", SqlDbType.NVarChar, state),
                DataLayer.CreateParameter("@Country", SqlDbType.NVarChar, country),
                DataLayer.CreateParameter("@Descriptions", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@ZipCode", SqlDbType.NVarChar, zipcode),
                DataLayer.CreateParameter("@ProspectSourceId", SqlDbType.Int, prospectSourceId),
                DataLayer.CreateParameter("@ProspectStatusId", SqlDbType.Int, prospectStatusId)
            );
            return result;
        }

        public static async Task<int> DeleteProspect(int ProspectId)
        {
            int result = await DataLayer.ExecuteNonQueryAsync("ProspectDelete", CommandType.StoredProcedure,
                         DataLayer.CreateParameter("@ProspectId", SqlDbType.Int, ProspectId));
            return result;
        }

        public static DataTable SearchLead(string search)
        {
            DataTable dt = DataLayer.ExecuteTable("SearchLead", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@Search", SqlDbType.NVarChar, search));
            return dt;
        }

        

    }

}
