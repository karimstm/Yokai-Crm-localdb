using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yokai.Crm.DataAccess;

namespace Yokai.Crm.Core
{
    public class Users
    {
        public static DataTable GetUsers()
        {
            var dt = DataLayer.ExecuteTable("usp_UsersSelect", CommandType.StoredProcedure);
            return dt;
        }

        public static async Task<int> InsertUser(string username, string fullname, string email, string psw, int permissionid)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_UsersInsert", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@username", SqlDbType.NVarChar, username),
                DataLayer.CreateParameter("@FullName", SqlDbType.NVarChar, fullname),
                DataLayer.CreateParameter("@Email", SqlDbType.NVarChar, email),
                DataLayer.CreateParameter("@pswd", SqlDbType.NVarChar, psw),
                DataLayer.CreateParameter("@permissionid", SqlDbType.BigInt, permissionid)
                );
            return result;
        }
        public static async Task<int> UpdateUser(string username, string fullname, string email, string psw, int permissionid)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_UsersUpdate", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@username", SqlDbType.NVarChar, username),
                DataLayer.CreateParameter("@FullName", SqlDbType.NVarChar, fullname),
                DataLayer.CreateParameter("@Email", SqlDbType.NVarChar, email),
                DataLayer.CreateParameter("@pswd", SqlDbType.NVarChar, psw),
                DataLayer.CreateParameter("@permissionid", SqlDbType.BigInt, permissionid)
            );
            return result;
        }

        public static async Task<int> DeleteUser(string username)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_UsersDelete", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@username", SqlDbType.NVarChar, username)
            );
            return result;
        }
        public static DataTable SelecteUserById(string username)
        {
            var result = DataLayer.ExecuteTable("usp_UsersSelectById", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@username", SqlDbType.NVarChar, username)
            );
            return result;
        }

        public static DataTable GetPermission()
        {
            var dt = DataLayer.ExecuteTable("usp_PermissionSelect", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable GetPrivileges(string username)
        {
            DataTable dt = DataLayer.ExecuteTable("usp_GetPriv", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@username", SqlDbType.NVarChar, username));
            return dt;
        }

        public static async Task<int> usp_UpatePriv(DataTable dt)
        {
            var result = await DataLayer.ExecuteNonQueryAsync("usp_UpatePriv", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@screen", SqlDbType.Structured, dt));
            return result;
        }

        public static DataTable UserSearch(string searchg)
        {
            var result = DataLayer.ExecuteTable("usp_UsersSearch", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@Search", SqlDbType.NVarChar, searchg)
            );
            return result;
        }

        public static DataTable GetPrivilege(string username)
        {
            var result = DataLayer.ExecuteTable("usp_GetMyPrevilages", CommandType.StoredProcedure,
                DataLayer.CreateParameter("@username", SqlDbType.NVarChar, username)
            );
            return result;
        }
    }
}
