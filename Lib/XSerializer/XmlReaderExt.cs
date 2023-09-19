using System;
using System.Collections.Generic;
using System.Xml;

namespace Serialization
{
    public static class XmlReaderExt
    {
        public static void CheckElement(this XmlReader reader, string elementName)
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

        #region Read Simple

        public static string ReadAttributeText(this XmlReader reader)
        {
            return reader.Value;
        }

        public static string ReadElementText(this XmlReader reader)
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

        public static bool ReadAttributeBool(this XmlReader reader)
        {
            string value = reader.ReadAttributeText();
            return value == "1" || value == "true" ? true : false;
        }

        public static bool ReadElementBool(this XmlReader reader)
        {
            string value = reader.ReadElementText();
            return value == "1" || value == "true" ? true : false;
        }

        public static int ReadAttributeInt(this XmlReader reader)
        {
            string value = reader.ReadAttributeText();
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new Exception("Unknown format");
        }

        public static int ReadElementInt(this XmlReader reader)
        {
            string value = reader.ReadElementText();
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new Exception("Unknown format");
        }

        public static long ReadAttributeLong(this XmlReader reader)
        {
            string value = reader.ReadAttributeText();
            if (long.TryParse(value, out long result))
            {
                return result;
            }
            throw new Exception("Unknown format");
        }

        public static long ReadElementLong(this XmlReader reader)
        {
            string value = reader.ReadElementText();
            if (long.TryParse(value, out long result))
            {
                return result;
            }
            throw new Exception("Unknown format");
        }

        public static double ReadAttributeDouble(this XmlReader reader)
        {
            string value = reader.ReadAttributeText();
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            throw new Exception("Unknown format");
        }

        public static double ReadElementDouble(this XmlReader reader)
        {
            string value = reader.ReadElementText();
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            throw new Exception("Unknown format");
        }

        public static DateTime ReadAttributeDateTime(this XmlReader reader)
        {
            long value = reader.ReadAttributeLong();
            return DateTimeOffset.FromUnixTimeSeconds(value).DateTime;
        }

        public static DateTime ReadElementDateTime(this XmlReader reader)
        {
            long value = reader.ReadElementLong();
            return DateTimeOffset.FromUnixTimeSeconds(value).DateTime;
        }

        public static Version ReadAttributeVersion(this XmlReader reader)
        {
            string value = reader.ReadAttributeText();
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

        public static Version ReadElementVersion(this XmlReader reader)
        {
            string value = reader.ReadElementText();
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

        public static T ReadAttributeEnum<T>(this XmlReader reader) where T : Enum
        {
            string value = reader.ReadAttributeText();
            if (long.TryParse(value, out long result))
            {
                return (T)Enum.ToObject(typeof(T), result);
            }
            return (T)Enum.ToObject(typeof(T), value);

        }

        public static T ReadElementEnum<T>(this XmlReader reader) where T : struct, Enum
        {
            string value = reader.ReadElementText();
            if (long.TryParse(value, out long result))
            {
                return (T)Enum.ToObject(typeof(T), result);
            }
            return (T)Enum.ToObject(typeof(T), value);
        }

        #endregion

        #region Read Nullable

        public static bool? ReadAttributeNullableBool(this XmlReader reader)
        {
            string value = reader.ReadAttributeText();
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return value == "1" || value == "true" ? true : false;
        }

        public static bool? ReadElementNullableBool(this XmlReader reader)
        {
            string value = reader.ReadElementText();
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return value == "1" || value == "true" ? true : false;
        }

        public static int? ReadAttributeNullableInt(this XmlReader reader)
        {
            string value = reader.ReadAttributeText();
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return null;
        }

        public static int? ReadElementNullableInt(this XmlReader reader)
        {
            string value = reader.ReadElementText();
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return null;
        }

        public static long? ReadAttributeNullableLong(this XmlReader reader)
        {
            string value = reader.ReadAttributeText();
            if (long.TryParse(value, out long result))
            {
                return result;
            }
            return null;
        }

        public static long? ReadElementNullableLong(this XmlReader reader)
        {
            string value = reader.ReadElementText();
            if (long.TryParse(value, out long result))
            {
                return result;
            }
            return null;
        }

        public static double? ReadAttributeNullableDouble(this XmlReader reader)
        {
            string value = reader.ReadAttributeText();
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            return null;
        }

        public static double? ReadElementNullableDouble(this XmlReader reader)
        {
            string value = reader.ReadElementText();
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            return null;
        }

        public static DateTime? ReadAttributeNullableDateTime(this XmlReader reader)
        {
            long? value = reader.ReadAttributeNullableLong();
            return value.HasValue ? (DateTime?)DateTimeOffset.FromUnixTimeSeconds(value.Value).DateTime : null;
        }

        public static DateTime? ReadElementNullableDateTime(this XmlReader reader)
        {
            long? value = reader.ReadElementNullableLong();
            return value.HasValue ? (DateTime?)DateTimeOffset.FromUnixTimeSeconds(value.Value).DateTime : null;
        }

        public static T? ReadAttributeNullableEnum<T>(this XmlReader reader) where T : struct, Enum
        {
            string value = reader.ReadAttributeText();

            return string.IsNullOrEmpty(value) ? null : (T?)Enum.ToObject(typeof(T), value);
        }

        public static T? ReadElementNullableEnum<T>(this XmlReader reader) where T : struct, Enum
        {
            string value = reader.ReadElementText();
            return string.IsNullOrEmpty(value) ? null : (T?)Enum.ToObject(typeof(T), value);
        }

        #endregion

        public static List<T> ReadElementList<T>(this XmlReader reader, string name, string itemName, Func<T> deserialize) where T : class, new()
        {
            //reader.CheckElement(name);

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

        
    }
}
