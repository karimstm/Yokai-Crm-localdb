using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Yokai.Crm.DataAccess
{
    public class Helper
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        //StringCipher.Decrypt(ConfigurationManager.ConnectionStrings["cn"].ConnectionString, "moutik");
        //Resource1.ConnectionString.ToString();
        //ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
    }
}
