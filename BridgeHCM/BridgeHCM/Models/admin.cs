using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wcf_Master;

namespace BridgeHCM.Models
{
    public class system_access_model
    {
        public int user_group_id { get; set; }
        public List<util_dropdown_view_lib> user_group { get; set; }
        public int system_access_type_id { get; set; }
        public List<SelectListItem> system_access_type { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Modules" },
            new SelectListItem { Value = "2", Text = "Reports" },
            new SelectListItem { Value = "3", Text = "Dashboard" }
        };
        public List<menu_view_restriction_lib> item_list { get; set; }
    }

    public class system_settings_model
    {
        public int setting_id { get; set; }
        public string description { get; set; }
        public List<util_dropdown_list_lib> drop_down_list { get; set; }
        public List<util_dropdown_view_lib> drop_down_table_list { get; set; }
    }
}
