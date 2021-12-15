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
    /// Interaction logic for report2.xaml
    /// </summary>
    public partial class report2 : Window
    {
        int number = 5;
        int width = 10;
        int height = 10;
        int top = 20;
        int left = 20;
        public report2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < number; i++)
            {
                // Create the rectangle
                Rectangle rec = new Rectangle()
                {
                    Width = 200,
                    Height = 30,
                    Fill = Brushes.Green,
                    Stroke = Brushes.Red,
                    StrokeThickness = 2,
                };

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}