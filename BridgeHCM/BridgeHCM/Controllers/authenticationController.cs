using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wcf_Master;
using BridgeHCM.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace BridgeHCM.Controllers
{
    public class authenticationController : Controller
    {
        wcf_Master.Master_ServiceClient _master = new wcf_Master.Master_ServiceClient();

        #region Login
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(login model)
        {
            string pass = Crypto.password_encrypt(model.userhash);
            login_authentication resp = _master.user_authenticateAsync(model.username, pass).Result;

            ClaimsIdentity identity = null;
            if (resp.username != null)
            {
                CookieOptions options = new CookieOptions();
                if(model.remember_me != true)
                {
                    options.Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                    options.Expires = DateTime.Now.AddDays(365);
                }

                Response.Cookies.Append("UserId", Crypto.password_encrypt(resp.employee_id.ToString()), options);
                Response.Cookies.Append("WarehouseId", Crypto.password_encrypt(resp.warehouse_id.ToString()), options);
                Response.Cookies.Append("CompanyId", Crypto.password_encrypt(resp.company_id.ToString()), options);
                Response.Cookies.Append("AccessLevelId", Crypto.password_encrypt(resp.access_level_id.ToString()), options);
                Response.Cookies.Append("ApprovalGroupId", Crypto.password_encrypt(resp.approval_group_id.ToString()), options);
                Response.Cookies.Append("DisplayName", resp.display_name.ToString(), options);

                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, model.username),
                    new Claim(ClaimTypes.Role, resp.approval_group_id.ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            CookieOptions option = new CookieOptions();
            if (Request.Cookies[".AspNetCore.Session"] != null)
            {
                option.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Append(".AspNetCore.Session", "", option);
            }
            option.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Append("UserId", "", option);
            Response.Cookies.Append("WarehouseId", "", option);
            Response.Cookies.Append("CompanyId", "", option);
            Response.Cookies.Append("AccessLevelId", "", option);
            Response.Cookies.Append("DisplayName", "", option);
            return RedirectToAction("Login", "authentication");
        }
        #endregion

        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Authorize]
        public IActionResult Change_Log()
        {
            return View();
        }

        public IActionResult Coming_Soon()
        {
            return View();
        }

        public IActionResult error_403()
        {
            return View();
        }
    }
}