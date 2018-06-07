using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;


namespace Yokai.Crm.Core
{
    public class Opportunity
    {
        public static async Task<int> OpprtunityInsert(string oppname, int? contactid, int? accountid,
            int? prospectsourceid, decimal montant, DateTime closedate, string salestage, int probability, 
            string description, string type, string etapenext, decimal chiffreaffaireattendu, int? compagneid)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_OpportunityInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@OpportunityName", SqlDbType.NVarChar, oppname),
                DataLayer.CreateParameter("@ContactId", SqlDbType.Int, contactid),
                DataLayer.CreateParameter("@AccountId", SqlDbType.Int, accountid),
                DataLayer.CreateParameter("@ProspectSourceId", SqlDbType.Int, prospectsourceid),
                DataLayer.CreateParameter("@Montant", SqlDbType.Decimal, montant),
                DataLayer.CreateParameter("@CloseDate", SqlDbType.DateTime, closedate),
                DataLayer.CreateParameter("@SalesStage", SqlDbType.NVarChar, salestage),
                DataLayer.CreateParameter("@Probability", SqlDbType.Int, probability),
                DataLayer.CreateParameter("@Descriptions", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@Typee", SqlDbType.NVarChar, type),
                DataLayer.CreateParameter("@EtapeNext", SqlDbType.NVarChar, etapenext),
                DataLayer.CreateParameter("@ChiffreAffaireAttendu", SqlDbType.Decimal, chiffreaffaireattendu),
                DataLayer.CreateParameter("@CompagneId", SqlDbType.Int, compagneid));
            return result;
        }

        public static async Task<int> OpprtunityUpdate(int oppid, string oppname, int? contactid, int? accountid,
            int? prospectsourceid, decimal montant, DateTime closedate, string salestage, int probability, 
            string description, string type, string etapenext, decimal chiffreaffaireattendu, int? compagneid)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_OpportunityUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@OpportunityId", SqlDbType.Int, oppid),
                DataLayer.CreateParameter("@OpportunityName", SqlDbType.NVarChar, oppname),
                DataLayer.CreateParameter("@ContactId", SqlDbType.Int, contactid),
                DataLayer.CreateParameter("@AccountId", SqlDbType.Int, accountid),
                DataLayer.CreateParameter("@ProspectSourceId", SqlDbType.Int, prospectsourceid),
                DataLayer.CreateParameter("@Montant", SqlDbType.Decimal, montant),
                DataLayer.CreateParameter("@CloseDate", SqlDbType.DateTime, closedate),
                DataLayer.CreateParameter("@SalesStage", SqlDbType.NVarChar, salestage),
                DataLayer.CreateParameter("@Probability", SqlDbType.Int, probability),
                DataLayer.CreateParameter("@Descriptions", SqlDbType.NVarChar, description),
                DataLayer.CreateParameter("@Typee", SqlDbType.NVarChar, type),
                DataLayer.CreateParameter("@EtapeNext", SqlDbType.NVarChar, etapenext),
                DataLayer.CreateParameter("@ChiffreAffaireAttendu", SqlDbType.Decimal, chiffreaffaireattendu),
                DataLayer.CreateParameter("@CompagneId", SqlDbType.Int, compagneid));
            return result;
        }

        public static DataTable OpportunitySelectById(int oppid)
        {
            var dt = DataLayer.ExecuteTable("usp_OpportunitySelectById", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@OpportunityId", SqlDbType.Int, oppid));
            return dt;
        }

        public static async Task<int> OpportunityDelete(int oppid)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_OpportunityDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@OpportunityId", SqlDbType.Int, oppid));
            return result;
        }

        public static DataTable GetOpportunity()
        {
            var dt = DataLayer.ExecuteTable("usp_OpportunitySelect", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable OpportunitySearch(string id)
        {
            var dt = DataLayer.ExecuteTable("usp_OpportunitySearch", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@ID", SqlDbType.NVarChar, id));
            return dt;
        }
    }
}
