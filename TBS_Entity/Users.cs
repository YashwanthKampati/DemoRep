using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBS_Entity
{
    public class Users
    {
        public string LoginID { get; set; }
        public string Password  { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }
        public string Role { get; set; }
    }
}
