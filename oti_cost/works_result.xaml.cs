using System;
using System.Windows;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for works_result.xaml
    /// </summary>
    public partial class works_result : Window
    {
        oknote ok;
        note n;
        public works_result()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            string q = "", q1 = "", q2 = "";

            string query = "select work_done from project_card where project_number= " + card_number.Text;
            q = DBVariables.executescaler(query);

            query = "select hours from project_card where project_number= " + card_number.Text;
            q1 = DBVariables.executescaler(query);

            query = "select notes from project_card where project_number= " + card_number.Text;
            q2 = DBVariables.executescaler(query);


            if (q == "" || q1 == "" || q2 == "")
            {

                if (result_work.Text == "")
                {
                    ok = new oknote("يجب إدخال توصيف العمل   !    ");
                    ok.ShowDialog();
                }
                else if (hour_work.Text == "")
                {
                    ok = new oknote("يجب إدخال عدد ساعات العمل      !    ");
                    ok.ShowDialog();
                }
                else if (!sharedvariables.isNumber(hour_work.Text))
                {
                    ok = new oknote("  عدد ساعات العمل يجب أن يكون رقم حصراً ! ");
                    ok.ShowDialog();
                }
                else if (notes.Text == "")
                {
                    ok = new oknote("يجب إدخال الملاحظات    !    ");
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


                            query = "update project_card set work_done='" + result_work.Text + "', hours='" + hour_work.Text + "', notes ='" + notes.Text + "' where project_number  =" + card_number.Text;

                            DBVariables.executenq(query);




                            sharedvariables.confirmationmessagebox = "";
                            ok = new oknote("تم الإدخال بنجاح");
                            ok.ShowDialog();

                            //project_number.Text = "";
                            result_work.Text = "";
                            hour_work.Text = "";
                            notes.Text = "";




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
                        result_work.Text = "";
                        hour_work.Text = "";
                        notes.Text = "";

                    }
                }
            }
            else
            {
                ok = new oknote("تم إدخال بيانات هذه البطاقة مسبقاً .. تأكد من إضافة المواد المستخدمة !");
                ok.ShowDialog();
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
