using System;
using System.Windows;
using System.Windows.Controls;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for modulation.xaml
    /// </summary>
    public partial class modulation : Window
    {
        private oknote ok;
        private note n;
        private object total_prices;
        private listprojects _listProjects;

        public modulation(listprojects lp)
        {
            InitializeComponent();
            oknote ok;
            note n;
            _listProjects = lp;
        }
        public class Add
        {
            public string material_name { get; set; }

            public string index_number { get; set; }

            public string unit { get; set; }

            public string quantity { get; set; }

            public string unit_price { get; set; }
            public string total_price { get; set; }

            public string notes { get; set; }

        }

        private void close_Click(object sender, RoutedEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void abrogation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void add_Click_1(object sender, RoutedEventArgs e)
        {

            if (project_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم المشروع !");
                ok.ShowDialog();
            }
            else if (dept_name.Text == "")
            {
                ok = new oknote("يجب إدخال  اسم الجهة الطالبة ! ");
                ok.ShowDialog();
            }
            else if (help_team.Text == "")
            {
                ok = new oknote("يجب إدخال الفرق المساعدة   !    ");
                ok.ShowDialog();
            }
            else if (governorate.Text == "")
            {
                ok = new oknote("يجب إدخال   اسم المحافظة  !    ");
                ok.ShowDialog();
            }
            else if (start_date.Text == "")
            {
                ok = new oknote("يجب إدخال    تاريخ البدء  !    ");
                ok.ShowDialog();
            }
            else if (!sharedvariables.isDate(start_date.Text))
            {
                ok = new oknote("يجب إدخال قيمة صحيحة  لتاريخ البدء  !    ");
                ok.ShowDialog();
            }
            else if (finsh_date.Text == "")
            {
                ok = new oknote("يجب إدخال    تاريخ الانتهاء  !    ");
                ok.ShowDialog();
            }
            else if (!sharedvariables.isDate(finsh_date.Text))
            {
                ok = new oknote("يجب إدخال قيمة صحيحة  لتاريخ الانتهاء  !    ");
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
                        int projectNum = int.Parse(card_number.Text);
                        //////////////
                        string query = "delete from material_used where project_number=" + projectNum;
                        sharedvariables.proxy.ExecuteNQ(query);
                        //////////////
                        query = "update project_card set";
                        if (project_name.Text != null)
                            query = query + " project_name = '" + project_name.Text + "'";
                        if (dept_name.Text != null)
                            query = query + ", dept='" + dept_name.Text + "'";
                        if (help_team.Text != null)
                            query = query + ", help_team='" + help_team.Text + "'";
                        if (governorate.Text != null)
                            query = query + ", governorate='" + governorate.Text + "'";
                        if (start_date.Text != null)
                            query = query + ", start_date='" + start_date.Text + "'";
                        if (finsh_date.Text != null)
                            query = query + ", finsh_date='" + finsh_date.Text + "'";
                        query = query + " where project_number=" + projectNum;

                        sharedvariables.proxy.ExecuteNQ(query);

                        sharedvariables.confirmationmessagebox = "";
                        ok = new oknote("تم التعديل بنجاح");
                        ok.ShowDialog();

                        //project_number.Text = "";
                        project_name.Text = "";
                        dept_name.Text = "";
                        help_team.Text = "";
                        governorate.Text = "";
                        start_date.Text = "";
                        finsh_date.Text = "";
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
                    //project_number.Text = "";
                    project_name.Text = "";
                    dept_name.Text = "";
                    help_team.Text = "";
                    governorate.Text = "";
                    start_date.Text = "";
                    finsh_date.Text = "";
                }
            }

        }

        private void abrogation_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void close_Click_1(object sender, RoutedEventArgs e)
        {

        }



        private void addd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void teamgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            material_used_PC mupc = new material_used_PC(int.Parse(card_number.Text), _listProjects) ;
            mupc.card_number.Text = card_number.Text;
            mupc.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            works_result wr = new works_result(int.Parse(card_number.Text), _listProjects);
            wr.card_number.Text = card_number.Text;
            wr.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            mainactivecenter mac = new mainactivecenter(int.Parse(card_number.Text), _listProjects);
            mac.card_number.Text = card_number.Text;
            mac.ShowDialog();
        }
    }
}
