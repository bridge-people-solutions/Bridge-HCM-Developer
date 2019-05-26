using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wcf_Master;

namespace BridgeHCM.Components
{
    public class MenuList : ViewComponent
    {
        wcf_Master.Master_ServiceClient _master = new wcf_Master.Master_ServiceClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                int company_id = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["CompanyId"]));
                int access_level_id = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["AccessLevelId"]));

                var m = _master.menu_view_restrictionAsync(access_level_id, 0, company_id).Result.ToList();
                ViewBag.department = Crypto.password_decrypt(Request.Cookies["Department"]);
                ViewBag.imgPath = Crypto.password_decrypt(Request.Cookies["ImgPath"]);
                return View(m);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
