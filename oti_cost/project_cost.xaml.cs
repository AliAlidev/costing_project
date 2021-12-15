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
    /// Interaction logic for project_cost.xaml
    /// </summary>
    public partial class project_cost : Window
    {
        oknote ok;
        note n; public project_cost()
        {
            InitializeComponent();
        }

        private void addnumber_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edit_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addnumber_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void engine_data_Click(object sender, RoutedEventArgs e)
        {

        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
           Work2 p1 = new Work2 ();
            p1.ShowDialog();
            
        }

        private void works_Click(object sender, RoutedEventArgs e)
        {
            Work1 w = new Work1();
            w.ShowDialog();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void material_Click(object sender, RoutedEventArgs e)
        {
            Work2 w2 = new Work2();
            w2.ShowDialog();
        }

        private void add_Click_1(object sender, RoutedEventArgs e)
        {
            if (DBVariables.isFound(project_number.Text, "card_number", "engine_card"))
            {
                ok = new oknote("هذا المشروع موجود مسبقاً !");
                ok.ShowDialog();
            }
            else
           if (!sharedvariables.isNumber(this.project_number.Text))
            {
                ok = new oknote("يجب ادخال قيمة صحيحة لرقم المشروع !");
                ok.ShowDialog();
            }
            else
           if (date.Text == "")
            {
                ok = new oknote("يجب إدخال التاريخ !");
                ok.ShowDialog();
            }
            else if (project_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم المشروع !");
                ok.ShowDialog();
            }
            else if (number.Text == "")
            {
                ok = new oknote("يجب إدخال  رقم طلب الاصلاح ! ");
                ok.ShowDialog();
            }
            else if (depart.Text == "")
            {
                ok = new oknote("يجب إدخال الجهة الطالبة  !    ");
                ok.ShowDialog();
            }
            else if (request_date.Text == "")
            {
                ok = new oknote("يجب إدخال  تاريخ الطلب  !    ");
                ok.ShowDialog();
            }
          

            else if (!sharedvariables.isDate(request_date.Text))
            {
                ok = new oknote("يجب إدخال قيمة صحيحة  لتاريخ الطلب  !    ");
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

                        DBVariables.executenq("INSERT INTO engine_card (card_number , dept , sender_name ,  receiver_name , received_date ,sent_date )  VALUES('" +
                               project_number.Text +
                               "' , '" + date.Text +
                               "' , '" + project_name.Text +
                              "' , '" + number.Text +
                              "' , '" + depart.Text +
                               "' , '" + request_date.Text + "' ) ");

                        sharedvariables.confirmationmessagebox = "";
                        ok = new oknote("تم الإدخال بنجاح");
                        ok.ShowDialog();

                        project_number.Text = "";
                        date.Text = "";
                        project_name.Text = "";
                        number.Text = "";
                        depart.Text = "";
                        request_date.Text = "";



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
                    project_number.Text = "";
                    date.Text = "";
                    project_name.Text = "";
                    number.Text = "";
                    depart.Text = "";
                    request_date.Text = "";
                }
            }





        }

        private void abrogation_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
    }

