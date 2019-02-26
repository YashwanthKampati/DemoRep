using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBS_Entity;
using TBS_Exception;
using TBS_DAL;
using System.Data;
using System.Text.RegularExpressions;

namespace TBS_BLL
{
    public class RosterValidations
    {
        private bool ValiadateRoster(EmployeeRoster newRoster)
        {
            bool isValidRoster = true;
            StringBuilder sbClientError = new StringBuilder();
            if (newRoster.EmployeeID.Equals(string.Empty))
            {
                isValidRoster = false;
                sbClientError.Append("Employee ID cannot be empty!!:)" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newRoster.EmployeeID.ToString(), @"[0-9]{3,3}")))
            {
                isValidRoster = false;
                sbClientError.Append("Emplpoyee ID can have only 4 digits" + Environment.NewLine);
            }
            if (newRoster.RosterID.Equals(string.Empty))
            {
                isValidRoster = false;
                sbClientError.Append("Roster ID  cannot be blank!!:)" + Environment.NewLine);
            }
            if (newRoster.InTime.Equals(string.Empty))
            {
                isValidRoster = false;
                sbClientError.Append("In Time cannot be empty!!:)" + Environment.NewLine);
            }
            if (newRoster.OutTime.Equals(string.Empty))
            {
                isValidRoster = false;
                sbClientError.Append("Out Time cannot be empty!!:)" + Environment.NewLine);
            }
            if (newRoster.ToDate.Equals(string.Empty))
            {
                isValidRoster = false;
                sbClientError.Append("To Date  cannot be blank!!:)" + Environment.NewLine);
            }
            if (newRoster.FromDate.Equals(string.Empty))
            {
                isValidRoster = false;
                sbClientError.Append("From Date  cannot be blank!!:)" + Environment.NewLine);
            }
            if (!isValidRoster)
            {
                throw new EmployeeRosterException(sbClientError.ToString());
            }
            return isValidRoster;
        }
        public DataTable AddRoaster_BLL(EmployeeRoster robj)
        {
            DataTable addRoster = null;
            try
            {
                RoasterOperations pd = new RoasterOperations();
                if (ValiadateRoster(robj))
                {
                    addRoster=pd.AddRoaster_DAL(robj);
                    return addRoster;
                }
            }
            catch (EmployeeRosterException)
            {
                throw;
            }
            return addRoster;
        }
        public DataTable DisplayRoaster_BLL()
        {
            try
            {
                RoasterOperations pd = new RoasterOperations();
                return pd.DisplayRoaster_DAL();
            }
            catch (EmployeeRosterException)
            {
                throw;
            }
        }
        public DataTable CheckRoster_BLL(EmployeeRoster roster)
        {
            try
            {
                RoasterOperations pd = new RoasterOperations();
                return pd.CheckRoster_DAL(roster);
            }
            catch (EmployeeRosterException)
            {
                throw;
            }
        }
        public DataTable CheckDailyLog_BLL(EmployeeRoster roster)
        {
            try
            {
                RoasterOperations pd = new RoasterOperations();
                return pd.CheckDailyLog_DAL(roster);
            }
            catch (EmployeeRosterException)
            {
                throw;
            }
        }
    }
}
