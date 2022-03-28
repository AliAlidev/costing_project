using Newtonsoft.Json;
using System;
using System.Data;

namespace oti_cost
{
    public static class sharedvariables
    {
        public static WebReference.MainWebService proxy = new WebReference.MainWebService();

        public static string confirmationmessagebox;

        public static string errorMsg = "حدث خطأ أثناء تنفيذ العملية رمز الخطأ هو ";

        public static string team_name;
        public static string project_name;
        public static string dept;
        public static string help_team;
        public static string governorate;
        public static string start_date;
        public static string finsh_date;

        public static string username;
        public static string usertype;

        public static bool isDate(string val)
        {
            try
            {
                var dd = DateTime.Parse(val).ToShortDateString();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool isNumber(string val)
        {
            try
            {
                var dd = double.Parse(val);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool isServerAvailable()
        {
            try
            {
                WebReference.MainWebService p = new WebReference.MainWebService();
                DataSet ds = JsonConvert.DeserializeObject<DataSet>(p.FillDataTable("select * from project_card"));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public class workers_names
        {
            public string worker_name { get; set; }
            public string self_number { get; set; }
            public string category { get; set; }
            public string team_name { get; set; }
            public string active_name { get; set; }
        }

        public class materials
        {
            public string material_name { set; get; }
            public string index_number { set; get; }
            public string unit { set; get; }
            public string quantity { set; get; }
            public string unit_price { set; get; }
            public string total_price { set; get; }
            public string notes { set; get; }
            public string project_number { set; get; }
            public string total_sum { set; get; }
            public string source { set; get; }
            public string active_center_name { set; get; }
            
        }

        public class engine_data
        {
            public string engine_name { set; get;}
            public string engine_number { set; get;}
            public string dept { set; get; }
            public string card_number { set; get; }
            public string sender_name { set; get; }
            public string receiver_name { set; get; }
            public string received_date { set; get; }
            public string sent_date { set; get; }
            public string results { set; get; }
            public string engine_sequence_number { set; get; }
            public string engine_power { set; get; }
            public string engine_rpm { set; get; }

        }

        public static void listPrpjects(listprojects mainWindows)
        {
            ////////////// list projects
            DataSet ds = new DataSet();
            string query = "select active_center_name, project_name, dept, help_team, governorate, start_date, finsh_date, project_number from project_card";
            ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
            ds.Tables[0].Columns[0].ColumnName = "اسم مركز النشاط";
            ds.Tables[0].Columns[1].ColumnName = "اسم المشروع";
            ds.Tables[0].Columns[2].ColumnName = "الجهة الطالبة";
            ds.Tables[0].Columns[3].ColumnName = "الفرق المساعدة";
            ds.Tables[0].Columns[4].ColumnName = "لمحافظة";
            ds.Tables[0].Columns[5].ColumnName = "تاريخ البدء";
            ds.Tables[0].Columns[6].ColumnName = "تاريخ الانتهاء";
            ds.Tables[0].Columns[7].ColumnName = "رقم المشروع";
            mainWindows.listproject.ItemsSource = ds.Tables[0].DefaultView;
        }

        public static DataSet getActiveCentersList(int projectNum)
        {
            string query = "select active_center_name from active_center join project_active_center on project_active_center.active_center_id = active_center.id where project_active_center.project_id=" + projectNum;
            DataSet ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
            return ds;
        }

        public static DataSet getActiveCentersList()
        {
            string query = "select active_center_name from active_center";
            DataSet ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
            return ds;
        }
    }
}
