using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBS_Entity
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public string LoginID { get; set; }
        public string FeedbackMessage { get; set; }
        public DateTime FeedbackDate { get; set; }
    }
}
