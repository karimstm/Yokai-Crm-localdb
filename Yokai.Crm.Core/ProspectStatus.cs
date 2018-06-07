using System.Data;
using Yokai.Crm.DataAccess;


namespace Yokai.Crm.Core
{
    public class ProspectStatus
    {
        public static DataTable GetAll()
        {
            string Query = "SELECT ProspectStatusId, ProspectStatusName FROM ProspectStatus";
            var dt = DataLayer.ExecuteTable(Query, CommandType.Text);
            return dt;
        }
    }
}
