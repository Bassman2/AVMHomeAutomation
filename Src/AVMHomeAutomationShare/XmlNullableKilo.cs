using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public struct XmlNullableKilo : IXmlSerializable
    {
        public bool HasValue { get; private set; }

        public double Value { get; private set; }
                
        public XmlNullableKilo(double value)
        {
            this.HasValue = true;
            this.Value = value;
        }

        public double GetValueOrDefault()
        {
            return this.HasValue ? this.Value : default;
        }

        public double GetValueOrDefault(double defaultValue)
        {
            return this.HasValue ? this.Value : defaultValue;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            string strValue = reader.ReadElementContentAsString();
            if (this.HasValue = int.TryParse(strValue, out int val))
            {
                this.Value = val / 1000.0;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }
            if (other.GetType() == typeof(XmlNullableKilo))
            {
                return this.Value == ((XmlNullableKilo)other).Value; 
            }
            if (other.GetType() == typeof(double))
            {
                return this.Value == ((double)other);
            }
            if (other.GetType() == typeof(double?))
            {
                return this.Value == ((double?)other).Value;
            }
            return this.Value.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static implicit operator XmlNullableKilo(double value)
        {
            return new XmlNullableKilo(value);
        }

        public static implicit operator double(XmlNullableKilo value)
        {
            return value.Value;
        }

        public static implicit operator XmlNullableKilo(double? value)
        {
            return value.HasValue ? new XmlNullableKilo(value.Value) : null;
        }

        public static implicit operator double?(XmlNullableKilo value)
        {
            return value.HasValue ? new double?(value.Value) : null;
        }
    }
}
