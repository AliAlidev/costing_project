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
    /// Interaction logic for revise.xaml
    /// </summary>
    public partial class revise : Window
    {
        oknote ok;
        note n;
        public int getRowId = 0;
        public revise()
        {
            InitializeComponent();
            //getRowId = int.Parse(DBVariables.executescaler("select id from active_center where active_center_name = '" + active_name.Text + "' and team_name= '" + team_name.Text + "'"));
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
            else if (worker_name.Text == "")
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


                    this.teamgrid.Items.Add((object)new team_work_PC.Add()
                    {
                        worker_name = this.worker_name.Text,
                        self_number = this.self_number.Text,
                        category = this.category.Text
                    });
                    this.worker_name.Text = "";
                    this.self_number.Text = "";
                    this.category.Text = "";
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            teamgrid.Items.RemoveAt(teamgrid.SelectedIndex);

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void add_Click_1(object sender, RoutedEventArgs e)
        {
            n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من صحة البيانات المدخلة قبل الموافقة )");
            n.ShowDialog();



            if (sharedvariables.confirmationmessagebox == "ok")
            {

                IEnumerable items = (IEnumerable)teamgrid.Items;
  
                DBVariables.executenq("delete from workers_names where active_center_id=" + getRowId);

                foreach (object obj1 in items)
                {
                    try
                    {

                        ///////// update workers_names table
                        string str3 = (string)obj1.GetType().GetProperty("worker_name").GetValue(obj1, (object[])null);
                        object str4 = obj1.GetType().GetProperty("self_number").GetValue(obj1, (object[])null);
                        string str5 = (string)obj1.GetType().GetProperty("category").GetValue(obj1, (object[])null);

                        string query = "insert into workers_names(worker_name, self_number, category, active_center_id ) values('" + str3 + "','" + str4 + "','" + str5 + "', "+ getRowId + " )";

                        DBVariables.executenq(query);
                    }
                    catch (System.Exception)
                    {

                        ok = new oknote("حدثت مشكلة أثناء عملية الحفظ");
                        ok.ShowDialog();
                    }

                }
                //////// update active center table
                DBVariables.executenq("update active_center set active_center_name='" + active_name.Text + "', team_name='" + team_name.Text + "' where id=" + getRowId);

                getRowId = int.Parse(DBVariables.executescaler("select id from active_center where active_center_name = '" + active_name.Text + "' and team_name= '" + team_name.Text + "'"));

                ok = new oknote("تم إدخال البيانات بنجاح");
                ok.ShowDialog();
                team_name.Text = "";
                active_name.Text = "";
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

        private void add1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
