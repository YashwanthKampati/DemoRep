using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TBS_DAL;
using TBS_Entity;
using TBS_Exception;

namespace TBS_BLL
{
    public class EmployeeValidations
    {
        private bool ValidateEmployee(Employee newEmp, Users users)
        {
            bool isValidEmp = true;
            StringBuilder sbClientError = new StringBuilder();
            //validation for blank Name
            if (newEmp.EmployeeName.Equals(string.Empty))
            {
                isValidEmp = false;
                sbClientError.Append("Name cannot be empty!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newEmp.EmployeeName, @"[A-Z][a-z]{3,}")))
            {
                isValidEmp = false;
                sbClientError.Append("Name must have only characters starting with Uppercase " + Environment.NewLine);
            }
            if (newEmp.Designation.Equals(string.Empty))
            {
                isValidEmp = false;
                sbClientError.Append("Invalid Designation!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newEmp.Designation, @"[A-Za-z]{3,}")))
            {
                isValidEmp = false;
                sbClientError.Append("Name must have only characters starting with Uppercase " + Environment.NewLine);
            }
            //validation for blank Email ID
            if (newEmp.EmailID.Equals(string.Empty))
            {
                isValidEmp = false;
                sbClientError.Append("Email cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newEmp.EmailID, @"[\w]+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")))
            {
                isValidEmp = false;
                sbClientError.Append("Enter Valid Email Id!" + Environment.NewLine);
            }
            if (newEmp.PhoneNumber.Equals(string.Empty))
            {
                isValidEmp = false;
                sbClientError.Append("Phone Number cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newEmp.PhoneNumber.ToString(), @"^[6-9][0-9]{9}")))
            {
                isValidEmp = false;
                sbClientError.Append("Enter Valid Phone Number!" + Environment.NewLine);
            }
            if (newEmp.Address.Equals(string.Empty))
            {
                isValidEmp = false;
                sbClientError.Append("Address cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newEmp.Address, @"\w{3,}")))
            {
                isValidEmp = false;
                sbClientError.Append("Address Should have atleast 3 letters" + Environment.NewLine);
            }
            if (newEmp.DrivingLicenseNumber.Equals(string.Empty))
            {
                isValidEmp = false;
                sbClientError.Append("Driving License cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newEmp.DrivingLicenseNumber, @"[A-Za-z][0-9]{7,7}")))
            {
                isValidEmp = false;
                sbClientError.Append("Enter Valid Driving License Number" + Environment.NewLine);
            }
            if (users.LoginID.Equals(string.Empty))
            {
                isValidEmp = false;
                sbClientError.Append("LoginID cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(users.LoginID, @"\w{5,}")))
            {
                isValidEmp = false;
                sbClientError.Append("Login ID Should have atleast 5 letters" + Environment.NewLine);
            }
            if (users.Password.Equals(string.Empty))
            {
                isValidEmp = false;
                sbClientError.Append("Password cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(users.Password, @"\w{5,}")))
            {
                isValidEmp = false;
                sbClientError.Append("Password Should have atleast 5 letters" + Environment.NewLine);
            }
            if (!isValidEmp)
            {
                throw new EmployeeException(sbClientError.ToString());
            }
            return isValidEmp;
        }
        private bool ValidateUpdate(Employee newEmp)
        {
            bool isValidEmp = true;
            StringBuilder sbClientError = new StringBuilder();
            //validation for blank LoginID
            if (newEmp.EmployeeName.Equals(string.Empty))
            {
                isValidEmp = false;
                sbClientError.Append("Name cannot be empty!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newEmp.EmployeeName, @"[A-Z][a-z]{3,}")))
            {
                isValidEmp = false;
                sbClientError.Append("Name must have only characters starting with Uppercase " + Environment.NewLine);
            }
            //validation for blank Password
            if (newEmp.EmailID.Equals(string.Empty))
            {
                isValidEmp = false;
                sbClientError.Append("Email cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newEmp.EmailID, @"[\w]+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")))
            {
                isValidEmp = false;
                sbClientError.Append("Enter Valid Email Id!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newEmp.PhoneNumber.ToString(), @"^[6-9][0-9]{9}")))
            {
                isValidEmp = false;
                sbClientError.Append("Enter Valid Phone Number!" + Environment.NewLine);
            }
            if (newEmp.Address.Equals(string.Empty))
            {
                isValidEmp = false;
                sbClientError.Append("Address cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newEmp.Address, @"\w{3,}")))
            {
                isValidEmp = false;
                sbClientError.Append("Address Should have atleast 3 letters" + Environment.NewLine);
            }
            if (!isValidEmp)
            {
                throw new EmployeeException(sbClientError.ToString());
            }
            return isValidEmp;
        }
        public int AddEmployee_BLL(Employee pobj,Users users)
        {
            try
            {
                EmployeeOperations pd = new EmployeeOperations();
                return pd.AddEmployee_DAL(pobj,users);
            }
            catch (EmployeeException)
            {
                throw;
            }
        }

        public bool UpdateEmployee_BLL(Employee pobj)
        {
            try
            {
                EmployeeOperations pd = new EmployeeOperations();
                return pd.UpdateEmployee_DAL(pobj);
            }
            catch (EmployeeException)
            {
                throw;
            }
        }

        public bool DeleteEmployee_BLL(int employeeID)
        {
            try
            {
                EmployeeOperations pd = new EmployeeOperations();
                return pd.DeleteEmployee_DAL(employeeID);
            }
            catch (EmployeeException)
            {
                throw;
            }
        }

        public Employee SearchEmployee_BLL(int employeeID)
        {
            try
            {
                EmployeeOperations pd = new EmployeeOperations();
                return pd.SearchEmployee_DAL(employeeID);
            }
            catch (EmployeeException)
            {
                throw;
            }
        }

        public DataTable DisplayEmployee_BLL()
        {
            try
            {
                EmployeeOperations pd = new EmployeeOperations();
                return pd.DisplayEmployee_DAL();
            }
            catch (EmployeeException)
            {
                throw;
            }
        }
    }
}
