using Newtonsoft.Json;
using System.Data;
using System.Windows;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for show_active_center.xaml
    /// </summary>
    public partial class show_engines : Window
    {
        public show_engines()
        {
            InitializeComponent();

            /////////////// fill data
            string query = "select card_number, dept, sender_name, receiver_name, received_date, sent_date, results, engine_sequence_number, engine_power, engine_rpm from engine_card";
            DataSet ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns[0].ColumnName = "رقم البطاقة";
                ds.Tables[0].Columns[1].ColumnName = "الجهة الطالبة";
                ds.Tables[0].Columns[2].ColumnName = "اسم المرسل";
                ds.Tables[0].Columns[3].ColumnName = "اسم المستلم";
                ds.Tables[0].Columns[4].ColumnName = "تاريخ الاستلام";
                ds.Tables[0].Columns[5].ColumnName = "تاريخ الارسال";
                ds.Tables[0].Columns[6].ColumnName = "النتائج";
                ds.Tables[0].Columns[7].ColumnName = "الرقم التسلسلي للمحرك";
                ds.Tables[0].Columns[8].ColumnName = "استطاعة المحرك";
                ds.Tables[0].Columns[9].ColumnName = "سرعة دوران المحرك";
                listrequestgrid.ItemsSource = ds.Tables[0].DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listrequestgrid.SelectedItem.GetType().Name == "DataRowView")
            {
                DataRowView dr = (DataRowView)listrequestgrid.SelectedItem;
                int cardNumber = 0;
                int.TryParse(dr.Row.ItemArray[0].ToString(), out cardNumber);
                edit_engine_card eec = new edit_engine_card();
                eec.card_number.Text = dr.Row.ItemArray[0].ToString();
                eec.dept.Text = dr.Row.ItemArray[1].ToString();
                eec.sender_name.Text = dr.Row.ItemArray[2].ToString();
                eec.receiver_name.Text = dr.Row.ItemArray[3].ToString();
                eec.received_date.Text = dr.Row.ItemArray[4].ToString();
                eec.sent_date.Text = dr.Row.ItemArray[5].ToString();
                eec.engine_sequence_number.Text = dr.Row.ItemArray[6].ToString();
                eec.engine_power.Text = dr.Row.ItemArray[7].ToString();
                eec.engine_rpm.Text = dr.Row.ItemArray[8].ToString();
                eec.ShowDialog();
            }
        }
    }
}
