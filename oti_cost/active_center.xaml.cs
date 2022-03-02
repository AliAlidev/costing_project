using System.Data;
using System.Windows;

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
