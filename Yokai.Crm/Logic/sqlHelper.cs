using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yokai.Crm
{
    public class sqlHelper
    {
        SqlConnection cn;
        public sqlHelper(string connectionString)
        {
            cn = new SqlConnection(connectionString);
        }
        public bool IsConnection
        {
            get
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                return true;
            }
        }
    }
}
