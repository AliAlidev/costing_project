using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        note mb;
        oknote mb1;
        MainWindow mm;
        public MainWindow()
        {
            InitializeComponent();
            double h = SystemParameters.PrimaryScreenHeight;
            double w = SystemParameters.PrimaryScreenWidth;
            Height = h;
            Width = w;
        }


       



        private void engine_card_Click(object sender, RoutedEventArgs e)
        {
            engine_card en = new engine_card();
            en.ShowDialog();
        }

        private void jhv_Click(object sender, RoutedEventArgs e)
        {
            project_card i = new project_card();
            i.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            report1 r1 = new report1();
            r1.ShowDialog();
        }

        //private void next_Click(object sender, RoutedEventArgs e)
        //{
        //    bool msg = false;
        //    if(project_number.Text == "")
        //    {
        //        mb1 = new oknote("يجب إدخال رقم المشروع !!");
        //        mb1.ShowDialog();
        //    } else if ( msg == DBVariables.isFound(project_number.Text , "project_number" , "project_information"))
        //    {
        //        mb1 = new oknote("هذا المشروع غير موجود مسبقاً !! ");
        //        mb1.ShowDialog();
        //    }
        //    else
        //    {
        //        cost1 c1 = new cost1();

        //        string num = DBVariables.executescaler("select project_number from project_information where project_number =" + project_number.Text);
        //        string name = DBVariables.executescaler("select project_name from project_information where project_number =" + project_number.Text);

        //        c1.project_number.Text = num;
        //        c1.project_name.Text = name;
        //        c1.ShowDialog();

        //    }



        //}

        //        private void add_Click(object sender, RoutedEventArgs e)
        //        {
        //            if (team_name.Text == "")
        //            {
        //                mb1 = new oknote("يجب إدخال اسم الفريق");
        //                mb1.ShowDialog();
        //            }
        //            else if (project_name.Text == "")
        //            {
        //                mb1 = new oknote("يجب إدخال اسم المشروع");
        //                mb1.ShowDialog();
        //            }
        //            else if (dept_name.Text == "")
        //            {
        //                mb1 = new oknote("يجب إدخال اسم الجهة الطالبة");
        //                mb1.ShowDialog();
        //            }

        //            else if (help_team.Text == "")
        //            {
        //                mb1 = new oknote("يجب إدخال اسم اسم الفريق المساعد ");
        //                mb1.ShowDialog();
        //            }

        //            else if (governorate.SelectedIndex == -1)
        //            {
        //                mb1 = new oknote("يجب تحديد المحافظة   ");
        //                mb1.ShowDialog();
        //            }
        //            else if (!sharedvariables.isDate(this.start_date.Text))
        //            {
        //                mb1 = new oknote("يجب إدخال قيمة صحيحة لتاريخ البدء");
        //                mb1.ShowDialog();
        //            }
        //            else if (!sharedvariables.isDate(this.finsh_date.Text))
        //            {
        //                mb1 = new oknote("يجب إدخال قيمة صحيحة لتاريخ الانتهاء");
        //                mb1.ShowDialog();
        //            }
        //            else
        //            {

        //                mb = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من صحة البيانات المدخلة قبل الموافقة )");
        //                mb.ShowDialog();



        //                if (sharedvariables.confirmationmessagebox == "ok")
        //                {

        //                    try
        //                    {
        //                        ComboBoxItem typeItem = (ComboBoxItem)governorate.SelectedItem;

        //                        DBVariables.executenq("INSERT INTO project_information (team_name , project_name , dept ,  help_team , governorate ,start_date ,  finsh_date , project_number)  VALUES('" +
        //                               team_name.Text +
        //                               "' , '" + project_name.Text +
        //                               "' , '" + dept_name.Text +
        //                              "' , '" + help_team.Text +
        //                              "' , '" + governorate.Text.ToString() +
        //                               "' , '" + start_date.Text +
        //                               "' , '" + finsh_date.Text +
        //                               "' , '" + project_number.Text + "' )");

        //                        sharedvariables.confirmationmessagebox = "";
        //                        mb1 = new oknote("تم الإدخال بنجاح");
        //                        mb1.ShowDialog();

        //                        team_name.Text = "";
        //                        project_name.Text = "";
        //                        dept_name.Text = "";
        //                        help_team.Text = "";
        //                        team_name.Text = "";
        //                        start_date.Text = "";
        //                        finsh_date.Text = "";
        //                        governorate.SelectedIndex = -1;


        //                        //cost1 c1 = new cost1();

        //                        //string nu = DBVariables.executescaler("select project_number from project_information where project_number =" + project_number.Text);
        //                        //c1.project_number.Text = nu;
        //                        //c1.ShowDialog();


        //                    }
        //                    catch (Exception)
        //                    {
        //                        mb = new note("حدثت مشكلة أثناء عملية الإدخال");
        //                        mb.ShowDialog();
        //                    }



        //                }
        //                else
        //                {

        //                    sharedvariables.confirmationmessagebox = "";
        //                    mb = new note("لم يتم إدخال البيانات ");
        //                    mb.ShowDialog();
        //                    team_name.Text = "";
        //                    project_name.Text = "";
        //                    dept_name.Text = "";
        //                    help_team.Text = "";
        //                    team_name.Text = "";
        //                    start_date.Text = "";
        //                    finsh_date.Text = "";
        //                    governorate.SelectedIndex = -1;
        //                }
        //            }






        //        }

        //        private void delete_Click(object sender, RoutedEventArgs e)
        //        {
        //            bool msg = false;
        //            if (!sharedvariables.isNumber(this.project_number.Text))
        //            {
        //                mb1 = new oknote("يجب ادخال قيمة صحيحة لرقم المشروع");
        //                mb1.ShowDialog();
        //            }
        //            else if (msg == DBVariables.isFound(project_number.Text, "project_number", "project_information")
        //)
        //            {
        //                mb1 = new oknote("هذا المشروع غير موجود مسبقاً");
        //                mb1.ShowDialog();
        //            }
        //            else
        //            {

        //                mb = new note("تأكيد عملية الحذف");
        //                mb.ShowDialog();

        //                if (sharedvariables.confirmationmessagebox == "ok")
        //                {
        //                    try
        //                    {

        //                        DBVariables.executenq("delete from project_information where project_number =" + project_number.Text);

        //                        mb1 = new oknote("تم حذف المشروع بنجاح");
        //                        mb1.ShowDialog();




        //                    }
        //                    catch (Exception)
        //                    {

        //                        mb1 = new oknote("حدثت مشكلة أثناء عملية الحذف");
        //                        mb1.ShowDialog();
        //                        throw;
        //                    }

        //                }



        //                else
        //                {
        //                    sharedvariables.confirmationmessagebox = "";
        //                    mb1 = new oknote("لم يتم حذف المشروع");
        //                    mb1.ShowDialog();
        //                    team_name.Text = "";
        //                    project_name.Text = "";
        //                    help_team.Text = "";
        //                    dept_name.Text = "";
        //                    start_date.Text = "";
        //                    finsh_date.Text = "";
        //                    governorate.SelectedIndex = -1  ;
        //                }
        //            }
        //        }

        //        private void edit_Click(object sender, RoutedEventArgs e)
        //        {
        //            bool msg = false;
        //            if (!sharedvariables.isNumber(this.project_number.Text))
        //            {
        //                mb1 = new oknote("يجب ادخال قيمة صحيحة لرقم المشروع");
        //                mb1.ShowDialog();
        //            }
        //            //else if (!sharedvariables.isDate(this.start_date.Text))
        //            //{
        //            //    mb1 = new oknote("يجب ادخال قيمة صحيحة لتاريخ البدء");
        //            //    mb1.ShowDialog();
        //            //}
        //            else if (msg == DBVariables.isFound(project_number.Text, "project_number", "project_information"))
        //            {
        //                mb1 = new oknote("هذا المشروع غير موجود مسبقاً");
        //                mb1.ShowDialog();
        //            }
        //            else
        //            {

        //                mb = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من ملئ الحقول بالبيانات المطلوبة ) ");
        //                mb.ShowDialog();

        //                if (sharedvariables.confirmationmessagebox == "ok")
        //                {
        //                    try
        //                    {

        //                        if (team_name.Text != "")
        //                        {
        //                            DBVariables.executenq("UPDATE project_information set team_name='" + team_name.Text + "' where project_number =" + project_number.Text + " )");
        //                        }

        //                        if (project_name.Text != "")
        //                        {
        //                            string query = "UPDATE project_information set project_name = '" + project_name.Text + "' where project_number = " + project_number.Text;

        //                            DBVariables.executenq(query);
        //                        }

        //                        if (dept_name.Text != "")
        //                        {
        //                            DBVariables.executenq("UPDATE project_information set dept='" + dept_name.Text + "' where project_number=" + project_number.Text + " )");
        //                        }

        //                        if (help_team.Text != "")
        //                        {
        //                            DBVariables.executenq("UPDATE project_information set help_team='" + help_team.Text + "' where project_number=" + project_number.Text + " )");
        //                        }

        //                    }
        //                    catch (Exception)
        //                    {
        //                        mb1 = new oknote("حدثت مشكلة أثناء عملية التعديل ");
        //                        mb1.ShowDialog();

        //                        throw;
        //                    }


        //                    mb1 = new oknote("انتبه .. تاريخ بداية و نهاية المشروع  ثابت و لن يتم تعديله في حال قمت بتغييره !");
        //                    mb1.ShowDialog();
        //                    mb1 = new oknote("تم تعديل البيانات بنجاح");
        //                    mb1.ShowDialog();

        //                    team_name.Text = "";
        //                    project_name.Text = "";
        //                    dept_name.Text = "";
        //                    help_team.Text = "";
        //                    start_date.Text = "";
        //                    finsh_date.Text = "";
        //                    governorate.SelectedIndex = -1;

        //                }
        //                else
        //                {
        //                    sharedvariables.confirmationmessagebox = "";
        //                    mb1 = new oknote("لم يتم تعديل البيانات ");
        //                    mb1.ShowDialog();
        //                    project_name.Text = "";
        //                    team_name.Text = "";
        //                    dept_name.Text = "";
        //                    help_team.Text = "";
        //                    start_date.Text = "";
        //                    finsh_date.Text = "";
        //                    governorate.SelectedIndex = -1;

        //                }

        //            }
        //        }


        //        private void addnumber_Click(object sender, RoutedEventArgs e)
        //        {

        //            mb1 = new oknote("انتبه .. ان رقم المشروع هو رقم تسلسلي فقط للتمييز بين المشاريع ! ");
        //            mb1.ShowDialog();

        //            string id0 = "";
        //            string res1 = null;
        //            string query = "select project_number from project_information order by id desc limit 1 ";
        //            string res = DBVariables.executescaler(query);
        //            if (res != null)
        //            {

        //                res1 = (int.Parse(res) + 1).ToString();

        //                verify:
        //                id0 = res1;
        //                query = "select count(*) from project_information where project_number= " + (int.Parse(res1));
        //                res1 = DBVariables.executescaler(query);

        //                if (int.Parse(res1) > 0)
        //                {
        //                    res1 = (int.Parse(res1) + 1).ToString();
        //                    goto verify;
        //                }
        //            }
        //            else
        //            {
        //                int i = 1;
        //                id0 = i.ToString();

        //            }

        //            project_number.Text = id0;

        //        }

        //        private void nekxt_Click(object sender, RoutedEventArgs e)
        //        {
        //            report3 r1 = new report3();
        //            r1.ShowDialog();
        //        }


    }
}
