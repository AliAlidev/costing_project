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
    /// Interaction logic for active_center.xaml
    /// </summary>
    public partial class active_center : Window
    {
        public active_center()
        {
            InitializeComponent();
        }

        private void active_name_Click(object sender, RoutedEventArgs e)
        {
            add_active a = new add_active();
            a.ShowDialog();
        }

        private void show_active_name_Click(object sender, RoutedEventArgs e)
        {
            //show_active a = new show_active();
            //a.ShowDialog();
            DataTable dt = DBVariables.showactivecenter();

            show_active lr = new show_active(dt);
            lr.ShowDialog();
        }
    }
}
