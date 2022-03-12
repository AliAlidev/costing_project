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
        public works_result(int projectNumber,listprojects mw = null)
        {
            InitializeComponent();
            mainWindows = mw;

            /////////////////////// fill active centers
            DataSet ds = sharedvariables.getActiveCentersList(projectNumber);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                active_name.Items.Add(item.ItemArray[0]);
            }
        }


        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (resultafter.Text == "")
            {
                ok = new oknote("يجب إدخال توصيف العمل   !    ");
                ok.ShowDialog();
                goto end1;
            }
            else if (hour_work.Text == "")
            {
                ok = new oknote("يجب إدخال عدد ساعات العمل      !    ");
                ok.ShowDialog();
                goto end1;
            }
            else if (!sharedvariables.isNumber(hour_work.Text))
            {
                ok = new oknote("  عدد ساعات العمل يجب أن يكون رقم حصراً ! ");
                ok.ShowDialog();
                goto end1;
            }
            else if (notes.Text == "")
            {
                ok = new oknote("يجب إدخال الملاحظات    !    ");
                ok.ShowDialog();
                goto end1;
            }

            n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من صحة البيانات المدخلة قبل الموافقة )");
            n.ShowDialog();
            if (sharedvariables.confirmationmessagebox == "ok")
            {
                ////////////////// remove old
                string query = "delete from project_results where project_number='"+ card_number.Text + "' and active_center_name='"+active_name.Text+"'";
                response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                if (!respo.success)
                {
                    ok = new oknote(sharedvariables.errorMsg + respo.code);
                    ok.ShowDialog();
                }

                ////////////////// add new
                query = "insert into project_results(project_number, work_done, hours, notes, active_center_name) values('" + card_number.Text + "','"+ resultafter.Text + "','"+ hour_work.Text + "','"+ notes.Text + "','"+active_name.Text+"')";
                respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                if (!respo.success)
                {
                    ok = new oknote(sharedvariables.errorMsg + respo.code);
                    ok.ShowDialog();
                }

                ////////////// list projects
                sharedvariables.listPrpjects(mainWindows);

                Close();
            }
        end1:;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
