using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBS_Entity;
using TBS_Exception;

namespace TBS_DAL
{
    public class CustomerOperations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pboj"></param>
        /// <returns></returns>
        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlCommand usercmd = null;
        SqlCommand usercmd1 = null;
        static CustomerOperations()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        }

        public CustomerOperations()
        {
            con = new SqlConnection(conStr);

        }
        public int AddCustomer_DAL(Customer pboj, Users users)
        {
            int cid = 0;
            try
            {
                usercmd1 = new SqlCommand();
                cmd = new SqlCommand();
                usercmd = new SqlCommand("select IDENT_CURRENT('Group4.Customer') +IDENT_Incr('Group4.Customer')", con);
                con.Open();
                cid = int.Parse(usercmd.ExecuteScalar().ToString());
                //cusid = new SqlCommand("");



                cmd.CommandText = "Group4.udp_InsertCustomer";

                cmd.Connection = con;
                usercmd1.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerName", pboj.CustomerName);
                cmd.Parameters.AddWithValue("@EmailID", pboj.EmailID);
                cmd.Parameters.AddWithValue("@CustomerAddress", pboj.Address);
                cmd.Parameters.AddWithValue("@PhoneNumber", pboj.PhoneNumber);
                usercmd1.CommandText = "Group4.udp_InsertUsers";
                usercmd1.CommandType = CommandType.StoredProcedure;
                usercmd1.Parameters.AddWithValue("@LoginID", users.LoginID);
                usercmd1.Parameters.AddWithValue("@UserPassword", users.Password);
                usercmd1.Parameters.AddWithValue("@CustomerID", cid);
                //usercmd1.Parameters.AddWithValue("@EmployeeID", null);
                usercmd1.Parameters.AddWithValue("@UserRole", users.Role);
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                int noOfRowsAffected1 = usercmd1.ExecuteNonQuery();
            }

            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return cid;


        }
        #region UpdateCustomer
        //public bool UpdateCustomer_DAL(Customer pboj)
        //{
        //    bool result = false;
        //    try
        //    {
        //        // con = new SqlConnection();
        //        //   con.ConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        //        cmd = new SqlCommand();
        //        cmd.CommandText = "Group4.udp_UpdateCustomer";
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@CustomerID", pboj.CustomerID);
        //        cmd.Parameters.AddWithValue("@CustomerName", pboj.CustomerName);
        //        cmd.Parameters.AddWithValue("@EmailID", pboj.EmailID);
        //        cmd.Parameters.AddWithValue("@CustomerAddress", pboj.Address);
        //        cmd.Parameters.AddWithValue("@PhoneNumber", pboj.PhoneNumber);
        //        con.Open();
        //        int noOfRowsAffected = cmd.ExecuteNonQuery();
        //        if (noOfRowsAffected == 1)
        //        {
        //            result = true;
        //        }
        //    }

        //    catch (SqlException)
        //    {
        //        throw;
        //    }
        //    catch (SystemException)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return result;
        //}
        #endregion
        public bool DeleteCustomer_DAL(int customerID)
        {

            bool result = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_DeleteCustomer";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerID", customerID);

                con.Open();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected == 1)
                {
                    result = true;
                }
            }


            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return result;
        }

        public DataTable DisplayCustomer_DAL()
        {
            DataTable dt = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_DisplayCustomer";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }

            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dt;
        }
        public bool UpdateCustomer_DAL(Customer pboj)
        {
            bool result = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_UpdateCustomer";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", pboj.CustomerID);
                cmd.Parameters.AddWithValue("@CustomerName", pboj.CustomerName);
                cmd.Parameters.AddWithValue("@PhoneNumber", pboj.PhoneNumber);
                cmd.Parameters.AddWithValue("@EmailID", pboj.EmailID);
                cmd.Parameters.AddWithValue("@CustomerAddress", pboj.Address);

                con.Open();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                if (noOfRowsAffected == 1)
                {
                    result = true;
                }
            }

            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return result;
        }
        public Customer SearchCustomer_DAL(int customerID)
        {
            Customer p = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_SearchCustomer";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customerID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    p = new Customer();

                    p.CustomerID = int.Parse(dr["CustomerID"].ToString());
                    p.CustomerName = dr["CustomerName"].ToString();
                    p.EmailID = dr["EmailID"].ToString();
                    p.Address = dr["CustomerAddress"].ToString();
                    p.PhoneNumber = long.Parse(dr["PhoneNumber"].ToString());

                    dr.Close();
                }
            }

            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return p;
        }
    }
}

