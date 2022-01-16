using System.Collections;
using System.Windows;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for cost1.xaml
    /// </summary>
    public partial class cost1 : Window
    {
        note n1;
        oknote ok;
        public cost1()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (worker_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم العامل");
                ok.ShowDialog();
            }
            else if (self_number.Text == "")
            {
                ok = new oknote("يجب إدخال الرقم الذاتي");
                ok.ShowDialog();
            }
            else if (category.Text == "")
            {
                ok = new oknote("يجب إدخال الفئة");
                ok.ShowDialog();

            }
            else if (work_done.Text == "")
            {
                ok = new oknote("يجب إدخال العمل المنجز");
                ok.ShowDialog();

            }
            else if (hours_number.Text == "")
            {
                ok = new oknote("يجب إدخال عدد الساعات");
                ok.ShowDialog();

            }
            else if (!sharedvariables.isNumber(this.self_number.Text))
            {
                ok = new oknote("الرقم الذاتي يجب أن يكون عدد حصراً ! ");
                ok.ShowDialog();
            }
            else if (!sharedvariables.isNumber(this.hours_number.Text))
            {
                ok = new oknote("عدد الساعات يجب أن يكون عدد حصراً ! ");
                ok.ShowDialog();
            }



            else
            {

                n1 = new note(" الرجاء التأكد من صحة المعلومات المدخلة ثم الضغط على زر موافق للإدخال ");
                n1.ShowDialog();

                if (sharedvariables.confirmationmessagebox == "ok")
                {


                    this.mygrid.Items.Add((object)new cost1.Add()
                    {
                        worker_name = this.worker_name.Text,
                        self_number = this.self_number.Text,
                        category = this.category.Text,
                        work_done = this.work_done.Text,
                        hours_number = this.hours_number.Text,
                        notes = this.notes.Text

                    });

                    this.worker_name.Text = "";
                    this.self_number.Text = "";
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


        public class Add
        {
            public string worker_name { get; set; }

            public string self_number { get; set; }

            public string category { get; set; }

            public string hours_number { get; set; }
            public string work_done { get; set; }
            public string notes { get; set; }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            n1 = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟");
            n1.ShowDialog();

            if (sharedvariables.confirmationmessagebox == "ok")
            {


                IEnumerable items = (IEnumerable)mygrid.Items;
                foreach (object obj1 in items)
                {
                    try
                    {

                        string str1 = (string)obj1.GetType().GetProperty("worker_name").GetValue(obj1, (object[])null);
                        object obj2 = obj1.GetType().GetProperty("self_number").GetValue(obj1, (object[])null);
                        object obj3 = obj1.GetType().GetProperty("category").GetValue(obj1, (object[])null);
                        string str2 = (string)obj1.GetType().GetProperty("work_done").GetValue(obj1, (object[])null);
                        object obj4 = obj1.GetType().GetProperty("hours_number").GetValue(obj1, (object[])null);
                        string str3 = (string)obj1.GetType().GetProperty("notes").GetValue(obj1, (object[])null);


                        DBVariables.executenq("INSERT INTO work_team (worker_name, self_number, category,work_done, hours_number,notes , project_number )VALUES ('" + str1
                            + "' , '" + obj2 +
                            "','" + obj3 +
                            "','" + str2 +
                            "','" + obj4 +
                            "', '" + str3 +
                            "' ,'" + project_number.Text + "' )");



                    }
                    catch (System.Exception)
                    {

                        ok = new oknote("حدثت مشكلة أثناء عملية الإدخال");
                        ok.ShowDialog();
                        throw;
                    }

                   
                }
                ok = new oknote("تم إدخال البيانات بنجاح");
                ok.ShowDialog();




                this.mygrid.Items.Clear();


            }
            else
            {
                sharedvariables.confirmationmessagebox = "";
                ok = new oknote("لم يتم إدخال البيانات المطلوبة !");
                ok.ShowDialog();
                this.worker_name.Text = "";
                this.self_number.Text = "";
                this.category.Text = " ";
                this.work_done.Text = "";
                this.hours_number.Text = "";
                this.work_done.Text = "";
                this.notes.Text = "";


            }

        }


        private void delete_Click(object sender, RoutedEventArgs e)
        {
            bool msg = false;

            if (msg == DBVariables.isFound(project_number.Text, "project_number", "work_team"))
            {
                ok = new oknote("لم يتم ادخال معلومات  فريق العمل لهذا المشروع مسبقاً");
                ok.ShowDialog();
            }
            else
            {
                n1 = new note("تأكيد عملية الحذف ");
                n1.ShowDialog();

                if (sharedvariables.confirmationmessagebox == "ok")
                {
                    try
                    {

                        string query = "delete from work_team where project_number=" + project_number.Text;
                        DBVariables.executenq(query);

                        ok = new oknote("تم حذف معلومات فريق العمل بنجاح");
                        ok.ShowDialog();

                    }
                    catch (System.Exception)
                    {

                        ok = new oknote("حدثت مشكلة أثناء عملية الحذف");
                        ok.ShowDialog();
                        throw;
                    }



                }
                else
                {
                    sharedvariables.confirmationmessagebox = "";
                    ok = new oknote("لم يتم حذف المعلومات  !");
                    ok.ShowDialog();
                }
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

            bool msg = false;
            if (msg == DBVariables.isFound(project_number.Text, "project_number", "work_team"))
            {
                ok = new oknote("لم يتم ادخال معلومات فريق العمل مسبقاً");
                ok.ShowDialog();
            }
            else if (this.mygrid.Items.Count == 0)
            {
                ok = new oknote("يجب ادخال البيانات أولاً");
                ok.ShowDialog();
            }
            else
            {
                n1 = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟");
                n1.ShowDialog();

                if (sharedvariables.confirmationmessagebox == "ok")
                {

                    string query = "delete from work_team where project_number=" + project_number.Text;
                    DBVariables.executenq(query);



                    IEnumerable items = (IEnumerable)mygrid.Items;
                    foreach (object obj1 in items)
                    {
                        try
                        {

                            string str1 = (string)obj1.GetType().GetProperty("worker_name").GetValue(obj1, (object[])null);
                            object obj2 = obj1.GetType().GetProperty("self_number").GetValue(obj1, (object[])null);
                            object obj3 = obj1.GetType().GetProperty("category").GetValue(obj1, (object[])null);
                            string str2 = (string)obj1.GetType().GetProperty("work_done").GetValue(obj1, (object[])null);
                            object obj4 = obj1.GetType().GetProperty("hours_number").GetValue(obj1, (object[])null);
                            string str3 = (string)obj1.GetType().GetProperty("notes").GetValue(obj1, (object[])null);


                            DBVariables.executenq("INSERT INTO work_team (worker_name, self_number, category,work_done, hours_number,notes , project_number )VALUES ('" + str1
                                + "' , '" + obj2 +
                                "','" + obj3 +
                                "','" + str2 +
                                "','" + obj4 +
                                "', '" + str3 +
                                "' ,'" + project_number.Text + "' )");

                        }
                        catch (System.Exception)
                        {

                            ok = new oknote("حدثت مشكلة أثناء عملية التعديل");
                            ok.ShowDialog();
                            throw;
                        }

                    }


                            ok = new oknote("تم تعديل البيانات بنجاح");
                            ok.ShowDialog();






                }
                else
                {
                    sharedvariables.confirmationmessagebox = "";
                    ok = new oknote("لم يتم تعديل البيانات المطلوبة !");
                    ok.ShowDialog();
                    this.worker_name.Text = "";
                    this.self_number.Text = "";
                    this.category.Text = " ";
                    this.work_done.Text = "";
                    this.hours_number.Text = "";
                    this.work_done.Text = "";
                    this.notes.Text = "";


                }


            }





        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            bool msg = false;


            costt2 c2 = new costt2();

            string nu = DBVariables.executescaler("select project_number from project_information where project_number =" + project_number.Text);
            c2.project_number.Text = nu;
            c2.ShowDialog();



        }

        private void project_name_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void mygrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void next_Click_1(object sender, RoutedEventArgs e)
        {
            costt2 c2 = new costt2();
            c2.ShowDialog();
        }
    }
}
