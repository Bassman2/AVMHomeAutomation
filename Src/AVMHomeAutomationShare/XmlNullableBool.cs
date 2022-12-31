using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class XmlNullableBool : IXmlSerializable
    {
        public bool HasValue { get; private set; }

        public bool Value { get; private set; }

        public XmlNullableBool()
        { }

        public XmlNullableBool(bool value)
        {
            this.HasValue = true;
            this.Value = value;
        }

        public XmlNullableBool(bool? value)
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
                this.Value = value != 0 ? true : false;
            }
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public static implicit operator XmlNullableBool(bool? value)
        {
            return new XmlNullableBool(value);
        }

        public static implicit operator bool?(XmlNullableBool value)
        {
            return value.HasValue ? ((bool?)value.Value) : null;
        }
    }
}
