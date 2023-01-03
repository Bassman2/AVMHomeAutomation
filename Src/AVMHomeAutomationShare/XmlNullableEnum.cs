using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public struct XmlNullableEnum<T> : IXmlSerializable where T : struct //System.Enum
    {
        public bool HasValue { get; private set; }

        public T Value { get; private set; }

        public XmlNullableEnum(T val)
        {
            this.HasValue = true;
            this.Value = val;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            string strValue = reader.ReadElementContentAsString();
            if (this.HasValue = int.TryParse(strValue, out int value))
            {
                this.Value = (T)Enum.ToObject(typeof(T), value);
            }
            //reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public static implicit operator XmlNullableEnum<T>(T value)
        {
            return new XmlNullableEnum<T>(value);
        }

        public static implicit operator T(XmlNullableEnum<T> value)
        {
            return value.Value;
        }

        public static implicit operator XmlNullableEnum<T>(Nullable<T> value)
        {
            return value.HasValue ? new XmlNullableEnum<T>(value.Value) : null;
        }

        public static implicit operator Nullable<T>(XmlNullableEnum<T> value)
        {
            return value.HasValue ? ((Nullable<T>)value.Value) : null;
        }
    }
}
