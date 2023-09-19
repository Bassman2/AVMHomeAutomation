using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Serialization
{
    public static class XmlWriterExt
    {

        #region Write Simple

        public static void WriteAttributeString(this XmlWriter writer, string name, bool value)
        {
            writer.WriteAttributeString(name, value ? "true" : "false");
        }

        public static void WriteElementString(this XmlWriter writer, string name, bool value)
        {
            writer.WriteElementString(name, value ? "true" : "false");
        }

        public static void WriteAttributeString(this XmlWriter writer, string name, int value)
        {
            writer.WriteAttributeString(name, value.ToString());
        }

        public static void WriteElementString(this XmlWriter writer, string name, int value)
        {
            writer.WriteElementString(name, value.ToString());
        }

        public static void WriteAttributeString(this XmlWriter writer, string name, double value)
        {
            writer.WriteAttributeString(name, value.ToString());
        }

        public static void WriteElementString(this XmlWriter writer, string name, double value)
        {
            writer.WriteElementString(name, value.ToString());
        }

        public static void WriteAttributeString(this XmlWriter writer, string name, DateTime value)
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

        public static void WriteElementString(this XmlWriter writer, string name, DateTime value)
        {
            long seconds = new DateTimeOffset(value).ToUnixTimeSeconds();
            writer.WriteElementString(name, seconds.ToString());
        }

        public static void WriteAttributeString(this XmlWriter writer, string name, Version value)
        {
            writer.WriteAttributeString(name, value.ToString());
        }

        public static void WriteElementString(this XmlWriter writer, string name, Version value)
        {
            writer.WriteElementString(name, value.ToString());
        }



        public static void WriteAttributeString<T>(this XmlWriter writer, string name, T value) where T : struct, Enum
        {
            writer.WriteAttributeString(name, value.ToString());
        }

        public static void WriteElementString<T>(this XmlWriter writer, string name, T value) where T : struct, Enum
        {
            writer.WriteElementString(name, value.ToString());
        }


        //public static string ToValue<T>(this Nullable<T> value) where T : struct, Enum
        //{
        //    return value.HasValue ? value.ToString() : string.Empty;
        //}

        #endregion

        #region Write Nullable

        public static void WriteAttributeString(this XmlWriter writer, string name, bool? value)
        {
            if (value.HasValue)
            {
                writer.WriteAttributeString(name, value.Value);
            }
        }

        public static void WriteElementString(this XmlWriter writer, string name, bool? value)
        {
            if (value.HasValue)
            {
                writer.WriteElementString(name, value.Value);
            }
        }

        public static void WriteAttributeString(this XmlWriter writer, string name, int? value)
        {
            if (value.HasValue)
            {
                writer.WriteAttributeString(name, value.Value);
            }
        }

        public static void WriteElementString(this XmlWriter writer, string name, int? value)
        {
            if (value.HasValue)
            {
                writer.WriteElementString(name, value.Value);
            }
        }

        public static void WriteAttributeString(this XmlWriter writer, string name, double? value)
        {
            if (value.HasValue)
            {
                writer.WriteAttributeString(name, value.Value);
            }
        }

        public static void WriteElementString(this XmlWriter writer, string name, double? value)
        {
            if (value.HasValue)
            {
                writer.WriteElementString(name, value.Value);
            }
        }

        public static void WriteAttributeString(this XmlWriter writer, string name, DateTime? value)
        {
            if (value.HasValue)
            {
                writer.WriteAttributeString(name, value.Value);
            }
        }

        public static void WriteElementString(this XmlWriter writer, string name, DateTime? value)
        {
            if (value.HasValue)
            {
                writer.WriteElementString(name, value.Value);
            }
        }

        public static void WriteAttributeString<T>(this XmlWriter writer, string name, T? value) where T : struct, Enum
        {
            if (value.HasValue)
            {
                writer.WriteAttributeString(name, value.Value);
            }
        }

        public static void WriteElementString<T>(this XmlWriter writer, string name, T? value) where T : struct, Enum
        {
            if (value.HasValue)
            {
                writer.WriteElementString(name, value.Value);
            }
        }

        //public static void WriteAttribute<T>(this XmlWriter writer, string name, T? value) where T : struct
        //{
        //    if (value.HasValue)
        //    {
        //        writer.WriteAttribute(name, value.Value);
        //    }
        //}

        //public static void WriteElement<T>(this XmlWriter writer, string name, T? value) where T : struct
        //{
        //    if (value.HasValue)
        //    {
        //        writer.WriteElement(name, value.Value);
        //    }
        //}


        #endregion

        public static void WriteElementList<T>(this XmlWriter writer, string name, string itemName, List<T> list, Action<T> serialize)
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

        public static void WriteConverter(this XmlWriter writer, string elementName, object value, Type typeToConvert, Type converterType)
        {
            IXmlConverter converter = (IXmlConverter)Activator.CreateInstance(converterType);
            converter.Write(writer, elementName, value, typeToConvert);
        }
    }
}
