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
    public class BookingOperations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pboj"></param>
        /// <returns></returns>
        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlCommand cmd1 = null;


        static BookingOperations()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        }

        public BookingOperations()
        {
            con = new SqlConnection(conStr);

        }
        public int BookingTaxi_DAL(Booking pboj,string LoginId)
        {
            int pid = 0;
            int getId = 0;
            try
            {
                cmd = new SqlCommand();
                cmd1 = new SqlCommand("select IDENT_CURRENT('Group4.Booking')", con);
                con.Open();

                pid = int.Parse(cmd1.ExecuteScalar().ToString());
                cmd.CommandText = "Group4.udp_InsertBooking";
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                SqlCommand cmd2 = new SqlCommand($"select CustomerID from group4.Users where LoginID='{LoginId}'", con);
                getId = int.Parse(cmd2.ExecuteScalar().ToString());
                pid = int.Parse(cmd1.ExecuteScalar().ToString());
                cmd.Parameters.AddWithValue("@CustomerID", getId);
                cmd.Parameters.AddWithValue("@BookingDate", pboj.BookingDate.ToShortDateString());
                cmd.Parameters.AddWithValue("@EndTime", pboj.EndDate);
                cmd.Parameters.AddWithValue("@StartTime", pboj.StartDate);
                cmd.Parameters.AddWithValue("@TaxiID", pboj.TaxiID);
                cmd.Parameters.AddWithValue("@TripDate", pboj.TripDate.ToShortDateString());
                cmd.Parameters.AddWithValue("@SourceAddress", pboj.SourceAddress);
                cmd.Parameters.AddWithValue("@DestinationAddress", pboj.DestinationAddress);

                int noOfRowsAffected = cmd.ExecuteNonQuery();
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
            return pid;
        }
        public DataTable CheckBooking_DAL(string EmpID)
        {
            SqlDataReader dr;
            int TaxiID = 0;
            int EmpID1 = 0;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand($"select EmployeeID from Group4.Users where LoginID='{EmpID}'", con);
                EmpID1 = int.Parse(cmd2.ExecuteScalar().ToString());
                cmd = new SqlCommand("Group4.udpCheekBooking");
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", EmpID1);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt1.Load(dr);
                    TaxiID = int.Parse(dt1.Rows[0][0].ToString());
                    dr.Close();
                }
                if (TaxiID != 0)
                {
                    SqlCommand cmd1 = new SqlCommand("Group4.udpCheekBooking1");
                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@TaxiID", TaxiID);

                    dr = cmd1.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dt2.Load(dr);
                        dr.Close();
                    }
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
            return dt2;
        }
        public DataTable PrintReport_DAL(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand("Group4.usp_Report");
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@EndDate", toDate);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

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
        public DataTable Book_Statusdal(string custId)
        {
            DataTable dt = new DataTable();
            try
            {

                cmd = new SqlCommand("group4.BookingStatus");
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlCommand cmd1 = new SqlCommand($"select CustomerID from group4.Users where LoginID='{custId}'", con);
                custId = (cmd1.ExecuteScalar().ToString());

                cmd.Parameters.AddWithValue("@CustomerID", custId);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

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
        public DataTable DisplayBook_DAL()
        {
            DataTable dt = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_DisplayBooking";
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
        public Booking SearchBook_DAL(int bookingID)
        {
            Booking p = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_SearchBooking";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookingID", bookingID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    p = new Booking
                    {
                        BookingID = int.Parse(dr["BookingID"].ToString()),
                        CustomerID = int.Parse(dr["CustomerID"].ToString()),
                        SourceAddress = dr["SourceAddress"].ToString(),
                        DestinationAddress = dr["DestinationAddress"].ToString(),
                        StartDate = DateTime.Parse(dr["StartDate"].ToString()),
                        EndDate = DateTime.Parse(dr["EndDate"].ToString()),
                        TaxiID = int.Parse(dr["TaxiID"].ToString()),
                        TripDate = DateTime.Parse(dr["TripDate"].ToString())
                    };
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
        public DataTable DisplayTaxi_DAL()
        {
            DataTable dt = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "select * from Group4.Taxi";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
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
        public DataTable DriverHistory_DAL(string id)
        {

            SqlDataReader dr = null;

            int TaxiID = 0;
            int Custid = 0;
            int EmployeeId = 0;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand($"select CustomerID from Group4.Users where LoginID='{id}'", con);
                dr = cmd2.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    Custid = int.Parse(dt.Rows[0][0].ToString());
                    dr.Close();
                    dt = null;
                }

                cmd = new SqlCommand($"select TaxiId from Group4.Booking where CustomerID={Custid}", con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt1.Load(dr);
                    TaxiID = int.Parse(dt1.Rows[0][0].ToString());
                    dr.Close();
                }
                if (TaxiID != 0)
                {
                    SqlCommand cmd1 = new SqlCommand($"select EmployeeId from Group4.Taxi where TaxiId={TaxiID}", con);

                    dr = cmd1.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dt2.Load(dr);
                        EmployeeId = int.Parse(dt2.Rows[0][0].ToString());
                        dr.Close();
                        dt2 = null;
                    }
                }
                if (EmployeeId != 0)
                {
                    SqlCommand cmd1 = new SqlCommand($"select *from Group4.Employee where EmployeeId={EmployeeId}", con);

                    dr = cmd1.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dt3.Load(dr);
                        dr.Close();
                    }
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
            return dt3;
        }
    }
}
