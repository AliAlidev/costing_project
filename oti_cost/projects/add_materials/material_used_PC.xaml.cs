using Newtonsoft.Json;
using System.Collections;
using System.Data;
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
        private listprojects _listprojects;
        public material_used_PC(int projectNum, listprojects lp)
        {
            InitializeComponent();
            double h = SystemParameters.PrimaryScreenHeight;
            double w = SystemParameters.PrimaryScreenWidth;

            Width = w;
            Height = h;

            /////////////////////////////////
            _listprojects = lp;

            /////////////////////// fill active centers
            DataSet ds = sharedvariables.getActiveCentersList(projectNum);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                active_name.Items.Add(item.ItemArray[0]);
            }

            /////////////////////// fill materials
            string query = "select material_name, index_number, unit, quantity, unit_price, total_price, notes, source, active_center_name from material_used where project_number=" + projectNum;
            ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
            double total_prices_sum = 0;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                sharedvariables.materials mat = new sharedvariables.materials();
                mat.material_name = item.ItemArray[0].ToString();
                mat.index_number = item.ItemArray[1].ToString();
                mat.unit = item.ItemArray[2].ToString();
                mat.quantity = item.ItemArray[3].ToString();
                mat.unit_price = item.ItemArray[4].ToString();
                mat.total_price = item.ItemArray[5].ToString();
                mat.notes = item.ItemArray[6].ToString();
                mat.source = item.ItemArray[7].ToString();
                mat.active_center_name = item.ItemArray[8].ToString();
                gridmaterial.Items.Add(mat);
                double tmp = 0;
                double.TryParse(mat.total_price, out tmp);
                total_prices_sum += tmp;
            }
            total_prices.Content = total_prices_sum.ToString();
        }

        //public material_used_PC(listprojects lp)
        //{
        //    InitializeComponent();
        //    double h = SystemParameters.PrimaryScreenHeight;
        //    double w = SystemParameters.PrimaryScreenWidth;

        //    Width = w;
        //    Height = h;
        //    _listprojects = lp;

        //    /////////////////////// fill active centers
        //    string query = "select active_center_name from active_center";
        //    DataSet ds = JsonConvert.DeserializeObject<DataSet>(sharedvariables.proxy.FillDataTable(query));
        //    foreach (DataRow item in ds.Tables[0].Rows)
        //    {
        //        active_name.Items.Add(item.ItemArray[0]);
        //    }
        //}

        public class Add
        {
            public string material_name { get; set; }
            public string active_name { get; set; }

            public string index_number { get; set; }

            public string unit { get; set; }

            public string quantity { get; set; }

            public string unit_price { get; set; }
            public string total_price { get; set; }

            public string notes { get; set; }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (active_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم  مركز النشاط !");
                ok.ShowDialog();
            }
           else if (material_name.Text == "")
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
                    sharedvariables.materials mat = new sharedvariables.materials();
                    mat.material_name = this.material_name.Text;
                    mat.index_number = this.index_number.Text;
                    mat.unit = this.unit.Text;
                    mat.quantity = this.quantity.Text;
                    mat.unit_price = this.unit_price.Text;
                    mat.total_price = this.total_price.Text;
                    mat.notes = this.notes.Text;
                    mat.source = this.source.Text;
                    mat.active_center_name = this.active_name.Text;
                    gridmaterial.Items.Add(mat);

                    this.material_name.Text = "";
                    this.index_number.Text = "";
                    this.unit.Text = "";
                    this.quantity.Text = "";
                    this.unit_price.Text = "";
                    this.total_price.Text = "";
                    this.notes.Text = "";
                    this.source.Text = "";

                   //////////////////////////////////////// get total prices
                    double finalres = 0;
                    foreach (sharedvariables.materials item in gridmaterial.Items)
                    {
                        var res = item.total_price;
                        double res0 = 0;
                        double.TryParse(res.ToString(), out res0);
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
                /////////////////// remove old
                string query = "delete from material_used where project_number=" + card_number.Text;
                sharedvariables.proxy.ExecuteNQ(query);

                IEnumerable items = (IEnumerable)gridmaterial.Items;
                foreach (object obj1 in items)
                {
                    string str1 = (string)obj1.GetType().GetProperty("material_name").GetValue(obj1, (object[])null);
                    string str2 = (string)obj1.GetType().GetProperty("index_number").GetValue(obj1, (object[])null);
                    string str3 = (string)obj1.GetType().GetProperty("unit").GetValue(obj1, (object[])null);
                    object str4 = obj1.GetType().GetProperty("quantity").GetValue(obj1, (object[])null);
                    object str5 = obj1.GetType().GetProperty("unit_price").GetValue(obj1, (object[])null);
                    object str6 = obj1.GetType().GetProperty("total_price").GetValue(obj1, (object[])null);
                    string str7 = (string)obj1.GetType().GetProperty("notes").GetValue(obj1, (object[])null);
                    string str8 = (string)obj1.GetType().GetProperty("active_center_name").GetValue(obj1, (object[])null);
                    string str9 = (string)obj1.GetType().GetProperty("source").GetValue(obj1, (object[])null);

                    string query1 = "insert into material_used(material_name, index_number, unit, quantity , unit_price , total_price , notes, project_number ,active_center_name, source) values('" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "','"+ card_number.Text + "','" + str8 + "','" + str9 + "')";
                    response respo = JsonConvert.DeserializeObject<response>(sharedvariables.proxy.ExecuteNQ(query1));
                    if (!respo.success)
                    {
                        ok = new oknote(sharedvariables.errorMsg + respo.code);
                        ok.ShowDialog();
                        Close();
                    }
                }

                ok = new oknote("تم إدخال البيانات بنجاح");
                ok.ShowDialog();

                ////////////// list projects
                sharedvariables.listPrpjects(_listprojects);

                ////////////
                Close();
            }
            else
            {
                sharedvariables.confirmationmessagebox = "";
                ok = new oknote("لم يتم إدخال البيانات المطلوبة !");
                ok.ShowDialog();
                active_name.Text = "";

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
                double count = 0, price = 0;
                double.TryParse(quantity.Text, out count);
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