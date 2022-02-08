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
    /// Interaction logic for workers.xaml
    /// </summary>
    public partial class workers : Window
    {
        private readonly DataTable _dataset;

        public workers(System.Data.DataTable dt)
        {
            InitializeComponent();
            _dataset = dt;
            listrequestgrid.ItemsSource = dt.DefaultView;
        }
    }
}
