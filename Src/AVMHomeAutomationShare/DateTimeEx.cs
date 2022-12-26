using System;
using System.Collections.Generic;
using System.Text;

namespace AVMHomeAutomation
{
    public static class DateTimeEx
    {
        public static long ToUnixTime(this DateTime dateTime)
        {
            // return ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
            //return (long)dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            //return (long)dateTime.Subtract(DateTime.UnixEpoch).TotalSeconds;
            
            return (long)dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        } 

        public static long ToUnixTime(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToUnixTime() : 0;
        }

    }
}
