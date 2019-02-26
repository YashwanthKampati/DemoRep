using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TBS_BLL;
using TBS_Entity;
using TBS_Exception;

namespace TBS_PL
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void BtnChangePwd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Users u = new Users();
                u.LoginID = (txtLoginID.Text);
                u.Password = txtNewPwd.Text;
                AuthenticationValidation av = new AuthenticationValidation();
                if (av.UpdateUser_BLL(u))
                {
                    MessageBox.Show(string.Format("Password Changed Successfully"), "Change Password");
                    txtLoginID.Clear();
                    txtNewPwd.Clear();
                }
                else
                {
                    MessageBox.Show(string.Format("User with Login Id does not exist"), "Change Password");
                }
            }
            catch(UsersException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
