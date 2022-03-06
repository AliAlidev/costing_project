﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oti_cost
{
   public static class sharedvariables
    {
        public static localhost.MainWebService proxy;

        public static string confirmationmessagebox;

        public static string errorMsg = "حدث خطأ أثناء تنفيذ العملية رمز الخطأ هو ";

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

        public class workers_names
        {
            public string worker_name { get; set; }
            public string self_number { get; set; }
            public string category { get; set; }
            public string team_name { get; set; }
            public string active_name { get; set; }
        }
    }
}
