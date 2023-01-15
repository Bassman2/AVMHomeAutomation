using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Class to show if element is available or not.
    /// </summary>
    public struct XmlAvailable : IXmlSerializable
    {
        private bool value;


        /// <summary>
        /// Initializes a new instance of the XmlAvailable structure to the specified value.
        /// </summary>
        /// <param name="value">A int value.</param>
        public XmlAvailable(bool value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the value of the current object if it has been assigned a valid underlying value.
        /// </summary>
        public bool Value { get => this.value; }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="other">An object.</param>
        /// <returns>true if the other parameter is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }
            return this.value.Equals(other);
        }

        /// <summary>
        ///  Retrieves the hash code of the object returned by the Value property.
        /// </summary>
        /// <returns>The hash code of the object returned by the Value property.</returns>
        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        /// <summary>
        /// Returns the text representation of the value of the current object.
        /// </summary>
        /// <returns>The text representation of the value of the current object</returns>
        public override string ToString()
        {
            return this.value.ToString();
        }

        /// <summary>
        /// Creates a new object initialized to a specified value.
        /// </summary>
        /// <param name="value">A value.</param>
        /// <returns>New instance.</returns>
        public static implicit operator XmlAvailable(bool value)
        {
            return new XmlAvailable(value);
        }

        /// <summary>
        /// Defines an conversion of a instance to its underlyling value.
        /// </summary>
        /// <param name="value">A value.</param>
        /// <returns>The value.</returns>
        public static implicit operator bool(XmlAvailable value)
        {
            return value.Value;
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
            // if this function is called the element exists, so set to true
            this.value = true;
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
