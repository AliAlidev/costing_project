using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for show_active.xaml
    /// </summary>
    public partial class show_active : Window
    {
        private readonly DataTable _dataset;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listrequestgrid.Items.RemoveAt(listrequestgrid.SelectedIndex);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            revise r = new revise();
            r.ShowDialog();
        }

        private void listrequestgrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}
