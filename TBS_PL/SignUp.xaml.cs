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
using TBS_Entity;
using TBS_BLL;
using TBS_Exception;

namespace TBS_PL
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        //Sign Up for Customer
        private void Btn_SignUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                Customer cust = new Customer();
                cust.CustomerName = txt_Name.Text.ToString();
                cust.EmailID = txt_Email.Text;
                
                if (txt_PhoneNumber.Text==string.Empty)
                {
                    sb.Append("Enter Valid Phone Number!" + Environment.NewLine);
                }
                else
                {
                    cust.PhoneNumber = long.Parse(txt_PhoneNumber.Text.ToString());
                }
                cust.Address = txt_Address.Text;
                Users users = new Users();
                users.LoginID = (txt_LoginID.Text);
                users.Password = txt_Password.Password.ToString();
                users.Role = "Customer";
                CustomerValidations cv = new CustomerValidations();
                if (cv.AddCustomer_BLL(cust, users)!=0)
                {
                    MessageBox.Show("Customer Details are added");
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    Close();
                }
                else { throw new CustomerException("Enter details are not correct"); }
            }
            catch(CustomerException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Cancel 
        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
    }
}
