using EllieMae.Encompass.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NafTestForm.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsHoliday(this BusinessCalendar businessCalendar, DateTime dateTime)
        {
            return businessCalendar.GetDayType(dateTime) == BusinessCalendarDayType.Holiday;
        }
    }
}
