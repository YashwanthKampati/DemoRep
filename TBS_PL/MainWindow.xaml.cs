using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TBS_BLL;
using TBS_Entity;
using TBS_Exception;

namespace TBS_PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //    string connStr = ConfigurationManager.ConnectionStrings["ConStr"].ToString();
        //    SqlConnection conObj = new SqlConnection();
        //    SqlCommand cmdObj;
        //    DataTable dtStudent = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
        }
        public static string id = null;
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            CustomerHome customer = new CustomerHome();
            
            try
            {
                Users newUser = new Users();
                AuthenticationValidation user = new AuthenticationValidation();
                newUser.LoginID = (txtloginID.Text);
                id = newUser.LoginID;
                newUser.Password = txtPassword.Password.ToString();
                string userRole = user.Login_BLL(newUser);
                if (userRole.ToLower() == "customer")
                {
                    MessageBox.Show(string.Format("Login Successful"), "Login Window");
                    customer.EmployeeMenu.Visibility = Visibility.Hidden;
                    customer.AdminMenu.Visibility = Visibility.Hidden;
                    customer.Show();
                    Close();
                }
                else if (userRole.ToLower() == "employee")
                {
                    MessageBox.Show(string.Format("Login Successful"), "Login Window");
                    customer.CustomerMenu.Visibility = Visibility.Hidden;
                    customer.AdminMenu.Visibility = Visibility.Hidden;
                    customer.Show();
                    Close();
                }
                else if (userRole.ToLower() == "admin")
                {
                    MessageBox.Show(string.Format("Login Successful"), "Login Window");
                    customer.CustomerMenu.Visibility = Visibility.Hidden;
                    customer.EmployeeMenu.Visibility = Visibility.Hidden;
                    customer.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show(string.Format("Invalid Login"),"Login Window");
                }
            }
            catch (UsersException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_signup_Click(object sender, RoutedEventArgs e)
        {
            SignUp su = new SignUp();
            su.Show();
            Close();
        }
    }
}
