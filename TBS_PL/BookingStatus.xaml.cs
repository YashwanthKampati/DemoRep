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
    /// Interaction logic for BookingStatus.xaml
    /// </summary>
    public partial class BookingStatus : Window
    {
        public BookingStatus()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BookingValiadtions bookingValiadtions = new BookingValiadtions();
                string custId = MainWindow.id;

                DataTable dt = bookingValiadtions.BookStatus(custId);
                dg_view.ItemsSource = dt.DefaultView;
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
    }
}
