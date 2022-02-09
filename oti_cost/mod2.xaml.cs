using System;
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
    /// Interaction logic for mod2.xaml
    /// </summary>
    public partial class mod2 : Window
    {
        private oknote ok;
        private note n;
        private object total_prices;
        public mod2()
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

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void abrogation_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void addd_Click(object sender, RoutedEventArgs e)
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
    }
    //private void total_price_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
    //{
    //    if (quantity.Text != "" && unit_price.Text != "")
    //    {
    //        double count = 0, price = 0;
    //        double.TryParse(quantity.Text, out count);
    //        double.TryParse(unit_price.Text, out price);
    //        total_price.Text = (count * price).ToString();
    //    }
    //}
}
    

