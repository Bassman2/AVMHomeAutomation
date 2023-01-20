using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    internal static class HAConverter
    {
        private readonly static DateTime UnixDateTimeStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static string ToHkrTemperature(this double val)
        {
            switch (val)
            {
            case double.MaxValue:
                return "254";     // ON
            case double.MinValue:
                return "253";      // OFF
            default:
                return ((int)Math.Round(val * 2.0)).ToString();
            }
        }

        /// <summary>
        /// Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &lt;= 8 ° C, 17 =, 5 ° C ...... 56 &gt;= 28 ° C 254 = ON, 253 = OFF.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToHkrTemperature(this string value)
        {
            int val = int.Parse(value);
            switch (val)
            {
            case 254:   
                return HomeAutomation.On;
            case 253:   
                return HomeAutomation.Off;
            default:
                return val / 2.0;
            }
        }

        /// <summary>
        /// Temperature value in 0.1 ° C, negative and positive values possible Ex. "200" means 20 ° C
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToTemperature(this string value)
        {
            return int.Parse(value) / 10.0;
        }

        public static double? ToNullableTemperature(this string value)
        {
            if (int.TryParse(value, out int val))
            {
                return val / 10.0;
            }
            return null;
        }

        public static string[] SplitList(this string str)
        {
            return str.TrimEnd().Split(',');
        }

        public static int ToDeciseconds(this TimeSpan? duration)
        {
            return duration.HasValue ? (int)(duration.Value.Ticks / (TimeSpan.TicksPerSecond / 10)) : 0;
        }

        public static double? ToPower(this string value)
        {
            if (int.TryParse(value, out int res))
            {
                return res / 1000.0;
            }
            return null;
        }

        public static bool ToBool(this string value)
        {
            return value.TrimEnd() == "1";
        }

        public static bool? ToNullableBool(this string value)
        {
            switch (value.TrimEnd())
            {
            case "0": return false;
            case "1": return true;
            default: return null;
            }
        }

        public static OnOff ToOnOff(this string value)
        {
            switch (value.TrimEnd())
            {
            case "0": return OnOff.Off;
            case "1": return OnOff.On;
            case "2": return OnOff.Toggle;
            default: throw new ArgumentOutOfRangeException(nameof(value), value);
            }
        }

        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        public static T XmlToAs<T>(this string value)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(value))
            {
                T val = (T)serializer.Deserialize(reader);
                return val;
            }
        }

        public static T JsonToAs<T>(this string value)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };

            return JsonSerializer.Deserialize<T>(value, options);
        }

        public static string AsToJson<T>(this T value)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

            return JsonSerializer.Serialize(value, options);
        }
        
        public static long ToUnixTime(this DateTime dateTime)
        {
            // return ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
            //return (long)dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            //return (long)dateTime.Subtract(DateTime.UnixEpoch).TotalSeconds;

            return (long)dateTime.ToUniversalTime().Subtract(UnixDateTimeStart).TotalSeconds;
        }

        public static long ToUnixTime(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToUnixTime() : 0;
        }

        /// <summary>
        /// Time in seconds since 1970
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(this string value)
        {
            if (long.TryParse(value, out long val))
            {
                return val == 0 ? null : (DateTime?)(UnixDateTimeStart.AddSeconds(val));
            }
            return null;
        }

        /// <summary>
        /// Fix bug in Fritz!OS
        /// </summary>
        /// <param name="value">Result string.</param>
        /// <returns>Result string</returns>
        /// <exception cref="HttpRequestException">Throw exception is result string starts with HTTP error.</exception>

        public static string CheckStatusCode(this string value)
        {
            // "HTTP/1.0 500 Internal Server Error\r\nContent-Length: 0\r\nContent-Type: text/plain; charset=utf-8\r\nPragma: no-cache\r\nCache-Control: no-cache\r\nExpires: -1"
            if (value.StartsWith("HTTP/1.0 500"))
            {
#if NET
                throw new HttpRequestException("Internal Server Error", null, HttpStatusCode.InternalServerError);
#else
                throw new HttpRequestException("Internal Server Error", null);
#endif
            }
            return value;
        }
    }
}
