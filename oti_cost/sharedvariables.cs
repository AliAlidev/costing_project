using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oti_cost
{
   public static class sharedvariables
    {
        public static string confirmationmessagebox;


        public static string team_name;
        public static string project_name;
        public static string dept;
        public static string help_team;
        public static string governorate;
        public static string start_date;
        public static string finsh_date;

        public static bool isDate(string val)
        {
            try
            {
                var dd = DateTime.Parse(val).ToShortDateString();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool isNumber(string val)
        {
            try
            {
                var dd = int.Parse(val);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
