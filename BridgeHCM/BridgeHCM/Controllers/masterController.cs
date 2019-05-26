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
    public class masterController : Controller
    {
        wcf_Master.Master_ServiceClient _master = new wcf_Master.Master_ServiceClient();
        public IActionResult Index()
        {
            return View();
        }
        #region Employee
        [Authorize]
        [UserAuthentication(form = 11)]
        public IActionResult employee_list()
        {
            return View();
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult employee_list_view(employee_list_view_lib obj)
        {
            obj.company_id = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["CompanyId"]));
            var result = JsonConvert.SerializeObject(_master.employee_list_viewAsync(obj).Result.ToList());
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult employee_sel(employee_list_view_lib obj)
        {
            obj.company_id = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["CompanyId"]));
            var result = JsonConvert.SerializeObject(_master.employee_selAsync(obj).Result.ToList());
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult employee_fetch_view(int employee_id, int row, int index)
        {
            int company_id = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["CompanyId"]));
            var result = JsonConvert.SerializeObject(_master.employee_fetch_viewAsync(employee_id, company_id, row, index).Result.ToList());
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [UserAuthentication(form = 11, view = true)]
        public IActionResult employee_create(string b)
        {
            var ctr = b != null ? Crypto.password_decrypt(b.Replace(" ", "+")) : "0";
            ViewData["transaction_id"] = b != null ? Crypto.password_decrypt(b.Replace(" ", "+")) : "0";
            ViewBag.module = 11;
            return View();
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult employee_search(string search)
        {
            int company_id = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["CompanyId"]));
            var result = JsonConvert.SerializeObject(_master.employee_searchAsync(search, company_id).Result.ToList());
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [HttpPost()]
        [ValidateAntiForgeryToken]
        public JsonResult employee_in_up(employee_in_lib objPersonal, employee_information_in_lib objPayroll, employee_relative_in_lib[] objRelative,
            employee_emergency_in_lib[] objEmergency, employee_employment_in_lib[] objEmployment, employee_education_in_lib[] objEducation, employee_degree_in_lib[] objDegree, bool oldPath)
        {
            objPersonal.company_id = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["CompanyId"]));
            objPersonal.created_by = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["UserId"]));
            int approval_group_id = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["ApprovalGroupId"]));
            var result = _master.employee_in_upAsync(objPersonal, objPayroll, objRelative, objEmergency, objEmployment, objEducation, objDegree, approval_group_id, oldPath).Result;
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        public IActionResult employee_profile(employee_profile_model model, string url)
        {
            employee_list_view_lib obj = new employee_list_view_lib();
            util_dropdown_view_lib obj2 = new util_dropdown_view_lib();
            obj.active = false;
            obj.approved = false;
            obj.employee_id = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["UserId"]));
            obj.company_id = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["CompanyId"]));
            model.personal = _master.employee_list_viewAsync(obj).Result.FirstOrDefault();
            model.information = _master.employee_information_viewAsync(obj.employee_id).Result.FirstOrDefault();
            model.relative = _master.employee_relative_viewAsync(obj.employee_id).Result.ToList();
            model.emergency = _master.employee_emergency_viewAsync(obj.employee_id).Result.ToList();
            model.employment = _master.employee_employment_viewAsync(obj.employee_id).Result.ToList();
            model.education = _master.employee_education_viewAsync(obj.employee_id).Result.ToList();
            model.degree = _master.employee_degree_viewAsync(obj.employee_id).Result.ToList();
            model.question = _master.util_dropdown_viewAsync(16, false, 0, obj.company_id).Result.ToList();
            ViewBag.displayName = model.personal.display_name;
            ViewBag.occupation = model.information.occupation;
            ViewBag.path = model.personal.image_path;
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult employee_profile(employee_profile_model model)
        {
            model.personal.employee_id = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["UserId"]));
            var cont = _master.employee_credentials_upAsync(model.personal).Result;
            employee_list_view_lib obj = new employee_list_view_lib();
            util_dropdown_view_lib obj2 = new util_dropdown_view_lib();
            obj.active = false;
            obj.approved = false;
            obj.employee_id = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["UserId"]));
            obj.company_id = Convert.ToInt32(Crypto.password_decrypt(Request.Cookies["CompanyId"]));
            model.personal = _master.employee_list_viewAsync(obj).Result.FirstOrDefault();
            model.information = _master.employee_information_viewAsync(obj.employee_id).Result.FirstOrDefault();
            model.relative = _master.employee_relative_viewAsync(obj.employee_id).Result.ToList();
            model.emergency = _master.employee_emergency_viewAsync(obj.employee_id).Result.ToList();
            model.employment = _master.employee_employment_viewAsync(obj.employee_id).Result.ToList();
            model.education = _master.employee_education_viewAsync(obj.employee_id).Result.ToList();
            model.degree = _master.employee_degree_viewAsync(obj.employee_id).Result.ToList();
            model.question = _master.util_dropdown_viewAsync(16, false, 0, obj.company_id).Result.ToList();
            ViewBag.displayName = model.personal.display_name;
            ViewBag.occupation = model.information.occupation;
            ViewBag.path = model.personal.image_path;
            ViewBag.success = true;
            return View(model);
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult employee_relative_view(int employee_id)
        {
            var result = _master.employee_relative_viewAsync(employee_id).Result.ToList();
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult employee_emergency_view(int employee_id)
        {
            var result = _master.employee_emergency_viewAsync(employee_id).Result.ToList();
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult employee_employment_view(int employee_id)
        {
            var result = _master.employee_employment_viewAsync(employee_id).Result.ToList();
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult employee_education_view(int employee_id)
        {
            var result = _master.employee_education_viewAsync(employee_id).Result.ToList();
            JsonResult json = Json(result);
            return json;
        }

        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult employee_degree_view(int employee_id)
        {
            var result = _master.employee_degree_viewAsync(employee_id).Result.ToList();
            JsonResult json = Json(result);
            return json;
        }
        #endregion

        #region Payroll Information
        [Authorize]
        [HttpGet()]
        [ValidateAntiForgeryToken]
        public JsonResult payroll_type_view(int payroll_type_id)
        {
            var result = _master.payroll_type_viewAsync(payroll_type_id).Result;
            JsonResult json = Json(result);
            return json;
        }
        #endregion
    }
}