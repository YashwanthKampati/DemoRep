using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AddRoster.xaml
    /// </summary>
    public partial class AddRoster : Window
    {
        public AddRoster()
        {
            InitializeComponent();
        }

        private void Btn_AddRoster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployeeRoster er = new EmployeeRoster();
                er.EmployeeID = int.Parse(txt_EmpID.Text.ToString());
                er.RosterID = (RosterEnum)int.Parse(txt_RosterID.Text);
                er.FromDate = DateTime.Parse(dt_FromDate.Text);
                er.ToDate = DateTime.Parse(dt_ToDate.Text);
                er.InTime = DateTime.Parse(txt_InHour.Text + ":" + txt_InMins.Text);
                er.OutTime = DateTime.Parse(txt_OutHour.Text + ":" + txt_OutMins.Text);
                RosterValidations rv = new RosterValidations();
                DataTable displayRoster=rv.AddRoaster_BLL(er);
                if (displayRoster != null)
                {
                    MessageBox.Show("Roster Details are added");
                    dgEmployee.ItemsSource = displayRoster.DefaultView;
                }
                else throw new EmployeeRosterException("Entered details are not correct");
            }
            catch (EmployeeRosterException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable displayRoster = null;
            RosterValidations rv = new RosterValidations();
            displayRoster = rv.DisplayRoaster_BLL();
            if (displayRoster != null)
            {
                dgEmployee.ItemsSource = displayRoster.DefaultView;
            }
            else throw new EmployeeRosterException("No Roster to display");
            
        }
        ////RosterID int ,
        ////EmployeeID int constraint RosterEmpID_FK foreign key references Group4.Employee(EmployeeID),
        ////FromDate date,
        ////ToDate date, 
        ////InTime time,
        ////OutTime time
    }
}
