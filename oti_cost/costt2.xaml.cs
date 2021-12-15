using System;
using System.Collections;
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
    /// Interaction logic for costt2.xaml
    /// </summary>
    public partial class costt2 : Window
    {
        oknote ok;
        note n1;
        public costt2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (material_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم المادة");
                ok.ShowDialog();
            }
            else if (index_number.Text == "")
            {
                ok = new oknote("يجب إدخال رقم الفهرسة");
                ok.ShowDialog();
            }
            else if (unit.Text == "")
            {
                ok = new oknote("يجب إدخال الواحدة");
                ok.ShowDialog();

            }
            else if (quantity.Text == "")
            {
                ok = new oknote("يجب إدخال الكمية");
                ok.ShowDialog();

            }
            else if (origin.Text == "")
            {
                ok = new oknote("يجب إدخال المنشأ");
                ok.ShowDialog();

            }
            else if (!sharedvariables.isNumber(this.index_number.Text))
            {
                ok = new oknote("رقم الفهرسة  يجب أن يكون عدد حصراً ! ");
                ok.ShowDialog();
            }
            else if (!sharedvariables.isNumber(this.quantity.Text))
            {
                ok = new oknote("الكمية  يجب أن تكون عدد حصراً ! ");
                ok.ShowDialog();
            }

            else
            {

                n1 = new note(" الرجاء التأكد من صحة المعلومات المدخلة ثم الضغط على زر موافق للإدخال ");
                n1.ShowDialog();

                if (sharedvariables.confirmationmessagebox == "ok")
                {


                    this.grid.Items.Add((object)new costt2.Add()
                    {
                        item_name = this.material_name.Text,
                        index = this.index_number.Text,
                        unit = this.unit.Text,
                        amount = this.quantity.Text,
                        origin = this.origin.Text,
                        notes = this.notes.Text

                    });

                    this.material_name.Text = "";
                    this.index_number.Text = "";
                    this.unit.Text = "";
                    this.quantity.Text = "";
                    this.origin.Text = "";
                    this.notes.Text = "";



                }
                else
                {
                    ok = new oknote("لم يتم إدخال المعلومات المطلوبة !");
                    ok.ShowDialog();
                }
            }
        }

        public class Add
        {
            public string item_name { get; set; }

            public string index { get; set; }

            public string unit { get; set; }

            public string amount { get; set; }
            public string origin { get; set; }
            public string notes { get; set; }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            n1 = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟");
            n1.ShowDialog();

            if (sharedvariables.confirmationmessagebox == "ok")
            {

                try
                {

                    IEnumerable items = (IEnumerable)grid.Items;
                    foreach (object obj1 in items)
                    {
                        string str1 = (string)obj1.GetType().GetProperty("item_name").GetValue(obj1, (object[])null);
                        object obj2 = obj1.GetType().GetProperty("index").GetValue(obj1, (object[])null);
                        object obj3 = obj1.GetType().GetProperty("unit").GetValue(obj1, (object[])null);
                        string str2 = (string)obj1.GetType().GetProperty("amount").GetValue(obj1, (object[])null);
                        object str3 = obj1.GetType().GetProperty("origin").GetValue(obj1, (object[])null);
                        string str4 = (string)obj1.GetType().GetProperty("notes").GetValue(obj1, (object[])null);


                        DBVariables.executenq("INSERT INTO material_used (material_name, index_number, unit,quantity, origin,notes , project_number )VALUES ('" + str1
                            + "' , '" + obj2 +
                            "','" + obj3 +
                            "','" + str2 +
                            "','" + str3 +
                            "', '" + str4 +
                            "','" + project_number.Text + "' )");


                    }
                }
                catch (Exception)
                {

                    ok = new oknote("حدثت مشكلة أثناء عملية الإدخال");
                    ok.ShowDialog();

                    throw;
                }



                ok = new oknote("تم إضافة البيانات بنجاح");
                ok.ShowDialog();


                this.grid.Items.Clear();

            }
            else
            {
                sharedvariables.confirmationmessagebox = "";
                ok = new oknote("لم يتم إدخال البيانات المطلوبة !");
                ok.ShowDialog();
                this.material_name.Text = "";
                this.index_number.Text = "";
                this.unit.Text = " ";
                this.quantity.Text = "";
                this.origin.Text = "";
                this.notes.Text = "";


            }

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            bool msg = false;

            if (msg == DBVariables.isFound(project_number.Text, "project_number", "material_used"))
            {
                ok = new oknote("لم يتم ادخال معلومات  المواد المستخدمة  لهذا المشروع مسبقاً");
                ok.ShowDialog();
            }
            else
            {
                n1 = new note("تأكيد عملية الحذف ");
                n1.ShowDialog();

                if (sharedvariables.confirmationmessagebox == "ok")
                {
                    try
                    {

                        string query = "delete from material_used where project_number=" + project_number.Text;
                        DBVariables.executenq(query);

                        ok = new oknote("تم حذف معلومات المواد المستخدمة  بنجاح");
                        ok.ShowDialog();

                    }
                    catch (System.Exception)
                    {

                        ok = new oknote("حدثت مشكلة أثناء عملية الحذف");
                        ok.ShowDialog();
                        throw;
                    }



                }
                else
                {
                    sharedvariables.confirmationmessagebox = "";
                    ok = new oknote("لم يتم حذف المعلومات  !");
                    ok.ShowDialog();
                }
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            bool msg = false;
            if (msg == DBVariables.isFound(project_number.Text, "project_number", "material_used"))
            {
                ok = new oknote("لم يتم ادخال معلومات المواد المستخدمة لهذا المشروع مسبقاً");
                ok.ShowDialog();
            }
            else if (this.grid.Items.Count == 0)
            {
                ok = new oknote("يجب ادخال البيانات أولاً");
                ok.ShowDialog();
            }
            else
            {
                n1 = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟");
                n1.ShowDialog();

                if (sharedvariables.confirmationmessagebox == "ok")
                {

                    string query = "delete from material_used where project_number=" + project_number.Text;
                    DBVariables.executenq(query);



                    IEnumerable items = (IEnumerable)grid.Items;
                    foreach (object obj1 in items)
                    {
                        try
                        {

                            string str1 = (string)obj1.GetType().GetProperty("material_name").GetValue(obj1, (object[])null);
                            object obj2 = obj1.GetType().GetProperty("index_number").GetValue(obj1, (object[])null);
                            object str2 = (string)obj1.GetType().GetProperty("unit").GetValue(obj1, (object[])null);
                            object obj3 = obj1.GetType().GetProperty("quantity").GetValue(obj1, (object[])null);
                            string str3 = (string)obj1.GetType().GetProperty("origin").GetValue(obj1, (object[])null);
                            string str4 = (string)obj1.GetType().GetProperty("notes").GetValue(obj1, (object[])null);


                            DBVariables.executenq("INSERT INTO material_used (material_name, index_number, unit,quantity, origin,notes , project_number )VALUES ('" + str1
                                + "' , '" + obj2 +
                                "','" + str2 +
                                "','" + obj3 +
                                "','" + str3 +
                                "', '" + str4 +
                                "' ,'" + project_number.Text + "' )");

                        }
                        catch (System.Exception)
                        {

                            ok = new oknote("حدثت مشكلة أثناء عملية التعديل ");
                            ok.ShowDialog();
                            throw;
                        }

                    }

                    ok = new oknote("تم تعديل البيانات بنجاح");
                    ok.ShowDialog();







                }
                else
                {
                    sharedvariables.confirmationmessagebox = "";
                    ok = new oknote("لم يتم إدخال البيانات المطلوبة !");
                    ok.ShowDialog();
                    this.material_name.Text = "";
                    this.index_number.Text = "";
                    this.unit.Text = " ";
                    this.quantity.Text = "";
                    this.origin.Text = "";
                    this.notes.Text = "";


                }

            }
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
