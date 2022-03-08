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
                f1.reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
                f1.reportViewer1.LocalReport.DataSources.Add(rdc);
                //////// append work team
                query = "select * from work_team where project_number=" + projectNum;
                ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
                rdc = new ReportDataSource("WorkerDataSet", ds.Tables[0]);
                f1.reportViewer1.LocalReport.DataSources.Add(rdc);
                //////// append work team
                query = "select * from material_used where project_number=" + projectNum;
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
                string query = "select id, active_center_name, project_name, dept, help_team, governorate, start_date, finsh_date, project_number, work_done, hours, notes, active_center_name from project_card where project_number=" + projectNum;
                ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
                DataRow drv = ds.Tables[0].Rows[0];
                modulation m = new modulation();
                m.project_name.Text = (string)drv.ItemArray[2].ToString();
                m.dept_name.Text = (string)drv.ItemArray[3].ToString();
                m.help_team.Text = (string)drv.ItemArray[4].ToString();
                m.governorate.Text = (string)drv.ItemArray[5].ToString();
                m.start_date.Text = (string)drv.ItemArray[6].ToString();
                m.finsh_date.Text = (string)drv.ItemArray[7].ToString();
                m.result_work.Text = (string)drv.ItemArray[9].ToString();
                m.hour_work.Text = (string)drv.ItemArray[10].ToString();
                m.notes.Text = (string)drv.ItemArray[11].ToString();
                m.active_name.Text = (string)drv.ItemArray[12].ToString();
                m.card_number.Text = (string)drv.ItemArray[8].ToString();

                ///id, material_name, index_number, unit, quantity, unit_price, total_price, notes, project_number, total_sum
                query = "select * from material_used where project_number=" + projectNum;
                ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    materials_class mc = new materials_class
                    {
                        material_name = (string)item.ItemArray[1],
                        index_number = (string)item.ItemArray[2],
                        unit = (string)item.ItemArray[3],
                        quantity = (string)item.ItemArray[4],
                        unit_price = (string)item.ItemArray[5],
                        total_price = (string)item.ItemArray[6],
                        notes = (string)item.ItemArray[7]
                    };
                    m.teamgrid.Items.Add(mc);
                }
                m.ShowDialog();
            }
        }

        private void description_Click(object sender, RoutedEventArgs e)
        {
            if (listproject.SelectedItem.GetType().Name == "DataRowView")
            {
                works_result wr = new works_result(this);
                DataRowView dr = (DataRowView)listproject.SelectedItem;
                int projectNum = 0;
                int.TryParse(dr.Row.ItemArray[7].ToString(), out projectNum);
                wr.card_number.Text = projectNum.ToString();
                wr.ShowDialog();
            }
        }

        private void materials_Click(object sender, RoutedEventArgs e)
        {
            if (listproject.SelectedItem.GetType().Name == "DataRowView")
            {
                material_used_PC mu = new material_used_PC(this);
                DataRowView dr = (DataRowView)listproject.SelectedItem;
                int projectNum = 0;
                int.TryParse(dr.Row.ItemArray[7].ToString(), out projectNum);
                mu.card_numberrr.Text = projectNum.ToString();
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
                    DataSet ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable("select work_done,hours from project_card where project_number=" + projectNum));
                    string work_done = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    string hours = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                    if (!hasData(work_done) && !hasData(hours))
                        btn.Visibility = Visibility.Visible;
                    else
                        btn.Visibility = Visibility.Hidden;
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
    }
}
