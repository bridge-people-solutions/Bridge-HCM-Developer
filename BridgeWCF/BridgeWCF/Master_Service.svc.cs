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

        public List<menu_view_restriction_lib> menu_view_restriction(int user_group_id, int module_id, int company_id, int warehouse_id)
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
                sqlcomm.Parameters.AddWithValue("@user_group_id", user_group_id);
                sqlcomm.Parameters.AddWithValue("@module_id", module_id);
                sqlcomm.Parameters.AddWithValue("@company_id", company_id);
                sqlcomm.Parameters.AddWithValue("@warehouse_id", warehouse_id);
                da.Fill(dt);
                ret = (from DataRow dr in dt.Rows
                       select new menu_view_restriction_lib()
                       {
                           parent_module_id = Convert.ToInt32(dr["parent_module_id"].ToString()),
                           module_id = Convert.ToInt32(dr["module_id"].ToString()),
                           module_name = dr["module_name"].ToString(),
                           module_type = Convert.ToBoolean(dr["module_type"].ToString()),
                           class_ = dr["class"].ToString(),
                           user_group_id = Convert.ToInt32(dr["user_group_id"].ToString()),
                           warehouse_id = Convert.ToInt32(dr["warehouse_id"].ToString()),
                           company_id = Convert.ToInt32(dr["company_id"].ToString()),
                           action = dr["action"].ToString(),
                           controller = dr["controller"].ToString(),
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
                error_log_in("0", "SP = menu_view_side | " + e.Message, Convert.ToInt32(company_id), 0);
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
            //string filePath = @"C:\Error.txt";
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
    }
}
