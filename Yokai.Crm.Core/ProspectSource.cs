using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class ProspectSource
    {
        public static DataTable GetAll()
        {
            string Query = "SELECT ProspectSourceId, ProspectSourceName FROM ProspectSource";
            var dt = DataLayer.ExecuteTable(Query, CommandType.Text);
            return dt;
        }
    }
}
