using Newtonsoft.Json;
using System.Data;
using System.Windows;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for works_result.xaml
    /// </summary>
    public partial class works_result : Window
    {
        public listprojects mainWindows { get; private set; }
        oknote ok;
        note n;
        public works_result(listprojects mw = null)
        {
            InitializeComponent();
            mainWindows = mw;
        }


        private void add_Click(object sender, RoutedEventArgs e)
        {
            string q = "", q1 = "", q2 = "";

            string query = "select work_done from project_card where project_number= " + card_number.Text;
            q = JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query));

            query = "select hours from project_card where project_number= " + card_number.Text;
            q1 = JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query));

            query = "select notes from project_card where project_number= " + card_number.Text;
            q2 = JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query));


            //if (q == "" || q1 == "" || q2 == "")
            //{

            //    if (result_work.Text == "")
            //    {
            //        ok = new oknote("يجب إدخال توصيف العمل   !    ");
            //        ok.ShowDialog();
            //    }
            //    else if (hour_work.Text == "")
            //    {
            //        ok = new oknote("يجب إدخال عدد ساعات العمل      !    ");
            //        ok.ShowDialog();
            //    }
            //    else if (!sharedvariables.isNumber(hour_work.Text))
            //    {
            //        ok = new oknote("  عدد ساعات العمل يجب أن يكون رقم حصراً ! ");
            //        ok.ShowDialog();
            //    }
            //    else if (notes.Text == "")
            //    {
            //        ok = new oknote("يجب إدخال الملاحظات    !    ");
            //        ok.ShowDialog();
            //    }

            //    else
            //    {

            //        n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من صحة البيانات المدخلة قبل الموافقة )");
            //        n.ShowDialog();
            //        if (sharedvariables.confirmationmessagebox == "ok")
            //        {

            //            query = "update project_card set work_done='" + result_work.Text + "', hours='" + hour_work.Text + "', notes ='" + notes.Text + "' where project_number  =" + card_number.Text;
            //            response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
            //            if (!respo.success)
            //            {
            //                ok = new oknote(sharedvariables.errorMsg + respo.code);
            //                ok.ShowDialog();
            //                Close();
            //            }

            //            sharedvariables.confirmationmessagebox = "";
            //            ok = new oknote("تم الإدخال بنجاح");
            //            ok.ShowDialog();

            //            //project_number.Text = "";
            //            result_work.Text = "";
            //            hour_work.Text = "";
            //            notes.Text = "";

            //            ////////////// list projects
            //            DataSet ds = new DataSet();
            //            query = "select active_center_name, project_name, dept, help_team, governorate, start_date, finsh_date, project_number from project_card";
            //            ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
            //            ds.Tables[0].Columns[0].ColumnName = "اسم مركز النشاط";
            //            ds.Tables[0].Columns[1].ColumnName = "اسم المشروع";
            //            ds.Tables[0].Columns[2].ColumnName = "الجهة الطالبة";
            //            ds.Tables[0].Columns[3].ColumnName = "الفرق المساعدة";
            //            ds.Tables[0].Columns[4].ColumnName = "لمحافظة";
            //            ds.Tables[0].Columns[5].ColumnName = "تاريخ البدء";
            //            ds.Tables[0].Columns[6].ColumnName = "تاريخ الانتهاء";
            //            ds.Tables[0].Columns[7].ColumnName = "رقم المشروع";
            //            mainWindows.listproject.ItemsSource = ds.Tables[0].DefaultView;

            //            ////////////
            //            Close();
            //        }
            //        else
            //        {
            //            sharedvariables.confirmationmessagebox = "";
            //            ok = new oknote("لم يتم إدخال البيانات ");
            //            ok.ShowDialog();
            //            //project_number.Text = "";
            //            result_work.Text = "";
            //            hour_work.Text = "";
            //            notes.Text = "";

            //        }
            //    }
            //}
            //else
            //{
            //    ok = new oknote("تم إدخال بيانات هذه البطاقة مسبقاً .. تأكد من إضافة المواد المستخدمة !");
            //    ok.ShowDialog();
            //}
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
