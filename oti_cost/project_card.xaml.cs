﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            string query = "select project_number from project_card order by id desc limit 1 ";
            string res = DBVariables.executescaler(query);
            if (res != null)
            {

                res1 = (int.Parse(res) + 1).ToString();

                verify:
                id0 = res1;
                query = "select count(*) from project_card where project_number= " + (int.Parse(res1));
                res1 = DBVariables.executescaler(query);

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

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
           material_used_PC c1 = new material_used_PC();
            c1.ShowDialog();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void team_Click(object sender, RoutedEventArgs e)
        {
            team_work_PC t = new team_work_PC();
            t.ShowDialog();
        }

        private void add_Click_2(object sender, RoutedEventArgs e)
        {
         //   if (DBVariables.isFound(project_number.Text, "card_number", "engine_card"))
         //   {
         //       ok = new oknote("يجب ادخال رقم المشروع  !");
         //       ok.ShowDialog();
         //   }
         //   else
         //if (!sharedvariables.isNumber(this.project_number.Text))
         //   {
         //       ok = new oknote("يجب ادخال قيمة صحيحة لرقم المشروع !");
         //       ok.ShowDialog();
         //   }
         //   else
    
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
            else if (active_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم مركز النشاط !");
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

                       string query = "insert into project_card( project_name, dept, help_team , governorate , start_date , finsh_date , project_number,active_name,) values('" + active_name.Text + "','" + project_name.Text + "','" + dept_name.Text + "','" + help_team.Text+ "','" + governorate.Text + "','" + start_date.Text + "','" + finsh_date.Text + "','" + card_number.Text+ "' )";

                        DBVariables.executenq(query);


                        sharedvariables.confirmationmessagebox = "";
                        ok = new oknote("تم الإدخال بنجاح");
                        ok.ShowDialog();

                        //project_number.Text = "";
                        project_name.Text = "";
                        dept_name.Text = "";
                        help_team.Text = "";
                        governorate.Text = "";
                        start_date.Text = "";
                        finsh_date.Text = "";
                        active_name.Text = "";


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
                    active_name.Text = "";

                }
            }
        }

        //private void abrogation_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();

        //}

        private void addmaterial_Click(object sender, RoutedEventArgs e)
        {
            material_used_PC m = new material_used_PC();
            m.card_number.Text = card_number.Text;
            m.ShowDialog();
        }

        private void addteam_Click(object sender, RoutedEventArgs e)
        {
            works_result tw = new works_result();
            tw.ShowDialog();
        }

      
       

        private void abrogation_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void project_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dept_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void team_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
