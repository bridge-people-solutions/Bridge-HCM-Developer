using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using wcf_Master;
namespace BridgeHCM
{
    public class UserAuthenticationAttribute : ActionFilterAttribute
    {
        public int form { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string redirectTo = string.Format("~/Authentication/error_403");
            try
            {
                wcf_Master.Master_ServiceClient _master = new wcf_Master.Master_ServiceClient();
                var test = Crypto.url_decrypt(filterContext.HttpContext.Request.Cookies["CompanyId"]);
                var company_id = Convert.ToInt32(Crypto.url_decrypt(filterContext.HttpContext.Request.Cookies["CompanyId"]));
                var access_level_id = Convert.ToInt32(Crypto.url_decrypt(filterContext.HttpContext.Request.Cookies["AccessLevelId"]));
                var transaction_id = 0; //Convert.ToInt32(filterContext.HttpContext.Request.Query["b"].ToString());
                string top_menu = "";
                string bot_menu = "";

                List<menu_view_restriction_lib> resp = _master.menu_view_restrictionAsync(access_level_id, form, company_id).Result.ToList();
                if (resp.Count > 0)
                {
                    foreach (var x in resp)
                    {
                        if (transaction_id != 0)
                        {
                            if (x.enable_views != true)
                            {
                                //-- if created vs login enable --//
                                filterContext.HttpContext.Response.Redirect(redirectTo, true);
                            }
                            if (x.enable_modify)
                            {
                                //-- if created vs login enable --//
                                //-- enable save button--//
                                bot_menu = "<button class='btn btn-out-dashed waves-effect waves-light btn-inverse btn-square pull-right' type='button' ng-click='submit();'>Save Changes</button>";
                            }
                            if (x.enable_new)
                            {
                                top_menu += "<button class='btn btn-sm waves-effect waves-light btn-primary'><i class='icofont icofont-ui-edit'></i><strong>New Transaction</strong></button>"
                                    + "<div class='or or-sm'></div>";
                            }
                            if (x.duplicate == true)
                            {
                                top_menu += "<button class='btn btn-sm waves-effect waves-light btn-primary'><i class='icofont icofont-ui-copy'></i><strong>Duplicate</strong></button>"
                                    + "<div class='or or-sm'></div>";
                            }
                            if (x.enable_prints == true)
                            {
                                top_menu += "<button class='btn btn-sm waves-effect waves-light btn-primary'><i class='icofont icofont-printer'></i><strong>Print</strong></button>"
                                    + "<div class='or or-sm'></div>";
                            }
                        }
                        else
                        {
                            if (x.enable_new)
                            {
                                //-- enable save button--//
                                top_menu += "<button class='btn btn-sm waves-effect waves-light btn-primary'><i class='icofont icofont-ui-edit'></i><strong>New Transaction</strong></button>"
                                    + "<div class='or or-sm'></div>";

                                bot_menu = "<button class='btn btn-out-dashed waves-effect waves-light btn-inverse btn-square pull-right' type='button' ng-click='submit();'>Save Changes</button>";
                            }
                        }

                    }
                }
                else
                {

                }
                var controller = filterContext.Controller as Controller;
                controller.ViewBag.TopMenu = top_menu;
                controller.ViewBag.BotMenu = bot_menu;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                filterContext.HttpContext.Response.Redirect(redirectTo, true);
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
