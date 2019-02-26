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

namespace TBS_PL
{
    /// <summary>
    /// Interaction logic for FareCaluclation.xaml
    /// </summary>
    public partial class FareCaluclation : Window
    {
        public FareCaluclation()
        {
            InitializeComponent();
        }

        private void Btn_cal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime EndDate = DateTime.Parse(dp_EndDate.SelectedDate.Value.Date.ToShortDateString());
                DateTime StartDate = DateTime.Parse(dp_StartDate.SelectedDate.Value.Date.ToShortDateString());
                DateTime StartTime = DateTime.Parse(txt_stime.Text.ToString());
                DateTime EndTime = DateTime.Parse(txt_etime.Text.ToString());
                int Days = -(StartDate.Day - EndDate.Day);
                int Hours = -(StartTime.Hour - EndTime.Hour);
                txt_calculation.Text = (Days * 24 * 150 + Hours * 150).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
