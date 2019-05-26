using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BridgeWCF.Library
{
    public class login_authentication
    {
        public int employee_id { get; set; }
        public string employee_code { get; set; }
        public string username { get; set; }
        public string userhash { get; set; }
        public int salutation_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
        public string display_name { get; set; }
        public string nick_name { get; set; }
        public int religion_id { get; set; }
        public int gender_id { get; set; }
        public int nationality_id { get; set; }
        public string birth_place { get; set; }
        public string birthday { get; set; }
        public int civil_status_id { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string blood_type { get; set; }
        public string phone_mobile { get; set; }
        public string phone_telephone { get; set; }
        public string phone_office { get; set; }
        public string phone_fax { get; set; }
        public string email_address { get; set; }
        public string present_address { get; set; }
        public string permanent_address { get; set; }
        public string image_path { get; set; }
        public int question1 { get; set; }
        public string answer1 { get; set; }
        public int question2 { get; set; }
        public string answer2 { get; set; }
        public string bp_status { get; set; }
        public bool approved { get; set; }
        public bool active { get; set; }
        public int approval_group_id { get; set; }
        public int access_level_id { get; set; }
        public int immediate_supervisor_id { get; set; }
        public int created_by { get; set; }
        public string date_created { get; set; }
        public string enc_key { get; set; }
        public int warehouse_id { get; set; }
        public int company_id { get; set; }
        public bool fix { get; set; }

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
        public string action_new { get; set; }
        public string action_view { get; set; }
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
        public int salutation_id { get; set; }
        public string salutation { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
        public string display_name { get; set; }
        public string nick_name { get; set; }
        public int religion_id { get; set; }
        public string religion { get; set; }
        public int gender_id { get; set; }
        public string gender { get; set; }
        public int nationality_id { get; set; }
        public string nationality { get; set; }
        public string birth_place { get; set; }
        public string birthday { get; set; }
        public int civil_status_id { get; set; }
        public string civil_status { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string blood_type { get; set; }
        public string phone_mobile { get; set; }
        public string phone_telephone { get; set; }
        public string phone_office { get; set; }
        public string phone_fax { get; set; }
        public string email_address { get; set; }
        public string present_address { get; set; }
        public string permanent_address { get; set; }
        public string image_path { get; set; }
        public int question1 { get; set; }
        public string answer1 { get; set; }
        public int question2 { get; set; }
        public string answer2 { get; set; }
        public string bp_status { get; set; }
        public bool approved { get; set; }
        public bool active { get; set; }
        public int approval_group_id { get; set; }
        public string approval_group { get; set; }
        public int access_level_id { get; set; }
        public string access_level { get; set; }
        public int immediate_supervisor_id { get; set; }
        public string immediate_supervisor { get; set; }
        public int created_by_id { get; set; }
        public string created_by { get; set; }
        public string date_created { get; set; }
        public string enc_key { get; set; }
        public int company_id { get; set; }
        public string company_name { get; set; }
        public bool fix { get; set; }

        public int payroll_type { get; set; }
        public string payroll_type_desc { get; set; }
        public string biometrics_id { get; set; }
        public string bank { get; set; }
        public string bankaccount { get; set; }
        public decimal basic_rate { get; set; }
        public decimal daily_rate { get; set; }
        public decimal hourly_rate { get; set; }
        public decimal semi_monthly_rate { get; set; }
        public int employee_status_id { get; set; }
        public string employee_status { get; set; }
        public int occupation_id { get; set; }
        public string occupation { get; set; }
        public int department_id { get; set; }
        public string department { get; set; }
        public string sss { get; set; }
        public string pagibig { get; set; }
        public string philhealth { get; set; }
        public string tin { get; set; }
        public string nbi { get; set; }
        public string gsis { get; set; }
        public string date_hired { get; set; }
        public int division_id { get; set; }
        public string division { get; set; }
        public int section_id { get; set; }
        public string section { get; set; }
        public int confidentiality_id { get; set; }
        public string confidentiality { get; set; }
        public int supervisor { get; set; }
        public string supervisor_desc { get; set; }
        public int warehouse { get; set; }
        public string warehouse_desc { get; set; }
        public bool is_fixed_salary { get; set; }
        public bool is_tardiness_deduction { get; set; }
        public bool is_without_ot { get; set; }
        public string button { get; set; }
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

    public class payroll_type_view_lib
    {
        public int payroll_type_id { get; set; }
        public string description { get; set; }
        public bool is_per_cut_off { get; set; }
        public bool is_per_month { get; set; }
        public bool is_per_day { get; set; }
        public bool is_per_hr { get; set; }
        public int cutoff_from { get; set; }
        public int cutoff_to { get; set; }
        public string date_created { get; set; }
    }

    public class employee_in_lib
    {
        public int employee_id { get; set; }
        public string username { get; set; }
        public string userhash { get; set; }
        public int salutation_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string display_name { get; set; }
        public string nick_name { get; set; }
        public int religion_id { get; set; }
        public int gender_id { get; set; }
        public int nationality_id { get; set; }
        public string birth_place { get; set; }
        public string birthday { get; set; }
        public int civil_status_id { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string blood_type { get; set; }
        public string phone_mobile { get; set; }
        public string phone_telephone { get; set; }
        public string phone_office { get; set; }
        public string phone_fax { get; set; }
        public string email_address { get; set; }
        public string present_address { get; set; }
        public string permanent_address { get; set; }
        public string image_path { get; set; }
        public int question1 { get; set; }
        public string answer1 { get; set; }
        public int question2 { get; set; }
        public string answer2 { get; set; }
        public bool active { get; set; }
        public int approval_group_id { get; set; }
        public int access_level_id { get; set; }
        public int immediate_supervisor_id { get; set; }
        public int created_by { get; set; }
        public string date_created { get; set; }
        public int company_id { get; set; }
        public bool fix { get; set; }
    }

    public class employee_information_in_lib
    {
        public int employee_id { get; set; }
        public int payroll_type { get; set; }
        public string payroll_type_desc { get; set; }
        public string biometrics_id { get; set; }
        public string bank { get; set; }
        public string bankaccount { get; set; }
        public decimal basic_rate { get; set; }
        public decimal daily_rate { get; set; }
        public decimal hourly_rate { get; set; }
        public decimal semi_monthly_rate { get; set; }
        public int employee_status_id { get; set; }
        public string employee_status { get; set; }
        public int occupation_id { get; set; }
        public string occupation { get; set; }
        public int department_id { get; set; }
        public string department { get; set; }
        public string sss { get; set; }
        public string pagibig { get; set; }
        public string philhealth { get; set; }
        public string tin { get; set; }
        public string nbi { get; set; }
        public string gsis { get; set; }
        public string date_hired { get; set; }
        public int division_id { get; set; }
        public string division { get; set; }
        public int section_id { get; set; }
        public string section { get; set; }
        public int confidentiality { get; set; }
        public string confidentiality_desc { get; set; }
        public int supervisor { get; set; }
        public string supervisor_desc { get; set; }
        public int warehouse { get; set; }
        public string warehouse_desc { get; set; }
        public bool is_fixed_salary { get; set; }
        public bool is_tardiness_deduction { get; set; }
        public bool is_without_ot { get; set; }
    }

    public class employee_relative_in_lib
    {
        public int employee_id { get; set; }
        public string name { get; set; }
        public int relationship_id { get; set; }
        public string relationship { get; set; }
        public string birthday { get; set; }
        public int gender_id { get; set; }
        public string gender { get; set; }
        public string occupation { get; set; }
        public string company { get; set; }
    }

    public class employee_emergency_in_lib
    {
        public int employee_id { get; set; }
        public string name { get; set; }
        public int relationship_id { get; set; }
        public string relationship { get; set; }
        public string address { get; set; }
        public string contact_number { get; set; }
    }

    public class employee_employment_in_lib
    {
        public int employee_id { get; set; }
        public string company { get; set; }
        public string position { get; set; }
        public decimal salary { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public string reason { get; set; }
    }

    public class employee_education_in_lib
    {
        public int employee_id { get; set; }
        public string name { get; set; }
        public int type_id { get; set; }
        public string type { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public string awards { get; set; }
    }

    public class employee_degree_in_lib
    {
        public int employee_id { get; set; }
        public string name { get; set; }
        public string course { get; set; }
        public string major { get; set; }
    }

    public class series_view_lib
    {
        public int series_id { get; set; }
        public int module_id { get; set; }
        public string module_name { get; set; }
        public string prefix { get; set; }
        public int series_num { get; set; }
        public int company_id { get; set; }
        public bool active { get; set; }
        public int year { get; set; }
        public string series_code { get; set; }
    }
}