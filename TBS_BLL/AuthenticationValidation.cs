using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBS_DAL;
using TBS_Entity;
using TBS_Exception;

namespace TBS_BLL
{
    public class AuthenticationValidation
    {
        private bool ValidateLogin(Users newUser)
        {
            bool isValidLogin = true;
            StringBuilder sbClientError = new StringBuilder();
            //validation for blank LoginID
            if (newUser.LoginID.Equals(string.Empty))
            {
                isValidLogin = false;
                sbClientError.Append("LoginID cannot be empty!!" + Environment.NewLine);
            }
            //validation for blank Password
            if (newUser.Password.Equals(string.Empty))
            {
                isValidLogin = false;
                sbClientError.Append("Password cannot be blank!!" + Environment.NewLine);
            }
            if (!isValidLogin)
            {
                throw new UsersException(sbClientError.ToString());
            }
            return isValidLogin;
        }
        public string Login_BLL(Users pbobj)
        {
            string userRole = null;
            try
            {
                Authentication pd = new Authentication();
                if (ValidateLogin(pbobj))
                {
                    userRole = pd.Login(pbobj);
                    return userRole;
                }
            }
            catch (UsersException)
            {
                throw;
            }
            return userRole;
        }
        public bool UpdateUser_BLL(Users u)
        {
            try
            {
                Authentication au = new Authentication();
                return au.UpdateUser_DAL(u);
            }
            catch (UsersException)
            {
                throw;
            }
        }

    }
}
