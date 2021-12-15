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
    /// Interaction logic for material_used_PC.xaml
    /// </summary>
    public partial class material_used_PC : Window
    {
        oknote ok;
        note n; public material_used_PC()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (material_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم  المادة !");
                ok.ShowDialog();
            }
            else if (index_number.Text == "")
            {
                ok = new oknote("يجب إدخال رقم الفهرسة    !");
                ok.ShowDialog();
            }
            else if (unit.Text == "")
            {
                ok = new oknote("يجب إدخال  الواحدة ! ");
                ok.ShowDialog();
            }
            else if (quantity.Text == "")
            {
                ok = new oknote("يجب إدخال   الكمية ! ");
                ok.ShowDialog();
            }
            else if (origin.Text == "")
            {
                ok = new oknote("يجب إدخال المنشأ  ! ");
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

                        DBVariables.executenq("INSERT INTO engine_card (material_name , index_number , unit ,  quantity , origin  )  VALUES('" +
                               material_name.Text +
                               "' , '" + index_number.Text +
                              "' , '" + unit.Text +
                              "' , '" + quantity.Text +
                               "' , '" + origin.Text + "' ) ");

                        sharedvariables.confirmationmessagebox = "";
                        ok = new oknote("تم الإدخال بنجاح");
                        ok.ShowDialog();

                        material_name.Text = "";
                        index_number.Text = "";
                        unit.Text = "";
                        quantity.Text = "";
                        origin.Text = "";



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
                    material_name.Text = "";
                    index_number.Text = "";
                    unit.Text = "";
                    quantity.Text = "";
                    origin.Text = "";
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
