using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BridgeWCF.Library
{
    public class login_authentication
    {
        public int user_id { get; set; }
        public string user_code { get; set; }
        public string username { get; set; }
        public string userhash { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
        public string display_name { get; set; }
        public string nick_name { get; set; }
        public string email_address { get; set; }
        public string birthday { get; set; }
        public string birth_place { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string phone_home { get; set; }
        public string phone_work { get; set; }
        public string phone_mobile { get; set; }
        public string phone_fax { get; set; }
        public string phone_other { get; set; }
        public string address_street { get; set; }
        public string address_city { get; set; }
        public string address_state { get; set; }
        public string address_country { get; set; }
        public string address_zipcode { get; set; }
        public string perm_street { get; set; }
        public string perm_city { get; set; }
        public string perm_state { get; set; }
        public string perm_country { get; set; }
        public string perm_zipcode { get; set; }
        public string image_path { get; set; }
        public int question1 { get; set; }
        public string answer1 { get; set; }
        public int question2 { get; set; }
        public string answer2 { get; set; }
        public string website { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string instagram { get; set; }
        public string linkedin { get; set; }
        public string skype { get; set; }
        public string tumblr { get; set; }
        public int salutation_id { get; set; }
        public int gender_id { get; set; }
        public int civil_status_id { get; set; }
        public int nationality_id { get; set; }
        public int religion_id { get; set; }
        public int user_group_id { get; set; }
        public int access_level_id { get; set; }
        public int warehouse_id { get; set; }
        public int company_id { get; set; }
        public int active { get; set; }
        public int created_by { get; set; }
        public string date_created { get; set; }
        public int approved { get; set; }
        public string bp_status { get; set; }
        public string enc_key { get; set; }
    }

    public class menu_view_restriction_lib
    {
        public int parent_module_id { get; set; }
        public int module_id { get; set; }
        public string module_name { get; set; }
        public bool module_type { get; set; }
        public string class_ { get; set; }
        public int access_level_id { get; set; }
        public int warehouse_id { get; set; }
        public int company_id { get; set; }
        public string action { get; set; }
        public string controller { get; set; }
        public string url { get; set; }
        public int seqn { get; set; }
        public bool new_ { get; set; }
        public bool enable_new { get; set; }
        public bool modify { get; set; }
        public bool enable_modify { get; set; }
        public bool views { get; set; }
        public bool enable_views { get; set; }
        public bool prints { get; set; }
        public bool enable_prints { get; set; }
        public bool duplicate { get; set; }
        public bool enable_duplicate { get; set; }
        public bool others1 { get; set; }
        public bool enable_others1 { get; set; }
        public bool others2 { get; set; }
        public bool enable_others2 { get; set; }
        public bool others3 { get; set; }
        public bool enable_others3 { get; set; }
        public bool others4 { get; set; }
        public bool enable_others4 { get; set; }
        public bool others5 { get; set; }
        public bool enable_others5 { get; set; }
        public int view_all { get; set; }
        public int enable_view_all { get; set; }
        public bool active { get; set; }
        public int created_by { get; set; }
    }

    public class util_dropdown_view_lib
    {
        public int setting_id_dms { get; set; }
        public int setting_id_ds { get; set; }
        public string setting_type { get; set; }
        public string description { get; set; }
        public int company_id { get; set; }
        public string company_name { get; set; }
        public int created_by { get; set; }
        public string display_name { get; set; }
        public string date_created_dms { get; set; }
        public string date_created_ds { get; set; }
        public bool active_dms { get; set; }
        public bool active_ds { get; set; }
        public string active_switch_dms { get; set; }
        public string active_switch_ds { get; set; }
    }

    public class util_dropdown_list_lib
    {
        public int setting_id { get; set; }
        public string setting_type { get; set; }
        public bool active { get; set; }
        public string date_created { get; set; }
    }

    public class warehouse_in_up_lib
    {
        public int warehouse_id { get; set; }
        public string warehouse_code { get; set; }
        public string image_path { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tin { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int created_by { get; set; }
        public int company_id { get; set; }
        public bool active { get; set; }
        public bool approved { get; set; }
        public string bp_status { get; set; }
    }

    public class file_manager_in_lib
    {
        public int module_id { get; set; }
        public int transaction_id { get; set; }
        public string file_name { get; set; }
        public string file_extension { get; set; }
        public string file_path { get; set; }
        public int created_by { get; set; }
        public int warehouse_id { get; set; }
        public int company_id { get; set; }
    }

    public class employee_list_view_lib
    {
        public int employee_id { get; set; }
        public string employee_code { get; set; }
        public string username { get; set; }
        public string userhash { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
        public string display_name { get; set; }
        public string nick_name { get; set; }
        public string email_address { get; set; }
        public string birthday { get; set; }
        public string birth_place { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string phone_home { get; set; }
        public string phone_work { get; set; }
        public string phone_mobile { get; set; }
        public string phone_fax { get; set; }
        public string phone_other { get; set; }
        public string address_street { get; set; }
        public string address_city { get; set; }
        public string address_state { get; set; }
        public string address_country { get; set; }
        public string address_zipcode { get; set; }
        public string perm_street { get; set; }
        public string perm_city { get; set; }
        public string perm_state { get; set; }
        public string perm_country { get; set; }
        public string perm_zipcode { get; set; }
        public string image_path { get; set; }
        public int question1 { get; set; }
        public string answer1 { get; set; }
        public int question2 { get; set; }
        public string answer2 { get; set; }
        public string website { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string instagram { get; set; }
        public string linkedin { get; set; }
        public string skype { get; set; }
        public string tumblr { get; set; }
        public int salutation_id { get; set; }
        public int gender_id { get; set; }
        public int civil_status_id { get; set; }
        public int nationality_id { get; set; }
        public int religion_id { get; set; }
        public int user_group_id { get; set; }
        public int warehouse_id { get; set; }
        public int company_id { get; set; }
        public bool active { get; set; }
        public int created_by { get; set; }
        public string date_created { get; set; }
        public bool approved { get; set; }
        public string bp_status { get; set; }
        public string enc_key { get; set; }
        public bool fix { get; set; }
        public int access_level_id { get; set; }
    }

    public class approval_process_in_lib
    {
        public int module_id { get; set; }
        public string status { get; set; }
        public int seq { get; set; }
        public int approval_group_id { get; set; }
        public int employee_id { get; set; }
        public string full_name { get; set; }
        public int warehouse_id { get; set; }
        public int company_id { get; set; }
        public bool active { get; set; }
        public int created_by { get; set; }
        public List<employee_list_view_lib> employee { get; set; }
}

    public class warehouse_view_lib
    {
      public int warehouse_id { get; set; }
      public string warehouse_code { get; set; }
      public string image_path { get; set; }
      public string name { get; set; }
      public string description { get; set; }
      public string tin { get; set; }
      public string phone { get; set; }
      public string fax { get; set; }
      public string email { get; set; }
      public string address { get; set; }
      public int created_by { get; set; }
      public string date_created { get; set; }
      public int company_id { get; set; }
      public bool active { get; set; }
      public bool approved { get; set; }
      public string bp_status { get; set; }
    }
}