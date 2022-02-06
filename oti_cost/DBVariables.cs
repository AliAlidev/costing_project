using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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



        public static DataTable showactivecenter()
        {
            string query = "select active_center_name , team_name from active_center";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            da.Fill(dt);

            // id column
            DataTable datatable0 = new DataTable();
            DataRow myDataRow;
            DataColumn dtColumn;
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "معرف";
            dtColumn.AutoIncrement = true;
            dtColumn.ReadOnly = true;
            dtColumn.Unique = false;
            datatable0.Columns.Add(dtColumn);

            // request_number column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "اسم مركز النشاط";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = true;
            dtColumn.Unique = false;
            datatable0.Columns.Add(dtColumn);

            // request_date column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "اسم الفريق";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = true;
            dtColumn.Unique = false;
            datatable0.Columns.Add(dtColumn);

           

            foreach (DataRow dr in dt.Rows)
            {
                myDataRow = datatable0.NewRow();
                myDataRow["اسم مركز النشاط"] = dr.ItemArray[0].ToString();
  
                myDataRow["اسم الفريق"] = dr.ItemArray[1].ToString();

             
                datatable0.Rows.Add(myDataRow);

            }

            return datatable0;
        }


    }
}
