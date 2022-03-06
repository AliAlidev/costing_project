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

        public modulation()
        {
            InitializeComponent();
            oknote ok;
            note n;

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
                        int projectNum = int.Parse(card_number.Text);
                        //////////////
                        DBVariables.executenq("delete from material_used where project_number=" + projectNum);
                        //////////////
                        string query = "update project_card set";
                        if (project_name.Text != null)
                            query = query + " project_name = '" + project_name.Text + "'";
                        if (active_name.Text != null)
                            query = query + ", active_center_name='" + active_name.Text + "'";
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
                        if (result_work.Text != null)
                            query = query + ", work_done='" + result_work.Text + "'";
                        if (hour_work.Text != null)
                            query = query + ", hours='" + hour_work.Text + "'";
                        if (notes.Text != null)
                            query = query + ", notes='" + notes.Text + "'";
                        query = query + " where project_number=" + projectNum;

                        DBVariables.executenq(query);

                        /////////////////////////
                        if (teamgrid.Items.Count > 0)
                        {
                            foreach (var item in teamgrid.Items)
                            {
                                string material_name = item.GetType().GetProperty("material_name").GetValue(item, null).ToString();
                                string index_number = item.GetType().GetProperty("index_number").GetValue(item, null).ToString();
                                string unit = item.GetType().GetProperty("unit").GetValue(item, null).ToString();
                                string quantity = item.GetType().GetProperty("quantity").GetValue(item, null).ToString();
                                string unit_price = item.GetType().GetProperty("unit_price").GetValue(item, null).ToString();
                                string total_price = item.GetType().GetProperty("total_price").GetValue(item, null).ToString();
                                string notes = item.GetType().GetProperty("notes").GetValue(item, null).ToString();

                                DBVariables.executenq("insert into material_used(material_name,index_number,unit,quantity,unit_price,total_price,notes,project_number) " +
                                    "values('"+ material_name + "','"+ index_number + "','"+unit+"','"+ quantity + "','"+ unit_price + "','"+ total_price + "','"+notes+"','"+projectNum+"')");
                            }

                        }

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

        private void addd_Click_1(object sender, RoutedEventArgs e)
        {
            if (material_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم  المادة !");
                ok.ShowDialog();
            }
            else if (index_number.Text == "")
            {
                ok = new oknote("يجب إدخال رقم الفهرسة    !");
                ok.ShowDialog();
            }
            else if (!sharedvariables.isNumber(index_number.Text))
            {
                ok = new oknote("  رقم الفهرسة يجب أن يكون رقم حصرا   !");
                ok.ShowDialog();
            }

            else if (unit.Text == "")
            {
                ok = new oknote("يجب إدخال  الواحدة ! ");
                ok.ShowDialog();
            }
            else if (quantity.Text == "")
            {
                ok = new oknote("يجب إدخال   الكمية ! ");
                ok.ShowDialog();
            }
            else if (!sharedvariables.isNumber(quantity.Text))
            {
                ok = new oknote("  الكمية  يجب أن تكون رقم حصرا   !");
                ok.ShowDialog();
            }

            else if (unit_price.Text == "")
            {
                ok = new oknote("يجب إدخال السعر الافرادي  ! ");
                ok.ShowDialog();
            }
            else if (!sharedvariables.isNumber(unit_price.Text))
            {
                ok = new oknote("   السعر الإفرادي يجب أن يكون رقم حصرا  !");
                ok.ShowDialog();
            }

            else if (total_price.Text == "")
            {
                ok = new oknote("يجب إدخال   السعر الاجمالي ! ");
                ok.ShowDialog();
            }
            else if (!sharedvariables.isNumber(total_price.Text))
            {
                ok = new oknote("  السعر الإجمالي  يجب أن يكون رقم حصرا   !");
                ok.ShowDialog();
            }


            else
            {

                n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من صحة البيانات المدخلة قبل الموافقة )");
                n.ShowDialog();




                if (sharedvariables.confirmationmessagebox == "ok")
                {


                    this.teamgrid.Items.Add((object)new modulation.Add()
                    {
                        material_name = this.material_name.Text,
                        index_number = this.index_number.Text,
                        unit = this.unit.Text,
                        quantity = this.quantity.Text,
                        unit_price = this.unit_price.Text,
                        total_price = this.total_price.Text,
                        notes = this.notes.Text,


                    });

                    this.material_name.Text = "";
                    this.index_number.Text = "";
                    this.unit.Text = "";
                    this.quantity.Text = "";
                    this.unit_price.Text = "";
                    this.total_price.Text = "";
                    this.notes.Text = "";

                    ////////
                    //var res = gridmaterial.Items["total_price"];
                    //var res = null;
                    //    double finalres = 0;
                    //    foreach (var item in teamgrid.Items)
                    //    {
                    //        var res = item.GetType().GetProperty("total_price");
                    //        var tt = res.GetValue(item, null);
                    //        double res0 = 0;
                    //        double.TryParse(tt.ToString(), out res0);
                    //        finalres += res0;
                    //    }
                    //    total_price.Content = finalres.ToString();
                }
                else
                {
                    ok = new oknote("لم يتم إدخال المعلومات المطلوبة !");
                    ok.ShowDialog();
                }
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            teamgrid.Items.RemoveAt(teamgrid.SelectedIndex);
            //double finalres = 0;
            //foreach (var item in teamgrid.Items)
            //{
            //    var res = item.GetType().GetProperty("total_price");
            //    var tt = res.GetValue(item, null);
            //    double res0 = 0;
            //    double.TryParse(tt.ToString(), out res0);
            //    finalres += res0;
            //}
            //total_price.VerticalContentAlignment = finalres.ToString();
        }
        private void total_price_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (quantity.Text != "" && unit_price.Text != "")
            {
                double count = 0, price = 0;
                double.TryParse(quantity.Text, out count);
                double.TryParse(unit_price.Text, out price);
                total_price.Text = (count * price).ToString();
            }
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
    }
}
