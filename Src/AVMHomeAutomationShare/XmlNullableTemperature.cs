using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public struct XmlNullableTemperature : IXmlSerializable
    {
        public bool HasValue { get; private set; }

        public double Value { get; private set; }

        //public XmlNullableTemperature()
        //{ }

        public XmlNullableTemperature(double value)
        {
            this.HasValue = true;
            this.Value = value;
        }

        public XmlNullableTemperature(double? value)
        {
            this.HasValue = value.HasValue;
            this.Value = value.Value;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            string strValue = reader.ReadString();

            if (this.HasValue = int.TryParse(strValue, out int value))
            {
                this.Value = value / 10.0;
            }
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public static implicit operator XmlNullableTemperature(double? value)
        {
            return new XmlNullableTemperature(value);
        }

        public static implicit operator double?(XmlNullableTemperature value)
        {
            return value.HasValue ? ((double?)value.Value) : null;
        }
        
    }
}
