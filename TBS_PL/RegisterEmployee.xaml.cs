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
    /// Interaction logic for RegisterEmployee.xaml
    /// </summary>
    public partial class RegisterEmployee : Window
    {
        public RegisterEmployee()
        {
            InitializeComponent();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            CustomerHome ch = new CustomerHome();
            ch.Show();
            Close();
        }

        private void Btn_EmpRegister_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Employee emp = new Employee();
                emp.EmployeeName = txt_EName.Text.ToString();
                emp.EmailID = txt_Email.Text;
                emp.PhoneNumber = long.Parse(txt_Phone.Text.ToString());
                emp.Designation = txt_Desgn.Text.ToString();
                emp.Address = txt_Address.Text;
                emp.DrivingLicenseNumber = txt_License.Text.ToString();
                Users users = new Users();
                users.LoginID = (txt_LoginID.Text);
                users.Password = txt_Password.Password.ToString();
                users.Role = "Employee";
                //users.EmployeeID = 0;

                EmployeeValidations ev = new EmployeeValidations();
                if (ev.AddEmployee_BLL(emp, users) != 0)
                {
                    MessageBox.Show("Employee Details are added");
                    Close();
                }
                else { throw new EmployeeException("Entered details are not correct"); }
            }
            catch (EmployeeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
