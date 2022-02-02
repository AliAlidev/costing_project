using System;
using System.Collections;
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
    /// Interaction logic for add_active.xaml
    /// </summary>
    public partial class add_active : Window
    {
        oknote ok;
        note n;
        public add_active()
        {
            InitializeComponent();
        }
        public class Add
        {
            public string worker_name { get; set; }

            public string self_number { get; set; }

            public string category { get; set; }

            public string team_name { get; set; }

            public string active_name { get; set; }


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (team_name.Text == "")
            {
                ok = new oknote("يجب إدخال   اسم الفريق ! ");
                ok.ShowDialog();
            }
            else if (active_name.Text == "")
            {
                ok = new oknote("يجب إدخال  اسم مركز النشاط ! ");
                ok.ShowDialog();
            }
            else  if (worker_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم  العامل !");
                ok.ShowDialog();
            }
            else if (self_number.Text == "")
            {
                ok = new oknote("يجب إدخال الرقم الذاتي   !");
                ok.ShowDialog();
            }
            else if (category.Text == "")
            {
                ok = new oknote("يجب إدخال  الفئة ! ");
                ok.ShowDialog();
            }
            
          
            

            else
            {

                n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من صحة البيانات المدخلة قبل الموافقة )");
                n.ShowDialog();


                if (sharedvariables.confirmationmessagebox == "ok")
                {


                    bool res = DBVariables.isFound(active_name.Text, "active_center_name", "active_center" );
                    if (res == false)
                    {
                        string query = "insert into active_center(active_center_name, team_name) values('" + active_name.Text + "','" + team_name.Text + "' )";

                        DBVariables.executenq(query);

                        ok = new oknote("تم إضافة مركز النشاط بنجاح ");
                        ok.ShowDialog();

                        this.teamgrid.Items.Add((object)new team_work_PC.Add()
                        {
                            //work_done = this.team_name.Text,
                            //hours_number = this.active_name.Text,
                            worker_name = this.worker_name.Text,
                            self_number = this.self_number.Text,
                            category = this.category.Text,



                        });
                        this.worker_name.Text = "";
                        this.self_number.Text = "";
                        this.category.Text = "";

                    }
                    else
                    {
                       string query = "select team_name from active_center where active_center_name='" + active_name.Text + "'";
                      string team =  DBVariables.executescaler(query);

                        if (team == team_name.Text)
                        {


                        this.teamgrid.Items.Add((object)new team_work_PC.Add()
                        {
                            //work_done = this.team_name.Text,
                            //hours_number = this.active_name.Text,
                            worker_name = this.worker_name.Text,
                            self_number = this.self_number.Text,
                            category = this.category.Text,



                        });
                        this.worker_name.Text = "";
                        this.self_number.Text = "";
                        this.category.Text = "";
                        }
                        else
                        {
                            ok = new oknote("خطأ ! .. يرجى  كتابة اسم الفريق بشكل صحيح   ");
                            ok.ShowDialog();
                        }





                    }
                
                }
                else
                {
                    ok = new oknote("لم يتم إدخال المعلومات المطلوبة !");
                    ok.ShowDialog();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من صحة البيانات المدخلة قبل الموافقة )");
            n.ShowDialog();



            if (sharedvariables.confirmationmessagebox == "ok")
            {


                string query = " ";




                IEnumerable items = (IEnumerable)teamgrid.Items;

                foreach (object obj1 in items)
                {
                    try
                    {
                        string str1 = (string)obj1.GetType().GetProperty("worker_name").GetValue(obj1, (object[])null);
                        object str2 = obj1.GetType().GetProperty("self_number").GetValue(obj1, (object[])null);                    
                        string str3 = (string)obj1.GetType().GetProperty("category").GetValue(obj1, (object[])null);


                        query = "select id from active_center where active_center_name='" + active_name.Text + "' and team_name ='" + team_name.Text + "'";


                       string idnum = DBVariables.executescaler(query);

                        query = "insert into workers_names( worker_name , self_number, category  , active_center_id) values('" + str1 + "','" + str2 + "','" + str3 + "','" + idnum + "' )";

                        DBVariables.executenq(query);


                    }
                    catch (System.Exception)
                    {

                        ok = new oknote("حدثت مشكلة أثناء عملية الحفظ");
                        ok.ShowDialog();
                    }

                }

                ok = new oknote("تم إدخال البيانات بنجاح");
                ok.ShowDialog();
                worker_name.Text = "";
                self_number.Text = "";
                category.Text = "";
               


                this.teamgrid.Items.Clear();
            }
            else
            {
                sharedvariables.confirmationmessagebox = "";
                ok = new oknote("لم يتم إدخال البيانات المطلوبة !");
                ok.ShowDialog();
                team_name.Text = "";
                active_name.Text = "";
                worker_name.Text = "";
                self_number.Text = "";
                category.Text = "";
               


            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            teamgrid.Items.RemoveAt(teamgrid.SelectedIndex);
        }
    }
}
