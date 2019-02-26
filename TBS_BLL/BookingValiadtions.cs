using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBS_DAL;
using TBS_Entity;
using TBS_Exception;

namespace TBS_BLL
{
    public class BookingValiadtions
    {
        private bool ValidateBooking(Booking newBooking)
        {
            bool isValidBooking = true;
            StringBuilder sbClientError = new StringBuilder();
            DateTime xTwoHours= DateTime.Now.AddHours(2);
            if (newBooking.TripDate.Equals(string.Empty))//validation for blank Trip Date
            {
                isValidBooking = false;
                sbClientError.Append("Trip date cannot be empty)" + Environment.NewLine);
            }
            if (newBooking.BookingDate.Equals(string.Empty))//validation for blank Booking Date
            {
                isValidBooking = false;
                sbClientError.Append("Booking date cannot be empty)" + Environment.NewLine);
            }
            if (newBooking.TaxiID.Equals(string.Empty))//validation for blank TaxiID
            {
                isValidBooking = false;
                sbClientError.Append("Taxi ID cannot be empty)" + Environment.NewLine);
            }
            if (newBooking.DestinationAddress.Equals(string.Empty))//validation for blank Destination Address
            {
                isValidBooking = false;
                sbClientError.Append("Destination Address cannot be empty)" + Environment.NewLine);
            }
            if (newBooking.SourceAddress.Equals(string.Empty))//validation for blank Source Address
            {
                isValidBooking = false;
                sbClientError.Append("Source Address cannot be empty)" + Environment.NewLine);
            }
            if (newBooking.StartDate.Equals(string.Empty))//validation for blank Start Time
            {
                isValidBooking = false;
                sbClientError.Append("Start Time cannot be empty)" + Environment.NewLine);
            }
            if (newBooking.EndDate.Equals(string.Empty))//validation for blank End Time
            {
                isValidBooking = false;
                sbClientError.Append("End Time cannot be empty)" + Environment.NewLine);
            }
            if (newBooking.TripDate<xTwoHours)//validation for trip date two hours from now
            {
                isValidBooking = false;
                sbClientError.Append("Trip date should be atleast two hours from now)" + Environment.NewLine);
            }
            if (!isValidBooking)
            {
                throw new BookingException(sbClientError.ToString());
            }
            return isValidBooking;
        }
        public int BookingTaxi_BLL(Booking pobj,string LoginId)
        {
            int bid = 0;
            try
            {
                BookingOperations pd = new BookingOperations();
                if (ValidateBooking(pobj))
                {
                    bid= pd.BookingTaxi_DAL(pobj, LoginId);
                    return bid;
                }
            }
            catch (BookingException)
            {
                throw;
            }
            return bid;
        }
        public DataTable BookStatus(string custId)
        {
            try
            {
                BookingOperations bookingOperations = new BookingOperations();
                return bookingOperations.Book_Statusdal(custId);
            }
            catch (BookingException)
            {
                throw;
            }
            
        }
        public DataTable PrintReport_BLL(DateTime fromDate,DateTime toDate)
        {
            try
            {
                BookingOperations bookingOperations = new BookingOperations();
                return bookingOperations.PrintReport_DAL(fromDate, toDate);
            }
            catch(BookingException)
            {
                throw;
            }
        }
        public DataTable CheckBooking_BLL(string EmpID)
        {
            try
            {
                BookingOperations bo = new BookingOperations();
                return bo.CheckBooking_DAL(EmpID);
            }
            catch(BookingException)
            {
                throw;
            }
        }
        public Booking SearchBooking_BLL(int bookingID)
        {
            try
            {
                BookingOperations pd = new BookingOperations();
                return pd.SearchBook_DAL(bookingID);
            }
            catch (BookingException)
            {
                throw;
            }
        }

        public DataTable DisplayBooking_BLL()
        {
            try
            {
                BookingOperations pd = new BookingOperations();
                return pd.DisplayBook_DAL();
            }
            catch (BookingException)
            {
                throw;
            }
        }
        public DataTable DisplayTaxi_BLL()
        {
            try
            {
                BookingOperations bookingOperations = new BookingOperations();
                return bookingOperations.DisplayTaxi_DAL();
            }
            catch (BookingException)
            {
                throw;
            }
        }
        public DataTable DriverHistory_BLL(string id)
        {
            try
            {
                BookingOperations bookingOperations = new BookingOperations();
                return bookingOperations.DriverHistory_DAL(id);
            }
            catch(BookingException)
            {
                throw;
            }
        }
    }
}
