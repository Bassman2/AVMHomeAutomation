using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public struct XmlKilo : IXmlSerializable
    {   
        public double Value { get; private set; }
                
        public XmlKilo(double value)
        {
            this.Value = value;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            string strValue = reader.ReadString();
            int val = int.Parse(strValue);
            this.Value = val / 1000.0;
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public static implicit operator XmlKilo(double value)
        {
            return new XmlKilo(value);
        }

        public static implicit operator double(XmlKilo value)
        {
            return value.Value;
        }
    }
}
