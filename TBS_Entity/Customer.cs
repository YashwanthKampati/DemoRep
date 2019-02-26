using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBS_Entity
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public long? PhoneNumber { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
    }
}
