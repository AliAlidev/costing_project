using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oti_cost
{

    internal class materials_class
    {
        public string material_name { get; set; }
        public string unit { get; set; }
        public string quantity { get; set; }
        public string unit_price { get; set; }
        public string total_price { get; set; }
        public string notes { get; set; }
        public string project_number { get; set; }
        public string total_sum { get; set; }
        public string index_number { get; set; }
        public string source { get; set; }
    }

    internal class workers_class
    {
        public string worker_name { get; set; }
        public string self_number { get; set; }
        public string category { get; set; }
        public string team_name { get; set; }
    }
    internal class project_class
    {
        public string work_done { get; set; }
        public string hours_number { get; set; }
        public string project_number { get; set; }
        public string active_center_name { get; set; }
        public string project_name { get; set; }
        public string dept { get; set; }
        public string help_team { get; set; }
        public string governorate { get; set; }
        public string start_date { get; set; }
        public string finsh_date { get; set; }
        public string hours { get; set; }
        public string notes { get; set; }
    }

    internal class project_cost_class
    {
        public string project_name { get; set; }
        public string active_center_name { get; set; }
        public string work_done { get; set; }
        public string hours { get; set; }
        public string notes { get; set; }

    }
}
