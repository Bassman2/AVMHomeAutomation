using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;

namespace AVMHomeAutomation
{
    
    public struct XmlNullableInt : IXmlSerializable 
    {
        public bool HasValue { get; private set; }

        public int Value { get; private set; }

        public XmlNullableInt(int value)
        {
            this.HasValue = true;
            this.Value = value;
        }

        public int GetValueOrDefault()
        {
            return this.Value;
        }

        public int GetValueOrDefault(int defaultValue)
        {
            return this.HasValue ? this.Value : defaultValue;
        }

        public override bool Equals(object other)
        {
            if (!this.HasValue)
            {
                return other == null;
            }
            if (other == null)
            {
                return false;
            }
            return this.Value.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.HasValue ? this.Value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return this.HasValue ? this.Value.ToString() : "";
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            string strValue = reader.ReadString();
            //if (String.IsNullOrEmpty(strValue))
            //{
            //    this.HasValue = false;
            //}
            //else
            //{
                if (this.HasValue = int.TryParse(strValue, out int val))
                {
                    this.Value = val;
                }
            //}
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public static implicit operator XmlNullableInt(int value)
        {
            return new XmlNullableInt(value);
        }

        public static implicit operator int(XmlNullableInt value)
        {
            return value.Value;
        }

        public static implicit operator XmlNullableInt(int? value)
        {
            return value.HasValue ? new XmlNullableInt(value.Value) : null;
        }

        public static implicit operator int?(XmlNullableInt value)
        {
            return value.HasValue ? new int?(value.Value) : null;
        }
    }
}
