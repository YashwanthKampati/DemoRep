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
using TBS_Exception;

namespace TBS_PL
{
    /// <summary>
    /// Interaction logic for CheckBooking.xaml
    /// </summary>
    public partial class CheckBooking : Window
    {
        public CheckBooking()
        {
            InitializeComponent();
        }

        private void Btn_CheckBooking_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BookingValiadtions bookingValiadtions = new BookingValiadtions();
                string custId = MainWindow.id;

                DataTable dt = bookingValiadtions.CheckBooking_BLL(custId);
                dg_CheckBooking.ItemsSource = dt.DefaultView;
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
