using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{

    public struct XmlNullable<T> : IXmlSerializable where T : struct
    {
        public bool HasValue { get; private set; }

        public T Value { get; private set; }

        public XmlNullable(T value)
        {
            this.HasValue = true;
            this.Value = value;
        }

        public T GetValueOrDefault()
        {
            return this.Value;
        }
                
        public T GetValueOrDefault(T defaultValue)
        {
            return this.HasValue ? this.Value : defaultValue;
        }

        public override bool Equals(object other)
        {
            if (!this.HasValue)
            {
                return other == null;
            }
            if (other == null)
            {
                return false;
            }
            return this.Value.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.HasValue ? this.Value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return this.HasValue ? this.Value.ToString() : "";
        }
        
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            string strValue = reader.ReadElementContentAsString();
            if (String.IsNullOrEmpty(strValue))
            {
                this.HasValue = false;
            }
            else
            {
                T convertedValue = strValue.To<T>();
                this.Value = convertedValue;
                this.HasValue = true;
            }
            //reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public static implicit operator XmlNullable<T>(T value)
        {
            return new XmlNullable<T>(value);
        }

        public static implicit operator T(XmlNullable<T> value)
        {
            return value.Value;
        }

        public static implicit operator XmlNullable<T>(Nullable<T> value)
        {
            return value.HasValue ? new XmlNullable<T>(value.Value) : null;
        }

        public static implicit operator Nullable<T>(XmlNullable<T> value)
        {
            return value.HasValue ? new Nullable<T>(value.Value) : null;
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
