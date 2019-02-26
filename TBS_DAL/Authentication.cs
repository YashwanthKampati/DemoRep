using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBS_Entity;

namespace TBS_DAL
{
    public class Authentication
    {
        //static string conStr = ConfigurationManager.ConnectionStrings["ConStr"].ToString();
        //SqlConnection con = new SqlConnection(conStr);
        //SqlCommand cmd = null;
        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;
        //using static constructor to load connection string
        static Authentication()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }
        //creating a object for the opened connection
        public Authentication()
        {
            con = new SqlConnection(conStr);
        }
        public string Login(Users pbobj)
        {
            string userRole = null;
            try
            {
                cmd = new SqlCommand("Group4.udp_LoginUser", con);//stored procedure for displaying customers
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserRole", SqlDbType.VarChar,30);
                cmd.Parameters["@UserRole"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@LoginID", pbobj.LoginID);
                cmd.Parameters.AddWithValue("@UserPassword", pbobj.Password);
                con.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                
                if (noOfRowsAffected==-1)
                {
                    userRole = cmd.Parameters["@UserRole"].Value.ToString();
                    return userRole;
                }
            }

            catch (SqlException)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return userRole;
        }
        public bool UpdateUser_DAL(Users u)
        {
            bool updPwd = false;
            try
            {
                cmd = new SqlCommand("Group4.udp_UpdateUsers", con);//stored procedure for displaying customers
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginID", u.LoginID);
                cmd.Parameters.AddWithValue("@UserPassword", u.Password);
                con.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                int noOfRowsAffected = cmd.ExecuteNonQuery();

                if (noOfRowsAffected == 1)
                {
                    updPwd = true;
                    return updPwd;
                }
            }

            catch (SqlException)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return updPwd;
        }
    }

}
