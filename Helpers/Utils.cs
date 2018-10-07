using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PGCare.Helpers
{
    public static class Utils
    {
        public static string ConvertDateTime(DateTime dateTime)
        {
            string date = dateTime.Day.ToString();
            string month = dateTime.Month.ToString();
            string year = dateTime.Year.ToString();
            string hour = dateTime.Hour.ToString();
            string minute = dateTime.Minute.ToString();
            string second = dateTime.Second.ToString();
            string miliSecond = dateTime.Millisecond.ToString();

            return $"{date}/{month}/{year} {hour}.{minute}.{second}.{miliSecond}";
        }
    }
}
