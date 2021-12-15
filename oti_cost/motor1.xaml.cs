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
    /// Interaction logic for motor1.xaml
    /// </summary>
    public partial class motor1 : Window
    {
        public motor1()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void add_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void engine_data_Click(object sender, RoutedEventArgs e)
        {

        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            motor3 m2 = new motor3();
            m2.ShowDialog();
        }
    }
}
