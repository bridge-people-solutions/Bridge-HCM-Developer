using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wcf_Master;

namespace BridgeHCM.Models
{
    public class employee_profile_model
    {
        public employee_list_view_lib personal { get; set; }
        public employee_information_in_lib information { get; set; }
        public List<employee_relative_in_lib> relative { get; set; }
        public List<employee_emergency_in_lib> emergency { get; set; }
        public List<employee_employment_in_lib> employment { get; set; }
        public List<employee_education_in_lib> education { get; set; }
        public List<employee_degree_in_lib> degree { get; set; }
        public List<util_dropdown_view_lib> question { get; set; }
        public int q1 { get; set; }
        public int q2 { get; set; }
    }
}
