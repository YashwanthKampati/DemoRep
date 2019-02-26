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
    /// Interaction logic for CheckFeedback.xaml
    /// </summary>
    public partial class CheckFeedback : Window
    {
        public CheckFeedback()
        {
            InitializeComponent();
        }

        private void BtnSearchFeed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Feedback f = new Feedback();
                DateTime date = DateTime.Parse(txtFeed.Text);
                FeedbackValidations fv = new FeedbackValidations();
                f = fv.SearchFeedback_BLL(date);
                if (f!=null)
                {
                    txtFeedID.Text = f.FeedbackID.ToString();
                    rtxtFeedMsg.AppendText(f.FeedbackMessage);
                    txtFeedUser.Text = f.LoginID;
                    txtFeedDate.Text = f.FeedbackDate.ToShortDateString();
                    gridFeed.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Feedback not available");
                }
            }
            catch(FeedbackException fe)
            {
                MessageBox.Show(fe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
