using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;

namespace AVMHomeAutomation
{
    public struct CustomNullable<T> : IXmlSerializable where T : struct
    {
        private T value;
        private bool hasValue;

        public bool HasValue
        {
            get { return hasValue; }
        }

        public T Value
        {
            get { return value; }
        }

        private CustomNullable(T value)
        {
            this.hasValue = true;
            this.value = value;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            string strValue = reader.ReadString();
            if (String.IsNullOrEmpty(strValue))
            {
                this.hasValue = false;
            }
            else
            {
                T convertedValue = strValue.To<T>();
                this.value = convertedValue;
                this.hasValue = true;
            }
            reader.ReadEndElement();

        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public static implicit operator CustomNullable<T>(T value)
        {
            return new CustomNullable<T>(value);
        }

    }

    public static class ObjectExtensions
    {
        public static T To<T>(this object value)
        {
            Type t = typeof(T);
            // Get the type that was made nullable.
            Type valueType = Nullable.GetUnderlyingType(typeof(T));
            if (valueType != null)
            {
                // Nullable type.
                if (value == null)
                {
                    // you may want to do something different here.
                    return default(T);
                }
                else
                {
                    // Convert to the value type.
                    object result = Convert.ChangeType(value, valueType);
                    // Cast the value type to the nullable type.
                    return (T)result;
                }
            }
            else
            {
                // Not nullable.
                return (T)Convert.ChangeType(value, typeof(T));
            }
        }
    }
}
