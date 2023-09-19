using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Serialization
{
    internal static partial class XSerializer
    {
        private static DateTime begin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        #region Checker

        private static void CheckElement(this XmlReader reader, string elementName)
        {
            if (reader.NodeType != XmlNodeType.Element)
            {
                throw new Exception("Not an element node");
            }
            if (reader.Name != elementName)
            {
                throw new Exception($"Wrong element: {reader.Name}");
            }
        }

        #endregion

        #region Write Simple

        private static void WriteAttributeString(this XmlWriter writer, string name, bool value)
        {
            writer.WriteAttributeString(name, value ? "true" : "false");
        }

        private static void WriteElementString(this XmlWriter writer, string name, bool value)
        {
            writer.WriteElementString(name, value ? "true" : "false");
        }

        private static void WriteAttributeString(this XmlWriter writer, string name, int value)
        {
            writer.WriteAttributeString(name, value.ToString());
        }

        private static void WriteElementString(this XmlWriter writer, string name, int value)
        {
            writer.WriteElementString(name, value.ToString());
        }

        private static void WriteAttributeString(this XmlWriter writer, string name, double value)
        {
            writer.WriteAttributeString(name, value.ToString());
        }

        private static void WriteElementString(this XmlWriter writer, string name, double value)
        {
            writer.WriteElementString(name, value.ToString());
        }

        private static void WriteAttributeString(this XmlWriter writer, string name, DateTime value)
        {
            // DateTimeOffset.FromUnixTimeSeconds(1000);
            // For the .NET Framework 4.6 and above there is now static DateTimeOffset.FromUnixMilliseconds and DateTimeOffset.ToUnixMilliseconds


            //DateTimeOffset.ToUnixMilliseconds


            //DateTimeOffset.
            //begin.AddSeconds(val);
            //long val = (long)((value - begin).S.TotalSeconds);
            //begin.AddSeconds(val);


            long seconds = new DateTimeOffset(value).ToUnixTimeSeconds();
            writer.WriteAttributeString(name, seconds.ToString());
        }

        private static void WriteElementString(this XmlWriter writer, string name, DateTime value)
        {
            long seconds = new DateTimeOffset(value).ToUnixTimeSeconds();
            writer.WriteElementString(name, seconds.ToString());
        }

        private static void WriteAttributeString(this XmlWriter writer, string name, Version value)
        {
            writer.WriteAttributeString(name, value.ToString());
        }

        private static void WriteElementString(this XmlWriter writer, string name, Version value)
        {
            writer.WriteElementString(name, value.ToString());
        }



        private static void WriteAttributeString<T>(this XmlWriter writer, string name, T value) where T : struct, Enum
        {
            writer.WriteAttributeString(name, value.ToString());
        }

        private static void WriteElementString<T>(this XmlWriter writer, string name, T value) where T : struct, Enum
        {
            writer.WriteElementString(name, value.ToString());
        }


        //private static string ToValue<T>(this Nullable<T> value) where T : struct, Enum
        //{
        //    return value.HasValue ? value.ToString() : string.Empty;
        //}

        #endregion

        #region Write Nullable

        private static void WriteAttributeString(this XmlWriter writer, string name, bool? value)
        {
            if (value.HasValue)
            {
                writer.WriteAttributeString(name, value.Value);
            }
        }

        private static void WriteElementString(this XmlWriter writer, string name, bool? value)
        {
            if (value.HasValue)
            {
                writer.WriteElementString(name, value.Value);
            }
        }

        private static void WriteAttributeString(this XmlWriter writer, string name, int? value)
        {
            if (value.HasValue)
            {
                writer.WriteAttributeString(name, value.Value);
            }
        }

        private static void WriteElementString(this XmlWriter writer, string name, int? value)
        {
            if (value.HasValue)
            {
                writer.WriteElementString(name, value.Value);
            }
        }

        private static void WriteAttributeString(this XmlWriter writer, string name, double? value)
        {
            if (value.HasValue)
            {
                writer.WriteAttributeString(name, value.Value);
            }
        }

        private static void WriteElementString(this XmlWriter writer, string name, double? value)
        {
            if (value.HasValue)
            {
                writer.WriteElementString(name, value.Value);
            }
        }

        private static void WriteAttributeString(this XmlWriter writer, string name, DateTime? value)
        {
            if (value.HasValue)
            {
                writer.WriteAttributeString(name, value.Value);
            }
        }

        private static void WriteElementString(this XmlWriter writer, string name, DateTime? value)
        {
            if (value.HasValue)
            {
                writer.WriteElementString(name, value.Value);
            }
        }

        private static void WriteAttributeString<T>(this XmlWriter writer, string name, T? value) where T : struct, Enum
        {
            if (value.HasValue)
            {
                writer.WriteAttributeString(name, value.Value);
            }
        }

        private static void WriteElementString<T>(this XmlWriter writer, string name, T? value) where T : struct, Enum
        {
            if (value.HasValue)
            {
                writer.WriteElementString(name, value.Value);
            }
        }

        //private static void WriteAttribute<T>(this XmlWriter writer, string name, T? value) where T : struct
        //{
        //    if (value.HasValue)
        //    {
        //        writer.WriteAttribute(name, value.Value);
        //    }
        //}

        //private static void WriteElement<T>(this XmlWriter writer, string name, T? value) where T : struct
        //{
        //    if (value.HasValue)
        //    {
        //        writer.WriteElement(name, value.Value);
        //    }
        //}


        #endregion

        #region Read Simple

        private static string ReadAttributeString(this XmlReader reader)
        {
            return reader.Value;
        }

        private static string ReadElementString(this XmlReader reader)
        {
            string result = string.Empty;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Text: result = reader.Value; break;
                case XmlNodeType.EndElement: return result;
                }
            }
            throw new Exception("error");
        }

        private static bool ReadAttributeBool(this XmlReader reader)
        {
            string value = reader.ReadAttributeString();
            return value == "1" || value == "true" ? true : false;
        }

        private static bool ReadElementBool(this XmlReader reader)
        {
            string value = reader.ReadElementString();
            return value == "1" || value == "true" ? true : false;
        }

        private static int ReadAttributeInt(this XmlReader reader)
        {
            string value = reader.ReadAttributeString();
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new Exception("Unknown format");
        }

        private static int ReadElementInt(this XmlReader reader)
        {
            string value = reader.ReadElementString();
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new Exception("Unknown format");
        }

        private static long ReadAttributeLong(this XmlReader reader)
        {
            string value = reader.ReadAttributeString();
            if (long.TryParse(value, out long result))
            {
                return result;
            }
            throw new Exception("Unknown format");
        }

        private static long ReadElementLong(this XmlReader reader)
        {
            string value = reader.ReadElementString();
            if (long.TryParse(value, out long result))
            {
                return result;
            }
            throw new Exception("Unknown format");
        }

        private static double ReadAttributeDouble(this XmlReader reader)
        {
            string value = reader.ReadAttributeString();
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            throw new Exception("Unknown format");
        }

        private static double ReadElementDouble(this XmlReader reader)
        {
            string value = reader.ReadElementString();
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            throw new Exception("Unknown format");
        }

        private static DateTime ReadAttributeDateTime(this XmlReader reader)
        {
            long value = reader.ReadAttributeLong();
            return DateTimeOffset.FromUnixTimeSeconds(value).DateTime;
        }

        private static DateTime ReadElementDateTime(this XmlReader reader)
        {
            long value = reader.ReadElementLong();
            return DateTimeOffset.FromUnixTimeSeconds(value).DateTime;
        }

        private static Version ReadAttributeVersion(this XmlReader reader)
        {
            string value = reader.ReadAttributeString();
            if (value.Contains("."))
            {
                if (Version.TryParse(value, out Version result))
                {
                    return result;
                }
                throw new Exception();
            }
            else
            {
                if (int.TryParse(value, out int result))
                {
                    return new Version(result, 0);
                }
                throw new Exception();
            }
        }

        private static Version ReadElementVersion(this XmlReader reader)
        {
            string value = reader.ReadElementString();
            if (value.Contains("."))
            {
                if (Version.TryParse(value, out Version result))
                {
                    return result;
                }
                throw new Exception();
            }
            else
            {
                if (int.TryParse(value, out int result))
                {
                    return new Version(result, 0);
                }
                throw new Exception();
            }
        }

        private static T ReadAttributeEnum<T>(this XmlReader reader) where T : struct, Enum
        {
            string value = reader.ReadAttributeString();
            return (T)Enum.ToObject(typeof(T), value);

        }

        private static T ReadElementEnum<T>(this XmlReader reader) where T : struct, Enum
        {
            string value = reader.ReadElementString();
            return (T)Enum.ToObject(typeof(T), value);
        }

        #endregion

        #region Read Nullable

        private static bool? ReadAttributeNullableBool(this XmlReader reader)
        {
            string value = reader.ReadAttributeString();
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return value == "1" || value == "true" ? true : false;
        }

        private static bool? ReadElementNullableBool(this XmlReader reader)
        {
            string value = reader.ReadElementString();
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return value == "1" || value == "true" ? true : false;
        }

        private static int? ReadAttributeNullableInt(this XmlReader reader)
        {
            string value = reader.ReadAttributeString();
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return null;
        }

        private static int? ReadElementNullableInt(this XmlReader reader)
        {
            string value = reader.ReadElementString();
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return null;
        }

        private static long? ReadAttributeNullableLong(this XmlReader reader)
        {
            string value = reader.ReadAttributeString();
            if (long.TryParse(value, out long result))
            {
                return result;
            }
            return null;
        }

        private static long? ReadElementNullableLong(this XmlReader reader)
        {
            string value = reader.ReadElementString();
            if (long.TryParse(value, out long result))
            {
                return result;
            }
            return null;
        }

        private static double? ReadAttributeNullableDouble(this XmlReader reader)
        {
            string value = reader.ReadAttributeString();
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            return null;
        }

        private static double? ReadElementNullableDouble(this XmlReader reader)
        {
            string value = reader.ReadElementString();
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            return null;
        }

        private static DateTime? ReadAttributeNullableDateTime(this XmlReader reader)
        {
            long? value = reader.ReadAttributeNullableLong();
            return value.HasValue ? (DateTime?)DateTimeOffset.FromUnixTimeSeconds(value.Value).DateTime : null;
        }

        private static DateTime? ReadElementNullableDateTime(this XmlReader reader)
        {
            long? value = reader.ReadElementNullableLong();
            return value.HasValue ? (DateTime?)DateTimeOffset.FromUnixTimeSeconds(value.Value).DateTime : null;
        }

        private static T? ReadAttributeNullableEnum<T>(this XmlReader reader) where T : struct, Enum
        {
            string value = reader.ReadAttributeString();

            return string.IsNullOrEmpty(value) ? null : (T?)Enum.ToObject(typeof(T), value);
        }

        private static T? ReadElementNullableEnum<T>(this XmlReader reader) where T : struct, Enum
        {
            string value = reader.ReadElementString();
            return string.IsNullOrEmpty(value) ? null : (T?)Enum.ToObject(typeof(T), value);
        }

        #endregion

        //private static string ToValue(this int value)
        //{
        //    return value.ToString();
        //}

        //private static string ToValue(this int? value)
        //{
        //    return value.HasValue ? value.Value.ToString() : string.Empty;
        //}

        //private static string ToValue(this bool? value)
        //{
        //    return value.HasValue ? value.Value.ToString() : string.Empty;
        //}

        //private static string ToValue(this double? value)
        //{
        //    return value.HasValue ? value.Value.ToString() : string.Empty;
        //}

        //private static string ToValue(this DateTime? value)
        //{
        //    return value.HasValue ? value.Value.ToString() : string.Empty;
        //}

        //private static string ToValue<T>(this Nullable<T> value) where T : struct, Enum
        //{
        //    return value.HasValue ? value.ToString() : string.Empty;
        //}

        //private static string ToValue<T>(this T value) where T : struct, Enum
        //{
        //    return value.ToString();
        //}







        //private static string ReadValue(this XmlReader reader)
        //{
        //    string result = string.Empty;
        //    while (reader.Read())
        //    {
        //        switch (reader.NodeType)
        //        {
        //        case XmlNodeType.Text: result = reader.Value; break;
        //        case XmlNodeType.EndElement: return result;
        //        }
        //    }
        //    throw new Exception("error");
        //}

        //private static string ValueToString(this string value)
        //{
        //    return value;
        //}

        //private static bool? ValueToNullableBool(this string value)
        //{
        //    if (value == "true" || value == "1")
        //    {
        //        return true;
        //    }
        //    if (value == "false" || value == "0")
        //    {
        //        return false;
        //    }
        //    return null;
        //}

        //private static int? ValueToNullableInt(this string value)
        //{
        //    if (int.TryParse(value, out int result))
        //    {
        //        return result;
        //    }
        //    return null;
        //}

        //private static T ValueToEnum<T>(this string value) where T : Enum
        //{
        //    if (int.TryParse(value, out var result))
        //    {
        //        return (T)Enum.ToObject(typeof(T), result);
        //    }
        //    return (T)Enum.ToObject(typeof(T), 0);
        //}

        private static void WriteElementList<T>(this XmlWriter writer, string name, string itemName, List<T> list, Action<T> serialize)
        {
            if (!string.IsNullOrEmpty(name))
            {
                writer.WriteStartElement(name);
            }
            foreach (T item in list)
            {
                serialize(item);
            }
            if (!string.IsNullOrEmpty(name))
            {
                writer.WriteEndElement();
            }
        }

        private static List<T> ReadElementList<T>(this XmlReader reader, string name, string itemName, Func<T> deserialize) where T : class, new()
        {
            reader.CheckElement(name);

            List<T> list = new List<T>();
            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    if (reader.Name == itemName)
                    {
                        T item = deserialize();
                        list.Add(item);
                    }
                    else
                    {
                        reader.ReadInnerXml();
                    }
                    break;

                case XmlNodeType.EndElement:
                    return list;
                }
            }
            return list;
        }


        private static List<T> AddElement<T>(List<T> list, T obj)
        {
            list = list ?? new List<T>();
            list.Add(obj);
            return list;
        }

        //private static void AddElement<T>(ref T[] array, T obj)
        //{
        //    T[] newArray = null;

        //    array = newArray;
        //}

        private static void WriteConverter(this XmlWriter writer, string elementName, object value, Type typeToConvert, Type converterType)
        {
            IXmlConverter converter = (IXmlConverter)Activator.CreateInstance(converterType);
            converter.Write(writer, elementName, value, typeToConvert);
        }
    }
}
