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
    /// Interaction logic for PrintReports.xaml
    /// </summary>
    public partial class PrintReports : Window
    {
        public PrintReports()
        {
            InitializeComponent();
        }

        private void BtnAnnual_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime moment = DateTime.Now;
                DateTime fromDate = moment;
                DateTime toDate = moment.AddYears(-1);
                BookingValiadtions bo = new BookingValiadtions();
                DataTable dt = bo.PrintReport_BLL(fromDate, toDate);
                if (dt != null)
                {
                    MessageBox.Show("The Report is generated");
                    dgReport.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Report cannot be generated");
                }
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

        private void BtnWeekly_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime moment = DateTime.Now;
                DateTime fromDate = moment;
                DateTime toDate = moment.AddDays(-7);
                BookingValiadtions bo = new BookingValiadtions();
                DataTable dt = bo.PrintReport_BLL(fromDate, toDate);
                if (dt != null)
                {
                    
                    MessageBox.Show("The Report is generated");
                    dgReport.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Report cannot be generated");
                }
            }
            catch (BookingException be)
            {
                MessageBox.Show(be.Message);
            }
        }

        private void BtnDaily_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime moment = DateTime.Now;
                DateTime fromDate = moment;
                DateTime toDate = moment.AddDays(-1);
                BookingValiadtions bo = new BookingValiadtions();
                DataTable dt = bo.PrintReport_BLL(fromDate, toDate);
                if (dt != null)
                {
                    MessageBox.Show("The Report is generated");
                    dgReport.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("Report cannot be generated");
                }
            }
            catch (BookingException be)
            {
                MessageBox.Show(be.Message);
            }
        }
    }
}
