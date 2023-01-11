using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public struct XmlNullableDateTime : IXmlSerializable
    {
        private static DateTime begin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        
        public bool HasValue { get; private set; }

        public DateTime Value { get; private set; }

        //public XmlNullableDateTime()
        //{ }

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
            string strValue = reader.ReadElementContentAsString();

            if (this.HasValue = long.TryParse(strValue, out long value))
            {
                if (value == 0)
                {
                    this.HasValue = false;
                }
                else
                {
                    this.HasValue = true;
                    this.Value = begin.AddSeconds(value); //.ToLocalTime();
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object other)
        {
            if (!this.HasValue)
            {
                return other == null;
            }
            //if (other.GetType() == typeof(DateTime))
            //{
            //    return false;
            //}
            return this.Value.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.HasValue ? this.Value.GetHashCode() : 0;
        }

        public static implicit operator XmlNullableDateTime(DateTime value)
        {
            return new XmlNullableDateTime(value);
        }

        public static implicit operator DateTime(XmlNullableDateTime value)
        {
            return value.Value;
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
