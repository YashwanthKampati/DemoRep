using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBS_Exception
{
    public class FeedbackException:ApplicationException
    {
        public FeedbackException(string Message):base(Message)
        {

        }
    }
}
