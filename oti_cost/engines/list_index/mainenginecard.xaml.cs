using Newtonsoft.Json;
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
    /// Interaction logic for mainenginecard.xaml
    /// </summary>
    public partial class mainenginecard : Window
    {
        public mainenginecard()
        {
            InitializeComponent();
        }

        private void show_engine_name_Click(object sender, RoutedEventArgs e)
        {
            show_engines se = new show_engines();
            se.ShowDialog();
        }

        private void engine_name_Click(object sender, RoutedEventArgs e)
        {
            engine_card g = new engine_card();
            g.ShowDialog();
        }

        private void show_engine_name_Click_1(object sender, RoutedEventArgs e)
        {
            show_engines sheng = new show_engines();
            sheng.ShowDialog();
        }
    }
}
