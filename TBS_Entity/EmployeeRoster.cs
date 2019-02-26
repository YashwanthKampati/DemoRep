using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBS_Entity
{
    public enum RosterEnum { Morning=0,Evening,Night}
    public class EmployeeRoster
    {
        public RosterEnum RosterID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
    }
}
