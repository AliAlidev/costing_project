using Newtonsoft.Json;
using System;
using System.Windows;
using System.Windows.Controls;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for engine_card.xaml
    /// </summary>
    public partial class edit_engine_card : Window
    {
        oknote ok;
        note n;

        public edit_engine_card()
        {
            InitializeComponent();
            double h = SystemParameters.PrimaryScreenHeight;
            double w = SystemParameters.PrimaryScreenWidth;
            Width = w;
            Height = h;
        }

        private void add_Click_2(object sender, RoutedEventArgs e)
        {

            string[] values = new string[3];
            values[0] = card_number.Text;
            values[1] = "card_number";
            values[2] = "engine_card";
            string data = JsonConvert.SerializeObject(values);
            bool res = JsonConvert.DeserializeObject<bool>(sharedvariables.proxy.IsFound(data));

            if (!res)
            {
                ok = new oknote("هذه البطاقة غير موجودة مسبقاً !");
                ok.ShowDialog();
            }else if (!sharedvariables.isNumber(this.card_number.Text))
            {
                ok = new oknote("يجب ادخال قيمة صحيحة لرقم البطاقة !");
                ok.ShowDialog();
            }
            else if (dept.Text == "")
            {
                ok = new oknote("يجب إدخال اسم الجهة الطالبة !");
                ok.ShowDialog();
            }
            else if (sender_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم المسلم !");
                ok.ShowDialog();
            }
            else if (receiver_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم المستلم ! ");
                ok.ShowDialog();
            }
            else if (received_date.Text == "")
            {
                ok = new oknote("يجب إدخال قيمة  لتاريخ الاستلام  !    ");
                ok.ShowDialog();
            }

            else if (!sharedvariables.isDate(received_date.Text))
            {
                ok = new oknote("يجب إدخال قيمة صحيحة  لتاريخ الاستلام  !    ");
                ok.ShowDialog();
            }
            else if (sent_date.Text == "")
            {
                ok = new oknote("يجب إدخال قيمة  لتاريخ التسليم  !    ");
                ok.ShowDialog();
            }
            else if (!sharedvariables.isDate(sent_date.Text))
            {
                ok = new oknote("يجب إدخال قيمة صحيحة  لتاريخ التسليم  !    ");
                ok.ShowDialog();
            }
            else if (engine_sequence_number.Text == "")
            {
                ok = new oknote("يجب إدخال الرقم التسلسلي للمحرك   !");
                ok.ShowDialog();
            }
            else if (engine_power.Text == "")
            {
                ok = new oknote("يجب تحديد استطاعة المحرك    !");
                ok.ShowDialog();
            }
            else if (engine_rpm.Text == "")
            {
                ok = new oknote("يجب تحديد عدد دورات المحرك    ! ");
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
                        string query = "Update engine_card set dept='" + dept.Text +
                            "', sender_name = '" + sender_name.Text +
                            "', receiver_name='" + receiver_name.Text +
                            "', received_date = '" + received_date.Text +
                            "', sent_date='" + sent_date.Text +
                            "', engine_sequence_number='" + engine_sequence_number.Text +
                            "', engine_power = '" + engine_power.Text + "',engine_rpm = '" + engine_rpm.Text +
                            "' where card_number='" + card_number.Text + "'";

                        /////////////////// insert into engine table
                        response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                        if (!respo.success)
                        {
                            ok = new oknote(sharedvariables.errorMsg + respo.code);
                            ok.ShowDialog();
                            Close();
                        }

                        //////////////////// insert into project table
                        query = "update project_card set dept = '" + dept.Text + "' , start_date='" + sent_date + "' , finsh_date , project_number) values('Ali shaheen','engine maintenance','" +
                            dept.Text + "','" + sent_date.Text + "','" + received_date.Text + "','" + card_number.Text + "' )";
                        respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                        if (!respo.success)
                        {
                            ok = new oknote(sharedvariables.errorMsg + respo.code);
                            ok.ShowDialog();
                            Close();
                        }

                        sharedvariables.confirmationmessagebox = "";
                        ok = new oknote("تم الإدخال بنجاح");
                        ok.ShowDialog();

                        dept.Text = "";
                        sender_name.Text = "";
                        sent_date.Text = "";
                        received_date.Text = "";
                        receiver_name.Text = "";
                        engine_sequence_number.Text = "";
                        engine_power.Text = "";
                        engine_rpm.Text = "";



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
                    card_number.Text = "";
                    sent_date.Text = "";
                    dept.Text = "";
                    receiver_name.Text = "";
                    received_date.Text = "";
                    sender_name.Text = "";
                    engine_sequence_number.Text = "";
                    engine_power.Text = "";
                    engine_rpm.Text = "";
                }
            }





        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            string[] values = new string[3];
            values[0] = card_number.Text;
            values[1] = "card_number";
            values[2] = "engine_card";
            string data = JsonConvert.SerializeObject(values);
            bool res = JsonConvert.DeserializeObject<bool>(sharedvariables.proxy.IsFound(data));

            if (!sharedvariables.isNumber(this.card_number.Text))
            {
                ok = new oknote("يجب ادخال قيمة صحيحة لرقم البطاقة !");
                ok.ShowDialog();
            }

            else if (res)
            {
                ok = new oknote("هذه البطاقة غير موجودة مسبقاً !");
                ok.ShowDialog();
            }
            else
            {

                n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من ملئ الحقول بالبيانات المطلوبة ) ");
                n.ShowDialog();

                if (sharedvariables.confirmationmessagebox == "ok")
                {

                    string query;
                    if (dept.Text != "")
                    {
                        query = "UPDATE engine_card set dept='" + dept.Text + "' where card_number =" + card_number.Text;

                        response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                        if (!respo.success)
                        {
                            ok = new oknote(sharedvariables.errorMsg + respo.code);
                            ok.ShowDialog();
                        }
                    }

                    if (sender_name.Text != "")
                    {
                        query = "UPDATE engine_card set sender_name = '" + sender_name.Text + "' where card_number = " + card_number.Text;

                        response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                        if (!respo.success)
                        {
                            ok = new oknote(sharedvariables.errorMsg + respo.code);
                            ok.ShowDialog();
                        }
                    }

                    if (receiver_name.Text != "")
                    {
                        query = "UPDATE engine_card set receiver_name = '" + receiver_name.Text + "' where card_number = " + card_number.Text;
                        response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                        if (!respo.success)
                        {
                            ok = new oknote(sharedvariables.errorMsg + respo.code);
                            ok.ShowDialog();
                            Close();
                        }
                    }


                    ok = new oknote("انتبه .. تاريخ التسليم و الاستلام  ثابت و لن يتم تعديله في حال قمت بتغييره !");
                    ok.ShowDialog();
                    ok = new oknote("تم تعديل البيانات بنجاح");
                    ok.ShowDialog();

                    dept.Text = "";
                    sender_name.Text = "";
                    receiver_name.Text = "";
                    sent_date.Text = "";
                    received_date.Text = "";
                    engine_sequence_number.Text = "";
                    engine_power.Text = "";
                    engine_rpm.Text = "";
                }
                else
                {
                    sharedvariables.confirmationmessagebox = "";
                    ok = new oknote("لم يتم تعديل البيانات ");
                    ok.ShowDialog();

                    dept.Text = "";
                    sender_name.Text = "";
                    receiver_name.Text = "";
                    sent_date.Text = "";
                    received_date.Text = "";
                    engine_sequence_number.Text = "";
                    engine_power.Text = "";
                    engine_rpm.Text = "";
                }

            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            string[] values = new string[3];
            values[0] = card_number.Text;
            values[1] = "card_number";
            values[2] = "engine_card";
            string data = JsonConvert.SerializeObject(values);
            bool res = JsonConvert.DeserializeObject<bool>(sharedvariables.proxy.IsFound(data));

            if (!sharedvariables.isNumber(this.card_number.Text))
            {
                ok = new oknote("يجب ادخال قيمة صحيحة لرقم المشروع");
                ok.ShowDialog();
            }
            else if (res)
            {
                ok = new oknote("هذه البطاقة غير موجودة مسبقاً ! ");
                ok.ShowDialog();
            }
            else
            {

                n = new note("تأكيد عملية الحذف");
                n.ShowDialog();

                if (sharedvariables.confirmationmessagebox == "ok")
                {
                    string query = "delete from engine_card where card_number =" + card_number.Text;
                    response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                    if (!respo.success)
                    {
                        ok = new oknote(sharedvariables.errorMsg + respo.code);
                        ok.ShowDialog();
                        Close();
                    }
                    else
                    {
                        ok = new oknote("تم حذف المشروع بنجاح");
                        ok.ShowDialog();
                    }
                }
                else
                {
                    sharedvariables.confirmationmessagebox = "";
                    ok = new oknote("لم يتم حذف المشروع");
                    ok.ShowDialog();
                    card_number.Text = "";
                    dept.Text = "";
                    sent_date.Text = "";
                    received_date.Text = "";
                    sender_name.Text = "";
                    receiver_name.Text = "";
                    engine_sequence_number.Text = "";
                    engine_power.Text = "";
                    engine_rpm.Text = "";
                }
            }
        }

        private void add_card_number_Click(object sender, RoutedEventArgs e)
        {
            ok = new oknote("انتبه .. ان رقم البطاقة هو رقم تسلسلي فقط للتمييز بين البطاقات ! ");
            ok.ShowDialog();

            string id0 = "";
            string res1 = null;
            string query = "select card_number from engine_card order by id desc limit 1 ";
            string res = JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query));
            if (res != null)
            {

                res1 = (int.Parse(res) + 1).ToString();

            verify:
                id0 = res1;
                query = "select count(*) from engine_card where card_number= " + (int.Parse(res1));
                res1 = JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query));

                if (int.Parse(res1) > 0)
                {
                    res1 = (int.Parse(res1) + 1).ToString();
                    goto verify;
                }
            }
            else
            {
                int i = 1;
                id0 = i.ToString();

            }

            card_number.Text = id0;

        }

        private void engine_data_Click(object sender, RoutedEventArgs e)
        {
            string[] values = new string[3];
            values[0] = card_number.Text;
            values[1] = "card_number";
            values[2] = "engine_card";
            string data = JsonConvert.SerializeObject(values);
            bool res = JsonConvert.DeserializeObject<bool>(sharedvariables.proxy.IsFound(data));

            if (card_number.Text == "")
            {
                ok = new oknote("يجب إدخال رقم البطاقة أولاً ! ");
                ok.ShowDialog();
            }
            else if (res)
            {
                engine_info enginfo = new engine_info();
                enginfo.card_number1.Text = card_number.Text;
                enginfo.ShowDialog();
            }
            else
            {
                ok = new oknote("هذه البطاقة غير موجودة مسبقاً ! .. يرجى إدخال رقم بطاقة صحيح !");
                ok.ShowDialog();

            }




        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add_engine_info_Click(object sender, RoutedEventArgs e)
        {

            engine_info en = new engine_info();
            en.card_number1.Text = card_number.Text;
            en.ShowDialog();
        }

        private void receiver_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void result_Click(object sender, RoutedEventArgs e)
        {
            results r1 = new results();
            r1.card_number.Text = card_number.Text;
            r1.ShowDialog();
        }
    }
}
