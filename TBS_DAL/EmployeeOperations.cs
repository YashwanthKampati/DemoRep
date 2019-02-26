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
    public class EmployeeOperations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pboj"></param>
        /// <returns></returns>
        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlCommand empcmd = null;
        SqlCommand empcmd1 = null;
        static EmployeeOperations()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        }

        public EmployeeOperations()
        {
            con = new SqlConnection(conStr);

        }
        public int AddEmployee_DAL(Employee pboj, Users users)
        {
            int eid = 0;
            try
            {
                empcmd1 = new SqlCommand();
                cmd = new SqlCommand();
                empcmd = new SqlCommand("select IDENT_CURRENT('Group4.Employee') +IDENT_Incr('Group4.Employee')", con);
                con.Open();
                eid = int.Parse(empcmd.ExecuteScalar().ToString());
                //cusid = new SqlCommand("");



                cmd.CommandText = "Group4.udp_AddEmployee";

                cmd.Connection = con;
                empcmd1.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeName", pboj.EmployeeName);
                cmd.Parameters.AddWithValue("@EmailID", pboj.EmailID);
                cmd.Parameters.AddWithValue("@EmployeeAddress", pboj.Address);
                cmd.Parameters.AddWithValue("@PhoneNumber", pboj.PhoneNumber);
                cmd.Parameters.AddWithValue("@Designation", pboj.Designation);
                cmd.Parameters.AddWithValue("@DirvingLicenseNumber", pboj.DrivingLicenseNumber);
                empcmd1.CommandText = "Group4.udp_InsertEmpUser";
                empcmd1.CommandType = CommandType.StoredProcedure;
                empcmd1.Parameters.AddWithValue("@LoginID", users.LoginID);
                empcmd1.Parameters.AddWithValue("@UserPassword", users.Password);
                empcmd1.Parameters.AddWithValue("@EmployeeID", eid);
                empcmd1.Parameters.AddWithValue("@UserRole", users.Role);
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                int noOfRowsAffected1 = empcmd1.ExecuteNonQuery();
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
            return eid;
        }
        public bool UpdateEmployee_DAL(Employee pboj)
        {
            bool result = false;
            //try
            //{
            //    cmd = new SqlCommand();
            //    cmd.CommandText = "Group4.udp_SearchEmployee";
            //    cmd.Connection = con;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@EmployeeID", pboj);

            //    con.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        dr.Read();
            //        p = new Employee();

            //        p.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
            //        p.EmployeeName = dr["EmployeeName"].ToString();
            //        p.EmailID = dr["EmailID"].ToString();
            //        p.Address = dr["EmployeeAddress"].ToString();
            //        p.PhoneNumber = long.Parse(dr["PhoneNumber"].ToString());
            //        p.DrivingLicenseNumber = dr["DirvingLicenseNumber"].ToString();
            //        p.Designation = dr["Designation"].ToString();

            //        dr.Close();
            //    }
            //}
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_UpdateEmployee";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", pboj.EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeName", pboj.EmployeeName);
                cmd.Parameters.AddWithValue("@EmailID", pboj.EmailID);
                cmd.Parameters.AddWithValue("@DirvingLicenseNumber", pboj.DrivingLicenseNumber);
                cmd.Parameters.AddWithValue("@Designation", pboj.Designation);
                cmd.Parameters.AddWithValue("@EmployeeAddress", pboj.Address);
                cmd.Parameters.AddWithValue("@PhoneNumber", pboj.PhoneNumber);

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
        public bool DeleteEmployee_DAL(int employeeID)
        {
            bool result = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_DeleteEmployee";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
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
        public DataTable DisplayEmployee_DAL()
        {
            DataTable dt = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_DisplayEmployee";
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
        public Employee SearchEmployee_DAL(int employeeID)
        {
            Employee p = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_SearchEmployee";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    p = new Employee();

                    p.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                    p.EmployeeName = dr["EmployeeName"].ToString();
                    p.EmailID = dr["EmailID"].ToString();
                    p.Address = dr["EmployeeAddress"].ToString();
                    p.PhoneNumber = long.Parse(dr["PhoneNumber"].ToString());
                    p.DrivingLicenseNumber = dr["DirvingLicenseNumber"].ToString();
                    p.Designation = dr["Designation"].ToString();

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
