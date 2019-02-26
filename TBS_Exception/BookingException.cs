using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBS_Exception
{
    public class BookingException:ApplicationException
    {
        public BookingException(string message):base(message)
        {

        }
    }
}
