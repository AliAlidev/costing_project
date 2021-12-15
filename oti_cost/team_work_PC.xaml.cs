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
    /// Interaction logic for team_work_PC.xaml
    /// </summary>
    public partial class team_work_PC : Window
    {
        oknote ok;
        note n;
        public team_work_PC()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (worker_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم  العامل !");
                ok.ShowDialog();
            }
            else if (index_number.Text == "")
            {
                ok = new oknote("يجب إدخال الرقم الذاتي   !");
                ok.ShowDialog();
            }
            else if (category.Text == "")
            {
                ok = new oknote("يجب إدخال  الفئة ! ");
                ok.ShowDialog();
            }
            else if (work_done.Text == "")
            {
                ok = new oknote("يجب إدخال   العمل المنجز ! ");
                ok.ShowDialog();
            }
            else if (hours_number.Text == "")
            {
                ok = new oknote("يجب إدخال  عدد ساعات العمل ! ");
                ok.ShowDialog();
            }
            //else if (hours_number.Text == "")
            //{
            //    ok = new oknote("يجب إدخال  عدد ساعات العمل ! ");
            //    ok.ShowDialog();
            //}
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

                        DBVariables.executenq("INSERT INTO engine_card (worker_name , index_number , category ,  work_done , hours_number  )  VALUES('" +
                               worker_name.Text +
                               "' , '" + index_number.Text +
                              "' , '" + category.Text +
                              "' , '" + work_done.Text +
                               "' , '" + hours_number.Text + "' ) ");

                        sharedvariables.confirmationmessagebox = "";
                        ok = new oknote("تم الإدخال بنجاح");
                        ok.ShowDialog();

                        worker_name.Text = "";
                        index_number.Text = "";
                        category.Text = "";
                        work_done.Text = "";
                        hours_number.Text = "";



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
                    worker_name.Text = "";
                    index_number.Text = "";
                    category.Text = "";
                    work_done.Text = "";
                    hours_number.Text = "";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
