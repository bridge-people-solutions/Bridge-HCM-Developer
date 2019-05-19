using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BridgeHCM.Models;
using wcf_Master;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace BridgeHCM.Controllers
{
    public class adminController : Controller
    {
        wcf_Master.Master_ServiceClient _master = new wcf_Master.Master_ServiceClient();

        public IActionResult Index()
        {
            return View();
        }

        #region Global Function
        private readonly IHostingEnvironment _environment;
        // Constructor
        public adminController(IHostingEnvironment IHostingEnvironment)
        {
            _environment = IHostingEnvironment;
        }

        [HttpPost]
        public int Upload(string folder, int module, int transaction)
        {
            try
            {
                int result = 0;
                file_manager_in_lib obj = new file_manager_in_lib();
                int company_id = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["CompanyId"]));
                int created_by = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["UserId"]));
                int warehouse_id = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["WarehouseId"]));

                if (Request.Form.Files.Count > 0)
                {
                    foreach (var file in Request.Form.Files)
                    {
                        var fileName = file.FileName;

                        var customDir = "Uploaded\\Images\\"+ company_id.ToString() + "\\" + folder;

                        var directory = Path.Combine(_environment.WebRootPath, customDir);

                        if (!Directory.Exists(directory))
                            Directory.CreateDirectory(directory);

                        var fullPath = Path.Combine(_environment.WebRootPath, customDir) + $@"\{fileName}";

                        using (FileStream fs = System.IO.File.Create(fullPath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                        obj.module_id = module;
                        obj.transaction_id = transaction;
                        obj.file_name = fileName;
                        obj.file_extension = Path.GetExtension(fileName);
                        obj.file_path = "\\" + customDir + "\\" + fileName;
                        obj.created_by = created_by;
                        obj.warehouse_id = warehouse_id;
                        obj.company_id = company_id;

                        result = _master.file_manager_inAsync(obj).Result;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                string cont = ex.Message;
                return 0;
            }
        }
        #endregion

        #region System Access
        [Authorize]
        public IActionResult system_access()
        {
            return View();
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult modules_access_view(int id)
        {
            string company_id = Crypto.url_decrypt(Request.Cookies["CompanyId"]);
            var result = JsonConvert.SerializeObject(_master.modules_access_viewAsync(id, 0, Convert.ToInt32(company_id)).Result.ToList());
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult module_access_in(menu_view_restriction_lib[] objHeader)
        {
            int company_id = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["CompanyId"]));
            int created_by = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["UserId"]));
            menu_view_restriction_lib result = _master.module_access_inAsync(objHeader, company_id, created_by).Result;
            JsonResult json = Json(result);
            return json;
        }
        #endregion

        #region System Settings
        [Authorize]
        public IActionResult system_settings()
        {
            return View();
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult util_dropdown_view(int id, bool active)
        {
            string company_id = Crypto.url_decrypt(Request.Cookies["CompanyId"]);
            var result = JsonConvert.SerializeObject(_master.util_dropdown_viewAsync(id, active, 0, Convert.ToInt32(company_id)).Result.ToList());
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult util_dropdown_list(int setting_id)
        {
            string company_id = Crypto.url_decrypt(Request.Cookies["CompanyId"]);
            string warehouse_id = Crypto.url_decrypt(Request.Cookies["WarehouseId"]);
            var result = JsonConvert.SerializeObject(_master.util_dropdown_listAsync(setting_id).Result.ToList());
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult util_dropdown_setting_in(util_dropdown_view_lib obj)
        {
            obj.company_id = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["CompanyId"]));
            obj.active_ds = true;
            obj.created_by = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["UserId"]));
            var result = _master.util_dropdown_setting_inAsync(obj).Result;
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult util_dropdown_setting_up(util_dropdown_view_lib obj)
        {
            obj.company_id = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["CompanyId"]));
            obj.created_by = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["UserId"]));
            var result = _master.util_dropdown_setting_upAsync(obj).Result;
            JsonResult json = Json(result);
            return json;
        }
        #endregion

        #region Warehouse
        [Authorize]
        [UserAuthentication(form = 8)]
        public IActionResult warehouse()
        {
            ViewBag.module = 8;
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult warehouse_in_up(warehouse_in_up_lib objHeader)
        {
            objHeader.company_id = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["CompanyId"]));
            objHeader.created_by = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["UserId"]));
            warehouse_in_up_lib result = _master.warehouse_in_upAsync(objHeader).Result;
            JsonResult json = Json(result);
            return json;
        }
        #endregion

        #region Approval Process
        [Authorize]
        public IActionResult approval_process()
        {
            return View();
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult modules_view(int module_id, bool is_ap, bool is_active)
        {
            string company_id = Crypto.url_decrypt(Request.Cookies["CompanyId"]);
            var result = JsonConvert.SerializeObject(_master.modules_viewAsync(module_id, is_ap, is_active).Result.ToList());
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult approval_process_in(approval_process_in_lib[] obj, int module_id, bool all, int group)
        {
            int company_id = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["CompanyId"]));
            int warehouse_id = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["WarehouseId"]));
            int created_by = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["UserId"]));
            approval_process_in_lib result =  _master.approval_process_inAsync(obj, group, module_id, all, company_id, warehouse_id, created_by).Result;
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult approval_process_view(int module_id, int group)
        {
            int company_id = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["CompanyId"]));
            int warehouse_id = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["WarehouseId"]));
            var result = JsonConvert.SerializeObject(_master.approval_process_viewAsync(module_id, group, warehouse_id, company_id).Result.ToList());
            JsonResult json = Json(result);
            return json;
        }
        #endregion

        #region Employee
        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult employee_list_view(employee_list_view_lib obj)
        {
            obj.company_id = Convert.ToInt32(Crypto.url_decrypt(Request.Cookies["CompanyId"]));
            var result = JsonConvert.SerializeObject(_master.employee_list_viewAsync(obj).Result.ToList());
            JsonResult json = Json(result);
            return json;
        }
        #endregion
    }
}