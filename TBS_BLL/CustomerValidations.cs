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
    public class CustomerValidations
    {
        private bool ValidateCustomer(Customer newCust,Users users)
        {
            bool isValidCust = true;
            StringBuilder sbClientError = new StringBuilder();
            //validation for blank LoginID
            if (newCust.CustomerName.Equals(string.Empty))
            {
                isValidCust = false;
                sbClientError.Append("Name cannot be empty!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newCust.CustomerName, @"[A-Z][a-z]{3,}")))
            {
                isValidCust = false;
                sbClientError.Append("Name must have only characters starting with Uppercase " + Environment.NewLine);
            }
            //validation for blank Password
            if (newCust.EmailID.Equals(string.Empty))
            {
                isValidCust = false;
                sbClientError.Append("Email cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newCust.EmailID, @"[\w]+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")))
            {
                isValidCust = false;
                sbClientError.Append("Enter Valid Email Id!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newCust.PhoneNumber.ToString(), @"^[6-9][0-9]{9}")))
            {
                isValidCust = false;
                sbClientError.Append("Enter Valid Phone Number!" + Environment.NewLine);
            }
            if (newCust.Address.Equals(string.Empty))
            {
                isValidCust = false;
                sbClientError.Append("Address cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newCust.Address, @"\w{3,}")))
            {
                isValidCust = false;
                sbClientError.Append("Address Should have atleast 3 letters" + Environment.NewLine);
            }
            if (users.LoginID.Equals(string.Empty))
            {
                isValidCust = false;
                sbClientError.Append("LoginID cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(users.LoginID, @"\w{5,}")))
            {
                isValidCust = false;
                sbClientError.Append("Login ID Should have atleast 5 letters" + Environment.NewLine);
            }
            if (users.Password.Equals(string.Empty))
            {
                isValidCust = false;
                sbClientError.Append("Password cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(users.Password, @"\w{5,}")))
            {
                isValidCust = false;
                sbClientError.Append("Password Should have atleast 5 letters" + Environment.NewLine);
            }
            if (!isValidCust)
            {
                throw new CustomerException(sbClientError.ToString());
            }
            return isValidCust;
        }
        private bool ValidateUpdate(Customer newCust)
        {
            bool isValidCust = true;
            StringBuilder sbClientError = new StringBuilder();
            //validation for blank LoginID
            if (newCust.CustomerName.Equals(string.Empty))
            {
                isValidCust = false;
                sbClientError.Append("Name cannot be empty!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newCust.CustomerName, @"[A-Z][a-z]{3,}")))
            {
                isValidCust = false;
                sbClientError.Append("Name must have only characters starting with Uppercase " + Environment.NewLine);
            }
            //validation for blank Password
            if (newCust.EmailID.Equals(string.Empty))
            {
                isValidCust = false;
                sbClientError.Append("Email cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newCust.EmailID, @"[\w]+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")))
            {
                isValidCust = false;
                sbClientError.Append("Enter Valid Email Id!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newCust.PhoneNumber.ToString(), @"^[6-9][0-9]{9}")))
            {
                isValidCust = false;
                sbClientError.Append("Enter Valid Phone Number!" + Environment.NewLine);
            }
            if (newCust.Address.Equals(string.Empty))
            {
                isValidCust = false;
                sbClientError.Append("Address cannot be blank!!" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(newCust.Address, @"\w{3,}")))
            {
                isValidCust = false;
                sbClientError.Append("Address Should have atleast 3 letters" + Environment.NewLine);
            }
            if (!isValidCust)
            {
                throw new CustomerException(sbClientError.ToString());
            }
            return isValidCust;
        }
        public int AddCustomer_BLL(Customer pobj,Users users)
        {
            int cid = 0;
            try
            {
                CustomerOperations pd = new CustomerOperations();
                if (ValidateCustomer(pobj,users))
                {
                    cid= pd.AddCustomer_DAL(pobj, users);
                    return cid;
                }
            }
            catch (CustomerException)
            {
                throw;
            }
            return cid;

        }
        public bool UpdateCustomer_BLL(Customer pobj)
        {
            bool updCust = false;
            try
            {
                CustomerOperations co = new CustomerOperations();
                if (ValidateUpdate(pobj))
                {
                    updCust = co.UpdateCustomer_DAL(pobj);
                    return updCust;
                }
                
            }
            catch (CustomerException)
            {
                throw;
            }
            return updCust;
        }
        public bool DeleteCustomer_BLL(int customerID)
        {
            try
            {
                CustomerOperations pd = new CustomerOperations();
                return pd.DeleteCustomer_DAL(customerID);
            }
            catch (CustomerException)
            {
                throw;
            }
        }

        public Customer SearchCustomer_BLL(int customerID)
        {
            try
            {
                CustomerOperations pd = new CustomerOperations();
                return pd.SearchCustomer_DAL(customerID);
            }
            catch (CustomerException)
            {
                throw;
            }
        }

        public DataTable DisplayCustomer_BLL()
        {
            try
            {
                CustomerOperations pd = new CustomerOperations();
                return pd.DisplayCustomer_DAL();
            }
            catch (CustomerException)
            {
                throw;
            }
        }
    }
}
