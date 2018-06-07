using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class DbSettings
    {
        public static DataTable GetNames()
        {
            DataTable dt = DataLayer.ExecuteTable(@"USE MASTER; SELECT [name] as DbName FROM master.dbo.sysdatabases",
                CommandType.Text);
            return dt;
        }

        public static async Task<int> Backup(string name)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("USP_BACKUP", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@databaseName", SqlDbType.NVarChar, name));
            return result;
        }
    }
}
