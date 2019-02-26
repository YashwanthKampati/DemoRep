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
    /// Interaction logic for ManageUsers.xaml
    /// </summary>
    public partial class ManageUsers : Window
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            
            
            
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee emp = new Employee();

                EmployeeValidations ev = new EmployeeValidations();
                emp.EmployeeID = int.Parse(txtEId.Text.ToString());
                emp.EmployeeName = txtEName.Text.ToString();
                emp.Designation = txtDesgn.Text.ToString();
                emp.PhoneNumber = double.Parse(txtPhone.Text.ToString());
                emp.EmailID = txtEmail.Text.ToString();
                emp.Address = txtAddress.Text.ToString();
                emp.DrivingLicenseNumber = txtDL.Text.ToString();
                bool updateStatus = ev.UpdateEmployee_BLL(emp);

                if (updateStatus)
                {
                    MessageBox.Show("Employee Details Updated");
                    gridEmployee.Visibility = Visibility.Hidden;
                    txtEId.Clear();
                    txtEName.Clear();
                    txtDesgn.Clear();
                    txtPhone.Clear();
                    txtEmail.Clear();
                    txtAddress.Clear();
                    txtDL.Clear();
                }
                else
                {
                    MessageBox.Show("Employee Cannot be Updated");
                }
            }
            catch (EmployeeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee emp = new Employee();

                EmployeeValidations ev = new EmployeeValidations();
                int eid = int.Parse(txtEId.Text.ToString());
                bool deleteStatus = ev.DeleteEmployee_BLL(eid);
                if (deleteStatus)
                {
                    MessageBox.Show("Employee Details Deleted");
                    gridEmployee.Visibility = Visibility.Hidden;
                    txtEId.Clear();
                    txtEName.Clear();
                    txtDesgn.Clear();
                    txtPhone.Clear();
                    txtEmail.Clear();
                    txtAddress.Clear();
                    txtDL.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btnupdatec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer cust = new Customer();

                CustomerValidations cv = new CustomerValidations();
                cust.CustomerID = int.Parse(txtCId.Text.ToString());
                cust.CustomerName = txtCName.Text.ToString();
                cust.EmailID = txtCEmail.Text.ToString();
                cust.PhoneNumber = long.Parse(txtCPhone.Text.ToString());
                cust.Address = txtCAddress.Text.ToString();
                bool updateStatus = cv.UpdateCustomer_BLL(cust);

                if (updateStatus)
                {
                    MessageBox.Show("Customer Details Updated");
                    gridCustomer.Visibility = Visibility.Hidden;
                    txtCId.Clear();
                    txtCName.Clear();
                    txtCEmail.Clear();
                    txtCPhone.Clear();
                    txtCAddress.Clear();
                }
                else
                {
                    MessageBox.Show("Customer Cannot be Updated");
                }
            }
            catch(CustomerException ce)
            {
                MessageBox.Show(ce.Message);
            }
            catch (Exception ce)
            {
                MessageBox.Show(ce.Message);
            }
        }

        private void Btndeletec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer cust = new Customer();

                CustomerValidations cv = new CustomerValidations();
                int cid = int.Parse(txtCId.Text.ToString());
                bool deleteStatus = cv.DeleteCustomer_BLL(cid);
                if (deleteStatus)
                {
                    MessageBox.Show("Customer Details Deleted");
                    gridEmployee.Visibility = Visibility.Hidden;
                    txtCId.Clear();
                    txtCName.Clear();
                    txtCPhone.Clear();
                    txtCEmail.Clear();
                    txtCAddress.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnMainSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gridEmployee.Visibility = Visibility.Hidden;
                gridCustomer.Visibility = Visibility.Hidden;
                if (rbEmployee.IsChecked == true)
                {
                    Employee emp = new Employee();

                    EmployeeValidations ev = new EmployeeValidations();
                    int eid = int.Parse(txtSearch.Text);
                    emp = ev.SearchEmployee_BLL(eid);

                    if (emp != null)
                    {

                        txtEId.Text = emp.EmployeeID.ToString();
                        txtEName.Text = emp.EmployeeName;
                        txtDesgn.Text = emp.Designation;
                        txtPhone.Text = emp.PhoneNumber.ToString();
                        txtEmail.Text = emp.EmailID;
                        txtAddress.Text = emp.Address;
                        txtDL.Text = emp.DrivingLicenseNumber;
                        gridEmployee.Visibility = Visibility.Visible;
                        gridCustomer.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        MessageBox.Show("Employee Not Found");
                    }
                }
                else if (rbCustomer.IsChecked == true)
                {
                    Customer cust = new Customer();

                    CustomerValidations cv = new CustomerValidations();
                    int cid = int.Parse(txtSearch.Text);
                    cust = cv.SearchCustomer_BLL(cid);

                    if (cust != null)
                    {
                        txtCId.Text = cust.CustomerID.ToString();
                        txtCName.Text = cust.CustomerName;
                        txtCEmail.Text = cust.EmailID;
                        txtCPhone.Text = cust.PhoneNumber.ToString();
                        txtCAddress.Text = cust.Address;
                        gridCustomer.Visibility = Visibility.Visible;
                        gridEmployee.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        MessageBox.Show("Customer Not Found");
                    }
                }
                else
                {
                    gridEmployee.Visibility = Visibility.Hidden;
                    gridCustomer.Visibility = Visibility.Hidden;
                    MessageBox.Show("Select Employee or Customer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
