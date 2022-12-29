using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class XmlTemperature : IXmlSerializable
    {
        public bool HasValue { get; private set; }

        public double Value { get; private set; }

        public XmlTemperature()
        { }

        public XmlTemperature(double value)
        {
            this.HasValue = true;
            this.Value = value;
        }

        public XmlTemperature(double? value)
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

        public static implicit operator XmlTemperature(double? value)
        {
            return new XmlTemperature(value);
        }

        public static implicit operator double?(XmlTemperature value)
        {
            return value.HasValue ? ((double?)value.Value) : null;
        }
        
    }
}
