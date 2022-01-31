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
    /// Interaction logic for works_result.xaml
    /// </summary>
    public partial class works_result : Window
    {
        oknote ok;
        note n;
        public works_result()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (result_work.Text == "")
            {
                ok = new oknote("يجب إدخال توصيف العمل   !    ");
                ok.ShowDialog();
            }
            else if (hour_work.Text == "")
            {
                ok = new oknote("يجب إدخال عدد ساعات العمل      !    ");
                ok.ShowDialog();
            }
            else if (notes.Text == "")
            {
                ok = new oknote("يجب إدخال الملاحظات    !    ");
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


                        string query = "update engine_card set results='" + result_work.Text + "', hour_work='" + hour_work.Text + "', notes ='" + notes.Text + "' where card_number=" ;

                        DBVariables.executenq(query);




                        sharedvariables.confirmationmessagebox = "";
                        ok = new oknote("تم الإدخال بنجاح");
                        ok.ShowDialog();

                        //project_number.Text = "";
                        result_work.Text = "";
                        hour_work.Text = "";
                        notes.Text = "";




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
                    result_work.Text = "";
                    hour_work.Text = "";
                    notes.Text = "";

                }
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
