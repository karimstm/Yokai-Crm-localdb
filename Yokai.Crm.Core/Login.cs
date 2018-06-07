using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class Login
    {
        public static DataTable usp_login(string username, string password)
        {
            DataTable dt = DataLayer.ExecuteTable("usp_login", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@username", SqlDbType.NVarChar, username),
                DataLayer.CreateParameter("@pswd", SqlDbType.NVarChar, password));
            return dt;
        }
    }
}
