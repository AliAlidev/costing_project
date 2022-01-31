using System;
using System.Collections.Generic;
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
        public show_active()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            showgrid.Items.RemoveAt(showgrid.SelectedIndex);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            revise r = new revise();
            r.ShowDialog();
        }
    }
}
