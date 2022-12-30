using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class XmlEnum<T> : IXmlSerializable where T : System.Enum
    {
        public T Value { get; private set; }
        public XmlEnum() 
        { }

        public XmlEnum(T val)
        {
            this.Value = val;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            string strValue = reader.ReadString();
            int val = int.Parse(strValue);

            this.Value = (T)Enum.ToObject(typeof(T), val);
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public static implicit operator XmlEnum<T>(T value)
        {
            return new XmlEnum<T>(value);
        }

        public static implicit operator T(XmlEnum<T> value)
        {
            return value.Value;
        }
    }


}
