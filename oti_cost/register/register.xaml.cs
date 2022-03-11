using Newtonsoft.Json;
using System.Windows;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for register.xaml
    /// </summary>
    public partial class register : Window
    {
        public register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string query = "insert into users(user_type, user_name, email, password) values(" +
            //    "'" + usertype.Text + "'" +
            //    ",'" + user_name.Text + "'" +
            //    ",'" + email.Text + "'" +
            //    ",'" + your_password.Password.GetHashCode() + "'" +
            //    ")";

            string query = "insert into users(user_type, user_name, email, password) values(" +
                           "'" + "admin" + "'" +
                           ",'" + "ali" + "'" +
                           ",'" + "ali@gmail.com" + "'" +
                           ",'" + "12345".GetHashCode() + "'" +
                           ")";

            response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
            oknote ok;
            if (respo.success)
            {
                ok = new oknote("تم اضافة المستخدم بنجاح");
            }
            else if (!respo.success)
            {
                ok = new oknote(sharedvariables.errorMsg + respo.code);
                ok.ShowDialog();
            }
        }
    }
}
