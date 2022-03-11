using Newtonsoft.Json;
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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void signin_Click(object sender, RoutedEventArgs e)
        {
            string query = "select count(*) from users where email='"+user_email.Text+"' and password='"+ user_password.Password.GetHashCode() +"'";
            int res = 0;
            int.TryParse(JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query)), out res);
            if(res==0)
            {
                oknote ok = new oknote("البيانات المدخلة غير صحيحة يرجى التأكد منها");
            }
            else
            {
                query = "select user_name from users where email='" + user_email.Text + "' and pasword='" + user_password.Password.GetHashCode() + "'";
                string username = JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query));
                sharedvariables.username = username;
                MainWindow main = new MainWindow();
                main.ShowDialog();
                Close();
            }
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
