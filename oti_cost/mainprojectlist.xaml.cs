using System.Data;
using System.Windows;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for active_center.xaml
    /// </summary>
    public partial class mainprojectlist : Window
    {
        public mainprojectlist()
        {
            InitializeComponent();
        }

        private void show_active_name_Click(object sender, RoutedEventArgs e)
        {
            listprojects lp = new listprojects();
            lp.ShowDialog();
        }

        private void active_name_Click(object sender, RoutedEventArgs e)
        {
            project_card pc = new project_card();
            pc.ShowDialog();
        }
    }
}
