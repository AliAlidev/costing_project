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

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}
        public class Add
        {
            public string worker_name { get; set; }

            public string index_number { get; set; }

            public string category { get; set; }

            public string work_done { get; set; }

            public string hours_number { get; set; }

            public string notes { get; set; }

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
            //else if (notes.Text == "")
            //{
            //    ok = new oknote("يجب إدخال   ملاحظات ! ");
            //    ok.ShowDialog();
            //}


            else
            {

                n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من صحة البيانات المدخلة قبل الموافقة )");
                n.ShowDialog();



                //if (sharedvariables.confirmationmessagebox == "ok")
                //{

                //        try
                //        {

                //            DBVariables.executenq("INSERT INTO engine_card (worker_name , index_number , category ,  work_done , hours_number  )  VALUES('" +
                //                   worker_name.Text +
                //                   "' , '" + index_number.Text +
                //                  "' , '" + category.Text +
                //                  "' , '" + work_done.Text +
                //                   "' , '" + hours_number.Text + "' ) ");

                //            sharedvariables.confirmationmessagebox = "";
                //            ok = new oknote("تم الإدخال بنجاح");
                //            ok.ShowDialog();

                //            worker_name.Text = "";
                //            index_number.Text = "";
                //            category.Text = "";
                //            work_done.Text = "";
                //            hours_number.Text = "";



                //        }
                //        catch (Exception)
                //        {
                //            ok = new oknote("حدثت مشكلة أثناء عملية الإدخال");
                //            ok.ShowDialog();
                //        }



                //    }
                //    else
                //    {

                //        sharedvariables.confirmationmessagebox = "";
                //        ok = new oknote("لم يتم إدخال البيانات ");
                //        ok.ShowDialog();
                //        worker_name.Text = "";
                //        index_number.Text = "";
                //        category.Text = "";
                //        work_done.Text = "";
                //        hours_number.Text = "";
                //    }
                //}
                if (sharedvariables.confirmationmessagebox == "ok")
                {


                    this.teamgrid.Items.Add((object)new team_work_PC.Add()
                    {
                        worker_name = this.worker_name.Text,
                        index_number = this.index_number.Text,
                        category = this.category.Text,
                        work_done = this.work_done.Text,
                        hours_number = this.hours_number.Text,
                        notes = this.notes.Text,


                    });

                    this.worker_name.Text = "";
                    this.index_number.Text = "";
                    this.category.Text = "";
                    this.work_done.Text = "";
                    this.hours_number.Text = "";
                    this.notes.Text = "";




                }
                else
                {
                    ok = new oknote("لم يتم إدخال المعلومات المطلوبة !");
                    ok.ShowDialog();
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    }
