using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace oti_cost
{

    class DBVariables
    {
        static string connectionstring = "server=127.0.0.1;uid=user1;pwd=123qweASD;database=oti_cost";
        static MySqlConnection conn = new MySqlConnection(connectionstring);
        static MySqlCommand comm = new MySqlCommand();
        MySqlDataReader myReader;



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


        public static MySqlDataReader ExecuteReader(string query)
        {
            try
            {
                comm.Connection = conn;
                comm.CommandText = query;
                openConn();

                MySqlDataReader res = comm.ExecuteReader();
                //closeConn();
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
            string query = "select id , active_center_name , team_name from active_center";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            da.Fill(dt);

            // id column
            DataTable datatable0 = new DataTable();
            DataRow myDataRow;
            DataColumn dtColumn;

            //dtColumn = new DataColumn();
            //dtColumn.DataType = typeof(string);
            //dtColumn.ColumnName = "معرف";
            //dtColumn.AutoIncrement = true;
            //dtColumn.ReadOnly = true;
            //dtColumn.Unique = false;
            //datatable0.Columns.Add(dtColumn);


            // team name column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "اسم الفريق";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = true;
            dtColumn.Unique = false;
            datatable0.Columns.Add(dtColumn);


            // active centers column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "اسم مركز النشاط";
           
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = true;
            dtColumn.Unique = false;
            datatable0.Columns.Add(dtColumn);

            // workers column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "اسم العمال";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = true;
            dtColumn.Unique = false;
            datatable0.Columns.Add(dtColumn);





            foreach (DataRow dr in dt.Rows)
            {
                myDataRow = datatable0.NewRow();
                int id = (int)dr.ItemArray[0];
                string quy = "select worker_name from workers_names where active_center_id=" + id;
                DataSet workersds = new DataSet();
                da = new MySqlDataAdapter(quy, conn);
                da.Fill(workersds);
                string workersnames = "";
                foreach (DataRow item in workersds.Tables[0].Rows)
                {
                    workersnames +=  (item.ItemArray[0].ToString() + ", ");
                }
                myDataRow["اسم العمال"] = workersnames;
                myDataRow["اسم مركز النشاط"] = dr.ItemArray[1].ToString();
                myDataRow["اسم الفريق"] = dr.ItemArray[2].ToString();

                




                datatable0.Rows.Add(myDataRow);
            }

            return datatable0;
        }



        //public static DataTable showWorkers(string tt)
        //{

        //    //string query = "select worker_name  from workers_names";
        //    //query = "select worker_name from workers_names where active_center_name='" + active_name.Text + "' and team_name ='" + team_name.Text + "'";

        //    DataTable dt = new DataTable();
        //    MySqlDataAdapter da = new MySqlDataAdapter(tt, conn);
        //    da.Fill(dt);

        //    // id column
        //    DataTable datatable0 = new DataTable();
        //    DataRow myDataRow;
        //    DataColumn dtColumn;


        //    // worker name column
        //    dtColumn = new DataColumn();
        //    dtColumn.DataType = typeof(string);
        //    dtColumn.ColumnName = "أسماء العمال";
        //    dtColumn.AutoIncrement = false;
        //    dtColumn.ReadOnly = true;
        //    dtColumn.Unique = false;
        //    datatable0.Columns.Add(dtColumn);





        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        myDataRow = datatable0.NewRow();
        //        myDataRow["أسماء العمال"] = dr.ItemArray[0].ToString();

        //        datatable0.Rows.Add(myDataRow);
        //    }

        //    return datatable0;
        //}



    }
}
