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

namespace TBS_PL
{
    /// <summary>
    /// Interaction logic for CustomerHome.xaml
    /// </summary>
    public partial class CustomerHome : Window
    {
        public CustomerHome()
        {
            InitializeComponent();
        }

        
        //Search Menu Item Click

        private void SearchMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        //Sign Out Menu Item Click

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void Btn_CheckBookings_Click(object sender, RoutedEventArgs e)
        {
            CheckBooking check = new CheckBooking();
            check.Show();
        }

        private void Btn_BookTaxi_Click(object sender, RoutedEventArgs e)
        {
            BookingHome booking = new BookingHome();
            booking.Show();
        }

        private void Btn_RegisterEmployees_Click(object sender, RoutedEventArgs e)
        {
            RegisterEmployee register = new RegisterEmployee();
            register.Show();
        }

        private void Btn_AddRoster_Click(object sender, RoutedEventArgs e)
        {
            AddRoster ar = new AddRoster();
            ar.Show();
        }

        private void Btn_ManageUsers_Click(object sender, RoutedEventArgs e)
        {
            ManageUsers mu = new ManageUsers();
            mu.Show();
        }

        private void Btn_BookingStatus_Click(object sender, RoutedEventArgs e)
        {
            BookingStatus bs = new BookingStatus();
            bs.Show();
        }

        private void Btn_FareCalculator_Click(object sender, RoutedEventArgs e)
        {
            FareCaluclation fareCaluclation = new FareCaluclation();
            fareCaluclation.Show();
        }

        private void Btn_ChangePasswords_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword change = new ChangePassword();
            change.Show();
        }

        private void Btn_PrintReports_Click(object sender, RoutedEventArgs e)
        {
            PrintReports pr = new PrintReports();
            pr.Show();
        }

        private void Btn_CheckRoster_Click(object sender, RoutedEventArgs e)
        {
            CheckRoster check = new CheckRoster();
            check.Show();
        }

        private void Btn_DailyLog_Click(object sender, RoutedEventArgs e)
        {
            CheckRoster check = new CheckRoster();
            check.Show();
        }

        private void Btn_CheckFeedbacks_Click(object sender, RoutedEventArgs e)
        {
            CheckFeedback check = new CheckFeedback();
            check.Show();
        }

        private void Btn_DriverHistory_Click(object sender, RoutedEventArgs e)
        {
            DriverHistory dh = new DriverHistory();
            dh.Show();
        }
    }
}
