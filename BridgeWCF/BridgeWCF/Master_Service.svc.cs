using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using BridgeWCF.Library;

namespace BridgeWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Master_Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Master_Service.svc or Master_Service.svc.cs at the Solution Explorer and start debugging.
    public class Master_Service : IMaster_Service
    {
        string _master = ConfigurationManager.ConnectionStrings["DB_Master"].ConnectionString;

        #region Global Function
        public login_authentication user_authenticate(string username, string userhash)
        {
            login_authentication ret = new login_authentication();
            DataTable dt = new DataTable();
            try
            {
                SqlConnection oConn = new SqlConnection(_master);
                SqlTransaction oTrans;
                oConn.Open();
                oTrans = oConn.BeginTransaction();
                SqlCommand oCmd = new SqlCommand();
                oCmd.Connection = oConn;
                oCmd.Transaction = oTrans;
                oCmd.CommandText = "login_authentication";
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Clear();
                oCmd.Parameters.AddWithValue("@username", username);
                oCmd.Parameters.AddWithValue("@userhash", userhash);
                SqlDataReader sdr = oCmd.ExecuteReader();
                while (sdr.Read())
                {
                    ret.employee_id = Convert.ToInt32(sdr["employee_id"].ToString());
                    ret.employee_code = sdr["employee_code"].ToString();
                    ret.username = sdr["username"].ToString();
                    ret.userhash = sdr["userhash"].ToString();
                    ret.salutation_id = Convert.ToInt32(sdr["salutation_id"].ToString());
                    ret.first_name = sdr["first_name"].ToString();
                    ret.middle_name = sdr["middle_name"].ToString();
                    ret.last_name = sdr["last_name"].ToString();
                    ret.full_name = sdr["full_name"].ToString();
                    ret.display_name = sdr["display_name"].ToString();
                    ret.nick_name = sdr["nick_name"].ToString();
                    ret.religion_id = Convert.ToInt32(sdr["religion_id"].ToString());
                    ret.gender_id = Convert.ToInt32(sdr["gender_id"].ToString());
                    ret.nationality_id = Convert.ToInt32(sdr["nationality_id"].ToString());
                    ret.birth_place = sdr["birth_place"].ToString();
                    ret.birthday = sdr["birthday"].ToString();
                    ret.civil_status_id = Convert.ToInt32(sdr["civil_status_id"].ToString());
                    ret.height = sdr["height"].ToString();
                    ret.weight = sdr["weight"].ToString();
                    ret.blood_type = sdr["blood_type"].ToString();
                    ret.phone_mobile = sdr["phone_mobile"].ToString();
                    ret.phone_telephone = sdr["phone_telephone"].ToString();
                    ret.phone_office = sdr["phone_office"].ToString();
                    ret.phone_fax = sdr["phone_fax"].ToString();
                    ret.email_address = sdr["email_address"].ToString();
                    ret.present_address = sdr["present_address"].ToString();
                    ret.permanent_address = sdr["permanent_address"].ToString();
                    ret.image_path = sdr["image_path"].ToString();
                    ret.question1 = Convert.ToInt32(sdr["question1"].ToString());
                    ret.answer1 = sdr["answer1"].ToString();
                    ret.question2 = Convert.ToInt32(sdr["question2"].ToString());
                    ret.answer2 = sdr["answer2"].ToString();
                    ret.bp_status = sdr["bp_status"].ToString();
                    ret.approved = Convert.ToBoolean(sdr["approved"].ToString());
                    ret.active = Convert.ToBoolean(sdr["active"].ToString());
                    ret.approval_group_id = Convert.ToInt32(sdr["approval_group_id"].ToString());
                    ret.access_level_id = Convert.ToInt32(sdr["access_level_id"].ToString());
                    ret.immediate_supervisor_id = Convert.ToInt32(sdr["immediate_supervisor_id"].ToString());
                    ret.created_by = Convert.ToInt32(sdr["created_by"].ToString());
                    ret.date_created = sdr["date_created"].ToString();
                    ret.enc_key = sdr["enc_key"].ToString();
                    ret.warehouse_id = Convert.ToInt32(sdr["company_id"].ToString());
                    ret.company_id = Convert.ToInt32(sdr["company_id"].ToString());
                    ret.fix = Convert.ToBoolean(sdr["fix"].ToString());
                }
                sdr.Close();
                oConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = login_users_view_sel | " + e.Message, Convert.ToInt32(ret.company_id), 0);
            }

            return ret;
        }

        public series_view_lib series_view(int module_id, int company_id)
        {
            series_view_lib ret = new series_view_lib();
            DataTable dt = new DataTable();
            try
            {
                SqlConnection oConn = new SqlConnection(_master);
                SqlTransaction oTrans;
                oConn.Open();
                oTrans = oConn.BeginTransaction();
                SqlCommand oCmd = new SqlCommand();
                oCmd.Connection = oConn;
                oCmd.Transaction = oTrans;
                oCmd.CommandText = "series_view";
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Clear();
                oCmd.Parameters.AddWithValue("@module_id", module_id);
                oCmd.Parameters.AddWithValue("@company_id", company_id);
                SqlDataReader sdr = oCmd.ExecuteReader();
                while (sdr.Read())
                {
                    ret.series_id = Convert.ToInt32(sdr["series_id"].ToString());
                    ret.module_id = Convert.ToInt32(sdr["module_id"].ToString());
                    ret.module_name = sdr["module_name"].ToString();
                    ret.prefix = sdr["prefix"].ToString();
                    ret.series_num = Convert.ToInt32(sdr["series_num"].ToString());
                    ret.company_id = Convert.ToInt32(sdr["company_id"].ToString());
                    ret.active = Convert.ToBoolean(sdr["active"].ToString());
                    ret.year = Convert.ToInt32(sdr["year"].ToString());
                    ret.series_code = sdr["series_code"].ToString();
                }
                sdr.Close();
                oConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = series_view | " + e.Message, Convert.ToInt32(ret.company_id), 0);
            }

            return ret;
        }

        public List<menu_view_restriction_lib> menu_view_restriction(int access_level_id, int module_id, int company_id)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<menu_view_restriction_lib> ret = new List<menu_view_restriction_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "menu_view_restriction";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@access_level_id", access_level_id);
                sqlcomm.Parameters.AddWithValue("@module_id", module_id);
                sqlcomm.Parameters.AddWithValue("@company_id", company_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new menu_view_restriction_lib()
                       {
                           parent_module_id = Convert.ToInt32(dr["parent_module_id"].ToString()),
                           module_id = Convert.ToInt32(dr["module_id"].ToString()),
                           module_name = dr["module_name"].ToString(),
                           module_type = Convert.ToBoolean(dr["module_type"].ToString()),
                           class_ = dr["class"].ToString(),
                           access_level_id = Convert.ToInt32(dr["access_level_id"].ToString()),
                           company_id = Convert.ToInt32(dr["company_id"].ToString()),
                           action = dr["action"].ToString(),
                           action_new = dr["action_new"].ToString(),
                           action_view = dr["action_view"].ToString(),
                           controller = dr["controller"].ToString(),
                           url = dr["url"].ToString(),
                           seqn = Convert.ToInt32(dr["seqn"].ToString()),
                           new_ = Convert.ToBoolean(dr["new"].ToString()),
                           enable_new = Convert.ToBoolean(dr["enable_new"].ToString()),
                           modify = Convert.ToBoolean(dr["modify"].ToString()),
                           enable_modify = Convert.ToBoolean(dr["enable_modify"].ToString()),
                           views = Convert.ToBoolean(dr["views"].ToString()),
                           enable_views = Convert.ToBoolean(dr["enable_views"].ToString()),
                           prints = Convert.ToBoolean(dr["prints"].ToString()),
                           enable_prints = Convert.ToBoolean(dr["enable_prints"].ToString()),
                           duplicate = Convert.ToBoolean(dr["duplicate"].ToString()),
                           enable_duplicate = Convert.ToBoolean(dr["enable_duplicate"].ToString()),
                           others1 = Convert.ToBoolean(dr["others1"].ToString()),
                           enable_others1 = Convert.ToBoolean(dr["enable_others1"].ToString()),
                           others2 = Convert.ToBoolean(dr["others2"].ToString()),
                           enable_others2 = Convert.ToBoolean(dr["enable_others2"].ToString()),
                           others3 = Convert.ToBoolean(dr["others3"].ToString()),
                           enable_others3 = Convert.ToBoolean(dr["enable_others3"].ToString()),
                           others4 = Convert.ToBoolean(dr["others4"].ToString()),
                           enable_others4 = Convert.ToBoolean(dr["enable_others4"].ToString()),
                           others5 = Convert.ToBoolean(dr["others5"].ToString()),
                           enable_others5 = Convert.ToBoolean(dr["enable_others5"].ToString()),
                           view_all = Convert.ToInt32(dr["view_all"].ToString()),
                           enable_view_all = Convert.ToInt32(dr["enable_view_all"].ToString())
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = menu_view_restriction | " + e.Message, Convert.ToInt32(company_id), 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public List<util_dropdown_view_lib> util_dropdown_view(int setting_id, bool active, int setting_type_id, int company_id)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<util_dropdown_view_lib> ret = new List<util_dropdown_view_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "util_dropdown_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@setting_id", setting_id);
                sqlcomm.Parameters.AddWithValue("@setting_type_id", setting_type_id);
                sqlcomm.Parameters.AddWithValue("@active", active);
                sqlcomm.Parameters.AddWithValue("@company_id", company_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new util_dropdown_view_lib()
                       {
                           setting_id_dms = Convert.ToInt32(dr["setting_id_dms"].ToString()),
                           setting_id_ds = Convert.ToInt32(dr["setting_id_ds"].ToString()),
                           setting_type = dr["setting_type"].ToString(),
                           description = dr["description"].ToString(),
                           company_id = Convert.ToInt32(dr["company_id"].ToString()),
                           company_name = dr["company_name"].ToString(),
                           created_by = Convert.ToInt32(dr["created_by"].ToString()),
                           display_name = dr["display_name"].ToString(),
                           date_created_dms = dr["date_created_dms"].ToString(),
                           date_created_ds = dr["date_created_ds"].ToString(),
                           active_dms = Convert.ToBoolean(dr["active_dms"].ToString()),
                           active_ds = Convert.ToBoolean(dr["active_ds"].ToString()),
                           active_switch_dms = dr["active_switch_dms"].ToString(),
                           active_switch_ds = dr["active_switch_ds"].ToString()

                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = util_dropdown_view_lib | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public void error_log_in(string transaction_id, string error_log, Int32 company_id, Int32 created_by)
        {
            string path = HttpContext.Current.Server.MapPath("~");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = path + "Error.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("-----------------------------------------------------------------------------");
                sw.WriteLine("Error : " + error_log.ToString());
                sw.WriteLine("Date : " + DateTime.Now.ToString());
                sw.WriteLine("Transaction Id : " + transaction_id);
                sw.WriteLine("Company Id : " + company_id.ToString());
                sw.WriteLine("Created By : " + created_by.ToString());
                sw.WriteLine();
                sw.Flush();
                sw.Close();
            }
        }

        public int file_manager_in(file_manager_in_lib objHeader)
        {
            int ret = 1;
            SqlConnection oConn = new SqlConnection(_master);
            SqlTransaction oTrans;
            oConn.Open();
            oTrans = oConn.BeginTransaction();
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = oConn;
            oCmd.Transaction = oTrans;
            try
            {
                oCmd.CommandText = "file_manager_in";
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Clear();
                oCmd.Parameters.AddWithValue("@module_id", objHeader.module_id);
                oCmd.Parameters.AddWithValue("@transaction_id", objHeader.transaction_id);
                oCmd.Parameters.AddWithValue("@file_name", objHeader.file_name);
                oCmd.Parameters.AddWithValue("@file_extension", objHeader.file_extension);
                oCmd.Parameters.AddWithValue("@file_path", objHeader.file_path);
                oCmd.Parameters.AddWithValue("@created_by", objHeader.created_by);
                oCmd.Parameters.AddWithValue("@warehouse_id", objHeader.warehouse_id);
                oCmd.Parameters.AddWithValue("@company_id", objHeader.company_id);
                oCmd.ExecuteNonQuery();
                oTrans.Commit();
            }
            catch (Exception e)
            {
                oTrans.Rollback();
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = file_manager_in | " + e.Message, objHeader.company_id, objHeader.created_by);
                ret = 0;
            }
            finally
            {
                oConn.Close();

            }
            return ret;
        }

        public void function_encrypt(int module_id, int id, int company_id, int created_by, SqlCommand oCmd)
        {
            try
            {
                var enc_key = Crypto.password_encrypt(id.ToString());
                oCmd.CommandText = "util_encrypt_up";
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Clear();
                oCmd.Parameters.AddWithValue("@module_id", module_id);
                oCmd.Parameters.AddWithValue("@id", id);
                oCmd.Parameters.AddWithValue("@enc_key", enc_key);
                oCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = util_encrypt_up | " + e.Message, company_id, created_by);
            }
        }

        public void function_approval(int module_id, int transaction_id, int approval_group_id, int company_id, int created_by, SqlCommand oCmd)
        {
            try
            {
                oCmd.CommandText = "util_approval_process_up";
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Clear();
                oCmd.Parameters.AddWithValue("@module_id", module_id);
                oCmd.Parameters.AddWithValue("@transaction_id", transaction_id);
                oCmd.Parameters.AddWithValue("@approval_group_id", approval_group_id);
                oCmd.Parameters.AddWithValue("@company_id", company_id);
                oCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = util_approval_process_up | " + e.Message, company_id, created_by);
            }
        }
        #endregion

        #region Module Access
        public List<menu_view_restriction_lib> modules_access_view(int access_level_id, int module_id, int company_id)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<menu_view_restriction_lib> ret = new List<menu_view_restriction_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "modules_access_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@access_level_id", access_level_id);
                sqlcomm.Parameters.AddWithValue("@module_id", module_id);
                sqlcomm.Parameters.AddWithValue("@company_id", company_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new menu_view_restriction_lib()
                       {
                           module_id = Convert.ToInt32(dr["module_id"].ToString()),
                           module_name = dr["module_name"].ToString(),
                           module_type = Convert.ToBoolean(dr["module_type"].ToString()),
                           class_ = dr["class"].ToString(),
                           access_level_id = Convert.ToInt32(dr["access_level_id"].ToString()),
                           company_id = Convert.ToInt32(dr["company_id"].ToString()),
                           action = dr["action"].ToString(),
                           controller = dr["controller"].ToString(),
                           new_ = Convert.ToBoolean(dr["new"].ToString()),
                           enable_new = Convert.ToBoolean(dr["enable_new"].ToString()),
                           modify = Convert.ToBoolean(dr["modify"].ToString()),
                           enable_modify = Convert.ToBoolean(dr["enable_modify"].ToString()),
                           views = Convert.ToBoolean(dr["views"].ToString()),
                           enable_views = Convert.ToBoolean(dr["enable_views"].ToString()),
                           prints = Convert.ToBoolean(dr["prints"].ToString()),
                           enable_prints = Convert.ToBoolean(dr["enable_prints"].ToString()),
                           duplicate = Convert.ToBoolean(dr["duplicate"].ToString()),
                           enable_duplicate = Convert.ToBoolean(dr["enable_duplicate"].ToString()),
                           others1 = Convert.ToBoolean(dr["others1"].ToString()),
                           enable_others1 = Convert.ToBoolean(dr["enable_others1"].ToString()),
                           others2 = Convert.ToBoolean(dr["others2"].ToString()),
                           enable_others2 = Convert.ToBoolean(dr["enable_others2"].ToString()),
                           others3 = Convert.ToBoolean(dr["others3"].ToString()),
                           enable_others3 = Convert.ToBoolean(dr["enable_others3"].ToString()),
                           others4 = Convert.ToBoolean(dr["others4"].ToString()),
                           enable_others4 = Convert.ToBoolean(dr["enable_others4"].ToString()),
                           others5 = Convert.ToBoolean(dr["others5"].ToString()),
                           enable_others5 = Convert.ToBoolean(dr["enable_others5"].ToString()),
                           view_all = Convert.ToInt32(dr["view_all"].ToString()),
                           enable_view_all = Convert.ToInt32(dr["enable_view_all"].ToString()),
                           active = Convert.ToBoolean(dr["active"].ToString())
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = modules_access_view | " + e.Message, Convert.ToInt32(company_id), 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public menu_view_restriction_lib module_access_in(menu_view_restriction_lib[] obj, int company_id, int created_by)
        {
            menu_view_restriction_lib ret = new menu_view_restriction_lib();
            ret.access_level_id = 1;
            SqlConnection oConn = new SqlConnection(_master);
            SqlTransaction oTrans;
            oConn.Open();
            oTrans = oConn.BeginTransaction();
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = oConn;
            oCmd.Transaction = oTrans;
            try
            {
                oCmd.CommandText = "module_access_del";
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Clear();
                oCmd.Parameters.AddWithValue("@access_level_id", obj[0].access_level_id);
                oCmd.Parameters.AddWithValue("@company_id", company_id);
                oCmd.ExecuteNonQuery();

                foreach (var x in obj)
                {
                    oCmd.CommandText = "module_access_in";
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.Parameters.Clear();
                    oCmd.Parameters.AddWithValue("@module_id", x.module_id);
                    oCmd.Parameters.AddWithValue("@access_level_id", x.access_level_id);
                    oCmd.Parameters.AddWithValue("@created_by", created_by);
                    oCmd.Parameters.AddWithValue("@company_id", company_id);
                    oCmd.Parameters.AddWithValue("@new", x.enable_new);
                    oCmd.Parameters.AddWithValue("@modify", x.enable_modify);
                    oCmd.Parameters.AddWithValue("@views", x.enable_views);
                    oCmd.Parameters.AddWithValue("@prints", x.enable_prints);
                    oCmd.Parameters.AddWithValue("@duplicate", x.enable_duplicate);
                    oCmd.Parameters.AddWithValue("@others1", x.enable_others1);
                    oCmd.Parameters.AddWithValue("@others2", x.enable_others2);
                    oCmd.Parameters.AddWithValue("@others3", x.enable_others3);
                    oCmd.Parameters.AddWithValue("@others4", x.enable_others4);
                    oCmd.Parameters.AddWithValue("@others5", x.enable_others5);
                    oCmd.Parameters.AddWithValue("@viewAll", x.enable_view_all);
                    oCmd.ExecuteNonQuery();
                }
                oTrans.Commit();
            }
            catch (Exception e)
            {
                ret.access_level_id = 0;
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = module_access_in | " + e.Message, company_id, created_by);
                oTrans.Rollback();
            }
            finally
            {
                oConn.Close();

            }
            return ret;
        }
        #endregion

        #region System Settings
        public List<util_dropdown_list_lib> util_dropdown_list(int setting_id)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<util_dropdown_list_lib> ret = new List<util_dropdown_list_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "util_dropdown_list";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@setting_id", setting_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new util_dropdown_list_lib()
                       {
                           setting_id = Convert.ToInt32(dr["setting_id"].ToString()),
                           setting_type = dr["setting_type"].ToString(),
                           active = Convert.ToBoolean(dr["active"].ToString()),
                           date_created = dr["date_created"].ToString(),
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = util_dropdown_list | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public List<util_dropdown_view_lib> util_dropdown_setting_in(util_dropdown_view_lib obj)
        {
            List<util_dropdown_view_lib> ret = new List<util_dropdown_view_lib>();
            DataTable dt = new DataTable();
            SqlConnection oConn = new SqlConnection(_master);
            SqlTransaction oTrans;
            oConn.Open();
            oTrans = oConn.BeginTransaction();
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = oConn;
            oCmd.Transaction = oTrans;

            oCmd.CommandText = "util_dropdown_setting_in";
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Parameters.Clear();
            oCmd.Parameters.AddWithValue("@setting_type", obj.setting_id_ds);
            oCmd.Parameters.AddWithValue("@description", obj.description);
            oCmd.Parameters.AddWithValue("@company_id", obj.company_id);
            oCmd.Parameters.AddWithValue("@active", obj.active_ds);
            oCmd.Parameters.AddWithValue("@created_by", obj.created_by);
            try
            {
                oCmd.ExecuteNonQuery();
                oTrans.Commit();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = oCmd;
                oCmd.CommandText = "util_dropdown_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Clear();
                oCmd.Parameters.AddWithValue("@setting_id", obj.setting_id_ds);
                oCmd.Parameters.AddWithValue("@setting_type_id", 0);
                oCmd.Parameters.AddWithValue("@active", 0);
                oCmd.Parameters.AddWithValue("@company_id", obj.company_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new util_dropdown_view_lib()
                       {
                           setting_id_dms = Convert.ToInt32(dr["setting_id_dms"].ToString()),
                           setting_id_ds = Convert.ToInt32(dr["setting_id_ds"].ToString()),
                           setting_type = dr["setting_type"].ToString(),
                           description = dr["description"].ToString(),
                           company_id = Convert.ToInt32(dr["company_id"].ToString()),
                           company_name = dr["company_name"].ToString(),
                           created_by = Convert.ToInt32(dr["created_by"].ToString()),
                           display_name = dr["display_name"].ToString(),
                           date_created_dms = dr["date_created_dms"].ToString(),
                           date_created_ds = dr["date_created_ds"].ToString(),
                           active_dms = Convert.ToBoolean(dr["active_dms"].ToString()),
                           active_ds = Convert.ToBoolean(dr["active_ds"].ToString()),
                           active_switch_dms = dr["active_switch_dms"].ToString(),
                           active_switch_ds = dr["active_switch_ds"].ToString()

                       }).ToList();

                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = util_dropdown_setting_in | " + e.Message, obj.company_id, obj.created_by);
                oTrans.Rollback();
            }
            finally
            {
                oConn.Close();

            }
            return ret;
        }

        public int util_dropdown_setting_up(util_dropdown_view_lib obj)
        {
            int ret = 1;
            SqlConnection oConn = new SqlConnection(_master);
            SqlTransaction oTrans;
            oConn.Open();
            oTrans = oConn.BeginTransaction();
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = oConn;
            oCmd.Transaction = oTrans;

            oCmd.CommandText = "dropdown_setting_up";
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.Parameters.Clear();
            oCmd.Parameters.AddWithValue("@setting_id", obj.setting_id_ds);
            oCmd.Parameters.AddWithValue("@active", obj.active_ds);
            try
            {
                oCmd.ExecuteNonQuery();
                oTrans.Commit();
            }
            catch (Exception e)
            {
                ret = 0;
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = dropdown_setting_up | " + e.Message, obj.company_id, obj.created_by);
                oTrans.Rollback();
            }
            finally
            {
                oConn.Close();

            }
            return ret;
        }
        #endregion

        #region Warehouse
        public warehouse_in_up_lib warehouse_in_up(warehouse_in_up_lib obj)
        {
            warehouse_in_up_lib ret = new warehouse_in_up_lib();
            SqlConnection oConn = new SqlConnection(_master);
            SqlTransaction oTrans;
            oConn.Open();
            oTrans = oConn.BeginTransaction();
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = oConn;
            oCmd.Transaction = oTrans;
            try
            {
                var path = "\\Uploaded\\Images\\" + obj.company_id + "\\warehouse\\" + obj.image_path;

                oCmd.CommandText = "warehouse_in_up";
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Clear();
                oCmd.Parameters.AddWithValue("@warehouse_id", obj.warehouse_id);
                oCmd.Parameters.AddWithValue("@image_path", path);
                oCmd.Parameters.AddWithValue("@name", obj.name);
                oCmd.Parameters.AddWithValue("@description", obj.description);
                oCmd.Parameters.AddWithValue("@tin", obj.tin);
                oCmd.Parameters.AddWithValue("@phone", obj.phone);
                oCmd.Parameters.AddWithValue("@fax", obj.fax);
                oCmd.Parameters.AddWithValue("@email", obj.email);
                oCmd.Parameters.AddWithValue("@address", obj.address);
                oCmd.Parameters.AddWithValue("@created_by", obj.created_by);
                oCmd.Parameters.AddWithValue("@company_id", obj.company_id);
                oCmd.Parameters.AddWithValue("@active", obj.active);

                SqlDataReader sdr = oCmd.ExecuteReader();
                while (sdr.Read())
                {
                    ret.warehouse_id = Convert.ToInt32(sdr["warehouse_id"].ToString());
                }
                sdr.Close();
                oTrans.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = warehouse_in_up | " + e.Message, Convert.ToInt32(obj.company_id), 0);
            }
            finally
            {
                oConn.Close();
            }
            return ret;
        }

        #endregion

        #region Module Access
        public List<warehouse_view_lib> warehouse_view(int warehouse_id, int company_id, bool is_active, bool is_ap)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<warehouse_view_lib> ret = new List<warehouse_view_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "warehouse_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@warehouse_id", warehouse_id);
                sqlcomm.Parameters.AddWithValue("@company_id", company_id);
                sqlcomm.Parameters.AddWithValue("@active", is_active);
                sqlcomm.Parameters.AddWithValue("@approved", is_ap);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new warehouse_view_lib()
                       {
                           warehouse_id = Convert.ToInt32(dr["warehouse_id"].ToString()),
                           warehouse_code = dr["warehouse_code"].ToString(),
                           image_path = dr["image_path"].ToString(),
                           name = dr["name"].ToString(),
                           description = dr["description"].ToString(),
                           tin = dr["tin"].ToString(),
                           phone = dr["phone"].ToString(),
                           fax = dr["fax"].ToString(),
                           email = dr["email"].ToString(),
                           address = dr["address"].ToString(),
                           created_by = Convert.ToInt32(dr["created_by"].ToString()),
                           date_created = dr["date_created"].ToString(),
                           company_id = Convert.ToInt32(dr["company_id"].ToString()),
                           active = Convert.ToBoolean(dr["active"].ToString()),
                           approved = Convert.ToBoolean(dr["approved"].ToString()),
                           bp_status = dr["bp_status"].ToString(),
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = warehouse_view | " + e.Message, Convert.ToInt32(company_id), 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }
        #endregion

        #region Approval Process
        public List<menu_view_restriction_lib> modules_view(int module_id, bool is_ap, bool is_active)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<menu_view_restriction_lib> ret = new List<menu_view_restriction_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "modules_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@module_id", module_id);
                sqlcomm.Parameters.AddWithValue("@is_ap", is_ap);
                sqlcomm.Parameters.AddWithValue("@is_active", is_active);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new menu_view_restriction_lib()
                       {
                           module_id = Convert.ToInt32(dr["module_id"].ToString()),
                           module_name = dr["module_name"].ToString(),
                           module_type = Convert.ToBoolean(dr["module_type"].ToString()),
                           class_ = dr["class"].ToString(),
                           action = dr["action"].ToString(),
                           controller = dr["controller"].ToString(),
                           new_ = Convert.ToBoolean(dr["new"].ToString()),
                           modify = Convert.ToBoolean(dr["modify"].ToString()),
                           views = Convert.ToBoolean(dr["views"].ToString()),
                           prints = Convert.ToBoolean(dr["prints"].ToString()),
                           duplicate = Convert.ToBoolean(dr["duplicate"].ToString()),
                           others1 = Convert.ToBoolean(dr["others1"].ToString()),
                           others2 = Convert.ToBoolean(dr["others2"].ToString()),
                           others3 = Convert.ToBoolean(dr["others3"].ToString()),
                           others4 = Convert.ToBoolean(dr["others4"].ToString()),
                           others5 = Convert.ToBoolean(dr["others5"].ToString()),
                           view_all = Convert.ToInt32(dr["view_all"].ToString()),
                           active = Convert.ToBoolean(dr["active"].ToString())
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = modules_view | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public approval_process_in_lib approval_process_in(approval_process_in_lib[] obj, int approval_group_id, int module_id, bool all, int company_id, int warehouse_id, int created_by)
        {
            approval_process_in_lib ret = new approval_process_in_lib();
            List<menu_view_restriction_lib> resp = new List<menu_view_restriction_lib>();
            DataTable dt = new DataTable();
            ret.module_id = 1;
            SqlConnection oConn = new SqlConnection(_master);
            SqlTransaction oTrans;
            oConn.Open();
            oTrans = oConn.BeginTransaction();
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = oConn;
            oCmd.Transaction = oTrans;
            try
            {
                if (all)
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = oCmd;
                    oCmd.CommandText = "modules_view";
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    oCmd.Parameters.Clear();
                    oCmd.Parameters.AddWithValue("@module_id", 0);
                    oCmd.Parameters.AddWithValue("@is_ap", true);
                    oCmd.Parameters.AddWithValue("@is_active", true);
                    da.Fill(dt);
                    resp = (from DataRow dr in dt.Rows
                           select new menu_view_restriction_lib()
                           {
                               module_id = Convert.ToInt32(dr["module_id"].ToString()),
                           }).ToList();

                    foreach (var m in resp)
                    {
                        oCmd.CommandText = "approval_process_del";
                        oCmd.CommandType = CommandType.StoredProcedure;
                        oCmd.Parameters.Clear();
                        oCmd.Parameters.AddWithValue("@module_id", m.module_id);
                        oCmd.Parameters.AddWithValue("@approval_group_id", approval_group_id);
                        oCmd.Parameters.AddWithValue("@warehouse_id", warehouse_id);
                        oCmd.Parameters.AddWithValue("@company_id", company_id);
                        oCmd.ExecuteNonQuery();

                        int seq = 0;
                        foreach (var x in obj)
                        {
                            foreach (var y in x.employee)
                            {
                                oCmd.CommandText = "approval_process_in";
                                oCmd.CommandType = CommandType.StoredProcedure;
                                oCmd.Parameters.Clear();
                                oCmd.Parameters.AddWithValue("@module_id", m.module_id);
                                oCmd.Parameters.AddWithValue("@status", x.status);
                                oCmd.Parameters.AddWithValue("@seq", seq);
                                oCmd.Parameters.AddWithValue("@approval_group_id", approval_group_id);
                                oCmd.Parameters.AddWithValue("@employee_id", y.employee_id);
                                oCmd.Parameters.AddWithValue("@warehouse_id", warehouse_id);
                                oCmd.Parameters.AddWithValue("@company_id", company_id);
                                oCmd.Parameters.AddWithValue("@active", x.active);
                                oCmd.Parameters.AddWithValue("@created_by", created_by);
                                oCmd.ExecuteNonQuery();
                            }
                            seq++;
                        }
                    }
                }
                else
                {
                    oCmd.CommandText = "approval_process_del";
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.Parameters.Clear();
                    oCmd.Parameters.AddWithValue("@module_id", module_id);
                    oCmd.Parameters.AddWithValue("@approval_group_id", approval_group_id);
                    oCmd.Parameters.AddWithValue("@warehouse_id", warehouse_id);
                    oCmd.Parameters.AddWithValue("@company_id", company_id);
                    oCmd.ExecuteNonQuery();

                    int seq = 0;
                    foreach (var x in obj)
                    {
                        foreach (var y in x.employee)
                        {
                            oCmd.CommandText = "approval_process_in";
                            oCmd.CommandType = CommandType.StoredProcedure;
                            oCmd.Parameters.Clear();
                            oCmd.Parameters.AddWithValue("@module_id", module_id);
                            oCmd.Parameters.AddWithValue("@status", x.status);
                            oCmd.Parameters.AddWithValue("@seq", seq);
                            oCmd.Parameters.AddWithValue("@approval_group_id", approval_group_id);
                            oCmd.Parameters.AddWithValue("@employee_id", y.employee_id);
                            oCmd.Parameters.AddWithValue("@warehouse_id", warehouse_id);
                            oCmd.Parameters.AddWithValue("@company_id", company_id);
                            oCmd.Parameters.AddWithValue("@active", x.active);
                            oCmd.Parameters.AddWithValue("@created_by", created_by);
                            oCmd.ExecuteNonQuery();
                        }
                        seq++;
                    }
                }
                oTrans.Commit();
            }
            catch (Exception e)
            {
                ret.module_id = 0;
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = util_dropdown_setting_in | " + e.Message, company_id, created_by);
                oTrans.Rollback();
            }
            finally
            {
                oConn.Close();

            }
            return ret;
        }

        public List<approval_process_in_lib> approval_process_view(int module_id, int approval_group_id, int warehouse_id, int company_id)
        {
            List<approval_process_in_lib> ret = new List<approval_process_in_lib>();
            DataTable dt = new DataTable();
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "approval_process_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@module_id", module_id);
                sqlcomm.Parameters.AddWithValue("@approval_group_id", approval_group_id);
                sqlcomm.Parameters.AddWithValue("@warehouse_id", warehouse_id);
                sqlcomm.Parameters.AddWithValue("@company_id", company_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new approval_process_in_lib()
                       {
                           status = dr["status"].ToString(),
                           active = Convert.ToBoolean(dr["active"].ToString()),
                           employee_id = Convert.ToInt32(dr["employee_id"].ToString()),
                           full_name = dr["full_name"].ToString(),
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = modules_view | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }
        #endregion

        #region Employee
        public employee_in_lib employee_in_up(employee_in_lib objPersonal, employee_information_in_lib objPayroll, employee_relative_in_lib[] objRelative,
            employee_emergency_in_lib[] objEmergency, employee_employment_in_lib[] objEmployment, employee_education_in_lib[] objEducation, employee_degree_in_lib[] objDegree, int approval_group_id, bool oldPath)
        {
            string sp = "";
            employee_in_lib ret = new employee_in_lib();
            SqlConnection oConn = new SqlConnection(_master);
            SqlTransaction oTrans;
            oConn.Open();
            oTrans = oConn.BeginTransaction();
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = oConn;
            oCmd.Transaction = oTrans;
            try
            {
                var path = "";
                if (oldPath)
                {
                    path = objPersonal.image_path;
                }
                else
                {
                    path = "\\Uploaded\\Images\\" + objPersonal.company_id + "\\employee\\" + objPersonal.image_path;
                }
                

                sp = "employee_in_up";
                oCmd.CommandText = "employee_in_up";
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Clear();
                oCmd.Parameters.AddWithValue("@employee_id", objPersonal.employee_id);
                oCmd.Parameters.AddWithValue("@salutation_id", objPersonal.salutation_id);
                oCmd.Parameters.AddWithValue("@first_name", objPersonal.first_name);
                oCmd.Parameters.AddWithValue("@middle_name", objPersonal.middle_name);
                oCmd.Parameters.AddWithValue("@last_name", objPersonal.last_name);
                oCmd.Parameters.AddWithValue("@display_name", objPersonal.display_name);
                oCmd.Parameters.AddWithValue("@nick_name", objPersonal.nick_name);
                oCmd.Parameters.AddWithValue("@religion_id", objPersonal.religion_id);
                oCmd.Parameters.AddWithValue("@gender_id", objPersonal.gender_id);
                oCmd.Parameters.AddWithValue("@nationality_id", objPersonal.nationality_id);
                oCmd.Parameters.AddWithValue("@birth_place", objPersonal.birth_place);
                oCmd.Parameters.AddWithValue("@birthday", Convert.ToDateTime(objPersonal.birthday));
                oCmd.Parameters.AddWithValue("@civil_status_id", objPersonal.civil_status_id);
                oCmd.Parameters.AddWithValue("@height", objPersonal.height);
                oCmd.Parameters.AddWithValue("@weight", objPersonal.weight);
                oCmd.Parameters.AddWithValue("@blood_type", objPersonal.blood_type);
                oCmd.Parameters.AddWithValue("@phone_mobile", objPersonal.phone_mobile);
                oCmd.Parameters.AddWithValue("@phone_telephone", objPersonal.phone_telephone);
                oCmd.Parameters.AddWithValue("@phone_office", objPersonal.phone_office);
                oCmd.Parameters.AddWithValue("@phone_fax", objPersonal.phone_fax);
                oCmd.Parameters.AddWithValue("@email_address", objPersonal.email_address);
                oCmd.Parameters.AddWithValue("@present_address", objPersonal.present_address);
                oCmd.Parameters.AddWithValue("@permanent_address", objPersonal.permanent_address);
                oCmd.Parameters.AddWithValue("@image_path", path);
                oCmd.Parameters.AddWithValue("@active", objPersonal.active);
                oCmd.Parameters.AddWithValue("@approval_group_id", objPersonal.approval_group_id);
                oCmd.Parameters.AddWithValue("@access_level_id", objPersonal.access_level_id);
                oCmd.Parameters.AddWithValue("@immediate_supervisor_id", objPersonal.immediate_supervisor_id);
                oCmd.Parameters.AddWithValue("@created_by", objPersonal.created_by);
                oCmd.Parameters.AddWithValue("@company_id", objPersonal.company_id);
                oCmd.Parameters.AddWithValue("@fix", 0);
                SqlDataReader sdr = oCmd.ExecuteReader();
                while (sdr.Read())
                {
                    ret.employee_id = Convert.ToInt32(sdr["employee_id"].ToString());
                }
                sdr.Close();

                sp = "employee_details_del";
                oCmd.CommandText = "employee_details_del";
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Clear();
                oCmd.Parameters.AddWithValue("@employee_id", ret.employee_id);
                oCmd.ExecuteNonQuery();

                sp = "employee_information_in";
                oCmd.CommandText = "employee_information_in";
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Clear();
                oCmd.Parameters.AddWithValue("@employee_id", ret.employee_id);
                oCmd.Parameters.AddWithValue("@payroll_type", objPayroll.payroll_type);
                oCmd.Parameters.AddWithValue("@biometrics_id", objPayroll.biometrics_id);
                oCmd.Parameters.AddWithValue("@bank", objPayroll.bank);
                oCmd.Parameters.AddWithValue("@bankaccount", objPayroll.bankaccount);
                oCmd.Parameters.AddWithValue("@basic_rate", objPayroll.basic_rate);
                oCmd.Parameters.AddWithValue("@daily_rate", objPayroll.daily_rate);
                oCmd.Parameters.AddWithValue("@hourly_rate", objPayroll.hourly_rate);
                oCmd.Parameters.AddWithValue("@semi_monthly_rate", objPayroll.semi_monthly_rate);
                oCmd.Parameters.AddWithValue("@employee_status_id", objPayroll.employee_status_id);
                oCmd.Parameters.AddWithValue("@occupation_id", objPayroll.occupation_id);
                oCmd.Parameters.AddWithValue("@department_id", objPayroll.department_id);
                oCmd.Parameters.AddWithValue("@sss", objPayroll.sss);
                oCmd.Parameters.AddWithValue("@pagibig", objPayroll.pagibig);
                oCmd.Parameters.AddWithValue("@philhealth", objPayroll.philhealth);
                oCmd.Parameters.AddWithValue("@tin", objPayroll.tin);
                oCmd.Parameters.AddWithValue("@nbi", objPayroll.nbi);
                oCmd.Parameters.AddWithValue("@gsis", objPayroll.gsis);
                oCmd.Parameters.AddWithValue("@date_hired", Convert.ToDateTime(objPayroll.date_hired));
                oCmd.Parameters.AddWithValue("@division_id", objPayroll.division_id);
                oCmd.Parameters.AddWithValue("@section_id", objPayroll.section_id);
                oCmd.Parameters.AddWithValue("@confidentiality", objPayroll.confidentiality);
                oCmd.Parameters.AddWithValue("@supervisor", objPayroll.supervisor);
                oCmd.Parameters.AddWithValue("@warehouse", objPayroll.warehouse);
                oCmd.Parameters.AddWithValue("@is_fixed_salary", objPayroll.is_fixed_salary);
                oCmd.Parameters.AddWithValue("@is_tardiness_deduction", objPayroll.is_tardiness_deduction);
                oCmd.Parameters.AddWithValue("@is_without_ot", objPayroll.is_without_ot);
                oCmd.ExecuteNonQuery();

                if (objRelative != null)
                {
                    foreach (var item in objRelative)
                    {
                        sp = "employee_relative_in";
                        oCmd.CommandText = "employee_relative_in";
                        oCmd.CommandType = CommandType.StoredProcedure;
                        oCmd.Parameters.Clear();
                        oCmd.Parameters.AddWithValue("@employee_id", ret.employee_id);
                        oCmd.Parameters.AddWithValue("@name", item.name);
                        oCmd.Parameters.AddWithValue("@relationship_id", item.relationship_id);
                        oCmd.Parameters.AddWithValue("@birthday", item.birthday);
                        oCmd.Parameters.AddWithValue("@gender_id", item.gender_id);
                        oCmd.Parameters.AddWithValue("@occupation", item.occupation);
                        oCmd.Parameters.AddWithValue("@company", item.company);
                        oCmd.ExecuteNonQuery();
                    }
                }

                if (objEmergency != null)
                {
                    foreach (var item in objEmergency)
                    {
                        sp = "employee_emergency_in";
                        oCmd.CommandText = "employee_emergency_in";
                        oCmd.CommandType = CommandType.StoredProcedure;
                        oCmd.Parameters.Clear();
                        oCmd.Parameters.AddWithValue("@employee_id", ret.employee_id);
                        oCmd.Parameters.AddWithValue("@name", item.name);
                        oCmd.Parameters.AddWithValue("@relationship_id", item.relationship_id);
                        oCmd.Parameters.AddWithValue("@address", item.address);
                        oCmd.Parameters.AddWithValue("@contact_number", item.contact_number);
                        oCmd.ExecuteNonQuery();
                    }
                }

                if (objEmployment != null)
                {
                    foreach (var item in objEmployment)
                    {
                        sp = "employee_employment_in";
                        oCmd.CommandText = "employee_employment_in";
                        oCmd.CommandType = CommandType.StoredProcedure;
                        oCmd.Parameters.Clear();
                        oCmd.Parameters.AddWithValue("@employee_id", ret.employee_id);
                        oCmd.Parameters.AddWithValue("@company", item.company);
                        oCmd.Parameters.AddWithValue("@position", item.position);
                        oCmd.Parameters.AddWithValue("@salary", item.salary);
                        oCmd.Parameters.AddWithValue("@date_from", item.date_from);
                        oCmd.Parameters.AddWithValue("@date_to", item.date_to);
                        oCmd.Parameters.AddWithValue("@reason", item.reason);
                        oCmd.ExecuteNonQuery();
                    }
                }

                if (objEducation != null)
                {
                    foreach (var item in objEducation)
                    {
                        sp = "employee_education_in";
                        oCmd.CommandText = "employee_education_in";
                        oCmd.CommandType = CommandType.StoredProcedure;
                        oCmd.Parameters.Clear();
                        oCmd.Parameters.AddWithValue("@employee_id", ret.employee_id);
                        oCmd.Parameters.AddWithValue("@name", item.name);
                        oCmd.Parameters.AddWithValue("@type_id", item.type_id);
                        oCmd.Parameters.AddWithValue("@date_from", item.date_from);
                        oCmd.Parameters.AddWithValue("@date_to", item.date_to);
                        oCmd.Parameters.AddWithValue("@awards", item.awards);
                        oCmd.ExecuteNonQuery();
                    }
                }

                if (objDegree != null)
                {
                    foreach (var item in objDegree)
                    {
                        sp = "employee_degree_in";
                        oCmd.CommandText = "employee_degree_in";
                        oCmd.CommandType = CommandType.StoredProcedure;
                        oCmd.Parameters.Clear();
                        oCmd.Parameters.AddWithValue("@employee_id", ret.employee_id);
                        oCmd.Parameters.AddWithValue("@name", item.name);
                        oCmd.Parameters.AddWithValue("@course", item.course);
                        oCmd.Parameters.AddWithValue("@major", item.major);
                        oCmd.ExecuteNonQuery();
                    }
                }

                function_encrypt(11, ret.employee_id, objPersonal.company_id, objPersonal.created_by, oCmd);
                function_approval(11, ret.employee_id, approval_group_id, objPersonal.company_id, objPersonal.created_by, oCmd);
                oTrans.Commit();
            }
            catch (Exception e)
            {
                ret.employee_id = 0;
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = " + sp + " | " + e.Message, Convert.ToInt32(objPersonal.company_id), 0);
            }
            finally
            {
                oConn.Close();
            }
            return ret;
        }

        public employee_list_view_lib employee_credentials_up(employee_list_view_lib obj)
        {
            employee_list_view_lib ret = new employee_list_view_lib();
            SqlConnection oConn = new SqlConnection(_master);
            SqlTransaction oTrans;
            oConn.Open();
            oTrans = oConn.BeginTransaction();
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = oConn;
            oCmd.Transaction = oTrans;
            try
            {
                var pass = Crypto.password_encrypt(obj.userhash);
                oCmd.CommandText = "employee_credentials_up";
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Clear();
                oCmd.Parameters.AddWithValue("@employee_id", obj.employee_id);
                oCmd.Parameters.AddWithValue("@username", obj.username);
                oCmd.Parameters.AddWithValue("@userhash", pass);
                oCmd.Parameters.AddWithValue("@question1", obj.question1);
                oCmd.Parameters.AddWithValue("@answer1", obj.answer1);
                oCmd.Parameters.AddWithValue("@question2", obj.question2);
                oCmd.Parameters.AddWithValue("@answer2", obj.answer2);

                SqlDataReader sdr = oCmd.ExecuteReader();
                while (sdr.Read())
                {
                    ret.employee_id = Convert.ToInt32(sdr["employee_id"].ToString());
                }
                sdr.Close();
                oTrans.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = employee_credentials_up | " + e.Message, Convert.ToInt32(obj.company_id), 0);
            }
            finally
            {
                oConn.Close();
            }
            return ret;
        }

        public List<employee_list_view_lib> employee_list_view(employee_list_view_lib obj)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<employee_list_view_lib> ret = new List<employee_list_view_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "employee_list_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@employee_id", obj.employee_id);
                sqlcomm.Parameters.AddWithValue("@is_active", obj.active);
                sqlcomm.Parameters.AddWithValue("@is_bp", obj.approved);
                sqlcomm.Parameters.AddWithValue("@company_id", obj.company_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new employee_list_view_lib()
                       {
                           employee_id = Convert.ToInt32(dr["employee_id"].ToString()),
                           employee_code = dr["employee_code"].ToString(),
                           username = dr["username"].ToString(),
                           userhash = dr["userhash"].ToString(),
                           salutation_id = Convert.ToInt32(dr["salutation_id"].ToString()),
                           salutation = dr["salutation"].ToString(),
                           first_name = dr["first_name"].ToString(),
                           middle_name = dr["middle_name"].ToString(),
                           last_name = dr["last_name"].ToString(),
                           full_name = dr["full_name"].ToString(),
                           display_name = dr["display_name"].ToString(),
                           nick_name = dr["nick_name"].ToString(),
                           religion_id = Convert.ToInt32(dr["religion_id"].ToString()),
                           religion = dr["religion"].ToString(),
                           gender_id = Convert.ToInt32(dr["gender_id"].ToString()),
                           gender = dr["gender"].ToString(),
                           nationality_id = Convert.ToInt32(dr["nationality_id"].ToString()),
                           nationality = dr["nationality"].ToString(),
                           birth_place = dr["birth_place"].ToString(),
                           birthday = dr["birthday"].ToString(),
                           civil_status_id = Convert.ToInt32(dr["civil_status_id"].ToString()),
                           civil_status = dr["civil_status"].ToString(),
                           height = dr["height"].ToString(),
                           weight = dr["weight"].ToString(),
                           blood_type = dr["blood_type"].ToString(),
                           phone_mobile = dr["phone_mobile"].ToString(),
                           phone_telephone = dr["phone_telephone"].ToString(),
                           phone_office = dr["phone_office"].ToString(),
                           phone_fax = dr["phone_fax"].ToString(),
                           email_address = dr["email_address"].ToString(),
                           present_address = dr["present_address"].ToString(),
                           permanent_address = dr["permanent_address"].ToString(),
                           image_path = dr["image_path"].ToString(),
                           question1 = Convert.ToInt32(dr["question1"].ToString()),
                           answer1 = dr["answer1"].ToString(),
                           question2 = Convert.ToInt32(dr["question2"].ToString()),
                           answer2 = dr["answer2"].ToString(),
                           bp_status = dr["bp_status"].ToString(),
                           approved = Convert.ToBoolean(dr["approved"].ToString()),
                           active = Convert.ToBoolean(dr["active"].ToString()),
                           approval_group_id = Convert.ToInt32(dr["approval_group_id"].ToString()),
                           approval_group = dr["approval_group"].ToString(),
                           access_level_id = Convert.ToInt32(dr["access_level_id"].ToString()),
                           access_level = dr["access_level"].ToString(),
                           immediate_supervisor_id = Convert.ToInt32(dr["immediate_supervisor_id"].ToString()),
                           immediate_supervisor = dr["immediate_supervisor"].ToString(),
                           created_by_id = Convert.ToInt32(dr["created_by_id"].ToString()),
                           created_by = dr["created_by"].ToString(),
                           date_created = dr["date_created"].ToString(),
                           enc_key = dr["enc_key"].ToString(),
                           company_id = Convert.ToInt32(dr["company_id"].ToString()),
                           company_name = dr["company_name"].ToString(),
                           fix = Convert.ToBoolean(dr["fix"].ToString()),
                           button = dr["button"].ToString(),

                           payroll_type = Convert.ToInt32(dr["payroll_type_Id"].ToString()),
                           payroll_type_desc = dr["payroll_type_desc"].ToString(),
                           biometrics_id = dr["biometrics_id"].ToString(),
                           bank = dr["bank"].ToString(),
                           bankaccount = dr["bankaccount"].ToString(),
                           basic_rate = Convert.ToDecimal(dr["basic_rate"].ToString()),
                           daily_rate = Convert.ToDecimal(dr["daily_rate"].ToString()),
                           hourly_rate = Convert.ToDecimal(dr["hourly_rate"].ToString()),
                           semi_monthly_rate = Convert.ToDecimal(dr["semi_monthly_rate"].ToString()),
                           employee_status_id = Convert.ToInt32(dr["employee_status_id"].ToString()),
                           employee_status = dr["employee_status"].ToString(),
                           occupation_id = Convert.ToInt32(dr["occupation_id"].ToString()),
                           occupation = dr["occupation"].ToString(),
                           department_id = Convert.ToInt32(dr["department_id"].ToString()),
                           department = dr["department"].ToString(),
                           sss = dr["sss"].ToString(),
                           pagibig = dr["pagibig"].ToString(),
                           philhealth = dr["philhealth"].ToString(),
                           tin = dr["tin"].ToString(),
                           nbi = dr["nbi"].ToString(),
                           gsis = dr["gsis"].ToString(),
                           date_hired = dr["date_hired"].ToString(),
                           division_id = Convert.ToInt32(dr["division_id"].ToString()),
                           division = dr["division"].ToString(),
                           section_id = Convert.ToInt32(dr["section_id"].ToString()),
                           section = dr["section"].ToString(),
                           confidentiality_id = Convert.ToInt32(dr["confidentiality_id"].ToString()),
                           confidentiality = dr["confidentiality"].ToString(),
                           supervisor = Convert.ToInt32(dr["supervisor"].ToString()),
                           warehouse = Convert.ToInt32(dr["warehouse"].ToString()),
                           is_fixed_salary = Convert.ToBoolean(dr["is_fixed_salary"].ToString()),
                           is_tardiness_deduction = Convert.ToBoolean(dr["is_tardiness_deduction"].ToString()),
                           is_without_ot = Convert.ToBoolean(dr["is_without_ot"].ToString()),
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = employee_list_view | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public List<employee_list_view_lib> employee_sel(employee_list_view_lib obj)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<employee_list_view_lib> ret = new List<employee_list_view_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "employee_sel";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@employee_id", obj.employee_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new employee_list_view_lib()
                       {
                           employee_id = Convert.ToInt32(dr["employee_id"].ToString()),
                           employee_code = dr["employee_code"].ToString(),
                           username = dr["username"].ToString(),
                           userhash = dr["userhash"].ToString(),
                           salutation_id = Convert.ToInt32(dr["salutation_id"].ToString()),
                           salutation = dr["salutation"].ToString(),
                           first_name = dr["first_name"].ToString(),
                           middle_name = dr["middle_name"].ToString(),
                           last_name = dr["last_name"].ToString(),
                           full_name = dr["full_name"].ToString(),
                           display_name = dr["display_name"].ToString(),
                           nick_name = dr["nick_name"].ToString(),
                           religion_id = Convert.ToInt32(dr["religion_id"].ToString()),
                           religion = dr["religion"].ToString(),
                           gender_id = Convert.ToInt32(dr["gender_id"].ToString()),
                           gender = dr["gender"].ToString(),
                           nationality_id = Convert.ToInt32(dr["nationality_id"].ToString()),
                           nationality = dr["nationality"].ToString(),
                           birth_place = dr["birth_place"].ToString(),
                           birthday = dr["birthday"].ToString(),
                           civil_status_id = Convert.ToInt32(dr["civil_status_id"].ToString()),
                           civil_status = dr["civil_status"].ToString(),
                           height = dr["height"].ToString(),
                           weight = dr["weight"].ToString(),
                           blood_type = dr["blood_type"].ToString(),
                           phone_mobile = dr["phone_mobile"].ToString(),
                           phone_telephone = dr["phone_telephone"].ToString(),
                           phone_office = dr["phone_office"].ToString(),
                           phone_fax = dr["phone_fax"].ToString(),
                           email_address = dr["email_address"].ToString(),
                           present_address = dr["present_address"].ToString(),
                           permanent_address = dr["permanent_address"].ToString(),
                           image_path = dr["image_path"].ToString(),
                           question1 = Convert.ToInt32(dr["question1"].ToString()),
                           answer1 = dr["answer1"].ToString(),
                           question2 = Convert.ToInt32(dr["question2"].ToString()),
                           answer2 = dr["answer2"].ToString(),
                           bp_status = dr["bp_status"].ToString(),
                           approved = Convert.ToBoolean(dr["approved"].ToString()),
                           active = Convert.ToBoolean(dr["active"].ToString()),
                           approval_group_id = Convert.ToInt32(dr["approval_group_id"].ToString()),
                           approval_group = dr["approval_group"].ToString(),
                           access_level_id = Convert.ToInt32(dr["access_level_id"].ToString()),
                           access_level = dr["access_level"].ToString(),
                           immediate_supervisor_id = Convert.ToInt32(dr["immediate_supervisor_id"].ToString()),
                           immediate_supervisor = dr["immediate_supervisor"].ToString(),
                           created_by_id = Convert.ToInt32(dr["created_by_id"].ToString()),
                           created_by = dr["created_by"].ToString(),
                           date_created = dr["date_created"].ToString(),
                           enc_key = dr["enc_key"].ToString(),
                           company_id = Convert.ToInt32(dr["company_id"].ToString()),
                           company_name = dr["company_name"].ToString(),
                           fix = Convert.ToBoolean(dr["fix"].ToString()),

                           payroll_type = Convert.ToInt32(dr["payroll_type_Id"].ToString()),
                           payroll_type_desc = dr["payroll_type_desc"].ToString(),
                           biometrics_id = dr["biometrics_id"].ToString(),
                           bank = dr["bank"].ToString(),
                           bankaccount = dr["bankaccount"].ToString(),
                           basic_rate = Convert.ToDecimal(dr["basic_rate"].ToString()),
                           daily_rate = Convert.ToDecimal(dr["daily_rate"].ToString()),
                           hourly_rate = Convert.ToDecimal(dr["hourly_rate"].ToString()),
                           semi_monthly_rate = Convert.ToDecimal(dr["semi_monthly_rate"].ToString()),
                           employee_status_id = Convert.ToInt32(dr["employee_status_id"].ToString()),
                           employee_status = dr["employee_status"].ToString(),
                           occupation_id = Convert.ToInt32(dr["occupation_id"].ToString()),
                           occupation = dr["occupation"].ToString(),
                           department_id = Convert.ToInt32(dr["department_id"].ToString()),
                           department = dr["department"].ToString(),
                           sss = dr["sss"].ToString(),
                           pagibig = dr["pagibig"].ToString(),
                           philhealth = dr["philhealth"].ToString(),
                           tin = dr["tin"].ToString(),
                           nbi = dr["nbi"].ToString(),
                           gsis = dr["gsis"].ToString(),
                           date_hired = dr["date_hired"].ToString(),
                           division_id = Convert.ToInt32(dr["division_id"].ToString()),
                           division = dr["division"].ToString(),
                           section_id = Convert.ToInt32(dr["section_id"].ToString()),
                           section = dr["section"].ToString(),
                           confidentiality_id = Convert.ToInt32(dr["confidentiality_id"].ToString()),
                           confidentiality = dr["confidentiality"].ToString(),
                           supervisor = Convert.ToInt32(dr["supervisor"].ToString()),
                           warehouse = Convert.ToInt32(dr["warehouse"].ToString()),
                           is_fixed_salary = Convert.ToBoolean(dr["is_fixed_salary"].ToString()),
                           is_tardiness_deduction = Convert.ToBoolean(dr["is_tardiness_deduction"].ToString()),
                           is_without_ot = Convert.ToBoolean(dr["is_without_ot"].ToString()),
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = employee_sel | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public List<employee_information_in_lib> employee_information_view(int employee_id)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<employee_information_in_lib> ret = new List<employee_information_in_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "employee_information_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@employee_id", employee_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new employee_information_in_lib()
                       {
                           employee_id = Convert.ToInt32(dr["employee_id"].ToString()),
                           payroll_type = Convert.ToInt32(dr["payroll_type"].ToString()),
                           payroll_type_desc = dr["payroll_type_desc"].ToString(),
                           biometrics_id = dr["biometrics_id"].ToString(),
                           bank = dr["bank"].ToString(),
                           bankaccount = dr["bankaccount"].ToString(),
                           basic_rate = Convert.ToDecimal(dr["basic_rate"]),
                           daily_rate = Convert.ToDecimal(dr["daily_rate"].ToString()),
                           hourly_rate = Convert.ToDecimal(dr["hourly_rate"].ToString()),
                           semi_monthly_rate = Convert.ToDecimal(dr["semi_monthly_rate"].ToString()),
                           employee_status_id = Convert.ToInt32(dr["employee_status_id"].ToString()),
                           employee_status = dr["employee_status"].ToString(),
                           occupation_id = Convert.ToInt32(dr["occupation_id"].ToString()),
                           occupation = dr["occupation"].ToString(),
                           department_id = Convert.ToInt32(dr["department_id"].ToString()),
                           department = dr["department"].ToString(),
                           sss = dr["sss"].ToString(),
                           pagibig = dr["pagibig"].ToString(),
                           philhealth = dr["philhealth"].ToString(),
                           tin = dr["tin"].ToString(),
                           nbi = dr["nbi"].ToString(),
                           gsis = dr["gsis"].ToString(),
                           date_hired = dr["date_hired"].ToString(),
                           division_id = Convert.ToInt32(dr["division_id"].ToString()),
                           division = dr["division"].ToString(),
                           section_id = Convert.ToInt32(dr["section_id"].ToString()),
                           section = dr["section"].ToString(),
                           confidentiality = Convert.ToInt32(dr["confidentiality"].ToString()),
                           confidentiality_desc = dr["confidentiality_desc"].ToString(),
                           supervisor = Convert.ToInt32(dr["supervisor"].ToString()),
                           supervisor_desc = dr["supervisor_desc"].ToString(),
                           warehouse = Convert.ToInt32(dr["warehouse"].ToString()),
                           warehouse_desc = dr["warehouse_desc"].ToString(),
                           is_fixed_salary = Convert.ToBoolean(dr["is_fixed_salary"].ToString()),
                           is_tardiness_deduction = Convert.ToBoolean(dr["is_tardiness_deduction"].ToString()),
                           is_without_ot = Convert.ToBoolean(dr["is_without_ot"].ToString()),
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = employee_information_view | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public List<employee_degree_in_lib> employee_degree_view(int employee_id)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<employee_degree_in_lib> ret = new List<employee_degree_in_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "employee_degree_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@employee_id", employee_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new employee_degree_in_lib()
                       {
                           employee_id = Convert.ToInt32(dr["employee_id"].ToString()),
                           name = dr["name"].ToString(),
                           course = dr["course"].ToString(),
                           major = dr["major"].ToString()
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = employee_degree_view | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public List<employee_education_in_lib> employee_education_view(int employee_id)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<employee_education_in_lib> ret = new List<employee_education_in_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "employee_education_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@employee_id", employee_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new employee_education_in_lib()
                       {
                           employee_id = Convert.ToInt32(dr["employee_id"].ToString()),
                           name = dr["name"].ToString(),
                           type_id = Convert.ToInt32(dr["type_id"].ToString()),
                           type = dr["type"].ToString(),
                           date_from = dr["date_from"].ToString(),
                           date_to = dr["date_to"].ToString(),
                           awards = dr["awards"].ToString(),
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = employee_education_view | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public List<employee_emergency_in_lib> employee_emergency_view(int employee_id)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<employee_emergency_in_lib> ret = new List<employee_emergency_in_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "employee_emergency_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@employee_id", employee_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new employee_emergency_in_lib()
                       {
                           employee_id = Convert.ToInt32(dr["employee_id"].ToString()),
                           name = dr["name"].ToString(),
                           relationship_id = Convert.ToInt32(dr["relationship_id"].ToString()),
                           relationship = dr["relationship"].ToString(),
                           address = dr["address"].ToString(),
                           contact_number = dr["contact_number"].ToString()
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = employee_emergency_view | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public List<employee_employment_in_lib> employee_employment_view(int employee_id)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<employee_employment_in_lib> ret = new List<employee_employment_in_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "employee_employment_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@employee_id", employee_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new employee_employment_in_lib()
                       {
                           employee_id = Convert.ToInt32(dr["employee_id"].ToString()),
                           company = dr["company"].ToString(),
                           position = dr["position"].ToString(),
                           salary = Convert.ToDecimal(dr["salary"].ToString()),
                           date_from = dr["date_from"].ToString(),
                           date_to = dr["date_to"].ToString(),
                           reason = dr["reason"].ToString(),
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = employee_employment_view | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public List<employee_relative_in_lib> employee_relative_view(int employee_id)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<employee_relative_in_lib> ret = new List<employee_relative_in_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "employee_relative_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@employee_id", employee_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new employee_relative_in_lib()
                       {
                           employee_id = Convert.ToInt32(dr["employee_id"].ToString()),
                           name = dr["name"].ToString(),
                           relationship_id = Convert.ToInt32(dr["relationship_id"].ToString()),
                           relationship = dr["relationship"].ToString(),
                           birthday = dr["birthday"].ToString(),
                           gender_id = Convert.ToInt32(dr["gender_id"].ToString()),
                           gender = dr["gender"].ToString(),
                           occupation = dr["occupation"].ToString(),
                           company = dr["company"].ToString()
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = employee_relative_view | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public List<employee_list_view_lib> employee_fetch_view(int employee_id, int company_id, int row, int index)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<employee_list_view_lib> ret = new List<employee_list_view_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "employee_fetch_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@employee_id", employee_id);
                sqlcomm.Parameters.AddWithValue("@company_id", company_id);
                sqlcomm.Parameters.AddWithValue("@row", row);
                sqlcomm.Parameters.AddWithValue("@index", index);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new employee_list_view_lib()
                       {
                           employee_id = Convert.ToInt32(dr["employee_id"].ToString()),
                           employee_code = dr["employee_code"].ToString(),
                           username = dr["username"].ToString(),
                           userhash = dr["userhash"].ToString(),
                           salutation_id = Convert.ToInt32(dr["salutation_id"].ToString()),
                           salutation = dr["salutation"].ToString(),
                           first_name = dr["first_name"].ToString(),
                           middle_name = dr["middle_name"].ToString(),
                           last_name = dr["last_name"].ToString(),
                           full_name = dr["full_name"].ToString(),
                           display_name = dr["display_name"].ToString(),
                           nick_name = dr["nick_name"].ToString(),
                           religion_id = Convert.ToInt32(dr["religion_id"].ToString()),
                           religion = dr["religion"].ToString(),
                           gender_id = Convert.ToInt32(dr["gender_id"].ToString()),
                           gender = dr["gender"].ToString(),
                           nationality_id = Convert.ToInt32(dr["nationality_id"].ToString()),
                           nationality = dr["nationality"].ToString(),
                           birth_place = dr["birth_place"].ToString(),
                           birthday = Convert.ToDateTime(dr["birthday"].ToString()).ToShortDateString(),
                           civil_status_id = Convert.ToInt32(dr["civil_status_id"].ToString()),
                           civil_status = dr["civil_status"].ToString(),
                           height = dr["height"].ToString(),
                           weight = dr["weight"].ToString(),
                           blood_type = dr["blood_type"].ToString(),
                           phone_mobile = dr["phone_mobile"].ToString(),
                           phone_telephone = dr["phone_telephone"].ToString(),
                           phone_office = dr["phone_office"].ToString(),
                           phone_fax = dr["phone_fax"].ToString(),
                           email_address = dr["email_address"].ToString(),
                           present_address = dr["present_address"].ToString(),
                           permanent_address = dr["permanent_address"].ToString(),
                           image_path = dr["image_path"].ToString(),
                           question1 = Convert.ToInt32(dr["question1"].ToString()),
                           answer1 = dr["answer1"].ToString(),
                           question2 = Convert.ToInt32(dr["question2"].ToString()),
                           answer2 = dr["answer2"].ToString(),
                           bp_status = dr["bp_status"].ToString(),
                           approved = Convert.ToBoolean(dr["approved"].ToString()),
                           active = Convert.ToBoolean(dr["active"].ToString()),
                           approval_group_id = Convert.ToInt32(dr["approval_group_id"].ToString()),
                           approval_group = dr["approval_group"].ToString(),
                           access_level_id = Convert.ToInt32(dr["access_level_id"].ToString()),
                           access_level = dr["access_level"].ToString(),
                           immediate_supervisor_id = Convert.ToInt32(dr["immediate_supervisor_id"].ToString()),
                           immediate_supervisor = dr["immediate_supervisor"].ToString(),
                           created_by_id = Convert.ToInt32(dr["created_by_id"].ToString()),
                           created_by = dr["created_by"].ToString(),
                           date_created = dr["date_created"].ToString(),
                           enc_key = dr["enc_key"].ToString(),
                           company_id = Convert.ToInt32(dr["company_id"].ToString()),
                           company_name = dr["company_name"].ToString(),
                           fix = Convert.ToBoolean(dr["fix"].ToString()),

                           payroll_type = Convert.ToInt32(dr["payroll_type_Id"].ToString()),
                           payroll_type_desc = dr["payroll_type_desc"].ToString(),
                           biometrics_id = dr["biometrics_id"].ToString(),
                           bank = dr["bank"].ToString(),
                           bankaccount = dr["bankaccount"].ToString(),
                           basic_rate = Convert.ToDecimal(dr["basic_rate"].ToString()),
                           daily_rate = Convert.ToDecimal(dr["daily_rate"].ToString()),
                           hourly_rate = Convert.ToDecimal(dr["hourly_rate"].ToString()),
                           semi_monthly_rate = Convert.ToDecimal(dr["semi_monthly_rate"].ToString()),
                           employee_status_id = Convert.ToInt32(dr["employee_status_id"].ToString()),
                           employee_status = dr["employee_status"].ToString(),
                           occupation_id = Convert.ToInt32(dr["occupation_id"].ToString()),
                           occupation = dr["occupation"].ToString(),
                           department_id = Convert.ToInt32(dr["department_id"].ToString()),
                           department = dr["department"].ToString(),
                           sss = dr["sss"].ToString(),
                           pagibig = dr["pagibig"].ToString(),
                           philhealth = dr["philhealth"].ToString(),
                           tin = dr["tin"].ToString(),
                           nbi = dr["nbi"].ToString(),
                           gsis = dr["gsis"].ToString(),
                           date_hired = dr["date_hired"].ToString(),
                           division_id = Convert.ToInt32(dr["division_id"].ToString()),
                           division = dr["division"].ToString(),
                           section_id = Convert.ToInt32(dr["section_id"].ToString()),
                           section = dr["section"].ToString(),
                           confidentiality_id = Convert.ToInt32(dr["confidentiality_id"].ToString()),
                           confidentiality = dr["confidentiality"].ToString(),
                           supervisor = Convert.ToInt32(dr["supervisor"].ToString()),
                           warehouse = Convert.ToInt32(dr["warehouse"].ToString()),
                           is_fixed_salary = Convert.ToBoolean(dr["is_fixed_salary"].ToString()),
                           is_tardiness_deduction = Convert.ToBoolean(dr["is_tardiness_deduction"].ToString()),
                           is_without_ot = Convert.ToBoolean(dr["is_without_ot"].ToString()),
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = employee_fetch_view | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }

        public List<employee_list_view_lib> employee_search(string search, int company_id)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<employee_list_view_lib> ret = new List<employee_list_view_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "employee_search";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@search", search);
                sqlcomm.Parameters.AddWithValue("@company_id", company_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new employee_list_view_lib()
                       {
                           employee_id = Convert.ToInt32(dr["employee_id"].ToString()),
                           employee_code = dr["employee_code"].ToString(),
                           username = dr["username"].ToString(),
                           userhash = dr["userhash"].ToString(),
                           salutation_id = Convert.ToInt32(dr["salutation_id"].ToString()),
                           salutation = dr["salutation"].ToString(),
                           first_name = dr["first_name"].ToString(),
                           middle_name = dr["middle_name"].ToString(),
                           last_name = dr["last_name"].ToString(),
                           full_name = dr["full_name"].ToString(),
                           display_name = dr["display_name"].ToString(),
                           nick_name = dr["nick_name"].ToString(),
                           religion_id = Convert.ToInt32(dr["religion_id"].ToString()),
                           religion = dr["religion"].ToString(),
                           gender_id = Convert.ToInt32(dr["gender_id"].ToString()),
                           gender = dr["gender"].ToString(),
                           nationality_id = Convert.ToInt32(dr["nationality_id"].ToString()),
                           nationality = dr["nationality"].ToString(),
                           birth_place = dr["birth_place"].ToString(),
                           birthday = dr["birthday"].ToString(),
                           civil_status_id = Convert.ToInt32(dr["civil_status_id"].ToString()),
                           civil_status = dr["civil_status"].ToString(),
                           height = dr["height"].ToString(),
                           weight = dr["weight"].ToString(),
                           blood_type = dr["blood_type"].ToString(),
                           phone_mobile = dr["phone_mobile"].ToString(),
                           phone_telephone = dr["phone_telephone"].ToString(),
                           phone_office = dr["phone_office"].ToString(),
                           phone_fax = dr["phone_fax"].ToString(),
                           email_address = dr["email_address"].ToString(),
                           present_address = dr["present_address"].ToString(),
                           permanent_address = dr["permanent_address"].ToString(),
                           image_path = dr["image_path"].ToString(),
                           question1 = Convert.ToInt32(dr["question1"].ToString()),
                           answer1 = dr["answer1"].ToString(),
                           question2 = Convert.ToInt32(dr["question2"].ToString()),
                           answer2 = dr["answer2"].ToString(),
                           bp_status = dr["bp_status"].ToString(),
                           approved = Convert.ToBoolean(dr["approved"].ToString()),
                           active = Convert.ToBoolean(dr["active"].ToString()),
                           approval_group_id = Convert.ToInt32(dr["approval_group_id"].ToString()),
                           approval_group = dr["approval_group"].ToString(),
                           access_level_id = Convert.ToInt32(dr["access_level_id"].ToString()),
                           access_level = dr["access_level"].ToString(),
                           immediate_supervisor_id = Convert.ToInt32(dr["immediate_supervisor_id"].ToString()),
                           immediate_supervisor = dr["immediate_supervisor"].ToString(),
                           created_by_id = Convert.ToInt32(dr["created_by_id"].ToString()),
                           created_by = dr["created_by"].ToString(),
                           date_created = dr["date_created"].ToString(),
                           enc_key = dr["enc_key"].ToString(),
                           company_id = Convert.ToInt32(dr["company_id"].ToString()),
                           company_name = dr["company_name"].ToString(),
                           fix = Convert.ToBoolean(dr["fix"].ToString()),
                           button = dr["button"].ToString(),

                           payroll_type = Convert.ToInt32(dr["payroll_type_Id"].ToString()),
                           payroll_type_desc = dr["payroll_type_desc"].ToString(),
                           biometrics_id = dr["biometrics_id"].ToString(),
                           bank = dr["bank"].ToString(),
                           bankaccount = dr["bankaccount"].ToString(),
                           basic_rate = Convert.ToDecimal(dr["basic_rate"].ToString()),
                           daily_rate = Convert.ToDecimal(dr["daily_rate"].ToString()),
                           hourly_rate = Convert.ToDecimal(dr["hourly_rate"].ToString()),
                           semi_monthly_rate = Convert.ToDecimal(dr["semi_monthly_rate"].ToString()),
                           employee_status_id = Convert.ToInt32(dr["employee_status_id"].ToString()),
                           employee_status = dr["employee_status"].ToString(),
                           occupation_id = Convert.ToInt32(dr["occupation_id"].ToString()),
                           occupation = dr["occupation"].ToString(),
                           department_id = Convert.ToInt32(dr["department_id"].ToString()),
                           department = dr["department"].ToString(),
                           sss = dr["sss"].ToString(),
                           pagibig = dr["pagibig"].ToString(),
                           philhealth = dr["philhealth"].ToString(),
                           tin = dr["tin"].ToString(),
                           nbi = dr["nbi"].ToString(),
                           gsis = dr["gsis"].ToString(),
                           date_hired = dr["date_hired"].ToString(),
                           division_id = Convert.ToInt32(dr["division_id"].ToString()),
                           division = dr["division"].ToString(),
                           section_id = Convert.ToInt32(dr["section_id"].ToString()),
                           section = dr["section"].ToString(),
                           confidentiality_id = Convert.ToInt32(dr["confidentiality_id"].ToString()),
                           confidentiality = dr["confidentiality"].ToString(),
                           supervisor = Convert.ToInt32(dr["supervisor"].ToString()),
                           warehouse = Convert.ToInt32(dr["warehouse"].ToString()),
                           is_fixed_salary = Convert.ToBoolean(dr["is_fixed_salary"].ToString()),
                           is_tardiness_deduction = Convert.ToBoolean(dr["is_tardiness_deduction"].ToString()),
                           is_without_ot = Convert.ToBoolean(dr["is_without_ot"].ToString()),
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = employee_search | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }
        #endregion

        #region Payroll Information
        public List<payroll_type_view_lib> payroll_type_view(int payroll_type_id)
        {
            SqlConnection sqlConn = new SqlConnection(_master);
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConn;
            DataTable dt = new DataTable();
            List<payroll_type_view_lib> ret = new List<payroll_type_view_lib>();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcomm;
                sqlcomm.CommandText = "payroll_type_view";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Clear();
                sqlcomm.Parameters.AddWithValue("@payroll_type_id", payroll_type_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new payroll_type_view_lib()
                       {
                           payroll_type_id = Convert.ToInt32(dr["payroll_type_id"].ToString()),
                           description = dr["description"].ToString(),
                           is_per_cut_off = Convert.ToBoolean(dr["is_per_cut_off"].ToString()),
                           is_per_month = Convert.ToBoolean(dr["is_per_month"].ToString()),
                           is_per_day = Convert.ToBoolean(dr["is_per_day"].ToString()),
                           is_per_hr = Convert.ToBoolean(dr["is_per_hr"].ToString()),
                           cutoff_from = Convert.ToInt32(dr["cutoff_from"].ToString()),
                           cutoff_to = Convert.ToInt32(dr["cutoff_to"].ToString()),
                           date_created = dr["date_created"].ToString(),
                       }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                error_log_in("0", "SP = employee_list_view | " + e.Message, 0, 0);
            }
            finally
            {
                sqlConn.Close();

            }
            return ret;
        }
        #endregion
    }
}
