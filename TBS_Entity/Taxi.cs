using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBS_Entity
{
    public class Taxi
    {
        public int TaxiID { get; set; }
        public int EmployeeID { get; set; }
        public string TaxiModel { get; set; }
        public string Colour { get; set; }
        public string RegistrationNumber { get; set; }
        public string TaxiType { get; set; }
    }
}
