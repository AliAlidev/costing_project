using System;
using System.Collections;
using System.Windows;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for engine_info.xaml
    /// </summary>
    public partial class engine_info : Window
    {

        oknote ok;
        note n;
        public engine_info()
        {
            InitializeComponent();

            double h = SystemParameters.PrimaryScreenHeight;
            double w = SystemParameters.PrimaryScreenWidth;

            Width = w;
            Height = h;
        }

        private void receiver_after_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

       

        //private void addwor_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delet_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void close_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        private void addmaterial_Click(object sender, RoutedEventArgs e)
        {
            if (material_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم المادة !");
                ok.ShowDialog();
            }
            else if (unit.Text == "")
            {
                ok = new oknote("يجب تحديد الواحدة ! ");
                ok.ShowDialog();
            }
            else if (quantity.Text == "")
            {
                ok = new oknote("يجب تحديد الكمية ! ");
                ok.ShowDialog();

            }



            else
            {

                n = new note(" الرجاء التأكد من صحة المعلومات المدخلة ثم الضغط على زر موافق للإدخال ");
                n.ShowDialog();

                if (sharedvariables.confirmationmessagebox == "ok")
                {


                    this.materialgrid.Items.Add((object)new engine_info.Add()
                    {
                        material_name = this.material_name.Text,
                        unit = this.unit.Text,
                        quantity = this.quantity.Text,


                    });

                    this.material_name.Text = "";
                    this.unit.Text = "";
                    this.quantity.Text = "";




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
            public string material_name { get; set; }

            public string unit { get; set; }

            public string quantity { get; set; }

            public string operation { get; set; }

            public string worker_name { get; set; }

            public string work_hours { get; set; }

        }



        private void addwor_Click(object sender, RoutedEventArgs e)
        //private void addworkers_Click(object sender, RoutedEventArgs e)
        {
             if (operation.Text == "")
            {
                ok = new oknote("يجب تحديد العملية  ! ");
                ok.ShowDialog();

            }
           else if (worker_name.Text == "")
            {
                ok = new oknote("يجب إدخال اسم العامل  !");
                ok.ShowDialog();
            }
            else if (work_hours.Text == "")
            {
                ok = new oknote("يجب تحديد عدد ساعات العمل  ! ");
                ok.ShowDialog();
            }



            else
            {

                n = new note(" الرجاء التأكد من صحة المعلومات المدخلة ثم الضغط على زر موافق للإدخال ");
                n.ShowDialog();

                if (sharedvariables.confirmationmessagebox == "ok")
                {


                    this.workersgrid.Items.Add((object)new engine_info.Add()
                    {
                        operation = this.operation.Text,
                        worker_name = this.worker_name.Text,
                        work_hours = this.work_hours.Text,


                    });

                    this.operation.Text = "";
                    this.worker_name.Text = "";
                    this.work_hours.Text = "";




                }
                else
                {
                    ok = new oknote("لم يتم إدخال المعلومات المطلوبة !");
                    ok.ShowDialog();
                }
            }
        }

        private void addd_Click(object sender, RoutedEventArgs e)
        {

            if (DBVariables.isFound(card_number1.Text, "card_number", "engine_info"))
            {
                ok = new oknote("معلومات هذه البطاقة مدخلة مسبقاً !");
                ok.ShowDialog();

            }
            else
          if (engine_sequence_number.Text == "")
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
            //  //  else if (results.Text == "")
            //  //  {
            //  //      ok = new oknote("يجب إدخال نتائج الاختبار   !    ");
            //  //      ok.ShowDialog();
            //  //  }
            //  //  else if (sender_after.Text == "")
            //  //  {
            //  //      ok = new oknote("يجب إدخال اسم المسلم يعد الصيانة     !    ");
            //  //      ok.ShowDialog();
            //  //  }
            //  //  else if (receiver_after.Text == "")
            //  //  {
            //  //      ok = new oknote("يجب إدخال اسم المستلم بعد الصيانة    !    ");
            //  //      ok.ShowDialog();
            //  //  }

            else
            {

                n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من صحة البيانات المدخلة قبل الموافقة )");
                n.ShowDialog();



                if (sharedvariables.confirmationmessagebox == "ok")
                {


                    DBVariables.executenq("INSERT INTO engine_info (  engine_sequence_number , engine_power , engine_rpm  )  VALUES('" +
                        engine_sequence_number.Text +
                           "' , '" + engine_power.Text +
                           "' , '" + engine_rpm.Text + "' , '" + card_number1.Text + "') ");

                    IEnumerable items = (IEnumerable)materialgrid.Items;
                    IEnumerable items1 = (IEnumerable)workersgrid.Items;

                    foreach (object obj1 in items)
                    {
                        try
                        {

                            string str1 = (string)obj1.GetType().GetProperty("material_name").GetValue(obj1, (object[])null);
                            string str2 = (string)obj1.GetType().GetProperty("unit").GetValue(obj1, (object[])null);
                            string str3 = (string)obj1.GetType().GetProperty("quantity").GetValue(obj1, (object[])null);

                            DBVariables.executenq("INSERT INTO material_used_ec (material_name, unit, quantity , card_number )VALUES ('" + str1
                                + "' , '" + str2 +
                                "','" + str3 + "','" + card_number1.Text +
                                " )");



                        }
                        catch (System.Exception)
                        {

                            ok = new oknote("حدثت مشكلة أثناء عملية الحفظ");
                            ok.ShowDialog();
                        }

                    }

                    foreach (object obj1 in items1)
                    {
                        try
                        {

                            string str1 = (string)obj1.GetType().GetProperty("operation").GetValue(obj1, (object[])null);
                            string str2 = (string)obj1.GetType().GetProperty("worker_name").GetValue(obj1, (object[])null);
                            object obj2 = obj1.GetType().GetProperty("work_hours").GetValue(obj1, (object[])null);

                            DBVariables.executenq("INSERT INTO maintenance_workers_ec (operation, worker_name, work_hours , card_number )VALUES ('" + str1
                                + "' , '" + str2 +
                                "','" + obj2 + "','" + card_number1.Text + "' )");



                        }
                        catch (System.Exception)
                        {

                            ok = new oknote("حدثت مشكلة أثناء عملية الحفظ");
                            ok.ShowDialog();
                        }

                    }

                    ok = new oknote("تم إدخال البيانات بنجاح");
                    ok.ShowDialog();

                    engine_sequence_number.Text = "";
                    engine_power.Text = "";
                    engine_rpm.Text = "";


                    this.materialgrid.Items.Clear();
                    this.workersgrid.Items.Clear();
                }
                else
                {
                    sharedvariables.confirmationmessagebox = "";
                    ok = new oknote("لم يتم إدخال البيانات المطلوبة !");
                    ok.ShowDialog();

                    engine_sequence_number.Text = "";
                    engine_power.Text = "";
                    engine_rpm.Text = "";
                  


                }






            }





        }

        ////private void edit_Click(object sender, RoutedEventArgs e)
        ////{
        ////    bool msg =false ;

        ////     if (msg == DBVariables.isFound(card_number1.Text, "card_number", "engine_info"))
        ////    {
        ////        ok = new oknote("هذه البطاقة غير موجودة مسبقاً !");
        ////        ok.ShowDialog();
        ////    }
        ////    else
        ////    {

        ////        n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من ملئ الحقول بالبيانات المطلوبة ) ");
        ////        n.ShowDialog();

        ////        if (sharedvariables.confirmationmessagebox == "ok")
        ////        {

        ////            string query;
        ////            try
        ////            {

        ////                if (engine_sequence_number.Text != "")
        ////                {
        ////                    query = "UPDATE engine_info set engine_sequence_number='" + engine_sequence_number.Text + "' where card_number =" + card_number1.Text;

        ////                    DBVariables.executenq(query);
        ////                }

        ////                if (engine_power.Text != "")
        ////                {
        ////                    query = "UPDATE engine_info set engine_power = '" + engine_power.Text + "' where card_number = " + card_number1.Text;

        ////                    DBVariables.executenq(query);
        ////                }

        ////                if (engine_rpm.Text != "")
        ////                {
        ////                    query = "UPDATE engine_info set engine_rpm = '" + engine_rpm.Text + "' where card_number = " + card_number1.Text;
        ////                    DBVariables.executenq(query);
        ////                }
        ////                if (results.Text != "")
        ////                {
        ////                    query = "UPDATE engine_info set results = '" + results.Text + "' where card_number = " + card_number1.Text;
        ////                    DBVariables.executenq(query);
        ////                }
        ////                if (sender_after.Text != "")
        ////                {
        ////                    query = "UPDATE engine_info set sender_after = '" + sender_after.Text + "' where card_number = " + card_number1.Text;
        ////                    DBVariables.executenq(query);
        ////                }
        ////                if (receiver_after.Text != "")
        ////                {
        ////                    query = "UPDATE engine_info set receiver_after = '" + receiver_after.Text + "' where card_number = " + card_number1.Text;
        ////                    DBVariables.executenq(query);
        ////                }




        ////            }
        ////            catch (Exception)
        ////            {
        ////                ok = new oknote("حدثت مشكلة أثناء عملية التعديل ");
        ////                ok.ShowDialog();

        ////            }


        ////            ok = new oknote("انتبه .. تاريخ التسليم و الاستلام  ثابت و لن يتم تعديله في حال قمت بتغييره !");
        ////            ok.ShowDialog();
        ////            ok = new oknote("تم تعديل البيانات بنجاح");
        ////            ok.ShowDialog();

        ////            engine_sequence_number.Text = "";
        ////            engine_power.Text = "";
        ////            engine_rpm.Text = "";
        ////            results.Text = "";
        ////            sender_after.Text = "";
        ////            receiver_after.Text = "";


        ////        }
        ////        else
        ////        {
        ////            sharedvariables.confirmationmessagebox = "";
        ////            ok = new oknote("لم يتم تعديل البيانات ");
        ////            ok.ShowDialog();

        ////            engine_sequence_number.Text = "";
        ////            engine_power.Text = "";
        ////            engine_rpm.Text = "";
        ////            results.Text = "";
        ////            sender_after.Text = "";
        ////            receiver_after.Text = "";
        ////        }

        ////    }
        ////}

        ////private void delete_Click(object sender, RoutedEventArgs e)
        ////{

        ////}

        ////private void engine_power_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        ////{

        ////}

        ////private void addmaterial_Click_1(object sender, RoutedEventArgs e)
        ////{
        ////    if (material_name.Text == "")
        ////    {
        ////        ok = new oknote("يجب إدخال اسم المادة !");
        ////        ok.ShowDialog();
        ////    }
        ////    else if (unit.Text == "")
        ////    {
        ////        ok = new oknote("يجب تحديد الواحدة ! ");
        ////        ok.ShowDialog();
        ////    }
        ////    else if (quantity.Text == "")
        ////    {
        ////        ok = new oknote("يجب تحديد الكمية ! ");
        ////        ok.ShowDialog();

        ////    }



        ////    else
        ////    {

        ////        n = new note(" الرجاء التأكد من صحة المعلومات المدخلة ثم الضغط على زر موافق للإدخال ");
        ////        n.ShowDialog();

        ////        if (sharedvariables.confirmationmessagebox == "ok")
        ////        {


        ////            this.materialgrid.Items.Add((object)new engine_info.Add()
        ////            {
        ////                material_name = this.material_name.Text,
        ////                unit = this.unit.Text,
        ////                quantity = this.quantity.Text,


        ////            });

        ////            this.material_name.Text = "";
        ////            this.unit.Text = "";
        ////            this.quantity.Text = "";




        ////        }
        ////        else
        ////        {
        ////            ok = new oknote("لم يتم إدخال المعلومات المطلوبة !");
        ////            ok.ShowDialog();
        ////        }
        ////    }
        ////}

        //private void addworkers_Click_1(object sender, RoutedEventArgs e)
        //{
        //    if (worker_name.Text == "")
        //    {
        //        ok = new oknote("يجب إدخال اسم العامل  !");
        //        ok.ShowDialog();
        //    }
        //    else if (work_hours.Text == "")
        //    {
        //        ok = new oknote("يجب تحديد عدد ساعات العمل  ! ");
        //        ok.ShowDialog();
        //    }
        //    else if (operation.Text == "")
        //    {
        //        ok = new oknote("يجب تحديد العملية  ! ");
        //        ok.ShowDialog();

        //    }



        //    else
        //    {

        //        n = new note(" الرجاء التأكد من صحة المعلومات المدخلة ثم الضغط على زر موافق للإدخال ");
        //        n.ShowDialog();

        //        if (sharedvariables.confirmationmessagebox == "ok")
        //        {


        //            this.workersgrid.Items.Add((object)new engine_info.Add()
        //            {
        //                operation = this.operation.Text,
        //                worker_name = this.worker_name.Text,
        //                work_hours = this.work_hours.Text,


        //            });

        //            this.operation.Text = "";
        //            this.worker_name.Text = "";
        //            this.work_hours.Text = "";




        //        }
        //        else
        //        {
        //            ok = new oknote("لم يتم إدخال المعلومات المطلوبة !");
        //            ok.ShowDialog();
        //        }
        //    }
        //}

        //private void add_Click_1(object sender, RoutedEventArgs e)
        //{
        //    if (DBVariables.isFound(card_number1.Text, "card_number", "engine_info"))
        //    {
        //        ok = new oknote("معلومات هذه البطاقة مدخلة مسبقاً !");
        //        ok.ShowDialog();

        //    }
        //    else
        //if (engine_sequence_number.Text == "")
        //    {
        //        ok = new oknote("يجب إدخال الرقم التسلسلي للمحرك   !");
        //        ok.ShowDialog();
        //    }
        //    else if (engine_power.Text == "")
        //    {
        //        ok = new oknote("يجب تحديد استطاعة المحرك    !");
        //        ok.ShowDialog();
        //    }
        //    else if (engine_rpm.Text == "")
        //    {
        //        ok = new oknote("يجب تحديد عدد دورات المحرك    ! ");
        //        ok.ShowDialog();
        //    }
        //    else if (results.Text == "")
        //    {
        //        ok = new oknote("يجب إدخال نتائج الاختبار   !    ");
        //        ok.ShowDialog();
        //    }
        //    else if (sender_after.Text == "")
        //    {
        //        ok = new oknote("يجب إدخال اسم المسلم يعد الصيانة     !    ");
        //        ok.ShowDialog();
        //    }
        //    else if (receiver_after.Text == "")
        //    {
        //        ok = new oknote("يجب إدخال اسم المستلم بعد الصيانة    !    ");
        //        ok.ShowDialog();
        //    }

        //    else
        //    {

        //        n = new note("هل أنت متأكد بأنك تريد القيام بهذه العملية ؟ .. ( الرجاء التأكد من صحة البيانات المدخلة قبل الموافقة )");
        //        n.ShowDialog();



        //        if (sharedvariables.confirmationmessagebox == "ok")
        //        {


        //            DBVariables.executenq("INSERT INTO engine_info (  engine_sequence_number , engine_power , engine_rpm ,  results , sender_after ,receiver_after , card_number )  VALUES('" +
        //                engine_sequence_number.Text +
        //                   "' , '" + engine_power.Text +
        //                   "' , '" + engine_rpm.Text +
        //                  "' , '" + results.Text +
        //                  "' , '" + sender_after.Text +
        //                   "' , '" + receiver_after.Text + "' , '" + card_number1.Text + "') ");

        //            IEnumerable items = (IEnumerable)materialgrid.Items;
        //            IEnumerable items1 = (IEnumerable)workersgrid.Items;

        //            foreach (object obj1 in items)
        //            {
        //                try
        //                {

        //                    string str1 = (string)obj1.GetType().GetProperty("material_name").GetValue(obj1, (object[])null);
        //                    string str2 = (string)obj1.GetType().GetProperty("unit").GetValue(obj1, (object[])null);
        //                    string str3 = (string)obj1.GetType().GetProperty("quantity").GetValue(obj1, (object[])null);

        //                    DBVariables.executenq("INSERT INTO material_used_ec (material_name, unit, quantity , card_number )VALUES ('" + str1
        //                        + "' , '" + str2 +
        //                        "','" + str3 + "','" + card_number1.Text +
        //                        " )");



        //                }
        //                catch (System.Exception)
        //                {

        //                    ok = new oknote("حدثت مشكلة أثناء عملية الحفظ");
        //                    ok.ShowDialog();
        //                }

        //            }

        //            foreach (object obj1 in items1)
        //            {
        //                try
        //                {

        //                    string str1 = (string)obj1.GetType().GetProperty("operation").GetValue(obj1, (object[])null);
        //                    string str2 = (string)obj1.GetType().GetProperty("worker_name").GetValue(obj1, (object[])null);
        //                    object obj2 = obj1.GetType().GetProperty("work_hours").GetValue(obj1, (object[])null);

        //                    DBVariables.executenq("INSERT INTO maintenance_workers_ec (operation, worker_name, work_hours , card_number )VALUES ('" + str1
        //                        + "' , '" + str2 +
        //                        "','" + obj2 + "','" + card_number1.Text + "' )");



        //                }
        //                catch (System.Exception)
        //                {

        //                    ok = new oknote("حدثت مشكلة أثناء عملية الحفظ");
        //                    ok.ShowDialog();
        //                }

        //            }

        //            ok = new oknote("تم إدخال البيانات بنجاح");
        //            ok.ShowDialog();




        //            this.materialgrid.Items.Clear();
        //            this.workersgrid.Items.Clear();
        //        }
        //        else
        //        {
        //            sharedvariables.confirmationmessagebox = "";
        //            ok = new oknote("لم يتم إدخال البيانات المطلوبة !");
        //            ok.ShowDialog();

        //            engine_sequence_number.Text = "";
        //            engine_power.Text = "";
        //            engine_rpm.Text = "";
        //            results.Text = "";
        //            sender_after.Text = "";
        //            receiver_after.Text = "";


        //        }






        //    }
        //}

        //private void abrogation_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();

        //}

        //private void addmaterial_Click_1(object sender, RoutedEventArgs e)
        //{

        //}

        //private void addworkers_Click_2(object sender, RoutedEventArgs e)
        //{

        //}

        //private void addworkers_Click_3(object sender, RoutedEventArgs e)
        //{

        //}

        //private void sender_after_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        //{

        //}
    }


    }
