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
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class BookingHome : Window
    {
        public BookingHome()
        {
            InitializeComponent();
        }

        private void Btn_cancelBook_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Book_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string custId = MainWindow.id;
                Booking booking = new Booking();
                booking.TaxiID = int.Parse(txt_TaxiID.Text.ToString());
                booking.StartDate = DateTime.Parse(txtSHrs.Text.ToString() + ":" + txtSMins.Text.ToString());
                booking.EndDate = DateTime.Parse(txtEhrs.Text.ToString() + ":" + txtEMins.Text.ToString());
                booking.BookingDate = DateTime.Parse(dpBookingDate.Text.ToString());
                booking.TripDate = DateTime.Parse(dpTripDate.Text.ToString());
                booking.SourceAddress = txtSAddress.Text;
                booking.DestinationAddress = txtDAddress.Text;
                BookingValiadtions bv = new BookingValiadtions();
                if (bv.BookingTaxi_BLL(booking, custId) != 0)
                    MessageBox.Show("Booking success");
                else { throw new BookingException("Booking failed"); }
            }
            catch(BookingException be)
            {
                MessageBox.Show(be.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BookingValiadtions bd = new BookingValiadtions();
                DataTable dt = bd.DisplayTaxi_BLL();
                if (dt!=null)
                {
                    dgTaxi.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Error loading taxi details");
                }
            }
            catch (BookingException te)
            {
                MessageBox.Show(te.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
