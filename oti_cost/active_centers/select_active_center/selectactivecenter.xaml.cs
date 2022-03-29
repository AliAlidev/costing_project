using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using System.Data;
using System.Windows;

namespace oti_cost.active_centers.select_active_center
{
    /// <summary>
    /// Interaction logic for selectactivecenter.xaml
    /// </summary>
    public partial class selectactivecenter : Window
    {
        public int projectNum { get; set; }
        public selectactivecenter(int projectNumber)
        {
            InitializeComponent();

            projectNum = projectNumber;

            /////////////////////// fill active centers
            DataSet ds = sharedvariables.getActiveCentersList(projectNumber);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                active_name.Items.Add(item.ItemArray[0]);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //////////////////////////////
            Form1 f1 = new Form1();
            //////// append project data
            string query = "select project_card.project_number, project_card.project_name, active_center.active_center_name, project_results.work_done, project_results.hours, project_results.notes from ((project_card join project_active_center on project_active_center.project_id = project_card.project_number) join active_center on project_active_center.active_center_id = active_center.id) join project_results on project_results.project_number = project_card.project_number and project_results.active_center_name = active_center.active_center_name where project_card.project_number=" + projectNum + " and active_center.active_center_name='" + "aa1" + "'";
            DataSet ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
            ReportDataSource rdc = new ReportDataSource("CostDataSet", ds.Tables[0]);
            f1.reportViewer1.LocalReport.ReportPath = "Project_Card.rdlc";
            f1.reportViewer1.LocalReport.DataSources.Add(rdc);

            //////// append materials used
            query = "select * from material_used where project_number=" + projectNum + " and active_center_name='" + "aa1" + "'" + " group by active_center_name";
            ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
            rdc = new ReportDataSource("MaterialsDataSet", ds.Tables[0]);
            f1.reportViewer1.LocalReport.DataSources.Add(rdc);

            //////// append project data
            query = "select * from project_card where project_number=" + projectNum;
            ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
            rdc = new ReportDataSource("ProjectDataSet", ds.Tables[0]);
            f1.reportViewer1.LocalReport.DataSources.Add(rdc);

            f1.reportViewer1.RefreshReport();
            f1.Show();
            Close();
        }
    }
}
