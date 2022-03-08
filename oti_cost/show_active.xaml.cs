using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for show_active.xaml
    /// </summary>
    public partial class show_active : Window
    {
        private readonly DataTable _dataset;
        oknote ok;

        public show_active(System.Data.DataTable dt)
        {
            InitializeComponent();

            _dataset = dt;
            listrequestgrid.ItemsSource = dt.DefaultView;
            double w = SystemParameters.PrimaryScreenWidth;
            double h = SystemParameters.PrimaryScreenHeight;
            Width = w;
            Height = h;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //revise r = new revise();
            //r.ShowDialog();
        }



        private void listrequestgrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            var headerName = "Organization";

            var column = e.Column;
            if (!column.Header.ToString().Equals(headerName))
            {
                return;
            }

            var source = (sender as System.Windows.Controls.DataGrid).ItemsSource as ListCollectionView;
            if (source == null)
            {
                return;
            }

            e.Handled = true;
            var sortDirection = column.SortDirection == ListSortDirection.Ascending ?
                ListSortDirection.Descending : ListSortDirection.Ascending;

            using (source.DeferRefresh())
            {
                source.SortDescriptions.Clear();
                source.SortDescriptions.Add(new SortDescription(headerName, sortDirection));
            }
            source.Refresh();
            column.SortDirection = sortDirection;
        }

        private void listrequestgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid drv = (DataGrid)sender;
            var typ = drv.SelectedItem.GetType();
            if (typ.Name == "DataRowView")
            {
                DataRowView t = (DataRowView)drv.SelectedItem;
                var tt = t.Row.ItemArray;
                revise r = new revise();

                DataSet ds = new DataSet();
                string query = "select id from active_center where active_center_name = '" + tt[1].ToString() + "' and team_name= '" + tt[0].ToString() + "'";
                int getRowId = int.Parse(JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query)));

                query = "select worker_name, self_number, category from workers_names where active_center_id =" + getRowId;
                ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    var ob1 = new sharedvariables.workers_names();
                    ob1.worker_name = item.ItemArray[0].ToString();
                    ob1.self_number = item.ItemArray[1].ToString();
                    ob1.category = item.ItemArray[2].ToString();
                    r.teamgrid.Items.Add(ob1);
                }

                r.active_name.Text = tt[1].ToString();
                r.team_name.Text = tt[0].ToString();
                r.getRowId = getRowId;
                r.ShowDialog();
            }
        }
    }
}

