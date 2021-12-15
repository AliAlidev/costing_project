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
    /// Interaction logic for Work1.xaml
    /// </summary>
    public partial class Work1 : Window
    {

        oknote ok;
        note n;
        public Work1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Work2 p2 = new Work2();
            p2.ShowDialog();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //    if (DBVariables.isFound(item_name.Text, "card_number", "engine_card"))
            //    {
            //        ok = new oknote("هذه البطاقة  موجودة مسبقاً !");
            //        ok.ShowDialog();
            //    }
            // else
            //if (!sharedvariables.isNumber(this.card_number.Text))
            // {
            //     ok = new oknote("يجب ادخال قيمة صحيحة لرقم البطاقة !");
            //     ok.ShowDialog();
            // }
            //else
            if (activity_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم  النشاط !");
                ok.ShowDialog();
            }
            else if (center_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم مركز النشاط !");
                ok.ShowDialog();
            }
            else if (worker_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم العامل ! ");
                ok.ShowDialog();
            }
            else if (id.Text == "")
            {
                ok = new oknote("يجب إدخال  الرقم الذاتي ! ");
                ok.ShowDialog();
            }
            else if (category.Text == "")
            {
                ok = new oknote("يجب إدخال  الفئة ! ");
                ok.ShowDialog();
            }
            else if (work_hours.Text == "")
            {
                ok = new oknote("يجب إدخال  عدد ساعات العمل ! ");
                ok.ShowDialog();
            }
            //else if (sent_date.Text == "")
            //{
            //    ok = new oknote("يجب إدخال قيمة صحيحة  لتاريخ الاستلام  !    ");
            //    ok.ShowDialog();
            //}

            //else if (!sharedvariables.isDate(received_date.Text))
            //{
            //    ok = new oknote("يجب إدخال قيمة صحيحة  لتاريخ التسليم  !    ");
            //    ok.ShowDialog();
            //}
            else
            {

                n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من صحة البيانات المدخلة قبل الموافقة )");
                n.ShowDialog();



                if (sharedvariables.confirmationmessagebox == "ok")
                {

                    try
                    {

                        DBVariables.executenq("INSERT INTO engine_card (activity_name , center_name , worker_name ,  id , category ,work_hours )  VALUES('" +
                               activity_name.Text +
                               "' , '" + center_name.Text +
                               "' , '" + worker_name.Text +
                              "' , '" + id.Text +
                              "' , '" + category.Text +
                               "' , '" + work_hours.Text + "' ) ");

                        sharedvariables.confirmationmessagebox = "";
                        ok = new oknote("تم الإدخال بنجاح");
                        ok.ShowDialog();

                        activity_name.Text = "";
                        center_name.Text = "";
                        worker_name.Text = "";
                        id.Text = "";
                        category.Text = "";
                        work_hours.Text = "";



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
                    activity_name.Text = "";
                    center_name.Text = "";
                    worker_name.Text = "";
                    id.Text = "";
                    category.Text = "";
                    work_hours.Text = "";
                }
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
