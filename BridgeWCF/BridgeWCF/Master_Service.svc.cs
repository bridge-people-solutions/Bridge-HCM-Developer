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
                    ret.user_id = Convert.ToInt32(sdr["user_id"].ToString());
                    ret.user_code = sdr["user_code"].ToString();
                    ret.username = sdr["username"].ToString();
                    ret.userhash = sdr["userhash"].ToString();
                    ret.first_name = sdr["first_name"].ToString();
                    ret.middle_name = sdr["middle_name"].ToString();
                    ret.last_name = sdr["last_name"].ToString();
                    ret.full_name = sdr["full_name"].ToString();
                    ret.display_name = sdr["display_name"].ToString();
                    ret.nick_name = sdr["nick_name"].ToString();
                    ret.email_address = sdr["email_address"].ToString();
                    ret.birthday = sdr["birthday"].ToString();
                    ret.birth_place = sdr["birth_place"].ToString();
                    ret.height = sdr["height"].ToString();
                    ret.weight = sdr["weight"].ToString();
                    ret.phone_home = sdr["phone_home"].ToString();
                    ret.phone_work = sdr["phone_work"].ToString();
                    ret.phone_mobile = sdr["phone_mobile"].ToString();
                    ret.phone_fax = sdr["phone_fax"].ToString();
                    ret.phone_other = sdr["phone_other"].ToString();
                    ret.address_street = sdr["address_street"].ToString();
                    ret.address_city = sdr["address_city"].ToString();
                    ret.address_state = sdr["address_state"].ToString();
                    ret.address_country = sdr["address_country"].ToString();
                    ret.address_zipcode = sdr["address_zipcode"].ToString();
                    ret.perm_street = sdr["perm_street"].ToString();
                    ret.perm_city = sdr["perm_city"].ToString();
                    ret.perm_state = sdr["perm_state"].ToString();
                    ret.perm_country = sdr["perm_country"].ToString();
                    ret.perm_zipcode = sdr["perm_zipcode"].ToString();
                    ret.image_path = sdr["image_path"].ToString();
                    ret.question1 = Convert.ToInt32(sdr["question1"].ToString());
                    ret.answer1 = sdr["answer1"].ToString();
                    ret.question2 = Convert.ToInt32(sdr["question2"].ToString());
                    ret.answer2 = sdr["answer2"].ToString();
                    ret.website = sdr["website"].ToString();
                    ret.facebook = sdr["facebook"].ToString();
                    ret.twitter = sdr["twitter"].ToString();
                    ret.instagram = sdr["instagram"].ToString();
                    ret.linkedin = sdr["linkedin"].ToString();
                    ret.skype = sdr["skype"].ToString();
                    ret.tumblr = sdr["tumblr"].ToString();
                    ret.salutation_id = Convert.ToInt32(sdr["salutation_id"].ToString());
                    ret.gender_id = Convert.ToInt32(sdr["gender_id"].ToString());
                    ret.civil_status_id = Convert.ToInt32(sdr["civil_status_id"].ToString());
                    ret.nationality_id = Convert.ToInt32(sdr["nationality_id"].ToString());
                    ret.religion_id = Convert.ToInt32(sdr["religion_id"].ToString());
                    ret.user_group_id = Convert.ToInt32(sdr["user_group_id"].ToString());
                    ret.access_level_id = Convert.ToInt32(sdr["access_level_id"].ToString());
                    ret.warehouse_id = Convert.ToInt32(sdr["warehouse_id"].ToString());
                    ret.company_id = Convert.ToInt32(sdr["company_id"].ToString());
                    ret.active = Convert.ToInt32(sdr["active"].ToString());
                    ret.created_by = Convert.ToInt32(sdr["created_by"].ToString());
                    ret.date_created = sdr["date_created"].ToString();
                    ret.approved = Convert.ToInt32(sdr["approved"].ToString());
                    ret.bp_status = sdr["bp_status"].ToString();
                    ret.enc_key = sdr["enc_key"].ToString();
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

        public int util_dropdown_setting_in(util_dropdown_view_lib obj)
        {
            int ret = 1;
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
            }
            catch (Exception e)
            {
                ret = 0;
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
                error_log_in("0", "SP = login_users_view_sel | " + e.Message, Convert.ToInt32(ret.company_id), 0);
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
                sqlcomm.Parameters.AddWithValue("@is_active", is_active);
                sqlcomm.Parameters.AddWithValue("@is_ap", is_ap);
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
                           first_name = dr["first_name"].ToString(),
                           middle_name = dr["middle_name"].ToString(),
                           last_name = dr["last_name"].ToString(),
                           full_name = dr["full_name"].ToString(),
                           display_name = dr["display_name"].ToString(),
                           nick_name = dr["nick_name"].ToString(),
                           email_address = dr["email_address"].ToString(),
                           birthday = dr["birthday"].ToString(),
                           birth_place = dr["birth_place"].ToString(),
                           height = dr["height"].ToString(),
                           weight = dr["weight"].ToString(),
                           phone_home = dr["phone_home"].ToString(),
                           phone_work = dr["phone_work"].ToString(),
                           phone_mobile = dr["phone_mobile"].ToString(),
                           phone_fax = dr["phone_fax"].ToString(),
                           phone_other = dr["phone_other"].ToString(),
                           address_street = dr["address_street"].ToString(),
                           address_city = dr["address_city"].ToString(),
                           address_state = dr["address_state"].ToString(),
                           address_country = dr["address_country"].ToString(),
                           address_zipcode = dr["address_zipcode"].ToString(),
                           perm_street = dr["perm_street"].ToString(),
                           perm_city = dr["perm_city"].ToString(),
                           perm_state = dr["perm_state"].ToString(),
                           perm_country = dr["perm_country"].ToString(),
                           perm_zipcode = dr["perm_zipcode"].ToString(),
                           image_path = dr["image_path"].ToString(),
                           question1 = Convert.ToInt32(dr["question1"].ToString()),
                           answer1 = dr["answer1"].ToString(),
                           question2 = Convert.ToInt32(dr["question2"].ToString()),
                           answer2 = dr["answer2"].ToString(),
                           website = dr["website"].ToString(),
                           facebook = dr["facebook"].ToString(),
                           twitter = dr["twitter"].ToString(),
                           instagram = dr["instagram"].ToString(),
                           linkedin = dr["linkedin"].ToString(),
                           skype = dr["skype"].ToString(),
                           tumblr = dr["tumblr"].ToString(),
                           salutation_id = Convert.ToInt32(dr["salutation_id"].ToString()),
                           gender_id = Convert.ToInt32(dr["gender_id"].ToString()),
                           civil_status_id = Convert.ToInt32(dr["civil_status_id"].ToString()),
                           nationality_id = Convert.ToInt32(dr["nationality_id"].ToString()),
                           religion_id = Convert.ToInt32(dr["religion_id"].ToString()),
                           user_group_id = Convert.ToInt32(dr["user_group_id"].ToString()),
                           warehouse_id = Convert.ToInt32(dr["warehouse_id"].ToString()),
                           company_id = Convert.ToInt32(dr["company_id"].ToString()),
                           active = Convert.ToBoolean(dr["active"].ToString()),
                           created_by = Convert.ToInt32(dr["created_by"].ToString()),
                           date_created = dr["date_created"].ToString(),
                           approved = Convert.ToBoolean(dr["approved"].ToString()),
                           bp_status = dr["bp_status"].ToString(),
                           enc_key = dr["enc_key"].ToString(),
                           fix = Convert.ToBoolean(dr["fix"].ToString()),
                           access_level_id = Convert.ToInt32(dr["access_level_id"].ToString())
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
