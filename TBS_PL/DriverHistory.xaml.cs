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
using TBS_Exception;

namespace TBS_PL
{
    /// <summary>
    /// Interaction logic for DriverHistory.xaml
    /// </summary>
    public partial class DriverHistory : Window
    {
        public DriverHistory()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BookingValiadtions bookingValiadtions = new BookingValiadtions();
                dg_driverHistory.ItemsSource = bookingValiadtions.DriverHistory_BLL(MainWindow.id).DefaultView;
            }
            catch(BookingException be)
            {
                MessageBox.Show(be.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
