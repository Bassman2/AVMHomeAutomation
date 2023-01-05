using System;

namespace AVMHomeAutomation
{
    internal static class HAConverter
    {
        public static string ToHkrTemperature(this double val)
        {
            switch (val)
            {
            case double.MaxValue:
                return "254";     // ON
            case double.MinValue:
                return "253";      // OFF
            default:
                return ((int)Math.Round(val * 0.5)).ToString();
            }
        }

        /// <summary>
        /// Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &lt;= 8 ° C, 17 =, 5 ° C ...... 56 &gt;= 28 ° C 254 = ON, 253 = OFF.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double ToHkrTemperature(this int val)
        {
            switch (val)
            {
            case 254:   // ON
                return double.MaxValue;
            case 253:   // OFF
                return double.MinValue;
            default:
                return val / 0.5;
            }
        }

        /// <summary>
        /// Temperature value in 0.1 ° C, negative and positive values possible Ex. "200" means 20 ° C
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double ToTemperature(this int val)
        {
            return val / 10.0;
        }

        public static string[] SplitList(this string str)
        {
            return str.TrimEnd().Split(',');
        }

        public static int ToDeciseconds(this TimeSpan? duration)
        {
            return duration.HasValue ? (int)(duration.Value.Ticks / (TimeSpan.TicksPerSecond / 10)) : 0;
        }

        public static int? ToPower(this string value)
        {
            if (int.TryParse(value, out int res))
            {
                return res;
            }
            return null;
        }
    }
}
