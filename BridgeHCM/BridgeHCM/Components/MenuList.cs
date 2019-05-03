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
                string company_id = Crypto.password_decrypt(Request.Cookies["CompanyId"]);
                string warehouse_id = Crypto.password_decrypt(Request.Cookies["WarehouseId"]);
                string user_group_id = Crypto.password_decrypt(Request.Cookies["UserGroupId"]);

                //var model = _wcf.menu_view_restrictionAsync(Convert.ToInt32(user_group_id), 0, Convert.ToInt32(company_id), Convert.ToInt32(warehouse_id)).Result;
                var m = _master.menu_view_restrictionAsync(1, 0, 1, 1).Result.ToList();
                ViewBag.display_name = Crypto.password_decrypt(Request.Cookies["DisplayName"]);
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
