using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BridgeHCM.Models
{
    public class login
    {
        public string username { get; set; }
        public string userhash { get; set; }
        public bool remember_me { get; set; }
    }
}
