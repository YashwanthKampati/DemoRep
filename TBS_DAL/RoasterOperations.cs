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
    public class RoasterOperations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pboj"></param>
        /// <returns></returns>
        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlCommand displaycmd = null;
        static RoasterOperations()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }
        public RoasterOperations()
        {
            con = new SqlConnection(conStr);
        }
        public DataTable AddRoaster_DAL(EmployeeRoster pboj)
        {
            DataTable rid = null;
            try
            { 
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_InsertEmployeeRoster";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RosterID", pboj.RosterID);
                cmd.Parameters.AddWithValue("@EmployeeID", pboj.EmployeeID);
                cmd.Parameters.AddWithValue("@FromDate", pboj.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", pboj.ToDate);
                cmd.Parameters.AddWithValue("@InTime", pboj.InTime);
                cmd.Parameters.AddWithValue("@OutTime", pboj.OutTime);
                con.Open();
                displaycmd = new SqlCommand("Group4.udp_DisplayEmployeeRoster", con);
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                //pid = int.Parse(cmd.Parameters["@RosterID"].Value.ToString());
                SqlDataReader dr = displaycmd.ExecuteReader();
                if (noOfRowsAffected!=0)
                {
                    rid = new DataTable();
                    rid.Load(dr);
                    return rid;
                }
                else return rid;
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


        }
        #region UpdateRoaster
        //public bool UpdateRoasterDAL(EmployeeRoster pboj)
        //{
        //    bool result = false;
        //    try
        //    {
        //        cmd = new SqlCommand();
        //        cmd.CommandText = "Geetha.uspEditProduct";
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@up", pboj.RosterID);
        //        cmd.Parameters.AddWithValue("@up", pboj.EmployeeID);
        //        cmd.Parameters.AddWithValue("@st", pboj.FromDate);
        //        cmd.Parameters.AddWithValue("@cat", pboj.ToDate);
        //        cmd.Parameters.AddWithValue("@cat", pboj.InTime);
        //        cmd.Parameters.AddWithValue("@cat", pboj.OutTime);
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
        #region DeleteRoaster
        //public bool DeleteRoaster_DAL(int roasterID)
        //{

        //    bool result = false;
        //    try
        //    {
        //        //  con = new SqlConnection();
        //        // con.ConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        //        cmd = new SqlCommand();
        //        cmd.CommandText = "Geetha.uspDeleteProduct";
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@pId", roasterID);

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
        public DataTable DisplayRoaster_DAL()
        {
            DataTable dt = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_DisplayEmployeeRoster";
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
        #region SearchRoaster
        //public EmployeeRoster SearchRoaster_DAL(int roasterID)
        //{
        //    EmployeeRoster p = null;

        //    try
        //    {
        //        //  con = new SqlConnection();
        //        //con.ConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        //        cmd = new SqlCommand();
        //        cmd.CommandText = "Geetha.uspSearchProduct";
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@pId", roasterID);

        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            dr.Read();
        //            p = new EmployeeRoster
        //            {
        //                EmployeeID = int.Parse(dr["EmployeeID"].ToString()),
        //                RosterID = int.Parse(dr["RosterID"].ToString()),
        //                FromDate = DateTime.Parse(dr["EmailID"].ToString()),
        //                ToDate = DateTime.Parse(dr["ToDate"].ToString()),
        //                InTime = DateTime.Parse(dr["InTime"].ToString()),
        //                OutTime = DateTime.Parse(dr["OutTime"].ToString())

        //            };
        //            dr.Close();
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
        //    return p;
        //}
        #endregion
        public DataTable CheckRoster_DAL(EmployeeRoster roster)
        {
            DataTable dt = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_SearchEmployeeRoster";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", roster.EmployeeID);

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
        public DataTable CheckDailyLog_DAL(EmployeeRoster roster)
        {
            DataTable dt = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_CheckLog";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", roster.EmployeeID);

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
    }
}

