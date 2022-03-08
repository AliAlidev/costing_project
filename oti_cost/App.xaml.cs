using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace oti_cost
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            bool serverAvailable = sharedvariables.isServerAvailable();
            if (!serverAvailable)
            {
                MessageBox.Show("الاتصال مع السيرفر غير متوفر حاليا يرجى طلب الدعم من الفريق التقني");
                Environment.Exit(0);
            }
        }
    }
}
