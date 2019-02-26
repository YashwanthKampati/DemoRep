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
    public class FeedbackValidations
    {
        public Feedback SearchFeedback_BLL(DateTime date)
        {
            try
            {
                FeedbackOperations fo = new FeedbackOperations();
                return fo.SearchFeedback_DAL(date);
            }
            catch (FeedbackException)
            {
                throw;
            }
        }
    }
}
