using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace oti_cost
{

    class DBVariables
    {
        static string connectionstring = "server=127.0.0.1;uid=user1;pwd=123qweASD;database=oti_cost";
        static MySqlConnection conn = new MySqlConnection(connectionstring);
        static MySqlCommand comm = new MySqlCommand();

        static void openConn()
        {
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
        }

        static void closeConn()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public static void executenq(string query)
        {
            try
            {
                comm.Connection = conn;
                comm.CommandText = query;
                openConn();
                comm.ExecuteNonQuery();
                closeConn();
              
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public static string executescaler(string query)
        {
            try
            {
                comm.Connection = conn;
                comm.CommandText = query;
                openConn();
                string res = comm.ExecuteScalar().ToString();
                closeConn();
                return res;
            } 
            catch (System.Exception ex)
            {
                return null;
            }
        }


        public static bool isFound(string value, string column, string table)
        {
            try
            {
                string query = "select count(*) from " + table + " where " + column + " = '" + value + "'";
                comm.Connection = conn;
                comm.CommandText = query;
                openConn();
                var resutl = comm.ExecuteScalar();
                closeConn();
                if (int.Parse(resutl.ToString()) > 0)
                    return true;
                else
                    return false;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

    }
}
