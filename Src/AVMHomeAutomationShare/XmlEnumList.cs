using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Linq;

namespace AVMHomeAutomation
{
    
    public struct XmlEnumList<T> : IXmlSerializable where T : System.Enum
    {
        public List<T> Values { get; private set; }

        //public XmlEnumList()
        //{ }

        public XmlEnumList(List<T> val)
        {
            this.Values = val;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            string strValue = reader.ReadString();
            this.Values = strValue.Split(',').Select((t) => (T)Enum.ToObject(typeof(T), int.Parse(t))).ToList();
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public static implicit operator XmlEnumList<T>(List<T> values)
        {
            return new XmlEnumList<T>(values);
        }

        public static implicit operator List<T>(XmlEnumList<T> values)
        {
            return values.Values;
        }
    }
}
