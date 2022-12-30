using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class XmlNullableDateTime : IXmlSerializable
    {
        private static DateTime begin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        
        public bool HasValue { get; private set; }

        public DateTime Value { get; private set; }

        public XmlNullableDateTime()
        { }

        public XmlNullableDateTime(DateTime value)
        {
            this.HasValue = true;
            this.Value = value;
        }

        public XmlNullableDateTime(DateTime? value)
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

            if (this.HasValue = long.TryParse(strValue, out long value))
            {
                if (value == 0)
                {
                    this.HasValue = false;
                }
                else
                {
                    this.HasValue = true;
                    this.Value = begin.AddSeconds(value).ToLocalTime();
                }
            }
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public static implicit operator XmlNullableDateTime(DateTime? value)
        {
            return new XmlNullableDateTime(value);
        }

        public static implicit operator DateTime?(XmlNullableDateTime value)
        {
            return value.HasValue ? ((DateTime?)value.Value) : null;
        }
    }
}
