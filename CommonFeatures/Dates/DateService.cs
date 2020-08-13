using System;
using System.Collections.Generic;
using System.Text;

namespace SalesDetails.CommonFeatures.Dates
{
    public class DateService : IDateService
    {
        public DateTime GetDate()
        {
            return DateTime.Now.Date;
        }
    }
}
