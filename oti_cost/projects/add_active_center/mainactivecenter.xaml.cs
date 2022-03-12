using Newtonsoft.Json;
using System.Data;
using System.Windows;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for mainactivecenter.xaml
    /// </summary>
    public partial class mainactivecenter : Window
    {
        private listprojects _listprojects;

        public mainactivecenter(int project_number, listprojects lp)
        {
            InitializeComponent();
            _listprojects = lp;

            card_number.Text = project_number.ToString();

            /////////////////////// fill active centers
            DataSet ds = sharedvariables.getActiveCentersList();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                active_name.Items.Add(item.ItemArray[0]);
            }

            ///////////////////////
            string query = "select active_center_name from active_center join project_active_center on project_active_center.active_center_id = active_center.id where project_active_center.project_id=" + card_number.Text;
            ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                activeCenter ac = new activeCenter();
                ac.center_name = item.ItemArray[0].ToString();
                gridmaterial.Items.Add(ac);

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gridmaterial.Items.Remove(gridmaterial.SelectedItem);
        }

        class activeCenter
        {
            public string center_name { get; set; }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            activeCenter ac = new activeCenter();
            ac.center_name = active_name.Text;
            if (!inGrid(ac.center_name))
                gridmaterial.Items.Add(ac);
        }

        bool inGrid(string obj)
        {
            bool isFound = false;
            foreach (activeCenter item in gridmaterial.Items)
            {
                if (item.center_name == obj)
                    isFound = true;
            }
            return isFound;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            ///////////////////////////
            note no = new note("هل أنت متأكد من الاستمرار هذه العملية");
            no.ShowDialog();
            if (sharedvariables.confirmationmessagebox == "ok")
            {
                string query = "";

                ////////////////////////////// remove old values
                query = "delete from project_active_center where project_id=" + card_number.Text;
                response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                if (!respo.success)
                {
                    oknote ok;
                    ok = new oknote(sharedvariables.errorMsg + respo.code);
                    ok.ShowDialog();
                    Close();
                }

                ////////////////////////////// insert new values
                foreach (activeCenter item in gridmaterial.Items)
                {
                    query = "select id from active_center where active_center_name ='" + item.center_name + "'";
                    int activeId = 0;
                    int.TryParse(JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query)), out activeId);
                    query = "insert into project_active_center (project_id, active_center_id) values('" + card_number.Text + "','" + activeId + "')";
                    respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                    if (!respo.success)
                    {
                        oknote ok;
                        ok = new oknote(sharedvariables.errorMsg + respo.code);
                        ok.ShowDialog();
                        Close();
                    }
                }

                ////////////////////////////// list projects
                DataSet ds = new DataSet();
                query = "select active_center_name, project_name, dept, help_team, governorate, start_date, finsh_date, project_number from project_card";
                ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
                ds.Tables[0].Columns[0].ColumnName = "اسم مركز النشاط";
                ds.Tables[0].Columns[1].ColumnName = "اسم المشروع";
                ds.Tables[0].Columns[2].ColumnName = "الجهة الطالبة";
                ds.Tables[0].Columns[3].ColumnName = "الفرق المساعدة";
                ds.Tables[0].Columns[4].ColumnName = "لمحافظة";
                ds.Tables[0].Columns[5].ColumnName = "تاريخ البدء";
                ds.Tables[0].Columns[6].ColumnName = "تاريخ الانتهاء";
                ds.Tables[0].Columns[7].ColumnName = "رقم المشروع";
                _listprojects.listproject.ItemsSource = ds.Tables[0].DefaultView;

                //////////////////////////////
                Close();
            }
        }
    }
}
