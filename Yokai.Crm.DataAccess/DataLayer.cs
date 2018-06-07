using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Yokai.Crm.DataAccess
{
    public class DataLayer
    {
        /// <summary>
        /// Return the first column in an asynchrounous query
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="type">type of <see cref="CommandType"/></param>
        /// <param name="arr">return a list of sqlparmaeters array</param>
        /// <returns></returns>
        public static async Task<object> ExecuteScalarAsync(string query, CommandType type, params SqlParameter[] arr)
        {
            using (var cn = new SqlConnection(Helper.ConnectionString))
            {
                if(cn.State == ConnectionState.Closed)
                    cn.Open();
                var cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddRange(arr);
                cmd.CommandType = type;
                var result = await cmd.ExecuteScalarAsync();
                return result;
            }
        }
        /// <summary>
        /// Return the first column in an query
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="type">type of <see cref="CommandType"/></param>
        /// <param name="arr">return a list of sqlparmaeters array</param>
        /// <returns></returns>
        public static object ExecuteScalar(string query, CommandType type, params SqlParameter[] arr)
        {
            using (var cn = new SqlConnection(Helper.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                var cmd = new SqlCommand(query, cn) {CommandType = type};
                cmd.Parameters.AddRange(arr);
                cmd.CommandType = type;
                var result = cmd.ExecuteScalar();
                return result;
            }
        }

        /// <summary>
        /// Return the the number of row effect by insert, update, and delete
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="type">type of <see cref="CommandType"/></param>
        /// <param name="arr">return a list of sqlparmaeters array</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string query, CommandType type, params SqlParameter[] arr)
        {

            using (var cn = new SqlConnection(Helper.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn) {CommandType = type};
                cmd.Parameters.AddRange(arr);
                int n = cmd.ExecuteNonQuery();
                return n;
            }

        }
        /// <summary>
        /// Run a CRUD query async
        /// </summary>
        /// <param name="query"></param>
        /// <param name="type"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static async Task<int> ExecuteNonQueryAsync(string query, CommandType type, params SqlParameter[] arr)
        {

            using (var cn = new SqlConnection(Helper.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn) { CommandType = type };
                //cmd.CommandTimeout = 60;
                cmd.Parameters.AddRange(arr);
                int n = await cmd.ExecuteNonQueryAsync();
                return n;
            }

        }
        /// <summary>
        /// Return DataTable
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="type">type of <see cref="CommandType"/></param>
        /// <param name="arr">return a list of sqlparmaeters array</param>
        /// <returns></returns>
        public static DataTable ExecuteTable(String query, CommandType type, params SqlParameter[] arr)
        {
            using (var cn = new SqlConnection(Helper.ConnectionString))
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn) {CommandType = type};
                cmd.Parameters.AddRange(arr);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        // Return the parameters
        public static SqlParameter CreateParameter(string name, SqlDbType type, object value)
        {
            SqlParameter pr = new SqlParameter();
            pr.ParameterName = name;
            pr.SqlDbType = type;
            pr.SqlValue = value;
            return pr;

        }
    }
}