using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
﻿using Newtonsoft.Json;
using System;
using System.Windows;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for project_card.xaml
    /// </summary>
    public partial class project_card : Window
    {

        oknote ok;
        note n;

        public project_card()
        {
            InitializeComponent();

            double h = SystemParameters.PrimaryScreenHeight;
            double w = SystemParameters.PrimaryScreenWidth;

            Width = w;
            Height = h;

        }

        private void add_card_number_Click(object sender, RoutedEventArgs e)
        {


            ok = new oknote("انتبه .. ان رقم المشروع هو رقم تسلسلي فقط للتمييز بين المشاريع ! ");
            ok.ShowDialog();

            string id0 = "";
            string res1 = null;
            string re = " ";

            string query = "select project_number from project_card order by id desc limit 1 ";
            string res = JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query));

            if (res != null)
            {
                id0 = (int.Parse(res) + 1).ToString();

                //query = "select work_done  from project_card where project_number= " + (int.Parse(res));
                //re = JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query));
                //string[] values = new string[3];
                //values[0] = res;
                //values[1] = "project_number";
                //values[2] = "material_used";
                //string data = JsonConvert.SerializeObject(values);
                //bool re1 = JsonConvert.DeserializeObject<bool>(sharedvariables.proxy.IsFound(data));
                //if (re == "" || re1 == false)
                //{
                //    id0 = res.ToString();
                //    card_numberr.Text = id0;
                //    query = "select project_name from project_card where project_number= " + card_numberr.Text;
                //    re = JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query));

                //    ok = new oknote("البطاقة التي تحمل الرقم " + "   " + card_numberr.Text + "   " + " و الاسم " + "( " + re + ") " + "    " + "يجب  التأكد من إضافة توصيف نتائج العمل الخاص بها و إضافة المواد المستخدمة .. بعد ذلك يمكنك إضافة بطاقة مشروع جديدة ");
                //    ok.ShowDialog();

                //    query = "select project_name  from project_card where project_number= " + card_numberr.Text;
                //    re = JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query));
                //    project_name.Text = re.ToString();

                //    query = "select active_center_name  from project_card where project_number= " + card_numberr.Text;
                //    re = JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query));
                //    active_name.Text = re.ToString();

                //    project_name.Focusable = false;
                //    project_name.IsReadOnly = true;
                //    dept_name.Focusable = false;
                //    dept_name.IsReadOnly = true;
                //    help_team.Focusable = false;
                //    help_team.IsReadOnly = true;
                //    finsh_date.Focusable = false;
                //    //finsh_date.IsReadOnly = true;
                //    start_date.Focusable = false;
                //    //start_date.IsReadOnly = true;
                //    active_name.Focusable = false;
                //    active_name.IsReadOnly = true;


                //    goto ENDD;
                //}
                //else
                //{

                //    res1 = (int.Parse(res) + 1).ToString();

                //verify:
                //    id0 = res1;
                //    query = "select count(*) from project_card where project_number= " + (int.Parse(res1));
                //    res1 = JsonConvert.DeserializeObject<string>(sharedvariables.proxy.ExecuteScaler(query));

                //    if (int.Parse(res1) > 0)
                //    {
                //        res1 = (int.Parse(res1) + 1).ToString();
                //        goto verify;
                //    }
                //}
            }
            else
            {
                int i = 1;
                id0 = i.ToString();

            }

            card_numberr.Text = id0;

            //project_name.Focusable = true;
            //project_name.IsReadOnly = false;
            //dept_name.Focusable = true;
            //dept_name.IsReadOnly = false;
            //help_team.Focusable = true;
            //help_team.IsReadOnly = false;
            //finsh_date.Focusable = true;
            ////finsh_date.IsReadOnly = false;
            //start_date.Focusable = true;
            ////start_date.IsReadOnly = false;
            //active_name.Focusable = true;
            //active_name.IsReadOnly = false;

            //active_name.Text = "";
            //project_name.Text = "";



        ENDD:;

        }




        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add_Click_2(object sender, RoutedEventArgs e)
        {
            string[] values = new string[3];
            values[0] = card_numberr.Text;
            values[1] = "project_number";
            values[2] = "project_card";
            string data = JsonConvert.SerializeObject(values);
            bool res = JsonConvert.DeserializeObject<bool>(sharedvariables.proxy.IsFound(data));

            if (res == true)
            {
                ok = new oknote("تم إدخال بيانات هذه البطاقة مسبقاً !");
                ok.ShowDialog();
            }
            else
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
                            string query = "insert into project_card( active_center_name, project_name , dept, help_team , governorate , start_date , finsh_date , project_number) values('" + project_name.Text + "','" + dept_name.Text + "','" + help_team.Text + "','" + governorate.Text + "','" + start_date.Text + "','" + finsh_date.Text + "','" + card_numberr.Text + "' )";
                            response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query));
                            if (!respo.success)
                            {
                                ok = new oknote(sharedvariables.errorMsg + respo.code);
                                ok.ShowDialog();
                                Close();
                            }
                            sharedvariables.confirmationmessagebox = "";
                            ok = new oknote("تم الإدخال بنجاح");
                            ok.ShowDialog();

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
        }

        private void abrogation_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}