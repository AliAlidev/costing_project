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
    /// Interaction logic for results.xaml
    /// </summary>
    public partial class results : Window
    {
        oknote ok;
        note n;
        public results()
        {
            InitializeComponent();
            double h = SystemParameters.PrimaryScreenHeight;
            double w = SystemParameters.PrimaryScreenWidth;

            Width = w;
            Height = h;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (resultafter.Text == "")
            {
                ok = new oknote("يجب إدخال نتائج الاختبار   !    ");
                ok.ShowDialog();
            }
            else if (sender_after.Text == "")
            {
                ok = new oknote("يجب إدخال اسم المسلم يعد الصيانة     !    ");
                ok.ShowDialog();
            }
            else if (receiver_after.Text == "")
            {
                ok = new oknote("يجب إدخال اسم المستلم بعد الصيانة    !    ");
                ok.ShowDialog();
            }

            else
            {

                n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من صحة البيانات المدخلة قبل الموافقة )");
                n.ShowDialog();
                if (sharedvariables.confirmationmessagebox == "ok")
                {

                    try
                    {


                        string query = "update engine_card set results='" + resultafter.Text + "', sender_after='" + sender_after.Text + "', receiver_after ='" + receiver_after.Text + "' where card_number=" + card_number.Text;
                        response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                        if (!respo.success)
                        {
                            ok = new oknote(sharedvariables.errorMsg + respo.code);
                            ok.ShowDialog();
                            Close();
                        }
                        sharedvariables.confirmationmessagebox = "";
                        ok = new oknote("تم الإدخال بنجاح");
                        ok.ShowDialog();

                        //project_number.Text = "";
                        resultafter.Text = "";
                        sender_after.Text = "";
                        receiver_after.Text = "";
                      



                    }
                    catch (Exception)
                    {
                        ok = new oknote("حدثت مشكلة أثناء عملية الإدخال");
                        ok.ShowDialog();
                    }



                }
                else
                {

                    sharedvariables.confirmationmessagebox = "";
                    ok = new oknote("لم يتم إدخال البيانات ");
                    ok.ShowDialog();
                    //project_number.Text = "";
                    resultafter.Text = "";
                    sender_after.Text = "";
                    receiver_after.Text = "";
                  
                }
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
