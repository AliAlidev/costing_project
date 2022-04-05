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
                ok.ShowDialog();
            }
            else
            {
                query = "select user_name, user_type from users where email='" + user_email.Text + "' and password='" + user_password.Password.GetHashCode() + "'";
                DataSet ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
                sharedvariables.username = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                sharedvariables.usertype = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                MainWindow main = new MainWindow();
                Close();
                main.ShowDialog();
            }
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
