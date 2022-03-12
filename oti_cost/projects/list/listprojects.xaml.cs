using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for listprojects.xaml
    /// </summary>
    public partial class listprojects : Window
    {
        public listprojects()
        {
            InitializeComponent();

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
            listproject.ItemsSource = ds.Tables[0].DefaultView;

            //////////////////////////////
            double h = SystemParameters.PrimaryScreenHeight;
            double w = SystemParameters.PrimaryScreenWidth;
            Height = h;
            Width = w;

        }

        private void show_Click(object sender, RoutedEventArgs e)
        {
            if (listproject.SelectedItem.GetType().Name == "DataRowView")
            {
                DataRowView dr = (DataRowView)listproject.SelectedItem;
                int projectNum = 0;
                int.TryParse(dr.Row.ItemArray[7].ToString(), out projectNum);

                ////////////////////////////
                Form1 f1 = new Form1();
                //////// append project data
                string query = "select * from project_card where project_number=" + projectNum;
                DataSet ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
                ReportDataSource rdc = new ReportDataSource("ProjectDataSet", ds.Tables[0]);
                f1.reportViewer1.LocalReport.ReportPath = "Project_Card.rdlc";
                f1.reportViewer1.LocalReport.DataSources.Add(rdc);
                //////// append work team
                query = "select * from work_team where project_number=" + projectNum;
                ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
                rdc = new ReportDataSource("WorkerDataSet", ds.Tables[0]);
                f1.reportViewer1.LocalReport.DataSources.Add(rdc);
                //////// append work team
                query = "select * from material_used where project_number=" + projectNum + " group by active_center_name";
                ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
                rdc = new ReportDataSource("MaterialsDataSet", ds.Tables[0]);
                f1.reportViewer1.LocalReport.DataSources.Add(rdc);
                f1.reportViewer1.RefreshReport();
                f1.Show();
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (listproject.SelectedItem.GetType().Name == "DataRowView")
            {
                DataRowView dr = (DataRowView)listproject.SelectedItem;
                int projectNum = 0;
                int.TryParse(dr.Row.ItemArray[7].ToString(), out projectNum);

                DataSet ds = new DataSet();
                string query = "select id, active_center_name, project_name, dept, help_team, governorate, start_date, finsh_date, project_number, active_center_name from project_card where project_number=" + projectNum;
                ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
                DataRow drv = ds.Tables[0].Rows[0];
                modulation m = new modulation(this);
                m.project_name.Text = (string)drv.ItemArray[2].ToString();
                m.dept_name.Text = (string)drv.ItemArray[3].ToString();
                m.help_team.Text = (string)drv.ItemArray[4].ToString();
                m.governorate.Text = (string)drv.ItemArray[5].ToString();
                m.start_date.Text = (string)drv.ItemArray[6].ToString();
                m.finsh_date.Text = (string)drv.ItemArray[7].ToString();
                m.card_number.Text = (string)drv.ItemArray[8].ToString();

                m.ShowDialog();
            }
        }

        private void description_Click(object sender, RoutedEventArgs e)
        {
            if (listproject.SelectedItem.GetType().Name == "DataRowView")
            {
                DataRowView dr = (DataRowView)listproject.SelectedItem;
                int projectNum = 0;
                int.TryParse(dr.Row.ItemArray[7].ToString(), out projectNum);
                works_result wr = new works_result(projectNum, this);
                wr.card_number.Text = projectNum.ToString();
                wr.ShowDialog();
            }
        }

        private void materials_Click(object sender, RoutedEventArgs e)
        {
            if (listproject.SelectedItem.GetType().Name == "DataRowView")
            {
                DataRowView dr = (DataRowView)listproject.SelectedItem;
                int projectNum = 0;
                int.TryParse(dr.Row.ItemArray[7].ToString(), out projectNum);
                material_used_PC mu = new material_used_PC(projectNum, this);
                mu.card_number.Text = projectNum.ToString();
                mu.ShowDialog();
            }
        }

        private void materials_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                var rowType = ((Button)e.Source).DataContext.GetType().Name;
                if (rowType == "DataRowView")
                {
                    DataRowView drv = (DataRowView)((Button)e.Source).DataContext;
                    int projectNum = 0;
                    int.TryParse(drv.Row.ItemArray[7].ToString(), out projectNum);
                    int res = 0;
                    int.TryParse(JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler("select count(*) from material_used where project_number=" + projectNum)), out res);
                    if (res > 0)
                        btn.Visibility = Visibility.Hidden;
                    else
                        btn.Visibility = Visibility.Visible;
                }
                else
                    btn.Visibility = Visibility.Hidden;
            }
            catch (System.Exception)
            {

            }
        }

        private void description_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                var rowType = ((Button)e.Source).DataContext.GetType().Name;
                if (rowType == "DataRowView")
                {
                    DataRowView drv = (DataRowView)((Button)e.Source).DataContext;
                    int projectNum = 0;
                    int.TryParse(drv.Row.ItemArray[7].ToString(), out projectNum);

                    int res = 0;
                    int.TryParse(JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler("select count(*) from project_results where project_number=" + projectNum)), out res);
                    if (res > 0)
                        btn.Visibility = Visibility.Hidden;
                    else
                        btn.Visibility = Visibility.Visible;
                }
                else
                    btn.Visibility = Visibility.Hidden;
            }
            catch (System.Exception)
            {

            }
        }

        public bool hasData(string data)
        {
            if (data == "" || data == null | data == " ")
                return false;
            else
                return true;
        }

        private void show_Loaded(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            var rowType = ((Button)e.Source).DataContext.GetType().Name;
            if (rowType != "DataRowView")
                btn.Visibility = Visibility.Hidden;
        }

        private void edit_Loaded(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            var rowType = ((Button)e.Source).DataContext.GetType().Name;
            if (rowType != "DataRowView")
                btn.Visibility = Visibility.Hidden;
        }

        private void active_center_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                var rowType = ((Button)e.Source).DataContext.GetType().Name;
                if (rowType == "DataRowView")
                {
                    DataRowView drv = (DataRowView)((Button)e.Source).DataContext;
                    int projectNum = 0;
                    int.TryParse(drv.Row.ItemArray[7].ToString(), out projectNum);
                    int res = 0;
                    int.TryParse(JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler("select count(*) from project_active_center where project_id=" + projectNum)), out res);
                    if (res > 0)
                    {
                        btn.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        btn.Visibility = Visibility.Visible;
                    }
                }
                else
                    btn.Visibility = Visibility.Hidden;
            }
            catch (System.Exception)
            {

            }
        }

        private void active_center_Click(object sender, RoutedEventArgs e)
        {
            if (listproject.SelectedItem.GetType().Name == "DataRowView")
            {
                int projectNum = 0;
                DataRowView dr = (DataRowView)listproject.SelectedItem;
                int.TryParse(dr.Row.ItemArray[7].ToString(), out projectNum);
                mainactivecenter mac = new mainactivecenter(projectNum, this);
                mac.ShowDialog();
            }
        }
    }
}
