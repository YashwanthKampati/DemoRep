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
    /// Interaction logic for CheckRoster.xaml
    /// </summary>
    public partial class CheckRoster : Window
    {
        public CheckRoster()
        {
            InitializeComponent();
        }

        private void BtnRoster_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployeeRoster er = new EmployeeRoster();
                er.EmployeeID = int.Parse(txtEId.Text);
                RosterValidations roster = new RosterValidations();
                DataTable dt = roster.CheckRoster_BLL(er);
                if (dt!=null)
                {
                    MessageBox.Show("Roster Details Found");
                    dgRoster.Visibility = Visibility.Visible;
                    dgLog.Visibility = Visibility.Hidden;
                    dgRoster.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Enter valid employee ID");
                }
            }
            catch (EmployeeRosterException er)
            {
                MessageBox.Show(er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnDailyLog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployeeRoster er = new EmployeeRoster();
                er.EmployeeID = int.Parse(txtEId.Text);
                RosterValidations roster = new RosterValidations();
                DataTable dt = roster.CheckRoster_BLL(er);
                if (dt != null)
                {
                    dgRoster.Visibility = Visibility.Hidden;
                    dgLog.Visibility = Visibility.Visible;
                    MessageBox.Show("Daily Log Found");
                    dgRoster.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Enter valid Employee ID");
                }
            }
            catch (EmployeeRosterException er)
            {
                MessageBox.Show(er.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
