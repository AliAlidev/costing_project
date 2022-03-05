using Newtonsoft.Json;
using System.Collections;
using System.Windows;

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
                    ok = new oknote("لم تتم إضافة بيانات العامل  !");
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
                    string str1 = (string)obj1.GetType().GetProperty("worker_name").GetValue(obj1, (object[])null);
                    object str2 = obj1.GetType().GetProperty("self_number").GetValue(obj1, (object[])null);
                    string str3 = (string)obj1.GetType().GetProperty("category").GetValue(obj1, (object[])null);


                    query = "select id from active_center where active_center_name='" + active_name.Text + "' and team_name ='" + team_name.Text + "'";


                    string idnum = DBVariables.executescaler(query);

                    query = "insert into workers_names( worker_name , self_number, category  , active_center_id) values('" + str1 + "','" + str2 + "','" + str3 + "','" + idnum + "' )";

                    response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                    if (!respo.success)
                    {
                        ok = new oknote(sharedvariables.errorMsg + respo.code);
                        ok.ShowDialog();
                        Close();
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            string query = "select count(*) from active_center where active_center_name='" + active_name.Text + "' and team_name ='" + team_name.Text + "'";
            string count = DBVariables.executescaler(query);
            if (int.Parse(count) > 0)
            {

                ok = new oknote("  مركز النشاط هذا موجود بالفعل .. يمكنك  إضافة العمال   ");
                ok.ShowDialog();



            }
            else
            {
                bool res = DBVariables.isFound(active_name.Text, "active_center_name", "active_center");
                bool res1 = DBVariables.isFound(team_name.Text, "team_name", "active_center");

                if (res == false && res1 == false)
                {

                    query = "insert into active_center(active_center_name, team_name) values('" + active_name.Text + "','" + team_name.Text + "' )";

                    response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                    if (!respo.success)
                    {
                        ok = new oknote(sharedvariables.errorMsg + respo.code);
                        ok.ShowDialog();
                        Close();
                    }
                    else
                    {
                        ok = new oknote("تم إضافة مركز النشاط و اسم الفريق التابع له بنجاح .. يمكنك متابعة عملية إضافة العمال  ");
                        ok.ShowDialog();
                    }
                }
                else
                {
                    if (res == true)
                    {
                        query = "select team_name from active_center where avtive_center_name='" + active_name.Text + "'";
                        string team = DBVariables.executescaler(query);
                        if (team == team_name.Text)
                        {
                            ok = new oknote("  مركز النشاط هذا موجود بالفعل .. يمكنك متابعة عملية إضافة العمال   ");
                            ok.ShowDialog();


                        }
                        else
                        {
                            ok = new oknote("خطأ ! .. مركز النشاط ها موجود بالفعل يرجى  كتابة اسم الفريق الخاص به بشكل صحيح   ");
                            ok.ShowDialog();
                        }

                    }
                    else if (res1 == true)
                    {
                        res = DBVariables.isFound(team_name.Text, "team_name", "active_center");
                        if (res == true)
                        {
                            query = "select active_center_name from active_center where team_name='" + team_name.Text + "'";
                            string center = DBVariables.executescaler(query);
                            if (center == active_name.Text)
                            {
                                ok = new oknote("  مركز النشاط هذا موجود بالفعل .. يمكنك متابعة عملية إضافة العمال   ");
                                ok.ShowDialog();


                            }
                            else
                            {
                                ok = new oknote("خطأ ! ..الفريق هذا موجود بالفعل  يرجى  كتابة اسم مركز النشاط الخاص به بشكل صحيح   ");
                                ok.ShowDialog();
                            }
                        }

                    }
                }

            }
        }
    }
}
