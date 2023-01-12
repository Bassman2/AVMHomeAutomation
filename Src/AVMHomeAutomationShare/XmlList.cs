using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Class for string list serilization.
    /// </summary>
    /// <typeparam name="T">Underlying type.</typeparam>
    public struct XmlList<T> : IXmlSerializable
    {
        /// <summary>
        /// Initializes a new instance of the XmlStringList structure to the specified value.
        /// </summary>
        /// <param name="value">A list of strings.</param>
        public XmlList(List<T> value)
        {
            this.Values = value;
        }

        /// <summary>
        /// Get a list of the enums.
        /// </summary>
        public List<T> Values { get; private set; }

        /// <summary>
        /// Creates a new object initialized to a specified value.
        /// </summary>
        /// <param name="values">A enum list.</param>
        /// <returns>New instance.</returns>
        public static implicit operator XmlList<T>(List<T> values)
        {
            return new XmlList<T>(values);
        }

        /// <summary>
        /// Defines an conversion of a instance to its underlyling value.
        /// </summary>
        /// <param name="values">A value.</param>
        /// <returns>The value.</returns>
        public static implicit operator List<T>(XmlList<T> values)
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
            if (typeof(T) == typeof(string))
            {
                this.Values = str.Split(',').Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(int))
            {
                this.Values = str.Split(',').Select(s => int.Parse(s)).Cast<T>().ToList();
            }
            else //if (typeof(T).IsEnum)   // does not work for UWP
            {
                this.Values = str.Split(',').Select((t) => (T)Enum.ToObject(typeof(T), int.Parse(t))).ToList();
            }
            //else
            //{
            //    throw new Exception("type not specified");
            //}
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
