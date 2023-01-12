using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Linq;

namespace AVMHomeAutomation
{

    /// <summary>
    /// Class for enum list serilization.
    /// </summary>
    public struct XmlEnumList<T> : IXmlSerializable where T : System.Enum
    {
        /// <summary>
        /// Initializes a new instance of the XmlNullableTemperature structure to the specified value.
        /// </summary>
        /// <param name="value">A list of enums.</param>
        public XmlEnumList(List<T> val)
        {
            this.Values = val;
        }

        /// <summary>
        /// Get a list of the enums.
        /// </summary>
        public List<T> Values { get; private set; }

        /// <summary>
        /// Creates a new object initialized to a specified value.
        /// </summary>
        /// <param name="value">A enum list.</param>
        public static implicit operator XmlEnumList<T>(List<T> values)
        {
            return new XmlEnumList<T>(values);
        }

        /// <summary>
        /// Defines an conversion of a instance to its underlyling value.
        /// </summary>
        /// <param name="value">A value.</param>
        public static implicit operator List<T>(XmlEnumList<T> values)
        {
            return values.Values;
        }

        #region IXmlSerializable

        /// <summary>
        /// This method is reserved and should not be used.
        /// </summary>
        /// <returns>Return null.</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The XmlReader stream from which the object is deserialized.</param>
        public void ReadXml(XmlReader reader)
        {
            string str = reader.ReadElementContentAsString();
            this.Values = str.Split(',').Select((t) => (T)Enum.ToObject(typeof(T), int.Parse(t))).ToList();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The XmlWriter stream to which the object is serialized.</param>
        /// <exception cref="NotImplementedException">Not implemented in this class.</exception>
        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
