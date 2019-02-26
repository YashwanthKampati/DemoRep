using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBS_Exception
{
    public class TaxiExceptions:ApplicationException
    {
        public TaxiExceptions(string Message):base(Message)
        {

        }
    }
}
