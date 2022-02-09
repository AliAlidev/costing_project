using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Media;

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
            revise r = new revise();
            r.ShowDialog();
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

        }
    }

