using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class XmlNullableHkrTemperature : IXmlSerializable
    {
        public bool HasValue { get; private set; }

        public double Value { get; private set; }

        public XmlNullableHkrTemperature()
        { }

        public XmlNullableHkrTemperature(double value)
        {
            this.HasValue = true;
            this.Value = value;
        }

        public XmlNullableHkrTemperature(double? value)
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
                // 0,5 °C, Wertebereich: 0x0 – 0x64
                // 0 <= 0°C, 1 = 0,5°C......120 = 60°C, 254 = ON , 253 = OFF
                if (value == 254)
                {
                    // on
                    this.Value = double.MaxValue;
                }
                else if (value == 253)
                {
                    // off
                    this.Value = double.MinValue;
                }
                else
                {
                    this.Value = value * 0.5;
                }
            }
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public static implicit operator XmlNullableHkrTemperature(double? value)
        {
            return new XmlNullableHkrTemperature(value);
        }

        public static implicit operator double?(XmlNullableHkrTemperature value)
        {
            return value.HasValue ? ((double?)value.Value) : null;
        }
    }
}
