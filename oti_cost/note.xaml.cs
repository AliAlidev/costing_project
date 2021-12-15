using Microsoft.TeamFoundation.WorkItemTracking.Common;
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
    /// Interaction logic for note.xaml
    /// </summary>
    public partial class note : Window
    {
        private string _value;

        public note(string value)
        {
            InitializeComponent();
            notes.Text = value;

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            sharedvariables.confirmationmessagebox = "cancel";
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            sharedvariables.confirmationmessagebox = "ok";
            this.Close();

        }
    }
}
