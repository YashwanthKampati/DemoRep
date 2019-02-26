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
    public class FeedbackOperations
    {
        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;
        static FeedbackOperations()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }
        public FeedbackOperations()
        {
            con = new SqlConnection(conStr);
        }
        public Feedback SearchFeedback_DAL(DateTime date)
        {
            Feedback f = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.usp_SearchFeedback";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Date", date);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    f = new Feedback();
                    f.FeedbackID = int.Parse(dr["FeedbackID"].ToString());
                    f.FeedbackMessage = dr["FeedbackMsg"].ToString();
                    f.FeedbackDate = DateTime.Parse(dr["FeedbackDate"].ToString());
                    f.LoginID = dr["LoginID"].ToString();
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
            return f;
        }
    }
}
