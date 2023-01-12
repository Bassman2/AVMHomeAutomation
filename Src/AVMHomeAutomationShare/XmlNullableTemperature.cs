using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Class for nullable temperature serilization.
    /// </summary>
    public struct XmlNullableTemperature : IXmlSerializable
    {
        private bool hasValue;
        private double value;

        /// <summary>
        /// Initializes a new instance of the XmlNullableTemperature structure to the specified value.
        /// </summary>
        /// <param name="value">A double value.</param>
        public XmlNullableTemperature(double value)
        {
            this.hasValue = true;
            this.value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the current object has a valid value.
        /// </summary>
        public bool HasValue { get => hasValue; }

        /// <summary>
        /// Gets the value of the current object if it has been assigned a valid underlying value.
        /// </summary>
        public double Value { get { if (!hasValue) throw new InvalidOperationException("No value"); return value; } }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="other">An object.</param>
        /// <returns>true if the other parameter is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object other)
        {
            if (!this.hasValue)
            {
                return other == null;
            }
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
            return this.hasValue ? this.value.GetHashCode() : 0;
        }

        /// <summary>
        /// Returns the text representation of the value of the current object.
        /// </summary>
        /// <returns>The text representation of the value of the current object</returns>
        public override string ToString()
        {
            return this.hasValue ? this.value.ToString() : string.Empty;
        }

        /// <summary>
        /// Creates a new object initialized to a specified value.
        /// </summary>
        /// <param name="value">A value.</param>
        public static implicit operator XmlNullableTemperature(double value)
        {
            return new XmlNullableTemperature(value);
        }

        /// <summary>
        /// Defines an conversion of a instance to its underlyling value.
        /// </summary>
        /// <param name="value">A value.</param>
        public static implicit operator double(XmlNullableTemperature value)
        {
            return value.Value;
        }

        /// <summary>
        /// Defines an conversion of a instance to its underlyling nullable value.
        /// </summary>
        /// <param name="value">A value.</param>
        public static implicit operator double?(XmlNullableTemperature value)
        {
            return value.hasValue ? (double?)value.value : null;
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
            if (this.hasValue = int.TryParse(str, out int val))
            {
                this.value = val / 10.0;
            }
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
