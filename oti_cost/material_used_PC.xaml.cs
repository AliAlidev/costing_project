using System.Collections;
using System.Windows;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for material_used_PC.xaml
    /// </summary>
    public partial class material_used_PC : Window
    {
        oknote ok;
        note n;
        internal object numbercard;

        public material_used_PC()
        {
            InitializeComponent();
            double h = SystemParameters.PrimaryScreenHeight;
            double w = SystemParameters.PrimaryScreenWidth;

            Width = w;
            Height = h;
        }

        //private void close_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}
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
        private void Button_Click(object sender, RoutedEventArgs e)
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
            else if (!sharedvariables.isNumber( index_number.Text ))
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


                    this.gridmaterial.Items.Add((object)new material_used_PC.Add()
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
                    double finalres = 0;
                    foreach (var item in gridmaterial.Items)
                    {
                        var res =  item.GetType().GetProperty("total_price");
                        var tt = res.GetValue(item, null);
                        double res0 = 0;
                        double.TryParse(tt.ToString(), out res0);
                        finalres += res0;
                    }
                    total_prices.Content = finalres.ToString();

                }
                else
                {
                    ok = new oknote("لم يتم إدخال المعلومات المطلوبة !");
                    ok.ShowDialog();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من صحة البيانات المدخلة قبل الموافقة )");
            n.ShowDialog();



            if (sharedvariables.confirmationmessagebox == "ok")
            {



                IEnumerable items = (IEnumerable)gridmaterial.Items;

                foreach (object obj1 in items)
                {
                    try
                    {





                        string str1 = (string)obj1.GetType().GetProperty("material_name").GetValue(obj1, (object[])null);
                        string str2 = (string)obj1.GetType().GetProperty("index_number").GetValue(obj1, (object[])null);
                        string str3 = (string)obj1.GetType().GetProperty("unit").GetValue(obj1, (object[])null);
                        object str4 = obj1.GetType().GetProperty("quantity").GetValue(obj1, (object[])null);
                        object str5 = obj1.GetType().GetProperty("unit_price").GetValue(obj1, (object[])null);
                        object str6 = obj1.GetType().GetProperty("total_price").GetValue(obj1, (object[])null);
                        string str7 = (string)obj1.GetType().GetProperty("notes").GetValue(obj1, (object[])null);

                        string query = "insert into material_used(material_name, index_number, unit, quantity , unit_price , total_price , notes,project_number , total_sum ) values('" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','" + card_numberrr.Text + "','" +  total_prices.Content.ToString() +"')";

                        DBVariables.executenq(query);


                    }
                    catch (System.Exception)
                    {

                        ok = new oknote("حدثت مشكلة أثناء عملية الحفظ");
                        ok.ShowDialog();
                    }

                }
            
                ok = new oknote("تم إدخال البيانات بنجاح");
                ok.ShowDialog();

                material_name.Text = "";
                index_number.Text = "";
                unit.Text = "";
                quantity.Text = "";
                notes.Text = "";
                total_price.Text = "";
                unit_price.Text = "";


                this.gridmaterial.Items.Clear();
            }
            else
            {
                sharedvariables.confirmationmessagebox = "";
                ok = new oknote("لم يتم إدخال البيانات المطلوبة !");
                ok.ShowDialog();

                material_name.Text = "";
                index_number.Text = "";
                unit.Text = "";
                quantity.Text = "";
                notes.Text = "";
                total_price.Text = "";
                unit_price.Text = "";


            }


        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            gridmaterial.Items.RemoveAt(gridmaterial.SelectedIndex);
            double finalres = 0;
            foreach (var item in gridmaterial.Items)
            {
                var res = item.GetType().GetProperty("total_price");
                var tt = res.GetValue(item, null);
                double res0 = 0;
                double.TryParse(tt.ToString(), out res0);
                finalres += res0;
            }
            total_prices.Content = finalres.ToString();
        }

        private void total_price_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (quantity.Text != "" && unit_price.Text != "")
            {
                double count = 0, price =0;
                double.TryParse(quantity.Text,out count);
                double.TryParse(unit_price.Text, out price);
                total_price.Text = (count * price).ToString();
            }
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    this.Close();

        //}
    }
}